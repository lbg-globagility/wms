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
#t.`ordernumber`, t.PackingListID
t.*
FROM (SELECT
#		COALESCE(CONCAT(COALESCE(o.OrderNumber,''),' (C.O. No.) / ',  COALESCE(a.CompanyName,''),' - ',  COALESCE(a.AccountNo,''),' / ', CONCAT(COALESCE(pal.PackingListNo,''),' (Pa.L. No.)')),'') `ordernumber`
		COALESCE(CONCAT(COALESCE(a.CompanyName,''),' - ', COALESCE(a.AccountNo,''),' / ',COALESCE(o.OrderNumber,''),' (C.O. No.) / ',CONCAT(COALESCE(pal.PackingListNo,''),' (Pa.L. No.)')),'') `ordernumber`
		
		, oi.*, SUM(palci.QtyInCarton) `palciQtyInCarton`, MIN(piloi.QtyPicked) `piloiQtyPicked`, palc.PackingListID
		
		, SUM(palci.QtyInCarton) < MIN(piloi.QtyPicked) `Result1`
		, SUM(palci.QtyInCarton) = MIN(piloi.QtyPicked) AND FIND_IN_SET('Completed', GROUP_CONCAT(pal.`Status`)) = 0 AND FIND_IN_SET('Delivered', GROUP_CONCAT(pal.`Status`)) = 0 AND FIND_IN_SET('Cancelled', GROUP_CONCAT(pal.`Status`)) = 0 AND FIND_IN_SET('Inactive', GROUP_CONCAT(pal.`Status`)) = 0 `Result2`
		, GROUP_CONCAT(pal.`Status`) `Statuses`
		
		FROM packinglist pal
		INNER JOIN orders o ON o.RowID=pal.OrderID AND o.`Status` != 'Cancelled'
		INNER JOIN accounts a ON a.RowID=o.AccountID
		
		INNER JOIN packinglistcartons palc ON palc.PackingListID=pal.RowID AND palc.`Status` NOT IN ('Completed', 'Delivered', 'Cancelled')
		INNER JOIN packinglistcartonitems palci ON palci.PackingListCartonID=palc.RowID AND palci.`Status` != 'Cancelled'
		
		INNER JOIN orderitems oi ON oi.OrderID=pal.OrderID AND oi.RowID=palci.OrderItemID AND oi.`Status` != 'Cancelled'
		
		LEFT JOIN lineups lu ON lu.PackingListID=pal.RowID AND lu.`Status` != 'Cancelled'
		
		INNER JOIN picklistorders pilo ON pilo.OrderID=oi.OrderID AND pilo.OrderItemID=oi.RowID AND pilo.`Status` NOT IN ('Cancelled', 'Inactive') AND pilo.`Status`='Verified'
		INNER JOIN picklistorderitems piloi ON piloi.PickListOrderID=pilo.RowID AND piloi.`Status` NOT IN ('Cancelled', 'Inactive')
		INNER JOIN picklist pil ON pil.RowID=pilo.PickListID AND pil.`Status` NOT IN ('Cancelled', 'Inactive') # 'Completed'
		
		WHERE pal.`Status` NOT IN ('Cancelled', 'Inactive') # 'Completed', 'Delivered', 
		AND pal.OrganizationID=_orgId
		
		GROUP BY oi.RowID
		HAVING IF(SUM(palci.QtyInCarton) < MIN(piloi.QtyPicked), TRUE, SUM(palci.QtyInCarton) = MIN(piloi.QtyPicked) AND FIND_IN_SET('Completed', GROUP_CONCAT(pal.`Status`)) = 0 AND FIND_IN_SET('Delivered', GROUP_CONCAT(pal.`Status`)) = 0 AND FIND_IN_SET('Cancelled', GROUP_CONCAT(pal.`Status`)) = 0 AND FIND_IN_SET('Inactive', GROUP_CONCAT(pal.`Status`)) = 0)
		ORDER BY CAST(o.OrderNumber AS UNSIGNED) DESC
		) t
GROUP BY t.PackingListID
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
