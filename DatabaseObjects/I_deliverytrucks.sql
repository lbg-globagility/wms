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

-- Dumping structure for procedure dws.I_deliverytrucks
DELIMITER //
CREATE PROCEDURE `I_deliverytrucks`(
	IN `I_OrganizationID` INT(11),
	IN `I_Created` DATETIME,
	IN `I_CreatedBy` INT(11),
	IN `I_LastUpdBy` INT(11),
	IN `I_TruckNo` INT(11),
	IN `I_TruckName` VARCHAR(50),
	IN `I_PlateNo` VARCHAR(50),
	IN `I_BrandName` VARCHAR(50),
	IN `I_MadeIn` VARCHAR(50),
	IN `I_CBM` DECIMAL(10,2),
	IN `I_Status` VARCHAR(50),
	IN `I_MaxCapacity` VARCHAR(50),
	IN `I_YearAndModel` VARCHAR(50)
)
BEGIN
INSERT INTO deliverytrucks
(
	OrganizationID,
	Created,
	CreatedBy,
	LastUpdBy,
	TruckNo,
	TruckName,
	PlateNo,
	BrandName,
	MadeIn,
	CBM,
	MaxCapacity,
	YearAndModel,
	`Status`
)
VALUES
(
	I_OrganizationID,
	I_Created,
	I_CreatedBy,
	I_LastUpdBy,
	I_TruckNo,
	I_TruckName,
	I_PlateNo,
	I_BrandName,
	I_MadeIn,
	I_CBM,
	I_MaxCapacity,
	I_YearAndModel,
	I_Status
);
END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
