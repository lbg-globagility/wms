/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP FUNCTION IF EXISTS `I_address`;
DELIMITER //
CREATE FUNCTION `I_address`(`I_Created` DATETIME, `I_CreatedBy` INT(11), `I_LastUpdBy` INT(11), `I_StreetAddress1` VARCHAR(100), `I_StreetAddress2` VARCHAR(100), `I_Barangay` VARCHAR(50), `I_CityTown` VARCHAR(50), `I_Province` VARCHAR(50), `I_State` VARCHAR(50), `I_ZipCode` VARCHAR(50), `I_Country` VARCHAR(50)) RETURNS int(10)
BEGIN

DECLARE newAddressID INT(11);

INSERT INTO address
(
	Created,
	CreatedBy,
	LastUpdBy,
	StreetAddress1,
	StreetAddress2,
	Barangay,
	CityTown,
	Province,
	State,
	ZipCode,
	Country
)
VALUES
(
	I_Created,
	I_CreatedBy,
	I_LastUpdBy,
	I_StreetAddress1,
	I_StreetAddress2,
	I_Barangay,
	I_CityTown,
	I_Province,
	I_State,
	I_ZipCode,
	I_Country
);

SELECT @@Identity AS ID INTO newAddressID;
RETURN newAddressID;

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
