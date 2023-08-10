/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `invoicepayments`;
CREATE TABLE IF NOT EXISTS `invoicepayments` (
  `RowID` int(10) NOT NULL AUTO_INCREMENT,
  `CreatedBy` int(10) NOT NULL,
  `OrderID` int(10) DEFAULT NULL,
  `LastUpdBy` int(10) NOT NULL,
  `OrganizationID` int(10) NOT NULL,
  `InvoiceID` int(10) DEFAULT NULL,
  `PaymentID` int(10) NOT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `AppliedAmount` decimal(10,2) NOT NULL COMMENT 'amount payment applied to a invoice',
  PRIMARY KEY (`RowID`),
  KEY `FK_InvoicePayment_user` (`CreatedBy`),
  KEY `FK_InvoicePayment_user_2` (`LastUpdBy`),
  KEY `FK_InvoicePayment_invoice` (`InvoiceID`),
  KEY `FK_InvoicePayment_payment` (`PaymentID`),
  KEY `FK_InvoicePayment_order` (`OrderID`),
  KEY `FK_invoicepayment_organization` (`OrganizationID`),
  CONSTRAINT `FK_InvoicePayment_invoice` FOREIGN KEY (`InvoiceID`) REFERENCES `invoice` (`RowID`),
  CONSTRAINT `FK_InvoicePayment_order` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`RowID`),
  CONSTRAINT `FK_InvoicePayment_payment` FOREIGN KEY (`PaymentID`) REFERENCES `payments` (`RowID`),
  CONSTRAINT `FK_InvoicePayment_user` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_InvoicePayment_user_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_invoicepayment_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='an invoice can have many payments, and a payment can cover multiple invoices';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
