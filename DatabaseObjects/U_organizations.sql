/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `U_organizations`;
DELIMITER //
CREATE PROCEDURE `U_organizations`(IN `U_RowID` INT(11), IN `U_LastUpd` DATETIME, IN `U_LastUpdBy` INT(11), IN `U_PrimaryAddressID` INT(11), IN `U_PremiseAddressID` INT(11), IN `U_PrimaryContactID` INT(11), IN `U_Name` VARCHAR(100), IN `U_Tradename` VARCHAR(100), IN `U_MainPhone` VARCHAR(50), IN `U_AltPhone` VARCHAR(50), IN `U_FaxNumber` VARCHAR(50), IN `U_EmailAddress` VARCHAR(50), IN `U_AltEmailAddress` VARCHAR(50), IN `U_TINNo` VARCHAR(50), IN `U_Website` VARCHAR(50), IN `U_OrganizationType` VARCHAR(50), IN `U_Comments` VARCHAR(100), IN `U_Image` LONGBLOB)
BEGIN
Declare preImage LONGBLOB;
SELECT image FROM organizations WHERE rowid = U_RowID INTO preImage;
UPDATE organizations SET
	LastUpd = U_LastUpd,
	LastUpdBy = U_LastUpdBy,
	PrimaryAddressID = U_PrimaryAddressID,
	PremiseAddressID = U_PremiseAddressID,
	PrimaryContactID = U_PrimaryContactID,	
	Name = U_Name,
	TradeName = U_Tradename,
	MainPhone = U_MainPhone,
	AltPhone = U_AltPhone,
	FaxNumber = U_FaxNumber,
	EmailAddress = U_EmailAddress,
	AltEmailAddress = U_AltEmailAddress,
	TINNo = U_TINNo,
	Website = U_Website,
	OrganizationType = U_OrganizationType,
	Comments = U_Comments,
	Image = IFNULL(U_Image,preImage)
WHERE RowID = U_RowID;
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
