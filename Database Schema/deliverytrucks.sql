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

-- Dumping structure for table dws.deliverytrucks
CREATE TABLE IF NOT EXISTS `deliverytrucks` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) NOT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `TruckNo` int(11) NOT NULL,
  `TruckName` varchar(50) DEFAULT NULL,
  `PlateNo` varchar(50) DEFAULT NULL,
  `BrandName` varchar(50) DEFAULT NULL,
  `MadeIn` varchar(50) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `CBM` decimal(10,2) DEFAULT 0.00,
  `MaxCapacity` varchar(50) DEFAULT NULL,
  `YearAndModel` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index_deliverytrucks` (`OrganizationID`,`TruckNo`),
  KEY `FK_deliverytrucks_user` (`CreatedBy`),
  KEY `FK_deliverytrucks_user_2` (`LastUpdBy`),
  KEY `FK_deliverytrucks_organization` (`OrganizationID`),
  CONSTRAINT `deliverytrucks_ibfk_1` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `deliverytrucks_ibfk_2` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `deliverytrucks_ibfk_3` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci ROW_FORMAT=COMPACT COMMENT='Notes table used to add remarks.';

-- Data exporting was unselected.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
