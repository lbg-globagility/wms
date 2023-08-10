/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `contacts`;
CREATE TABLE IF NOT EXISTS `contacts` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) NOT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `AccountID` int(11) DEFAULT NULL COMMENT 'Links to the Account.  A Company can have multiple contacts.',
  `AddressID` int(11) DEFAULT NULL,
  `ContactNo` int(11) DEFAULT NULL,
  `Birthday` date DEFAULT NULL,
  `Type` varchar(50) DEFAULT NULL COMMENT 'Partners',
  `FirstName` varchar(50) DEFAULT NULL,
  `MiddleName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `Suffix` varchar(50) DEFAULT NULL,
  `Salutation` varchar(50) DEFAULT NULL COMMENT 'Mr, Mrs, Dr, etc.',
  `Nickname` varchar(50) DEFAULT NULL,
  `MainPhone` varchar(50) DEFAULT NULL,
  `MobilePhone` varchar(50) DEFAULT NULL,
  `WorkPhone` varchar(50) DEFAULT NULL,
  `AlternatePhone` varchar(50) DEFAULT NULL,
  `FaxNumber` varchar(50) DEFAULT NULL,
  `TINNumber` varchar(50) DEFAULT NULL,
  `EmailAddress` varchar(50) DEFAULT NULL,
  `Gender` varchar(50) DEFAULT NULL,
  `JobTitle` varchar(50) DEFAULT NULL,
  `CivilStatus` varchar(50) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL COMMENT 'On Leave,Prospect,Active,Deceased,,Inactive etc.',
  `Comments` varchar(100) DEFAULT NULL,
  `EmployeeFlg` char(50) DEFAULT NULL COMMENT 'Y if contact is employee',
  PRIMARY KEY (`RowID`),
  KEY `FK_contact_address` (`AddressID`),
  KEY `FK_contact_organization` (`OrganizationID`),
  KEY `FK_contact_user` (`LastUpdBy`),
  KEY `FK_contact_user_2` (`CreatedBy`),
  KEY `FK_contact_contact` (`AccountID`),
  CONSTRAINT `FK_contact_address` FOREIGN KEY (`AddressID`) REFERENCES `address` (`RowID`),
  CONSTRAINT `FK_contact_contact` FOREIGN KEY (`AccountID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_contact_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_contact_user` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_contact_user_2` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
