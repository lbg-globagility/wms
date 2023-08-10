/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `orderitems`;
CREATE TABLE IF NOT EXISTS `orderitems` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) NOT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `AccountID` int(11) DEFAULT NULL,
  `OrderID` int(11) NOT NULL,
  `ProductColorSizeID` int(11) DEFAULT NULL,
  `ProductBundleID` int(11) DEFAULT NULL,
  `OrderItemID` int(11) DEFAULT NULL,
  `VerifiedBy` int(11) DEFAULT NULL,
  `PackedBy` int(11) DEFAULT NULL,
  `DeliveredBy` int(11) DEFAULT NULL,
  `VerifiedDate` date DEFAULT NULL,
  `PackedDate` date DEFAULT NULL,
  `DeliveredDate` date DEFAULT NULL,
  `QtyOrdered` int(11) DEFAULT 0,
  `QtyAvailable` int(11) DEFAULT 0,
  `QtyDelivered` int(11) DEFAULT 0,
  `QtyDamaged` int(11) DEFAULT 0,
  `QtyReceived` int(11) DEFAULT 0,
  `SRP` decimal(10,2) DEFAULT 0.00,
  `ItemType` char(10) DEFAULT NULL,
  `Approval` char(1) DEFAULT 'N',
  `ItemCode` varchar(50) DEFAULT NULL,
  `SKU` varchar(50) DEFAULT NULL,
  `UnitOfMeasure` varchar(50) DEFAULT NULL,
  `Tags` varchar(50) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `Remarks` varchar(100) DEFAULT NULL,
  `Reasons` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  KEY `FK_orderitem_order` (`OrderID`),
  KEY `FK_orderitem_organization` (`OrganizationID`),
  KEY `FK_orderitem_lastupdby` (`LastUpdBy`),
  KEY `FK_orderitem_createdby` (`CreatedBy`),
  KEY `FK_orderitem_productcolorsize` (`ProductColorSizeID`),
  KEY `FK_orderitem_bundle` (`ProductBundleID`),
  KEY `FK_orderitem_account` (`AccountID`),
  KEY `FK_orderitem_verifiedby` (`VerifiedBy`),
  KEY `FK_orderitem_orderitem` (`OrderItemID`),
  KEY `FK_orderitem_packedby` (`PackedBy`),
  KEY `FK_orderitem_deliveredby` (`DeliveredBy`),
  CONSTRAINT `FK_orderitem_account` FOREIGN KEY (`AccountID`) REFERENCES `accounts` (`RowID`),
  CONSTRAINT `FK_orderitem_bundle` FOREIGN KEY (`ProductBundleID`) REFERENCES `productbundleitems` (`RowID`),
  CONSTRAINT `FK_orderitem_createdby` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_orderitem_deliveredby` FOREIGN KEY (`DeliveredBy`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_orderitem_lastupdby` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_orderitem_order` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`RowID`),
  CONSTRAINT `FK_orderitem_orderitem` FOREIGN KEY (`OrderItemID`) REFERENCES `orderitems` (`RowID`),
  CONSTRAINT `FK_orderitem_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_orderitem_packedby` FOREIGN KEY (`PackedBy`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_orderitem_productcolorsize` FOREIGN KEY (`ProductColorSizeID`) REFERENCES `productcolorsizes` (`RowID`),
  CONSTRAINT `FK_orderitem_verfiedby` FOREIGN KEY (`VerifiedBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Items ordered against a Sales, or Purchase order';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
