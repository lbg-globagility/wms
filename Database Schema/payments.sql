/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `payments`;
CREATE TABLE IF NOT EXISTS `payments` (
  `RowID` int(10) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(10) NOT NULL,
  `Created` datetime NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(10) NOT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(10) NOT NULL,
  `PaymentType` varchar(50) DEFAULT NULL,
  `PDCAmount` decimal(10,2) DEFAULT 0.00,
  `Amount` decimal(10,2) DEFAULT 0.00,
  `FinancialInstitutionID` int(10) DEFAULT NULL,
  `BankAccountNumber` varchar(10) DEFAULT NULL,
  `BankCheckNumber` varchar(10) DEFAULT NULL,
  `BankRoutingNumber` varchar(10) DEFAULT NULL,
  `CardHolder` varchar(100) DEFAULT NULL,
  `CardNumber` varchar(10) DEFAULT NULL,
  `CreditMemoNumber` varchar(10) DEFAULT NULL,
  `Description` varchar(500) DEFAULT NULL,
  `ExpirationDate` varchar(50) DEFAULT NULL,
  `ContactID` int(10) DEFAULT NULL,
  `ContractID` int(10) DEFAULT NULL,
  `RequestedAmount` decimal(10,2) DEFAULT 0.00,
  `RemainingBalance` decimal(10,2) DEFAULT 0.00,
  `PaymentNo` int(10) DEFAULT NULL,
  `AccountID` int(10) DEFAULT NULL,
  `PaymentDate` date DEFAULT NULL,
  `PaymentMethod` varchar(50) DEFAULT NULL,
  `ReferenceNumber` varchar(50) DEFAULT NULL,
  `PDCDateUsed` date DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  KEY `FK_payment_organization` (`OrganizationID`),
  KEY `FK_payment_user` (`CreatedBy`),
  KEY `FK_payment_user_2` (`LastUpdBy`),
  KEY `FK_payment_financialinstitution` (`FinancialInstitutionID`),
  KEY `FK_payment_contact` (`ContactID`),
  KEY `FK_payment_account` (`AccountID`),
  KEY `FK_payment_contract` (`ContractID`),
  CONSTRAINT `FK_payment_account` FOREIGN KEY (`AccountID`) REFERENCES `accounts` (`RowID`),
  CONSTRAINT `FK_payment_contact` FOREIGN KEY (`ContactID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_payment_contract` FOREIGN KEY (`ContractID`) REFERENCES `contracts` (`RowID`),
  CONSTRAINT `FK_payment_financialinstitution` FOREIGN KEY (`FinancialInstitutionID`) REFERENCES `financialinstitutions` (`RowID`),
  CONSTRAINT `FK_payment_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_payment_user` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_payment_user_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
