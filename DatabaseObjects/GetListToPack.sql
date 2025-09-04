/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `GetListToPack`;
DELIMITER //
CREATE PROCEDURE `GetListToPack`(
	IN `_orgId` INT
)
BEGIN

DROP TEMPORARY TABLE IF EXISTS `packinglistinlineup`;
CREATE TEMPORARY TABLE IF NOT EXISTS `packinglistinlineup`
SELECT
/*pal.RowID `PackingListID`,
palci.*
*/
palci.`OrderItemID`, pal.RowID `PackingListID`, palci.`RowID`, palci.`OrganizationID`, palci.`Created`, palci.`CreatedBy`, palci.`LastUpd`, palci.`LastUpdBy`, palci.`PackingListCartonID`, palci.`QtyInCarton`, palci.`Status`, piloi.QtyPicked, lu.RowID `LineupId`, lu.`Status` `LineupStatus`, o.`Status` `OrderStatus`, o.RowID `OrderID`

FROM packinglist pal
INNER JOIN orders o ON o.RowID=pal.OrderID AND o.`Status` != 'Cancelled'

INNER JOIN packinglistcartons palc ON palc.PackingListID=pal.RowID AND palc.`Status` != 'Cancelled'
INNER JOIN packinglistcartonitems palci ON palci.PackingListCartonID=palc.RowID AND palci.`Status` != 'Cancelled'

INNER JOIN orderitems oi ON oi.OrderID=pal.OrderID AND oi.RowID=palci.OrderItemID AND oi.`Status` != 'Cancelled'

LEFT JOIN lineups lu ON lu.PackingListID=pal.RowID AND lu.`Status` != 'Cancelled'

INNER JOIN picklistorders pilo ON pilo.OrderID=oi.OrderID AND pilo.OrderItemID=oi.RowID AND pilo.`Status` NOT IN ('Cancelled', 'Inactive') AND pilo.`Status`='Verified'
INNER JOIN picklistorderitems piloi ON piloi.PickListOrderID=pilo.RowID AND piloi.`Status` NOT IN ('Cancelled', 'Inactive')
INNER JOIN picklist pil ON pil.RowID=pilo.PickListID AND pil.`Status` NOT IN ('Completed', 'Cancelled', 'Inactive')

WHERE pal.`Status` != 'Cancelled'
AND pal.OrganizationID=_orgId

UNION
SELECT
#NULL `PackingListID`, NULL `RowID`, pil.`OrganizationID`, NULL `Created`, NULL `CreatedBy`, NULL `LastUpd`, NULL `LastUpdBy`, NULL `PackingListCartonID`, pilo.`OrderItemID`, 0 `QtyInCarton`, piloi.`Status`, piloi.QtyPicked `QtyPicked`, NULL `LineupId`, NULL `LineupStatus`, NULL `OrderStatus`, pilo.OrderID `OrderID`
pilo.`OrderItemID`, NULL `PackingListID`, NULL `RowID`, pil.`OrganizationID`, NULL `Created`, NULL `CreatedBy`, NULL `LastUpd`, NULL `LastUpdBy`, NULL `PackingListCartonID`, 0 `QtyInCarton`, piloi.`Status`, piloi.QtyPicked `QtyPicked`, NULL `LineupId`, NULL `LineupStatus`, NULL `OrderStatus`, pilo.OrderID `OrderID`
FROM picklist pil
INNER JOIN picklistorders pilo ON pilo.PickListID=pil.RowID AND pilo.`Status` NOT IN ('Cancelled', 'Inactive') AND pilo.`Status`='Verified' #AND pilo.OrderItemID NOT IN (SELECT DISTINCT `OrderItemID` FROM `xyz`)
INNER JOIN picklistorderitems piloi ON piloi.PickListOrderID=pilo.RowID AND piloi.`Status` NOT IN ('Cancelled', 'Inactive')
WHERE pil.OrganizationID=_orgId
AND pil.`Status` NOT IN ('Completed', 'Cancelled', 'Inactive')
;


DROP TEMPORARY TABLE IF EXISTS `packinglistnotinlineup`;
CREATE TEMPORARY TABLE IF NOT EXISTS `packinglistnotinlineup`
SELECT
palci.*

FROM lineups lu
INNER JOIN packinglist pal ON pal.RowID=lu.PackingListID AND pal.`Status` != 'Cancelled'
INNER JOIN orders o ON o.RowID=pal.OrderID AND o.`Status` != 'Cancelled'

INNER JOIN packinglistcartons palc ON palc.PackingListID=pal.RowID AND palc.`Status` != 'Cancelled'
INNER JOIN packinglistcartonitems palci ON palci.PackingListCartonID=palc.RowID AND palci.`Status` != 'Cancelled'

INNER JOIN orderitems oi ON oi.OrderID=pal.OrderID AND oi.RowID=palci.OrderItemID AND oi.`Status` != 'Cancelled'

WHERE lu.`Status` != 'Cancelled'
AND lu.PackingListID NOT IN (SELECT `PackingListID` FROM `packinglistinlineup` WHERE `PackingListID` IS NOT NULL)
AND lu.OrganizationID=_orgId
;


SELECT
#DISTINCT
#t.`TextDisplay`
t.*, GROUP_CONCAT(t.`OrderNumber`) `Result`
FROM (SELECT
		COALESCE(CONCAT(COALESCE(o.OrderNumber,''),' (C.O. No.) / ',COALESCE(a.CompanyName,''),' - ',COALESCE(a.AccountNo,'')),'') `TextDisplay`,
		i.`OrderID`,
		CAST(o.OrderNumber AS UNSIGNED) `OrderNumber`
		FROM `packinglistinlineup` i
		LEFT JOIN `packinglistnotinlineup` ii ON ii.OrderItemID=i.OrderItemID
		INNER JOIN orders o ON o.RowID=i.`OrderID`
		INNER JOIN accounts a ON a.RowID=o.AccountID
#		WHERE ((i.QtyInCarton + IFNULL(ii.QtyInCarton, 0)) MOD i.QtyPicked) != 0
#		WHERE ((i.QtyInCarton + IFNULL(ii.QtyInCarton, 0)) MOD i.QtyPicked) BETWEEN 0 AND i.QtyPicked
#		WHERE (i.QtyInCarton + IFNULL(ii.QtyInCarton, 0)) BETWEEN 0 AND i.QtyPicked
		GROUP BY i.OrderItemID
#		HAVING SUM(i.QtyInCarton) < MIN(i.QtyPicked)
		HAVING SUM(i.QtyInCarton + IFNULL(ii.QtyInCarton, 0)) < MIN(i.QtyPicked)
		ORDER BY CAST(o.OrderNumber AS UNSIGNED) DESC) t
GROUP BY t.`OrderID`
ORDER BY t.`OrderNumber` DESC
;
	
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
