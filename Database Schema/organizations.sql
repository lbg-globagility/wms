/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `organizations`;
CREATE TABLE IF NOT EXISTS `organizations` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `PrimaryAddressID` int(11) DEFAULT NULL,
  `PremiseAddressID` int(11) DEFAULT NULL,
  `PrimaryContactID` int(11) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `TradeName` varchar(100) DEFAULT NULL,
  `MainPhone` varchar(50) DEFAULT NULL,
  `AltPhone` varchar(50) DEFAULT NULL,
  `FaxNumber` varchar(50) DEFAULT NULL,
  `EmailAddress` varchar(50) DEFAULT NULL,
  `AltEmailAddress` varchar(50) DEFAULT NULL,
  `TINNo` varchar(50) DEFAULT NULL,
  `Website` varchar(50) DEFAULT NULL,
  `OrganizationType` varchar(50) DEFAULT NULL COMMENT 'Commercial Center, Office Building',
  `Comments` varchar(100) DEFAULT NULL,
  `Image` longblob DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index 4` (`Name`),
  KEY `FK_organization_user` (`CreatedBy`),
  KEY `FK_organization_user_2` (`LastUpdBy`),
  KEY `FK_organization_address` (`PrimaryAddressID`),
  KEY `FK_organization_address_2` (`PremiseAddressID`),
  KEY `FK_organization_contact` (`PrimaryContactID`),
  CONSTRAINT `FK_organization_address` FOREIGN KEY (`PrimaryAddressID`) REFERENCES `address` (`RowID`),
  CONSTRAINT `FK_organization_address_2` FOREIGN KEY (`PremiseAddressID`) REFERENCES `address` (`RowID`),
  CONSTRAINT `FK_organization_contact` FOREIGN KEY (`PrimaryContactID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_organization_user` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_organization_user_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='This is the internal Company';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
