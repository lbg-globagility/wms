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

DROP PROCEDURE IF EXISTS `U_products`;
-- Dumping structure for procedure dws.U_products
DELIMITER //
CREATE PROCEDURE `U_products`(
	IN `U_RowID` INT(11),
	IN `U_LastUpd` DATETIME,
	IN `U_LastUpdBy` INT(11),
	IN `U_CategoryID` INT(11),
	IN `U_BrandID` INT(11),
	IN `U_CompanyID` INT(11),
	IN `U_ProductCode` VARCHAR(100),
	IN `U_ProductName` VARCHAR(100),
	IN `U_UnitOfMeasure` VARCHAR(50),
	IN `U_BrandName` VARCHAR(50),
	IN `U_Category` VARCHAR(50),
	IN `U_Company` VARCHAR(50),
	IN `U_Description` VARCHAR(500),
	IN `U_UnitPrice` DECIMAL(10,2),
	IN `U_Image` LONGTEXT
)
BEGIN
Declare preImage LONGTEXT;
SELECT image FROM products WHERE rowid = U_RowID INTO preImage;
UPDATE products SET
	LastUpd = U_LastUpd,
	LastUpdBy = U_LastUpdBy,
	CategoryID = U_CategoryID,
	BrandID = U_BrandID,
	CompanyID = U_CompanyID,
	ProductCode = U_ProductCode,
	ProductName = U_ProductName,
	UnitOfMeasure = U_UnitOfMeasure,
	BrandName = U_BrandName,
	Category = U_Category,
	Company = U_Company,	
	Description = U_Description,
	UnitPrice = U_UnitPrice,
	Image = U_Image
WHERE RowID = U_RowID;
END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
