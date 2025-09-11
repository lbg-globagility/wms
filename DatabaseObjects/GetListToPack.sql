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

DROP TEMPORARY TABLE IF EXISTS `packingslate`;
CREATE TEMPORARY TABLE IF NOT EXISTS `packingslate`
SELECT
/*o.`Status`, #1
oi.`Status`, #2
pil.`Status`, #3
pilo.`Status`, #4
piloi.`Status`, #5
pal.`Status`, #6
palc.`Status`, #7
palco.`Status`, #8
lu1.`Status`, #9*/

#piloi.QtyPicked, IFNULL(palco.QtyInCarton, 0) `QtyInCarton`, lu1.RowID `LineupId`,
MIN(piloi.QtyPicked) `QtyPicked`, SUM(IFNULL(palco.QtyInCarton, 0)) `QtyInCarton`, SUM(IFNULL(palco2.QtyInCarton, 0)) `QtyInCarton2`, lu1.RowID `LineupId`,

o.OrderNumber, pilo.OrderID, pilo.OrderItemID,

IFNULL(CONCAT(IFNULL(o.OrderNumber,''),' (C.O. No.) / ',IFNULL(a.CompanyName,''),' - ',IFNULL(a.AccountNo,'')),'') `TextDisplay`

FROM picklist pil
INNER JOIN picklistorders pilo ON pilo.PickListID=pil.RowID AND pilo.`Status` NOT IN ('Cancelled', 'Inactive') AND pilo.`Status`='Verified'
INNER JOIN picklistorderitems piloi ON piloi.PickListOrderID=pilo.RowID AND piloi.`Status` NOT IN ('Cancelled', 'Inactive') AND piloi.`Status`=pilo.`Status`

INNER JOIN orders o ON o.RowID=pilo.OrderID AND o.`Status` != 'Cancelled'
#AND o.RowID=886
#AND o.OrderNumber=2462 # 2459 2459

INNER JOIN orderitems oi ON oi.RowID=pilo.OrderItemID AND oi.OrderID=o.RowID

LEFT JOIN packinglist pal ON pal.OrderID=o.RowID AND pal.`Status` NOT IN ('Cancelled')
LEFT JOIN packinglistcartons palc ON palc.PackingListID=pal.RowID AND palc.`Status` NOT IN ('Cancelled')
LEFT JOIN packinglistcartonitems palco ON palco.OrderItemID=oi.RowID AND palco.PackingListCartonID=palc.RowID AND palco.`Status` NOT IN ('Cancelled')

LEFT JOIN lineups lu1 ON lu1.PackingListID = pal.RowID AND lu1.`Status` NOT IN ('Cancelled')

LEFT JOIN packinglist pal2 ON pal2.RowID = lu1.PackingListID AND pal2.`Status` NOT IN ('Cancelled')
LEFT JOIN packinglistcartons palc2 ON pal2.RowID = palc2.PackingListID AND palc2.`Status` NOT IN ('Cancelled')
LEFT JOIN packinglistcartonitems palco2 ON palco2.OrderItemID=oi.RowID AND palco2.PackingListCartonID = palc2.RowID AND palco2.`Status` NOT IN ('Cancelled')

INNER JOIN accounts a ON a.RowID=o.AccountID

WHERE pil.`Status` NOT IN ('Cancelled', 'Inactive')
AND IF(pal.RowID IS NULL, TRUE, IFNULL(palco.QtyInCarton, 0) > 0)
#AND pal.`Status` NOT IN ('Cancelled')
AND IFNULL(lu1.`Status`, '') NOT IN ('Confirmed Delivery')

GROUP BY pilo.OrderItemID
HAVING IF(FIND_IN_SET(0, GROUP_CONCAT(IFNULL(lu1.RowID, 0))) > 0, SUM(IFNULL(palco.QtyInCarton, 0)) < MIN(piloi.QtyPicked), SUM(IFNULL(palco.QtyInCarton, 0) + IFNULL(palco2.QtyInCarton, 0)) < MIN(piloi.QtyPicked))
#HAVING SUM(IFNULL(palco.QtyInCarton, 0)) <= MIN(piloi.QtyPicked)

#ORDER BY pilo.OrderItemID # pilo.OrderID, 
ORDER BY CAST(o.OrderNumber AS UNSIGNED) DESC
;


SELECT
DISTINCT i.`TextDisplay`
FROM `packingslate` i
ORDER BY CAST(i.OrderNumber AS UNSIGNED) DESC
;


END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
