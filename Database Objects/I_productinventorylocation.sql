/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP FUNCTION IF EXISTS `I_productinventorylocation`;
DELIMITER //
CREATE FUNCTION `I_productinventorylocation`(`I_OrganizationID` INT(11), `I_Created` DATETIME, `I_CreatedBy` INT(11), `I_LastUpdBy` INT(11), `I_RackShelfColumnID` INT(11), `I_ProductColorSizeID` INT(11), `I_TotalAvailableQty` INT(11)) RETURNS int(10)
BEGIN

DECLARE newProductInventoryLocationID INT(11);

INSERT INTO productinventorylocation
(
	OrganizationID,
	Created,
	CreatedBy,
	LastUpdBy,
	RackShelfColumnID,
	ProductColorSizeID,
	TotalAvailableQty
)
VALUES
(
	I_OrganizationID,
	I_Created,
	I_CreatedBy,
	I_LastUpdBy,
	I_RackShelfColumnID,
	I_ProductColorSizeID,
	I_TotalAvailableQty
);

SELECT @@Identity AS ID INTO newProductInventoryLocationID;
RETURN newProductInventoryLocationID;

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
