/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `divisions`;
CREATE TABLE IF NOT EXISTS `divisions` (
  `RowID` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `TradeName` varchar(100) DEFAULT NULL,
  `OrganizationID` int(10) NOT NULL,
  `MainPhone` varchar(50) DEFAULT NULL,
  `FaxNumber` varchar(50) DEFAULT NULL,
  `BusinessAddress` varchar(1000) DEFAULT NULL,
  `ContactName` varchar(200) DEFAULT NULL,
  `EmailAddress` varchar(50) DEFAULT NULL,
  `AltEmailAddress` varchar(50) DEFAULT NULL,
  `AltPhone` varchar(50) DEFAULT NULL,
  `URL` varchar(50) DEFAULT NULL,
  `TINNo` varchar(50) DEFAULT NULL,
  `Created` datetime DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `ParentDivisionID` int(10) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `DivisionType` varchar(50) DEFAULT NULL COMMENT 'Department, Branch,',
  PRIMARY KEY (`RowID`),
  KEY `FK_organization_user` (`CreatedBy`),
  KEY `FK_organization_user_2` (`LastUpdBy`),
  KEY `FK_employeepreviousemployer_organization` (`OrganizationID`),
  KEY `FK_division_division` (`ParentDivisionID`),
  CONSTRAINT `division_division` FOREIGN KEY (`ParentDivisionID`) REFERENCES `divisions` (`RowID`),
  CONSTRAINT `divisions_ibfk_1` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `divisions_ibfk_2` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `divisions_ibfk_3` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `divisions_ibfk_4` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `divisions_ibfk_5` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT COMMENT='This is the internal Company';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
