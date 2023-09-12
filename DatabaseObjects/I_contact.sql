/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP FUNCTION IF EXISTS `I_contact`;
DELIMITER //
CREATE FUNCTION `I_contact`(`I_OrganizationID` INT(11), `I_Created` DATETIME, `I_CreatedBy` INT(11), `I_LastUpdBy` INT(11), `I_ContactNo` INT(11), `I_Type` VARCHAR(50), `I_Salutation` VARCHAR(50), `I_FirstName` VARCHAR(50), `I_MiddleName` VARCHAR(50), `I_LastName` VARCHAR(50), `I_Suffix` VARCHAR(50), `I_MainPhone` VARCHAR(50), `I_AlternatePhone` VARCHAR(50), `I_Birthday` DATE, `I_Gender` VARCHAR(50), `I_CivilStatus` VARCHAR(50), `I_EmailAddress` VARCHAR(50), `I_TINNumber` VARCHAR(50), `I_Comments` VARCHAR(100), `I_Status` VARCHAR(50), `I_MobilePhone` VARCHAR(50), `I_WorkPhone` VARCHAR(50), `I_FaxNumber` VARCHAR(50), `I_JobTitle` VARCHAR(50), `I_Nickname` VARCHAR(50)) RETURNS int(10)
BEGIN

DECLARE newContactID INT(11);

INSERT INTO contacts
(
	OrganizationID,
	Created,
	CreatedBy,
	LastUpdBy,
	ContactNo,
	`Type`,
	Salutation,
	FirstName,
	MiddleName,
	LastName,
	Suffix,
	MainPhone,
	AlternatePhone,
	Birthday,
	Gender,
	CivilStatus,
	EmailAddress,
	TINNumber,
	Comments,
	`Status`,
	MobilePhone,
	WorkPhone,
	FaxNumber,
	JobTitle,
	Nickname
) 
VALUES
(
	I_OrganizationID,
	I_Created,
	I_CreatedBy,
	I_LastUpdBy,
	I_ContactNo,
	I_Type,
	I_Salutation,
	I_FirstName,
	I_MiddleName,
	I_LastName,
	I_Suffix,
	I_MainPhone,
	I_AlternatePhone,
	I_Birthday,
	I_Gender,
	I_CivilStatus,
	I_EmailAddress,
	I_TINNumber,
	I_Comments,
	I_Status,
	I_MobilePhone,
	I_WorkPhone,
	I_FaxNumber,
	I_JobTitle,
	I_Nickname
);

SELECT @@Identity AS ID INTO newContactID;
RETURN newContactID;

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
