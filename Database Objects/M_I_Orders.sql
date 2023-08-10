/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP FUNCTION IF EXISTS `M_I_Orders`;
DELIMITER //
CREATE FUNCTION `M_I_Orders`(`I_OrganizationID` INT(10), `I_Created` DATETIME, `I_CreatedBy` INT(10), `I_LastUpdBy` INT(10), `I_AccountID` INT(10), `I_OrderNumber` VARCHAR(50), `I_OrderType` VARCHAR(50), `I_OrderDate` DATE, `I_TargetDate` DATE, `I_CustomerName` VARCHAR(100), `I_Comments` VARCHAR(100), `I_Status` VARCHAR(50), `I_TotalAmount` DECIMAL(10,2), `I_ReceivedBy` VARCHAR(100), `I_RelatedOrderID` INT(10), `I_ContactID` INT(11), `I_TimeArrived` TIME, `I_ReceivedBrands` VARCHAR(50), `I_ContainerNo` VARCHAR(50), `I_SealNo` VARCHAR(50), `I_ArrivedIn` VARCHAR(50)) RETURNS int(10)
    MODIFIES SQL DATA
BEGIN

DECLARE newOrdersID INT(10);

INSERT INTO orders
(
	OrganizationID,
	Created,
	CreatedBy,
	LastUpdBy,
	AccountID,
	OrderNumber,
	OrderType,
	OrderDate,
	TargetDate,
	CustomerName,
	Comments,
	`Status`,
	TotalAmount,
	ReceivedBy,
	RelatedOrderID,
	ContactID,
	TimeArrived,
	ReceivedBrands,
	ContainerNo,
	SealNo,
	ArrivedIn
)
VALUES
(
	I_OrganizationID,
	I_Created,
	I_CreatedBy,
	I_LastUpdBy,
	I_AccountID,
	I_OrderNumber,
	I_OrderType,
	I_OrderDate,
	I_TargetDate,
	I_CustomerName,
	I_Comments,
	I_Status,
	I_TotalAmount,
	I_ReceivedBy,
	I_RelatedOrderID,
	I_ContactID,
	I_TimeArrived,
	I_ReceivedBrands,
	I_ContainerNo,
	I_SealNo,
	I_ArrivedIn
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
