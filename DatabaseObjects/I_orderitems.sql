/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP FUNCTION IF EXISTS `I_orderitems`;
DELIMITER //
CREATE FUNCTION `I_orderitems`(`I_OrganizationID` INT(11), `I_Created` DATETIME, `I_CreatedBy` INT(11), `I_LastUpdBy` INT(11), `I_AccountID` INT(11), `I_OrderID` INT(11), `I_ProductColorSizeID` INT(11), `I_ProductBundleID` INT(11), `I_OrderItemID` INT(11), `I_QtyOrdered` INT(11), `I_QtyAvailable` INT(11), `I_ItemType` CHAR(10), `I_ItemCode` VARCHAR(50), `I_SKU` VARCHAR(50), `I_UnitOfMeasure` VARCHAR(50), `I_Remarks` VARCHAR(100), `I_SRP` DECIMAL(10,2), `I_Status` VARCHAR(50), `I_Tags` VARCHAR(50)) RETURNS int(10)
BEGIN

DECLARE newOrderItemID INT(11);

INSERT INTO orderitems
(
	OrganizationID, 
	Created,    
	CreatedBy,  
	LastUpdBy,
	AccountID,
	OrderID,  
	ProductColorSizeID, 	
	ProductBundleID,
	OrderItemID,  
	QtyOrdered,
	QtyAvailable,
	ItemType,
	ItemCode,
	SKU,
	UnitOfMeasure,
	Remarks,
	SRP,
	`Status`,
	Tags
)
VALUES
(
	I_OrganizationID, 
	I_Created,    
	I_CreatedBy,  
	I_LastUpdBy,
	I_AccountID,
	I_OrderID,  
	I_ProductColorSizeID, 	
	I_ProductBundleID,
	I_OrderItemID,  
	I_QtyOrdered,
	I_QtyAvailable,
	I_ItemType,
	I_ItemCode,
	I_SKU,
	I_UnitOfMeasure,
	I_Remarks,
	I_SRP, 
	I_Status,
	I_Tags
);

SELECT @@Identity AS ID INTO newOrderItemID;
RETURN newOrderItemID;

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
