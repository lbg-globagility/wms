/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `I_cyclecountitems`;
DELIMITER //
CREATE PROCEDURE `I_cyclecountitems`(IN `I_OrganizationID` INT(11), IN `I_Created` DATETIME, IN `I_CreatedBy` INT(11), IN `I_LastUpdBy` INT(11), IN `I_CycleCountID` INT(11), IN `I_ProductColorSizeID` INT(11), IN `I_ProductInventoryLocationID` INT(11), IN `I_CycleCount1ContactID` INT(11), IN `I_CycleCount2ContactID` INT(11), IN `I_OriginalQty` INT(11), IN `I_CycleCount1Qty` INT(11), IN `I_CycleCount2Qty` INT(11), IN `I_RackNo` VARCHAR(50), IN `I_ColumnNo` VARCHAR(50), IN `I_ShelfNo` VARCHAR(50), IN `I_Remarks` VARCHAR(100))
BEGIN
INSERT INTO cyclecountitems
(
	OrganizationID,
	Created,
	CreatedBy,
	LastUpdBy,
	CycleCountID, 
	ProductColorSizeID,
	ProductInventoryLocationID,
	CycleCount1ContactID,
	CycleCount2ContactID,
	OriginalQty,
	CycleCount1Qty,
	CycleCount2Qty,
	RackNo,
	ColumnNo,
	ShelfNo,
	Remarks
)
VALUES
(
	I_OrganizationID,
	I_Created,
	I_CreatedBy,
	I_LastUpdBy,
	I_CycleCountID,
	I_ProductColorSizeID,
	I_ProductInventoryLocationID,
	I_CycleCount1ContactID,
	I_CycleCount2ContactID,
	I_OriginalQty,
	I_CycleCount1Qty,
	I_CycleCount2Qty,
	I_RackNo,
	I_ColumnNo,
	I_ShelfNo,
	I_Remarks
);
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
