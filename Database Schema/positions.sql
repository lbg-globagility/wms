/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `positions`;
CREATE TABLE IF NOT EXISTS `positions` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) DEFAULT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `PositionName` varchar(50) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `ParentPositionID` int(10) DEFAULT NULL,
  `DivisionId` int(10) DEFAULT NULL COMMENT 'Department ID',
  `Comments` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index 5` (`PositionName`,`OrganizationID`),
  KEY `FK_position_organization` (`OrganizationID`),
  KEY `FK_position_user` (`CreatedBy`),
  KEY `FK_position_user_2` (`LastUpdBy`),
  KEY `FK_position_position` (`ParentPositionID`),
  KEY `FK_position_division` (`DivisionId`),
  CONSTRAINT `FK_position_division` FOREIGN KEY (`DivisionId`) REFERENCES `divisions` (`RowID`),
  CONSTRAINT `FK_position_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_position_position` FOREIGN KEY (`ParentPositionID`) REFERENCES `positions` (`RowID`),
  CONSTRAINT `FK_position_user` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_position_user_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
