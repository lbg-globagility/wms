/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `productinventorylocation`;
CREATE TABLE IF NOT EXISTS `productinventorylocation` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) DEFAULT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `RackShelfColumnID` int(11) DEFAULT NULL,
  `ProductColorSizeID` int(11) NOT NULL,
  `TotalAvailableQty` int(11) DEFAULT 0 COMMENT 'Total Available Quantity of this product in the branch',
  `TotalAllocatedQty` int(11) DEFAULT 0,
  `TotalReserveQty` int(11) DEFAULT 0 COMMENT 'Total Reserved Quantity of this product in the branch',
  `TotalDamageQty` int(11) DEFAULT 0 COMMENT 'Total Damaged Quantity of this product in this location',
  `TotalSupplierProblemQty` int(11) DEFAULT 0 COMMENT 'only used by Main Warehouse.  Quantity that needs to be returned to supplier or needs to be repaired and waiting for parts',
  `TotalInRepairQty` int(11) DEFAULT 0 COMMENT 'only used by Main Warehouse. Quantity of item that is still in Repair Center (meaning Status of Repair ticket=Open)',
  `TotalToReceiveQty` int(11) DEFAULT 0 COMMENT 'used by Branches to indicate how many quantites are expected to be received on Delivery',
  `RunningTotalQty` int(11) DEFAULT 0 COMMENT 'Running Total Quantity of this product in that particular branch.  (keeps summing item).  Total overall quantity since beginning of time.',
  `UnitPrice` decimal(10,2) DEFAULT 0.00,
  `LastInventoryCount` date DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index 7` (`OrganizationID`,`ProductColorSizeID`,`RackShelfColumnID`),
  KEY `FK_productinventorylocation_organization` (`OrganizationID`),
  KEY `FK_productinventorylocation_productcolorsize` (`ProductColorSizeID`),
  KEY `FK_productinventorylocation_createdby` (`CreatedBy`),
  KEY `FK_productinventorylocation_lastupdby` (`LastUpdBy`),
  KEY `FK_productinventorylocation_rackshelfcolumn` (`RackShelfColumnID`),
  CONSTRAINT `FK_productinventorylocation_createdby` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_productinventorylocation_lastupdby` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_productinventorylocation_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_productinventorylocation_productcolorsize` FOREIGN KEY (`ProductColorSizeID`) REFERENCES `productcolorsizes` (`RowID`),
  CONSTRAINT `FK_productinventorylocation_rackshelfcolumn` FOREIGN KEY (`RackShelfColumnID`) REFERENCES `rackshelfcolumn` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Table that contains what products the location have (the quantity and shelf locations are in ProdInvLocInventory table)';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
