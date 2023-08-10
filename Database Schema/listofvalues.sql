/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `listofvalues`;
CREATE TABLE IF NOT EXISTS `listofvalues` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `Created` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `DisplayValue` varchar(50) DEFAULT NULL,
  `LIC` varchar(50) DEFAULT NULL COMMENT 'Language Independent Code',
  `Type` varchar(50) DEFAULT NULL,
  `ParentLIC` varchar(50) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `SystemFlg` char(1) DEFAULT 'N',
  `DisplayFlg` char(1) DEFAULT 'Y',
  `OrderBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Unique` (`LIC`,`Type`),
  KEY `FK_listofval_user` (`LastUpdBy`),
  KEY `FK_listofval_user_2` (`CreatedBy`),
  CONSTRAINT `FK_listofval_user` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_listofval_user_2` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
