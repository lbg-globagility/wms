/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `attachments`;
CREATE TABLE IF NOT EXISTS `attachments` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) DEFAULT NULL,
  `Created` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `AccountID` int(11) DEFAULT NULL,
  `ContactID` int(11) DEFAULT NULL,
  `ProductID` int(11) DEFAULT NULL,
  `ContractID` int(11) DEFAULT NULL,
  `OrderID` int(11) DEFAULT NULL,
  `InvoiceID` int(11) DEFAULT NULL,
  `AttachedFile` longblob DEFAULT NULL,
  `FileType` varchar(10) DEFAULT NULL,
  `FileName` varchar(200) DEFAULT NULL,
  `Remarks` varchar(500) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  KEY `FK_attachments_account` (`AccountID`),
  KEY `FK_attachments_order` (`OrderID`),
  KEY `FK_attachments_contract` (`ContractID`),
  KEY `FK_attachments_createdby` (`CreatedBy`),
  KEY `FK_attachments_invoice` (`InvoiceID`),
  KEY `FK_attachments_lastupdby` (`LastUpdBy`),
  KEY `FK_attachments_contact` (`ContactID`),
  KEY `FK_attachments_product` (`ProductID`),
  KEY `FK_attachments_organization` (`OrganizationID`),
  CONSTRAINT `FK_attachments_account` FOREIGN KEY (`AccountID`) REFERENCES `accounts` (`RowID`),
  CONSTRAINT `FK_attachments_contact` FOREIGN KEY (`ContactID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_attachments_contract` FOREIGN KEY (`ContractID`) REFERENCES `contracts` (`RowID`),
  CONSTRAINT `FK_attachments_createdby` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_attachments_invoice` FOREIGN KEY (`InvoiceID`) REFERENCES `invoice` (`RowID`),
  CONSTRAINT `FK_attachments_lastupdby` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_attachments_order` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`RowID`),
  CONSTRAINT `FK_attachments_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_attachments_product` FOREIGN KEY (`ProductID`) REFERENCES `products` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT COMMENT='Notes table used to add remarks.';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
