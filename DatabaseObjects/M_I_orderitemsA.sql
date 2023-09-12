/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `M_I_orderitemsA`;
DELIMITER //
CREATE PROCEDURE `M_I_orderitemsA`(IN `I_OrganizationID` INT(10), IN `I_Created` DATETIME, IN `I_CreatedBy` INT(10), IN `I_LastUpdBy` INT(10), IN `I_AccountID` INT(10), IN `I_OrderID` INT(10), IN `I_ProductColorSizeID` INT(10), IN `I_ProductBundleID` INT(10), IN `I_QtyOrdered` INT(10), IN `I_QtyAvailable` INT(10), IN `I_ItemType` CHAR(10), IN `I_ItemCode` VARCHAR(50), IN `I_SKU` VARCHAR(50), IN `I_UnitOfMeasure` VARCHAR(50), IN `I_Remarks` VARCHAR(100), IN `I_SRP` DECIMAL(10,2), IN `I_Status` VARCHAR(50))
BEGIN
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
	QtyOrdered,
	QtyAvailable,
	ItemType,
	ItemCode,
	SKU,
	UnitOfMeasure,
	Remarks,
	SRP,
	Status
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
	I_QtyOrdered,
	I_QtyAvailable,
	I_ItemType,
	I_ItemCode,
	I_SKU,
	I_UnitOfMeasure,
	I_Remarks,
	I_SRP, 
	I_Status
);
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
