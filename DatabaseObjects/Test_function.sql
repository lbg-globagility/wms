/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP FUNCTION IF EXISTS `Test_function`;
DELIMITER //
CREATE FUNCTION `Test_function`(`I_OrganizationID` INT(10), `I_Created` DATETIME, `I_CreatedBy` INT(10), `I_LastUpdBy` INT(10), `I_ProductCode` VARCHAR(100), `I_ProductName` VARCHAR(100), `I_BrandName` VARCHAR(50), `I_CategoryName` VARCHAR(50), `I_CompanyName` VARCHAR(50), `I_UnitPrice` DECIMAL(10,2), `I_UnitOfMeasure` VARCHAR(50), `I_Description` VARCHAR(500), `I_ColorName` VARCHAR(50), `I_Size` DECIMAL(10,2), `I_SKU` VARCHAR(50), `I_Status` VARCHAR(50)) RETURNS int(10)
BEGIN

DECLARE newBrandID INT(10);
DECLARE newCategoryID INT(10);
DECLARE newCompanyID INT(10);
DECLARE newColorID INT(10);
DECLARE newProductID INT(10);
DECLARE newProductColorID INT(10);
DECLARE newProductColorSizeID INT(10);

IF NOT EXISTS(SELECT * FROM brands b WHERE b.brandname = I_BrandName) THEN
	INSERT INTO brands
		(
			OrganizationID,
			Created,
			CreatedBy,
			LastUpdBy,
			BrandName,
			`Status`
		)
	VALUES
		(	
			I_OrganizationID,
			I_Created,
			I_CreatedBy,
			I_LastUpdBy,
			I_BrandName,
			I_Status
		);
	SELECT @@Identity AS ID INTO newBrandID;
ELSE
	SELECT b.rowid FROM brands b WHERE b.brandname = I_BrandName INTO newBrandID;
END IF;
		
IF NOT EXISTS(SELECT * FROM categories ct WHERE ct.categoryname = I_CategoryName) THEN
	INSERT INTO categories
		(
			OrganizationID,
			Created,
			CreatedBy,
			LastUpdBy,
			CategoryName,
			`Status`
		)
	VALUES
		(	
			I_OrganizationID,
			I_Created,
			I_CreatedBy,
			I_LastUpdBy,
			I_CategoryName,
			I_Status
		);
	SELECT @@Identity AS ID INTO newCategoryID;
ELSE
	SELECT ct.rowid FROM categories ct WHERE ct.categoryname = I_CategoryName INTO newCategoryID;
END IF;

IF NOT EXISTS(SELECT * FROM companies co WHERE co.companyname = I_CompanyName) THEN
	INSERT INTO companies
		(
			OrganizationID,
			Created,
			CreatedBy,
			LastUpdBy,
			CompanyName,
			`Status`
		)
	VALUES
		(	
			I_OrganizationID,
			I_Created,
			I_CreatedBy,
			I_LastUpdBy,
			I_CompanyName,
			I_Status
		);
	SELECT @@Identity AS ID INTO newCompanyID;
ELSE
	SELECT co.rowid FROM companies co WHERE co.companyname = I_CompanyName INTO newCompanyID;
END IF;

IF NOT EXISTS(SELECT * FROM colors c WHERE c.colorname = I_ColorName) THEN
	INSERT INTO colors
		(
			OrganizationID,
			Created,
			CreatedBy,
			LastUpdBy,
			ColorName,
			`Status`
		)
	VALUES
		(	
			I_OrganizationID,
			I_Created,
			I_CreatedBy,
			I_LastUpdBy,
			I_ColorName,
			I_Status
		);
	SELECT @@Identity AS ID INTO newColorID;
ELSE
	SELECT c.rowid FROM colors c WHERE c.colorname = I_ColorName INTO newColorID;
END IF;

SELECT @@Identity AS ID INTO newProductColorSizeID;
RETURN newProductColorSizeID;

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
