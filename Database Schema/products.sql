/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `products`;
CREATE TABLE IF NOT EXISTS `products` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) DEFAULT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `CategoryID` int(11) DEFAULT NULL,
  `BrandID` int(11) DEFAULT NULL,
  `CompanyID` int(11) DEFAULT NULL,
  `ProductCode` varchar(100) NOT NULL COMMENT 'unique part number for this product',
  `ProductName` varchar(100) DEFAULT NULL,
  `BrandName` varchar(50) DEFAULT NULL,
  `Category` varchar(50) DEFAULT NULL COMMENT 'e.g. Lights, Bathroom,Walls',
  `Company` varchar(50) DEFAULT NULL,
  `UnitOfMeasure` varchar(50) DEFAULT NULL,
  `Description` varchar(500) DEFAULT NULL COMMENT 'description for the product',
  `Status` varchar(50) DEFAULT 'Active',
  `SKU` varchar(50) DEFAULT NULL COMMENT 'Stock Keeping Unit (for example, 2 suppliers - same item - the part # will be the same but the SKU will be different)',
  `SKU2` varchar(50) DEFAULT NULL,
  `BarCode` varchar(200) DEFAULT NULL,
  `UnitPrice` decimal(10,2) DEFAULT 0.00 COMMENT 'SuggestedRetailPrice',
  `CostPrice` decimal(10,2) DEFAULT 0.00 COMMENT 'Avg Cost from Supplier',
  `ReOrderPoint` int(10) DEFAULT NULL,
  `LastRcvdFromShipmentCount` int(11) DEFAULT NULL COMMENT 'how many of this item was received from last shipment',
  `LastSoldCount` int(11) DEFAULT NULL,
  `LastArrivedQty` int(11) DEFAULT NULL COMMENT 'This contains the summation of the quantities that arrived from last shipment (calculated when warehouse manager is entering rack/shelf/column',
  `TotalShipmentCount` int(11) DEFAULT NULL,
  `LastRcvdFromShipmentDate` date DEFAULT NULL COMMENT 'when this product was last received from Shipment',
  `LastPurchaseDate` date DEFAULT NULL COMMENT 'Date on which this item is last purchased',
  `LastSoldDate` date DEFAULT NULL COMMENT 'Date on which this item is last sold (to be able to determine aging)',
  `Image` longblob DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index 5` (`ProductCode`,`OrganizationID`),
  KEY `FK_product_user` (`CreatedBy`),
  KEY `FK_product_user_2` (`LastUpdBy`),
  KEY `FK_product_category` (`CategoryID`),
  KEY `FK_product_organization` (`OrganizationID`),
  KEY `FK_product_brand` (`BrandID`),
  KEY `FK_product_company` (`CompanyID`),
  KEY `Index 9` (`ProductCode`),
  CONSTRAINT `products_ibfk_1` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `products_ibfk_2` FOREIGN KEY (`CategoryID`) REFERENCES `categories` (`RowID`),
  CONSTRAINT `products_ibfk_3` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `products_ibfk_4` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `products_ibfk_5` FOREIGN KEY (`BrandID`) REFERENCES `brands` (`RowID`),
  CONSTRAINT `products_ibfk_6` FOREIGN KEY (`CompanyID`) REFERENCES `companies` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT COMMENT='Products/Material Items table';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
