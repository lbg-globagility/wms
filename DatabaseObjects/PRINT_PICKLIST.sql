/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `PRINT_PICKLIST`;
DELIMITER //
CREATE PROCEDURE `PRINT_PICKLIST`(
	IN `pickListId` INT,
	IN `customerIds` VARCHAR(50),
	IN `referenceNos` VARCHAR(50),
	IN `customerOrderNos` VARCHAR(50)
)
BEGIN

SET @pickListId=pickListId;
SET @customerIds=customerIds;
SET @referenceNos=referenceNos;
SET @customerOrderNos=customerOrderNos;

SET @_poNo=0;
SET @_isChanged=0;

SELECT
@_isChanged:=@_poNo != i.`poNo` `isChanged`,
IF(@_isChanged, @_poNo:=i.`poNo`, @_poNo) `_poNo`,
i.*
FROM (
SELECT
a.CompanyName `customer`,
GROUP_CONCAT(DISTINCT o.ReferenceNumber) `poNo`,
SUM(ploi.QtyPicked) `qty`,
GROUP_CONCAT(DISTINCT pil.UnitOfMeasure2 SEPARATOR '\n') `unit`,
GROUP_CONCAT(CONCAT(p.ProductCode, ' (', ploi.QtyPicked, ')') ORDER BY oi.RowID SEPARATOR ', ') `itemDescription`,
DATE_FORMAT(CURDATE(), '%M %e, %Y') `deliveryDate`
FROM picklistorders plo
INNER JOIN orders o ON o.RowID=plo.OrderID AND FIND_IN_SET(o.ReferenceNumber, @referenceNos) > 0 AND FIND_IN_SET(o.OrderNumber, @customerOrderNos) > 0
INNER JOIN accounts a ON a.RowID=o.AccountID
INNER JOIN orderitems oi ON oi.RowID=plo.OrderItemID
INNER JOIN productinventorylocation pil ON pil.RowID=oi.ProductInventoryLocationId
INNER JOIN productcolorsizes pcs ON pcs.RowID=pil.ProductColorSizeID
INNER JOIN productcolors pc ON pc.RowID=pcs.ProductColorID
INNER JOIN products p ON p.RowID=pc.ProductID
INNER JOIN picklistorderitems ploi ON ploi.PickListOrderID=plo.RowID AND IFNULL(ploi.QtyPicked, 0) > 0
WHERE plo.PickListID = @pickListId
AND FIND_IN_SET(o.AccountID, @customerIds) > 0
# GROUP BY a.RowID, o.ReferenceNumber, pil.UnitOfMeasure2
GROUP BY a.RowID, o.ReferenceNumber, p.ProductGroupName
ORDER BY a.CompanyName
) i
;

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
