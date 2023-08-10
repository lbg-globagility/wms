/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `M_I_productinventorylocation`;
DELIMITER //
CREATE PROCEDURE `M_I_productinventorylocation`(IN `I_OrganizationID` INT(10), IN `I_Created` DATETIME, IN `I_CreatedBy` INT(10), IN `I_LastUpdBy` INT(10), IN `I_RackShelfColumnID` INT(10), IN `I_ProductColorSizeID` INT(10), IN `I_TotalAvailableQty` INT(20), IN `I_TotalReserveQty` INT(20), IN `I_TotalDamageQty` INT(20), IN `I_TotalSupplierProblemQty` INT(20), IN `I_TotalInRepairQty` INT(20), IN `I_TotalToReceiveQty` INT(20), IN `I_RunningTotalQty` INT(20), IN `I_UnitPrice` DECIMAL(10,2), IN `I_LastInventoryCount` INT(20))
BEGIN
INSERT INTO productinventorylocation
(
	OrganizationID, 
	Created,    
	CreatedBy,  
	LastUpdBy,
	RackShelfColumnID,
	ProductColorSizeID,
	TotalAvailableQty,
	TotalReserveQty,
	TotalDamageQty,
	TotalSupplierProblemQty,
	TotalInRepairQty,
	TotalToReceiveQty,
	RunningTotalQty,
	UnitPrice,
	LastInventoryCount
)
VALUES
(
	I_OrganizationID, 
	I_Created,    
	I_CreatedBy,  
	I_LastUpdBy,
	I_RackShelfColumnID,
	I_ProductColorSizeID,
	I_TotalAvailableQty,
	I_TotalReserveQty,
	I_TotalDamageQty,
	I_TotalSupplierProblemQty,
	I_TotalInRepairQty,
	I_TotalToReceiveQty,
	I_RunningTotalQty,
	I_UnitPrice,
	I_LastInventoryCount
);
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
