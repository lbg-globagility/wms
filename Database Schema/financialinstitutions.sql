/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `financialinstitutions`;
CREATE TABLE IF NOT EXISTS `financialinstitutions` (
  `RowID` int(10) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) NOT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) NOT NULL,
  `AddressID` int(11) DEFAULT NULL,
  `ContactID` int(11) DEFAULT NULL,
  `Name` varchar(50) NOT NULL COMMENT 'BDO, Metrobank, Security Bank, etc',
  `Branch` varchar(50) NOT NULL COMMENT 'Ortigas,Quezon City, Shaw,etc.',
  `Type` varchar(50) DEFAULT NULL COMMENT 'Bank, Credit Card, etc (LOV Type="FININST_TYPE"',
  `FaxNo` varchar(50) DEFAULT NULL,
  `EmailAddress` varchar(50) DEFAULT NULL,
  `MainPhone` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  KEY `FK__address` (`AddressID`),
  KEY `FK_bank_user` (`CreatedBy`),
  KEY `FK_bank_user_2` (`LastUpdBy`),
  KEY `FK_bank_organization` (`OrganizationID`),
  KEY `FK_bank_contact` (`ContactID`),
  CONSTRAINT `FK_address` FOREIGN KEY (`AddressID`) REFERENCES `address` (`RowID`),
  CONSTRAINT `FK_bank_contact` FOREIGN KEY (`ContactID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_bank_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_bank_user` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_bank_user_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='List of Banks and their Information';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
