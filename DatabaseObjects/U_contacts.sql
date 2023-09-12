/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `U_contacts`;
DELIMITER //
CREATE PROCEDURE `U_contacts`(IN `U_RowID` INT(11), IN `U_LastUpd` DATETIME, IN `U_LastUpdBy` INT(11), IN `U_Salutation` VARCHAR(50), IN `U_FirstName` VARCHAR(50), IN `U_MiddleName` VARCHAR(50), IN `U_LastName` VARCHAR(50), IN `U_Suffix` VARCHAR(50), IN `U_MainPhone` VARCHAR(50), IN `U_AlternatePhone` VARCHAR(50), IN `U_Birthday` DATE, IN `U_Gender` VARCHAR(50), IN `U_CivilStatus` VARCHAR(50), IN `U_EmailAddress` VARCHAR(50), IN `U_TINNumber` VARCHAR(50), IN `U_Comments` VARCHAR(100), IN `U_MobilePhone` VARCHAR(50), IN `U_WorkPhone` VARCHAR(50), IN `U_FaxNumber` VARCHAR(50), IN `U_JobTitle` VARCHAR(50), IN `U_Nickname` VARCHAR(50), IN `U_Status` VARCHAR(50))
BEGIN
UPDATE contacts SET
	LastUpd = U_LastUpd,
	LastUpdBy = U_LastUpdBy,
	Salutation = U_Salutation,
	FirstName = U_FirstName,
	MiddleName = U_MiddleName,
	LastName = U_LastName,
	Suffix = U_Suffix,
	MainPhone = U_MainPhone,
	AlternatePhone = U_AlternatePhone,
	Birthday = U_Birthday,
	Gender = U_Gender,
	CivilStatus = U_CivilStatus,
	EmailAddress = U_EmailAddress,
	TINNumber = U_TINNUmber,
	Comments = U_Comments,
	MobilePhone = U_MobilePhone,
	WorkPhone = U_WorkPhone,
	FaxNumber = U_FaxNumber,
	JobTitle = U_JobTitle,
	Nickname = U_Nickname,
	`Status` = U_Status
WHERE RowID = U_RowID;
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
