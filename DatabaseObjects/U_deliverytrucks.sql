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

DROP FUNCTION IF EXISTS `U_deliverytrucks`;
-- Dumping structure for procedure dws.U_deliverytrucks
DELIMITER //
CREATE PROCEDURE `U_deliverytrucks`(
	IN `U_RowID` INT(11),
	IN `U_LastUpd` DATETIME,
	IN `U_LastUpdBy` INT(11),
	IN `U_TruckName` VARCHAR(50),
	IN `U_PlateNo` VARCHAR(50),
	IN `U_BrandName` VARCHAR(50),
	IN `U_MadeIn` VARCHAR(50),
	IN `U_CBM` DECIMAL(10,2),
	IN `U_Status` VARCHAR(50),
	IN `U_MaxCapacity` VARCHAR(50),
	IN `U_YearAndModel` VARCHAR(50)
)
BEGIN
UPDATE deliverytrucks SET
	LastUpd = U_LastUpd,
	LastUpdBy = U_LastUpdBy,
	TruckName = U_TruckName,
	PlateNo = U_PlateNo,
	BrandName = U_BrandName,
	MadeIn = U_MadeIn,
	CBM = U_CBM,
	`Status` = U_Status,
	MaxCapacity = U_MaxCapacity,
	YearAndModel = U_YearAndModel
WHERE RowID = U_RowID;END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
