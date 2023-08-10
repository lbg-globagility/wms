/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `lineups`;
CREATE TABLE IF NOT EXISTS `lineups` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) NOT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `ContactID` int(11) DEFAULT NULL,
  `PackingListID` int(11) DEFAULT NULL,
  `DeliveryTruckShiftID` int(11) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `LineUpDate` date DEFAULT NULL,
  `DeliveryDate` date DEFAULT NULL,
  `DeliveryHours` varchar(100) DEFAULT NULL,
  `DeliveryNo` varchar(50) DEFAULT NULL,
  `LineUpNo` varchar(50) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `Comments` varchar(100) DEFAULT NULL,
  `DeliveryAddress` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index_lineups` (`OrderID`,`LineUpDate`,`OrganizationID`,`DeliveryTruckShiftID`),
  KEY `FK_lineups_organization` (`OrganizationID`),
  KEY `FK_lineups_createdby` (`CreatedBy`),
  KEY `FK_lineups_lastupdby` (`LastUpdBy`),
  KEY `FK_lineups_contact` (`ContactID`),
  KEY `FK_lineups_deliverytruckshift` (`DeliveryTruckShiftID`),
  KEY `FK_lineups_order` (`OrderID`),
  KEY `FK_lineups_packinglist` (`PackingListID`),
  CONSTRAINT `lineups_ibfk_1` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `lineups_ibfk_2` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `lineups_ibfk_3` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `lineups_ibfk_4` FOREIGN KEY (`ContactID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `lineups_ibfk_5` FOREIGN KEY (`DeliveryTruckShiftID`) REFERENCES `deliverytruckshifts` (`RowID`),
  CONSTRAINT `lineups_ibfk_6` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`RowID`),
  CONSTRAINT `lineups_ibfk_7` FOREIGN KEY (`PackingListID`) REFERENCES `packinglist` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT COMMENT='Notes table used to add remarks.';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
