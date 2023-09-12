/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `I_accounts`;
DELIMITER //
CREATE PROCEDURE `I_accounts`(IN `I_OrganizationID` INT(11), IN `I_Created` DATETIME, IN `I_CreatedBy` INT(11), IN `I_LastUpdBy` INT(11), IN `I_PrimaryContactID` INT(11), IN `I_PrimaryAddressID` INT(11), IN `I_ParentAccountID` INT(11), IN `I_PickListGroupID` INT(11), IN `I_BranchID` INT(11), IN `I_AccountNo` INT(11), IN `I_AccountType` VARCHAR(50), IN `I_CompanyName` VARCHAR(100), IN `I_TradeName` VARCHAR(100), IN `I_MainPhone` VARCHAR(50), IN `I_AltPhone` VARCHAR(50), IN `I_FaxNumber` VARCHAR(50), IN `I_EmailAddress` VARCHAR(50), IN `I_VATRegistrationNo` VARCHAR(50), IN `I_Website` VARCHAR(100), IN `I_DeliveryHours` VARCHAR(100), IN `I_Comments` VARCHAR(200), IN `I_Status` VARCHAR(50))
BEGIN
INSERT INTO accounts
(
	OrganizationID, 
	Created,    
	CreatedBy,  
	LastUpdBy,
	PrimaryContactID,
	PrimaryAddressID,  
	ParentAccountID,
	PickListGroupID,
	BranchID,
	AccountNo,
	AccountType,  
	CompanyName,  
	TradeName, 	
	MainPhone,
	AltPhone,
	FaxNumber,
	EmailAddress,  
	VATRegistrationNo,
 	Website,
 	DeliveryHours,
	Comments, 
	`Status`
)
VALUES
(
	I_OrganizationID, 
	I_Created,    
	I_CreatedBy,  
	I_LastUpdBy,
	I_PrimaryContactID,
	I_PrimaryAddressID,  
	I_ParentAccountID,
	I_PickListGroupID,
	I_BranchID,  
	I_AccountNo,   
	I_AccountType,  
	I_CompanyName,  
	I_TradeName, 	
	I_MainPhone,
	I_AltPhone,
	I_FaxNumber,
	I_EmailAddress, 
	I_VATRegistrationNo,
  	I_Website,
	I_DeliveryHours,
	I_Comments,
	I_Status
);
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
