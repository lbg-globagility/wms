/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `cyclecount`;
CREATE TABLE IF NOT EXISTS `cyclecount` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(10) NOT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `BrandID` int(11) DEFAULT NULL,
  `CycleCountNo` int(11) NOT NULL,
  `CycleCountBy` varchar(50) DEFAULT NULL COMMENT 'Location or Product',
  `RackColumnShelf` varchar(50) DEFAULT NULL,
  `Comments` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Unique` (`CycleCountNo`,`OrganizationID`),
  KEY `FK_cyclecount_organization` (`OrganizationID`),
  KEY `FK_cyclecount_createdby` (`CreatedBy`),
  KEY `FK_cyclecount_lastupdby` (`LastUpdBy`),
  KEY `FK_cyclecount_brandid` (`BrandID`),
  CONSTRAINT `FK_cyclecount_brand` FOREIGN KEY (`BrandID`) REFERENCES `brands` (`RowID`),
  CONSTRAINT `FK_cyclecount_createdby` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_cyclecount_lastupdby` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_cyclecount_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT COMMENT='Notes table used to add remarks.';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
