/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP FUNCTION IF EXISTS `I_orders`;
DELIMITER //
CREATE FUNCTION `I_orders`(`I_OrganizationID` INT(11), `I_Created` DATETIME, `I_CreatedBy` INT(11), `I_LastUpdBy` INT(11), `I_AccountID` INT(11), `I_BranchID` INT(11), `I_CompanyID` INT(11), `I_CombineCodingID` INT(11), `I_OrderNumber` VARCHAR(50), `I_ReferenceNumber` VARCHAR(50), `I_DRNumber` VARCHAR(50), `I_OrderType` VARCHAR(50), `I_OrderDate` DATE, `I_TargetDate` DATE, `I_EndDate` DATE, `I_CustomerName` VARCHAR(100), `I_Comments` VARCHAR(100), `I_Status` VARCHAR(50), `I_TotalAmount` DECIMAL(10,2), `I_DeliveryHours` VARCHAR(100), `I_CustomerAddress` VARCHAR(150)) RETURNS int(10)
BEGIN

DECLARE newOrdersID INT(11);

INSERT INTO orders
(
	OrganizationID,
	Created,
	CreatedBy,
	LastUpdBy,
	AccountID,
	BranchID,
	CompanyID,
	CombineCodingID,
	OrderNumber,
	ReferenceNumber,
	DRNumber,
	OrderType,
	OrderDate,
	TargetDate,
	EndDate,
	CustomerName,
	Comments,
	`Status`,
	TotalAmount,
	DeliveryHours,
	CustomerAddress
)
VALUES
(
	I_OrganizationID,
	I_Created,
	I_CreatedBy,
	I_LastUpdBy,
	I_AccountID,
	I_BranchID,
	I_CompanyID,
	I_CombineCodingID,
	I_OrderNumber,
	I_ReferenceNumber,
	I_DRNumber,
	I_OrderType,
	I_OrderDate,
	I_TargetDate,
	I_EndDate,
	I_CustomerName,
	I_Comments,
	I_Status,
	I_TotalAmount,
	I_DeliveryHours,
	I_CustomerAddress
);

SELECT @@Identity AS ID INTO newOrdersID;
RETURN newOrdersID;

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
