/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) NOT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `RelatedOrderID` int(11) DEFAULT NULL,
  `InventoryLocationID` int(11) DEFAULT NULL,
  `ContactID` int(11) DEFAULT NULL,
  `BranchID` int(11) DEFAULT NULL,
  `CompanyID` int(11) DEFAULT NULL,
  `CombineCodingID` int(11) DEFAULT NULL,
  `AccountID` int(11) DEFAULT NULL,
  `OrderType` varchar(50) NOT NULL,
  `OrderNumber` varchar(50) NOT NULL,
  `ReferenceNumber` varchar(50) DEFAULT NULL,
  `DRNumber` varchar(50) DEFAULT NULL,
  `OrderDate` date DEFAULT NULL,
  `TargetDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  `DateSubmitted` date DEFAULT NULL,
  `TimeArrived` time DEFAULT NULL,
  `CustomerName` varchar(100) DEFAULT NULL,
  `CustomerAddress` varchar(150) DEFAULT NULL,
  `DeliveryHours` varchar(100) DEFAULT NULL,
  `Comments` varchar(100) DEFAULT NULL,
  `ReceivedBy` varchar(100) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `ReceivedBrands` varchar(50) DEFAULT NULL,
  `ContainerNo` varchar(50) DEFAULT NULL,
  `SealNo` varchar(50) DEFAULT NULL,
  `ArrivedIn` varchar(50) DEFAULT NULL,
  `TotalAmount` decimal(10,2) DEFAULT 0.00,
  `TotalDownPayment` decimal(10,2) DEFAULT 0.00,
  `TotalPayment` decimal(10,2) DEFAULT 0.00,
  `TotalBalance` decimal(10,2) DEFAULT 0.00,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index_orders` (`OrganizationID`,`OrderNumber`,`AccountID`,`OrderType`),
  KEY `FK_order_order` (`RelatedOrderID`),
  KEY `FK_order_organization` (`OrganizationID`),
  KEY `FK_order_contact` (`ContactID`),
  KEY `FK_order_inventorylocation` (`InventoryLocationID`),
  KEY `FK_order_account` (`AccountID`),
  KEY `FK_order_createdby` (`CreatedBy`),
  KEY `FK_order_lastupdby` (`LastUpdBy`),
  KEY `FK_order_branch` (`BranchID`),
  KEY `FK_order_company` (`CompanyID`),
  KEY `FK_order_combinecoding` (`CombineCodingID`),
  CONSTRAINT `FK_order_account` FOREIGN KEY (`AccountID`) REFERENCES `accounts` (`RowID`),
  CONSTRAINT `FK_order_branch` FOREIGN KEY (`BranchID`) REFERENCES `branches` (`RowID`),
  CONSTRAINT `FK_order_combinecoding` FOREIGN KEY (`CombineCodingID`) REFERENCES `combinecodings` (`RowID`),
  CONSTRAINT `FK_order_company` FOREIGN KEY (`CompanyID`) REFERENCES `companies` (`RowID`),
  CONSTRAINT `FK_order_contact` FOREIGN KEY (`ContactID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_order_createdby` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_order_inventorylocation` FOREIGN KEY (`InventoryLocationID`) REFERENCES `inventorylocations` (`RowID`),
  CONSTRAINT `FK_order_lastupdby` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_order_order` FOREIGN KEY (`RelatedOrderID`) REFERENCES `orders` (`RowID`),
  CONSTRAINT `FK_order_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='This is the table that holds all orders - Purchase Order/Requisition, Material Request, Sales Order, Service Order anything that has to do with Orders.  The differentiation is by the column "Type"';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
