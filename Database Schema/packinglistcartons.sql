/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `packinglistcartons`;
CREATE TABLE IF NOT EXISTS `packinglistcartons` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) NOT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `ContactID` int(11) DEFAULT NULL,
  `CartonSizeID` int(11) DEFAULT NULL,
  `PackingListID` int(11) DEFAULT NULL,
  `PackedDate` date DEFAULT NULL,
  `CartonNo` varchar(50) NOT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `WeightUOM` varchar(50) DEFAULT NULL,
  `Weight` decimal(10,2) DEFAULT 0.00,
  `Amount` decimal(10,2) DEFAULT 0.00,
  PRIMARY KEY (`RowID`),
  KEY `FK_packinglistcartons_organization` (`OrganizationID`),
  KEY `FK_packinglistcartons_lastupdby` (`LastUpdBy`),
  KEY `FK_packinglistcartons_createdby` (`CreatedBy`),
  KEY `FK_packinglistcartons_packinglist` (`PackingListID`),
  KEY `FK_packinglistcartons_contacts` (`ContactID`),
  KEY `FK_packinglistcartons_cartonsize` (`CartonSizeID`),
  CONSTRAINT `packinglistcartons_ibfk_1` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `packinglistcartons_ibfk_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `packinglistcartons_ibfk_3` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `packinglistcartons_ibfk_4` FOREIGN KEY (`PackingListID`) REFERENCES `packinglist` (`RowID`),
  CONSTRAINT `packinglistcartons_ibfk_5` FOREIGN KEY (`ContactID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `packinglistcartons_ibfk_6` FOREIGN KEY (`CartonSizeID`) REFERENCES `cartonsizes` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT COMMENT='Items ordered against a Sales, or Purchase order';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
