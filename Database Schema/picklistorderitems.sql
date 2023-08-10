/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `picklistorderitems`;
CREATE TABLE IF NOT EXISTS `picklistorderitems` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) NOT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `PickListOrderID` int(11) NOT NULL,
  `ProductInventoryLocationID` int(11) NOT NULL,
  `QtyPicked` int(11) DEFAULT 0,
  `QtyDelivered` int(11) DEFAULT 0,
  `QtyReserve` int(11) DEFAULT 0,
  `QtyAvailable` int(11) DEFAULT 0,
  `IssueFlg` char(1) DEFAULT 'N',
  `Status` varchar(50) DEFAULT 'Active',
  `Remarks` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index_picklistorderitems` (`OrganizationID`,`PickListOrderID`,`ProductInventoryLocationID`),
  KEY `FK_picklistorderitems_createdby` (`CreatedBy`),
  KEY `FK_picklistorderitems_lastupdby` (`LastUpdBy`),
  KEY `FK_picklistorderitems_organization` (`OrganizationID`),
  KEY `FK_picklistorderitems_picklistorder` (`PickListOrderID`),
  KEY `FK_picklistorderitems_productinventorylocation` (`ProductInventoryLocationID`),
  CONSTRAINT `picklistorderitems_ibfk_1` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `picklistorderitems_ibfk_2` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `picklistorderitems_ibfk_3` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `picklistorderitems_ibfk_4` FOREIGN KEY (`PickListOrderID`) REFERENCES `picklistorders` (`RowID`),
  CONSTRAINT `picklistorderitems_ibfk_5` FOREIGN KEY (`ProductInventoryLocationID`) REFERENCES `productinventorylocation` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT COMMENT='Notes table used to add remarks.';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
