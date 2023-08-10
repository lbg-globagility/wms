/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `M_I_productmovementhistory`;
DELIMITER //
CREATE PROCEDURE `M_I_productmovementhistory`(IN `I_OrganizationID` INT(10), IN `I_Created` DATETIME, IN `I_CreatedBy` INT(10), IN `I_OrderID` INT(10), IN `I_ProductColorSizeID` INT(10), IN `I_ProductInventoryLocationIDA` INT(10), IN `I_ProductInventoryLocationIDB` INT(10), IN `I_CurrentQty` INT(20), IN `I_QtyToApply` INT(20), IN `I_NewQty` INT(20), IN `I_TransactionType` VARCHAR(100), IN `I_ColumnName` VARCHAR(100), IN `I_Comments` VARCHAR(100))
BEGIN
INSERT INTO productmovementhistory
(
	OrganizationID,
	Created,
	CreatedBy,
	OrderID,
	ProductColorSizeID,
	ProductInventoryLocationIDA,
	ProductInventoryLocationIDB,
	CurrentQty,
	QtyToApply,
	NewQty,
	TransactionType,
	ColumnName,
	Comments
)
VALUES
(
	I_OrganizationID, 
	I_Created,    
	I_CreatedBy,  
	I_OrderID,
	I_ProductColorSizeID,
	I_ProductInventoryLocationIDA,
	I_ProductInventoryLocationIDB,
	I_CurrentQty,
	I_QtyToApply,
	I_NewQty,
	I_TransactionType,
	I_ColumnName,
	I_Comments
);
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
