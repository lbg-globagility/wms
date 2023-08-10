/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP FUNCTION IF EXISTS `I_packinglistcartons`;
DELIMITER //
CREATE FUNCTION `I_packinglistcartons`(`I_OrganizationID` INT(11), `I_Created` DATETIME, `I_CreatedBy` INT(11), `I_LastUpdBy` INT(11), `I_ContactID` INT(11), `I_CartonSizeID` INT(11), `I_PackingListID` INT(11), `I_CartonNo` VARCHAR(50), `I_PackedDate` DATE, `I_WeightUOM` VARCHAR(50), `I_Weight` DECIMAL(10,2), `I_Amount` DECIMAL(10,4), `I_Status` VARCHAR(50)) RETURNS int(10)
BEGIN

DECLARE newPackingListCartonID INT(11);

INSERT INTO packinglistcartons
(
	OrganizationID,
	Created,
	CreatedBy,
	LastUpdBy,
	ContactID,
	CartonSizeID,
	PackingListID,
	CartonNo,
	PackedDate,
	WeightUOM,	
	Weight,
	Amount,
	`Status`
)
VALUES
(
	I_OrganizationID,
	I_Created,
	I_CreatedBy,
	I_LastUpdBy,
	I_ContactID,
	I_CartonSizeID,
	I_PackingListID,
	I_CartonNo,
	I_PackedDate,
	I_WeightUOM,
	I_Weight,
	I_Amount,
	I_Status
);

SELECT @@Identity AS ID INTO newPackingListCartonID;
RETURN newPackingListCartonID;

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
