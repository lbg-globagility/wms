/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `inventorylocations`;
CREATE TABLE IF NOT EXISTS `inventorylocations` (
  `RowID` int(10) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) NOT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `AddressID` int(11) DEFAULT NULL COMMENT 'FK to Address Table',
  `PrimaryContactID` int(11) DEFAULT NULL COMMENT 'contact associated to this location. (for example, contact person in the branch). links to contact table',
  `Name` varchar(50) NOT NULL,
  `Type` varchar(50) DEFAULT NULL COMMENT 'Branch,Warehouse,Office,Retail Store',
  `MainPhone` varchar(50) DEFAULT NULL,
  `MobilePhone` varchar(50) DEFAULT NULL,
  `FaxNumber` varchar(50) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL COMMENT 'Active, Inactive',
  `Comments` varchar(500) DEFAULT NULL,
  `MainBranch` char(1) DEFAULT NULL COMMENT 'used to flag if this is the main warehouse/branch or not.  Y means main warehouse, N means not.',
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index 7` (`Name`,`OrganizationID`),
  KEY `FK_inventorylocation_contact` (`PrimaryContactID`),
  KEY `FK_inventorylocation_organization` (`OrganizationID`),
  KEY `FK_inventorylocation_user` (`CreatedBy`),
  KEY `FK_inventorylocation_user_2` (`LastUpdBy`),
  KEY `FK_inventorylocation_address` (`AddressID`),
  CONSTRAINT `FK_inventorylocation_address` FOREIGN KEY (`AddressID`) REFERENCES `address` (`RowID`),
  CONSTRAINT `FK_inventorylocation_contact` FOREIGN KEY (`PrimaryContactID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_inventorylocation_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_inventorylocation_user` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_inventorylocation_user_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Company Locations';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
