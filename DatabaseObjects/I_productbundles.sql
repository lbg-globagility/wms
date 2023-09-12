/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `I_productbundles`;
DELIMITER //
CREATE PROCEDURE `I_productbundles`(IN `I_OrganizationID` INT(11), IN `I_Created` DATETIME, IN `I_CreatedBy` INT(11), IN `I_LastUpdBy` INT(11), IN `I_CategoryID` INT(11), IN `I_BrandID` INT(11), IN `I_CompanyID` INT(11), IN `I_BundleName` VARCHAR(50), IN `I_SKU` VARCHAR(50), IN `I_UnitOfMeasure` VARCHAR(50), IN `I_Description` VARCHAR(100), IN `I_Status` VARCHAR(50), IN `I_SRP` DECIMAL(10,2))
BEGIN
INSERT INTO productbundles 
(
	OrganizationID,
	Created,
	CreatedBy,
	LastUpdBy,
	CategoryID,
	BrandID,
	CompanyID,
	BundleName,
	SKU,
	UnitOfMeasure,
	Description,
	`Status`,
	SRP
)
VALUES
(
	I_OrganizationID,
	I_Created,
	I_CreatedBy,
	I_LastUpdBy,
	I_CategoryID,
	I_BrandID,
	I_CompanyID,
	I_BundleName,
	I_SKU,
	I_UnitOfMeasure,
	I_Description,
	I_Status,
	I_SRP
);
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
