/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `rackshelfcolumn`;
CREATE TABLE IF NOT EXISTS `rackshelfcolumn` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) DEFAULT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL,
  `LastUpdBy` int(11) DEFAULT NULL,
  `InventoryLocationID` int(10) NOT NULL,
  `RackNo` varchar(50) DEFAULT NULL,
  `ShelfNo` varchar(50) DEFAULT NULL,
  `ColumnNo` varchar(50) DEFAULT NULL,
  `Remarks` varchar(100) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `PickOrderNo` int(11) DEFAULT 0,
  `AvailableQty` int(11) DEFAULT 0 COMMENT 'Qty available of this product in this location',
  `DistributedQty` int(11) DEFAULT 0 COMMENT 'Qty distributed to each rack/shelf/column when receiving',
  `ReservedQty` int(11) DEFAULT 0 COMMENT 'qty Reserved of this product in this location',
  `DamagedQty` int(11) DEFAULT 0 COMMENT 'This is used for damaged goods',
  `InRepairQty` int(11) DEFAULT 0 COMMENT 'This is used to track items that are in still in Repair Center (Status of Repair is Open)',
  `SupplierProblemQty` int(11) DEFAULT 0 COMMENT 'only used by main warehouse, this is the quantity that needs to be fixed by supplier or waiting parts from supplier to be fixed',
  `LastShippedToLocDate` date DEFAULT NULL COMMENT 'When this item from this inventory location was last shipped to',
  `LastCycleCountDate` date DEFAULT NULL COMMENT 'last cycle count on this rack/shelf',
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index_rackshelfcolumn` (`OrganizationID`,`InventoryLocationID`,`RackNo`,`ShelfNo`,`ColumnNo`),
  KEY `FK_rackshelfcolumn_organization` (`OrganizationID`),
  KEY `FK_rackshelfcolumn_createdby` (`CreatedBy`),
  KEY `FK_rackshelfcolumn_lastupdby` (`LastUpdBy`),
  KEY `FK_rackshelfcolumn_inventorylocation` (`InventoryLocationID`),
  KEY `Index 7` (`PickOrderNo`),
  CONSTRAINT `FK_rackshelfcolumn_createdby` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_rackshelfcolumn_inventorylocation` FOREIGN KEY (`InventoryLocationID`) REFERENCES `inventorylocations` (`RowID`),
  CONSTRAINT `FK_rackshelfcolumn_lastupdby` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_rackshelfcolumn_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Inventory Location''s inventory of products (including shelf location and quantities)';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
