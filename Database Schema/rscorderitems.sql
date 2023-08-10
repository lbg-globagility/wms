/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `rscorderitems`;
CREATE TABLE IF NOT EXISTS `rscorderitems` (
  `RowID` int(10) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(10) NOT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `ProdInventoryLocID` int(11) DEFAULT NULL,
  `OrderItemsID` int(11) DEFAULT NULL,
  `QtyApplied` int(20) DEFAULT 0,
  `Status` varchar(50) DEFAULT 'Active',
  PRIMARY KEY (`RowID`),
  KEY `FK_categories_user` (`CreatedBy`),
  KEY `FK_categories_user_2` (`LastUpdBy`),
  KEY `FK_categories_organization` (`OrganizationID`),
  KEY `ProdInventoryLocID` (`ProdInventoryLocID`),
  KEY `OrderItemsID` (`OrderItemsID`),
  CONSTRAINT `FK_rscorderitems_orderitems` FOREIGN KEY (`OrderItemsID`) REFERENCES `orderitems` (`RowID`),
  CONSTRAINT `FK_rscorderitems_productinventorylocation` FOREIGN KEY (`ProdInventoryLocID`) REFERENCES `productinventorylocation` (`RowID`),
  CONSTRAINT `rscorderitems_ibfk_1` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `rscorderitems_ibfk_2` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `rscorderitems_ibfk_3` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT COMMENT='Notes table used to add remarks.';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
