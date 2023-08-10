/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `productmovementhistory`;
CREATE TABLE IF NOT EXISTS `productmovementhistory` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) NOT NULL,
  `Created` datetime DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `LineUpID` int(11) DEFAULT NULL,
  `PickListID` int(11) DEFAULT NULL,
  `ProductColorSizeID` int(11) DEFAULT NULL,
  `ProductInventoryLocationIDA` int(11) DEFAULT NULL,
  `ProductInventoryLocationIDB` int(11) DEFAULT NULL,
  `CurrentQty` int(11) DEFAULT NULL,
  `QtyToApply` int(11) DEFAULT NULL,
  `NewQty` int(11) DEFAULT NULL,
  `TransactionType` varchar(50) DEFAULT NULL COMMENT 'Stock Adjustment, Stock Transfer, Receiving, Shipping,etc.',
  `ColumnName` varchar(50) DEFAULT NULL,
  `Comments` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  KEY `FK_productmovementhistory_organization` (`OrganizationID`),
  KEY `FK_productmovementhistory_order` (`OrderID`),
  KEY `FK_productmovementhistory_productcolorsize` (`ProductColorSizeID`),
  KEY `FK_productmovementhistory_lastupdby` (`LastUpdBy`),
  KEY `FK_productmovementhistory_createdby` (`CreatedBy`),
  KEY `FK_productmovementhistory_productinventorylocationA` (`ProductInventoryLocationIDA`),
  KEY `FK_productmovementhistory_productinventorylocationB` (`ProductInventoryLocationIDB`),
  KEY `FK_productmovementhistory_picklist` (`PickListID`),
  KEY `FK_productmovementhistory_lineup` (`LineUpID`),
  CONSTRAINT `FK_productmovementhistory_createdby` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_productmovementhistory_lastupdby` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_productmovementhistory_lineup` FOREIGN KEY (`LineUpID`) REFERENCES `lineups` (`RowID`),
  CONSTRAINT `FK_productmovementhistory_order` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`RowID`),
  CONSTRAINT `FK_productmovementhistory_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_productmovementhistory_picklist` FOREIGN KEY (`PickListID`) REFERENCES `picklist` (`RowID`),
  CONSTRAINT `FK_productmovementhistory_productcolorsize` FOREIGN KEY (`ProductColorSizeID`) REFERENCES `productcolorsizes` (`RowID`),
  CONSTRAINT `FK_productmovementhistory_productinventorylocationA` FOREIGN KEY (`ProductInventoryLocationIDA`) REFERENCES `productinventorylocation` (`RowID`),
  CONSTRAINT `FK_productmovementhistory_productinventorylocationB` FOREIGN KEY (`ProductInventoryLocationIDB`) REFERENCES `productinventorylocation` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Tracks the movement history of a particular product every time the product moves (whether it be Purchase Order, Warehouse Receivng, Customer Order, Customer Fulfillment, Stock Transfer, Stock Adjustment, Returns, etc)';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
