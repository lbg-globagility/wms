/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `U_orders`;
DELIMITER //
CREATE PROCEDURE `U_orders`(
	IN `U_RowID` INT(11),
	IN `U_LastUpd` DATETIME,
	IN `U_LastUpdBy` INT(11),
	IN `U_AccountID` INT(11),
	IN `U_BranchID` INT(11),
	IN `U_CompanyID` INT(11),
	IN `U_CombineCodingID` INT(11),
	IN `U_OrderNumber` VARCHAR(50),
	IN `U_ReferenceNumber` VARCHAR(50),
	IN `U_DRNumber` VARCHAR(50),
	IN `U_OrderDate` DATE,
	IN `U_TargetDate` DATE,
	IN `U_EndDate` DATE,
	IN `U_Comments` VARCHAR(100),
	IN `U_TotalAmount` DECIMAL(10,2),
	IN `U_DeliveryHours` VARCHAR(100),
	IN `U_CustomerAddress` VARCHAR(150),
	IN `U_InventoryLocationID` INT
)
BEGIN
UPDATE orders SET
	LastUpd = U_LastUpd,
	LastUpdBy = U_LastUpdBy,
	AccountID = U_AccountID,
	BranchID = U_BranchID,
	CompanyID = U_CompanyID,
	CombineCodingID = U_CombineCodingID,
	OrderNumber = U_OrderNumber,
	ReferenceNumber = U_ReferenceNumber,
	DRNumber = U_DRNumber,
	OrderDate = U_OrderDate,
	TargetDate = U_TargetDate,
	EndDate = U_EndDate,
	Comments = U_Comments,
	TotalAmount = U_TotalAmount,
	DeliveryHours = U_DeliveryHours,
	CustomerAddress = U_CustomerAddress,
	InventoryLocationID = U_InventoryLocationID
WHERE RowID = U_RowID;
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
