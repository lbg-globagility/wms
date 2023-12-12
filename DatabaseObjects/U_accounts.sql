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

DROP FUNCTION IF EXISTS `U_accounts`;
-- Dumping structure for procedure dws.U_accounts
DELIMITER //
CREATE PROCEDURE `U_accounts`(
	IN `U_RowID` INT(11),
	IN `U_LastUpd` DATETIME,
	IN `U_LastUpdBy` INT(11),
	IN `U_PrimaryContactID` INT(11),
	IN `U_PrimaryAddressID` INT(11),
	IN `U_ParentAccountID` INT(11),
	IN `U_PickListGroupID` INT(11),
	IN `U_BranchID` INT(11),
	IN `U_CompanyName` VARCHAR(100),
	IN `U_MainPhone` VARCHAR(50),
	IN `U_AltPhone` VARCHAR(50),
	IN `U_FaxNumber` VARCHAR(50),
	IN `U_EmailAddress` VARCHAR(50),
	IN `U_VATRegistrationNo` VARCHAR(50),
	IN `U_Website` VARCHAR(100),
	IN `U_DeliveryHours` VARCHAR(100),
	IN `U_Comments` VARCHAR(200),
	IN `U_Status` VARCHAR(50),
	IN `U_AgentID` INT
)
BEGIN
UPDATE accounts SET
	LastUpd = U_LastUpd,
	LastUpdBy = U_LastUpdBy,
	PrimaryContactID = U_PrimaryContactID,
	PrimaryAddressID = U_PrimaryAddressID,
	ParentAccountID = U_ParentAccountID,
	PickListGroupID = U_PickListGroupID,
	BranchID = U_BranchID,
	CompanyName = U_CompanyName,
	MainPhone = U_MainPhone,
	AltPhone = U_AltPhone,
	FaxNumber = U_FaxNumber,
	EmailAddress = U_EmailAddress,
	VATRegistrationNo = U_VATRegistrationNo,
	Website = U_Website,
	DeliveryHours = U_DeliveryHours,
	Comments = U_Comments,
	`Status` = U_Status,
	AgentID = U_AgentID
WHERE RowID = U_RowID;
END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
