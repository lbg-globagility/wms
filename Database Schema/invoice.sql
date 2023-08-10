/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `invoice`;
CREATE TABLE IF NOT EXISTS `invoice` (
  `RowID` int(10) NOT NULL AUTO_INCREMENT,
  `InvoiceNo` int(10) DEFAULT NULL,
  `CreatedBy` int(10) DEFAULT NULL,
  `LastUpdBy` int(10) DEFAULT NULL,
  `Created` datetime DEFAULT current_timestamp(),
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `OrganizationID` int(10) DEFAULT NULL,
  `InvoiceDate` date DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `BillPeriod` varchar(100) DEFAULT NULL,
  `TotalInvoiceAmount` decimal(10,2) DEFAULT 0.00,
  `TotalDue` decimal(10,2) DEFAULT 0.00,
  `BalanceForward` decimal(10,2) DEFAULT 0.00,
  `BalanceDue` decimal(10,2) DEFAULT 0.00,
  `PaymentAmount` decimal(10,2) DEFAULT 0.00,
  `BillToAccountID` int(10) DEFAULT NULL,
  `LatePaymentFlag` char(1) DEFAULT NULL,
  `BillPeriodID` int(11) DEFAULT NULL,
  `OrderID` int(10) DEFAULT NULL,
  `InvoiceDueDate` date DEFAULT NULL,
  `Comments` varchar(500) DEFAULT NULL,
  `InvoiceType` varchar(50) DEFAULT NULL,
  `WaivePenalty` char(1) DEFAULT NULL,
  `BillPeriodStartDate` date DEFAULT NULL,
  `BillPeriodEndDate` date DEFAULT NULL,
  `PaymentTerms` varchar(50) DEFAULT NULL,
  `ContractID` int(10) DEFAULT NULL,
  `PayableToAccountID` int(10) DEFAULT NULL,
  `AvailableCredit` decimal(10,2) DEFAULT 0.00,
  `DepositAmount` decimal(10,2) DEFAULT 0.00,
  `DepositAmountReceived` decimal(10,2) DEFAULT 0.00,
  `DepositDate` date DEFAULT NULL,
  `DepositDueDate` date DEFAULT NULL,
  `TotalTax` decimal(10,2) DEFAULT 0.00,
  `TotalPenalties` decimal(10,2) DEFAULT 0.00,
  `TotalVAT` decimal(10,2) DEFAULT 0.00,
  `DiscountPercent` decimal(10,2) DEFAULT 0.00,
  `DiscountAmount` decimal(10,2) DEFAULT 0.00,
  `TotalDiscounts` decimal(10,2) DEFAULT 0.00,
  `TotalGrossAmount` decimal(10,2) DEFAULT 0.00,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index 2` (`OrganizationID`,`OrderID`,`InvoiceNo`),
  KEY `FK_invoice_user` (`CreatedBy`),
  KEY `FK_invoice_user_2` (`LastUpdBy`),
  KEY `FK_invoice_account` (`BillToAccountID`),
  KEY `FK_invoice_billingperiod` (`BillPeriodID`),
  KEY `FK_invoice_order` (`OrderID`),
  KEY `FK_invoice_contract` (`ContractID`),
  KEY `FK_invoice_account_2` (`PayableToAccountID`),
  CONSTRAINT `FK_invoice_account` FOREIGN KEY (`BillToAccountID`) REFERENCES `accounts` (`RowID`),
  CONSTRAINT `FK_invoice_account_2` FOREIGN KEY (`PayableToAccountID`) REFERENCES `accounts` (`RowID`),
  CONSTRAINT `FK_invoice_billingperiod` FOREIGN KEY (`BillPeriodID`) REFERENCES `billingperiod` (`RowID`),
  CONSTRAINT `FK_invoice_contract` FOREIGN KEY (`ContractID`) REFERENCES `contracts` (`RowID`),
  CONSTRAINT `FK_invoice_order` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`RowID`),
  CONSTRAINT `FK_invoice_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_invoice_user` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_invoice_user_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='This is the billing statement table (Header)';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
