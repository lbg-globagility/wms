/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `invoiceitems`;
CREATE TABLE IF NOT EXISTS `invoiceitems` (
  `RowID` int(10) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(10) NOT NULL DEFAULT 0,
  `CreatedBy` int(10) NOT NULL DEFAULT 0,
  `Created` timestamp NOT NULL DEFAULT current_timestamp(),
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(10) NOT NULL DEFAULT 0,
  `ItemCode` varchar(50) DEFAULT '0' COMMENT 'LOV Type = "Invoice Item"',
  `ItemDescription` varchar(1000) DEFAULT '0',
  `AmountDue` decimal(10,2) DEFAULT 0.00,
  `InvoiceDate` date NOT NULL,
  `VAT` decimal(10,2) DEFAULT 0.00,
  `WithholdingTax` decimal(10,2) DEFAULT 0.00,
  `InvoiceID` int(10) NOT NULL DEFAULT 0,
  `AccountID` int(10) DEFAULT NULL,
  `BillingPeriodID` int(10) DEFAULT NULL,
  `AccountBillingPeriodID` int(10) DEFAULT NULL,
  `DiscountAmount` decimal(10,2) DEFAULT 0.00,
  `DiscountPercent` decimal(10,2) DEFAULT 0.00,
  `TotalDiscount` decimal(10,2) DEFAULT 0.00,
  `Comments` varchar(500) DEFAULT NULL,
  `ProratedBillingPeriod` varchar(100) DEFAULT NULL COMMENT 'store the billing period of the item if it is prorated. store also billing period of utilities since its different from billingperiod.  this is just the text that appears in bill',
  `TotalAmountDue` decimal(10,2) DEFAULT 0.00,
  `LineNumber` int(10) NOT NULL DEFAULT 0,
  `OrderID` int(10) DEFAULT NULL,
  `AdditionalItem` char(1) DEFAULT 'N' COMMENT 'for RoyalMP, flag to indicate if this is an additional invoice item aside from the calculated items from monthly billing',
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index 2` (`RowID`),
  KEY `FK_invoiceitems_user` (`CreatedBy`),
  KEY `FK_invoiceitems_user_2` (`LastUpdBy`),
  KEY `FK_invoiceitem_billingperiod` (`BillingPeriodID`),
  KEY `FK_invoiceitem_account` (`AccountID`),
  KEY `FK_invoiceitem_order` (`OrderID`),
  KEY `FK_invoiceitem_accountbillingperiod` (`AccountBillingPeriodID`),
  KEY `OrganizationID` (`OrganizationID`),
  KEY `InvoiceID` (`InvoiceID`),
  CONSTRAINT `FK_invoiceitem_account` FOREIGN KEY (`AccountID`) REFERENCES `accounts` (`RowID`),
  CONSTRAINT `FK_invoiceitem_accountbillingperiod` FOREIGN KEY (`AccountBillingPeriodID`) REFERENCES `accountbillingperiod` (`RowID`),
  CONSTRAINT `FK_invoiceitem_billingperiod` FOREIGN KEY (`BillingPeriodID`) REFERENCES `billingperiod` (`RowID`),
  CONSTRAINT `FK_invoiceitem_order` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`RowID`),
  CONSTRAINT `FK_invoiceitems_invoice` FOREIGN KEY (`InvoiceID`) REFERENCES `invoice` (`RowID`),
  CONSTRAINT `FK_invoiceitems_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_invoiceitems_user` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_invoiceitems_user_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Items for that particular bill';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
