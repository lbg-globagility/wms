/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `returns`;
CREATE TABLE IF NOT EXISTS `returns` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `DeductedFromInventory` char(1) NOT NULL DEFAULT '0',
  `Created` timestamp NOT NULL DEFAULT current_timestamp(),
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `CreatedBy` int(11) NOT NULL,
  `LastUpdBy` int(11) NOT NULL,
  `OrganizationID` int(11) NOT NULL,
  `InvoiceID` int(11) NOT NULL,
  `ReturnInvoiceID` int(11) NOT NULL,
  `ReturnOrderID` int(11) NOT NULL,
  `OrderID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Type` varchar(50) NOT NULL COMMENT 'Exchange, Refund',
  `TotalQty` int(11) NOT NULL,
  `TotalAmount` decimal(10,2) NOT NULL,
  `Amount` decimal(10,2) NOT NULL,
  `ProductID` int(10) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  KEY `FK_Returns_user` (`CreatedBy`),
  KEY `FK_Returns_user_2` (`LastUpdBy`),
  KEY `FK_Returns_organization` (`OrganizationID`),
  KEY `FK_Returns_invoice` (`InvoiceID`),
  KEY `FK_Returns_order` (`OrderID`),
  KEY `FK_Returns_product` (`ProductID`),
  KEY `FK_returns_order_returnOrderID` (`ReturnOrderID`),
  KEY `FK_returns_invoice_returnInvoiceID` (`ReturnInvoiceID`),
  CONSTRAINT `FK_Returns_invoice` FOREIGN KEY (`InvoiceID`) REFERENCES `invoice` (`RowID`),
  CONSTRAINT `FK_Returns_invoice_returnInvoiceID` FOREIGN KEY (`ReturnInvoiceID`) REFERENCES `invoice` (`RowID`),
  CONSTRAINT `FK_Returns_order` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`RowID`),
  CONSTRAINT `FK_Returns_order_returnOrderID` FOREIGN KEY (`ReturnOrderID`) REFERENCES `orders` (`RowID`),
  CONSTRAINT `FK_Returns_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_Returns_product` FOREIGN KEY (`ProductID`) REFERENCES `products` (`RowID`),
  CONSTRAINT `FK_Returns_user` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_Returns_user_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Table to store returns refunds/exchanges';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
