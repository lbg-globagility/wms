/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `GetCustomerOrderInfo`;
DELIMITER //
CREATE PROCEDURE `GetCustomerOrderInfo`(
	IN `_orgId` INT
)
BEGIN

SELECT
DISTINCT IFNULL(CONCAT(IFNULL(a.CompanyName,''),' - ', IFNULL(a.AccountNo,''),' / ',IFNULL(o.OrderNumber,''),' (C.O. No.) / ',CONCAT(IFNULL(pal.PackingListNo,''),' (Pa.L. No.)')),'') `ordernumber`

FROM (SELECT
#		COALESCE(CONCAT(COALESCE(o.OrderNumber,''),' (C.O. No.) / ',  COALESCE(a.CompanyName,''),' - ',  COALESCE(a.AccountNo,''),' / ', CONCAT(COALESCE(pal.PackingListNo,''),' (Pa.L. No.)')),'') `ordernumber`
#		COALESCE(CONCAT(COALESCE(a.CompanyName,''),' - ', COALESCE(a.AccountNo,''),' / ',COALESCE(o.OrderNumber,''),' (C.O. No.) / ',CONCAT(COALESCE(pal.PackingListNo,''),' (Pa.L. No.)')),'') `ordernumber`
		pilo.OrderItemID
		/*, oi.*, SUM(palci.QtyInCarton) `palciQtyInCarton`, MIN(piloi.QtyPicked) `piloiQtyPicked`, palc.PackingListID
		
		, SUM(palci.QtyInCarton) < MIN(piloi.QtyPicked) `Result1`
		, SUM(palci.QtyInCarton) = MIN(piloi.QtyPicked) AND FIND_IN_SET('Completed', GROUP_CONCAT(pal.`Status`)) = 0 AND FIND_IN_SET('Delivered', GROUP_CONCAT(pal.`Status`)) = 0 AND FIND_IN_SET('Cancelled', GROUP_CONCAT(pal.`Status`)) = 0 AND FIND_IN_SET('Inactive', GROUP_CONCAT(pal.`Status`)) = 0 `Result2`
		, GROUP_CONCAT(pal.`Status`) `Statuses`*/
		
		, CAST(o.OrderNumber AS UNSIGNED) `OrderNum`
		, GROUP_CONCAT(pal.RowID) `PackinglistIds`
		
		FROM picklist pil
		INNER JOIN picklistorders pilo ON pilo.PickListID=pil.RowID AND pilo.`Status` NOT IN ('Cancelled', 'Inactive') AND pilo.`Status`='Verified'
		INNER JOIN picklistorderitems piloi ON piloi.PickListOrderID=pilo.RowID AND piloi.`Status` NOT IN ('Cancelled', 'Inactive') AND piloi.`Status`=pilo.`Status`
		
		INNER JOIN orders o ON o.RowID=pilo.OrderID AND o.`Status` != 'Cancelled'
		#AND o.OrderNumber=2395 # 2459 2459
		
		INNER JOIN orderitems oi ON oi.RowID=pilo.OrderItemID AND oi.OrderID=o.RowID
		
		LEFT JOIN packinglist pal ON pal.OrderID=o.RowID AND pal.`Status` NOT IN ('Cancelled')
		LEFT JOIN packinglistcartons palc ON palc.PackingListID=pal.RowID AND palc.`Status` NOT IN ('Cancelled')
		LEFT JOIN packinglistcartonitems palco ON palco.OrderItemID=oi.RowID AND palco.PackingListCartonID=palc.RowID AND palco.`Status` NOT IN ('Cancelled')
		
		LEFT JOIN lineups lu1 ON lu1.PackingListID = pal.RowID AND lu1.`Status` NOT IN ('Cancelled')
		
		LEFT JOIN packinglist pal2 ON pal2.RowID = lu1.PackingListID AND pal2.`Status` NOT IN ('Cancelled')
		LEFT JOIN packinglistcartons palc2 ON pal2.RowID = palc2.PackingListID AND palc2.`Status` NOT IN ('Cancelled')
		LEFT JOIN packinglistcartonitems palco2 ON palco2.OrderItemID=oi.RowID AND palco2.PackingListCartonID = palc2.RowID AND palco2.`Status` NOT IN ('Cancelled')
		
#		INNER JOIN accounts a ON a.RowID=o.AccountID
		
		WHERE pil.`Status` NOT IN ('Cancelled', 'Inactive')
		AND IF(pal.RowID IS NULL, TRUE, IFNULL(palco.QtyInCarton, 0) > 0)
		AND IFNULL(lu1.`Status`, '') NOT IN ('Confirmed Delivery')
		
		AND pil.OrganizationID=_orgId
		
		GROUP BY pilo.OrderItemID
		HAVING IF(FIND_IN_SET(0, GROUP_CONCAT(IFNULL(pal.RowID, 0))) = 0 AND FIND_IN_SET(0, GROUP_CONCAT(IFNULL(lu1.RowID, 0))) > 0, # has packing list and no lineup
		SUM(IFNULL(palco.QtyInCarton, 0)) <= MIN(piloi.QtyPicked),
		IF(FIND_IN_SET(0, GROUP_CONCAT(IFNULL(lu1.RowID, 0))) > 0, SUM(IFNULL(palco.QtyInCarton, 0)) < MIN(piloi.QtyPicked), SUM(IFNULL(palco.QtyInCarton, 0) + IFNULL(palco2.QtyInCarton, 0)) < MIN(piloi.QtyPicked)))
		AND FIND_IN_SET('Cancelled', GROUP_CONCAT(IFNULL(pal.`Status`, 0))) = 0
		) t
INNER JOIN packinglist pal ON FIND_IN_SET(pal.RowID, t.`PackinglistIds`) > 0
INNER JOIN orders o ON o.RowID=pal.OrderID
INNER JOIN accounts a ON a.RowID=o.AccountID
#GROUP BY t.PackingListID
ORDER BY t.`OrderNum` DESC
;

/*FROM orderitems oi
INNER JOIN orders o ON o.RowID=oi.OrderID AND o.`Status` != 'Cancelled'
INNER JOIN accounts a ON a.RowID=o.AccountID
LEFT JOIN packinglist pal ON pal.OrderID=oi.OrderID AND pal.`Status` != 'Cancelled'
LEFT JOIN packinglistcartons palc ON palc.PackingListID=pal.RowID AND palc.`Status` != 'Cancelled'
LEFT JOIN packinglistcartonitems palci ON palci.PackingListCartonID=palc.RowID AND palci.OrderItemID=oi.RowID AND palci.`Status` != 'Cancelled'
LEFT JOIN lineups lu ON lu.PackingListID=pal.RowID AND lu.`Status` != 'Cancelled'

WHERE oi.OrganizationID=_orgId
AND oi.OrderID IS NOT NULL
AND pal.`Status` = 'New' AND palc.`Status` = 'Active' AND palci.`Status` = 'Active'
GROUP BY oi.OrderID
ORDER BY CAST(o.OrderNumber AS UNSIGNED) DESC;*/

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
