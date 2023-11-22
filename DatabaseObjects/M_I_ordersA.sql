-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.28-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for function dws.M_I_ordersA
DELIMITER //
CREATE FUNCTION `M_I_ordersA`(`I_OrganizationID` INT(10),
	`I_Created` DATETIME,
	`I_CreatedBy` INT(10),
	`I_LastUpdBy` INT(10),
	`I_AccountID` INT(10),
	`I_OrderNumber` VARCHAR(50),
	`I_OrderType` VARCHAR(50),
	`I_OrderDate` DATE,
	`I_TargetDate` DATE,
	`I_CustomerName` VARCHAR(100),
	`I_Comments` VARCHAR(100),
	`I_Status` VARCHAR(50),
	`I_TotalAmount` DECIMAL(10,2),
	`I_LineUpId` INT
) RETURNS int(10)
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
	LineUpId
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
	I_LineUpId
);
SELECT @@Identity AS ID INTO newOrdersID;
RETURN newOrdersID;
END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
