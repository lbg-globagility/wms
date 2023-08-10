/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `accounts`;
CREATE TABLE IF NOT EXISTS `accounts` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) DEFAULT NULL COMMENT 'Internal Company',
  `Created` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `PrimaryContactID` int(11) DEFAULT NULL COMMENT 'Primary Contact of the Account',
  `PrimaryAddressID` int(11) DEFAULT NULL COMMENT 'Links to Address table.  Primary address of Account',
  `PrimaryRepID` int(11) DEFAULT NULL COMMENT 'Primary Representative of the Account',
  `ParentAccountID` int(11) DEFAULT NULL COMMENT 'Links to Account.  If company has branch, then the parentaccountID should be used to link',
  `PickListGroupID` int(11) DEFAULT NULL,
  `BranchID` int(11) DEFAULT NULL,
  `AccountNo` int(11) NOT NULL COMMENT 'Account number of the Company',
  `AccountType` varchar(50) NOT NULL COMMENT 'Branch,Main,Retail,Supplier,Bank,Tenant',
  `CompanyName` varchar(100) DEFAULT NULL COMMENT 'Registered/Formal Customer name in BIR',
  `TradeName` varchar(100) DEFAULT NULL COMMENT 'Customer Company Name used outside ',
  `MainPhone` varchar(50) DEFAULT NULL,
  `AltPhone` varchar(50) DEFAULT NULL,
  `FaxNumber` varchar(50) DEFAULT NULL,
  `EmailAddress` varchar(50) DEFAULT NULL,
  `VATRegistrationNo` varchar(50) DEFAULT NULL COMMENT 'TIN Number',
  `Website` varchar(100) DEFAULT NULL,
  `Comments` varchar(200) DEFAULT NULL COMMENT 'General Comments about Customer',
  `Status` varchar(50) DEFAULT NULL COMMENT 'Prospect,Active',
  `Description` varchar(100) DEFAULT NULL COMMENT 'Description of the nature of business',
  `DeliveryHours` varchar(100) DEFAULT NULL,
  `AltEmailAddress` varchar(50) DEFAULT NULL,
  `MobilePhone` varchar(50) DEFAULT NULL,
  `ManagerName` varchar(50) DEFAULT NULL COMMENT 'Manager Name of the account',
  `BusinessType` varchar(50) DEFAULT NULL COMMENT 'Sole Propriator, Corporation, Partnership',
  `GoodStandingFlg` char(1) DEFAULT NULL,
  `CreditDays` int(11) DEFAULT NULL COMMENT 'Credit Days',
  `YearsInBusiness` decimal(10,2) DEFAULT 0.00 COMMENT 'Years in Business of the branch',
  `CustomerSinceDate` date DEFAULT NULL COMMENT 'When this customer started doing business with Organization',
  `Image` longblob DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index_accounts` (`AccountNo`,`AccountType`,`OrganizationID`),
  KEY `FK_accounts_user` (`CreatedBy`),
  KEY `FK_accounts_user_2` (`LastUpdBy`),
  KEY `FK_accounts_contact` (`PrimaryContactID`),
  KEY `FK_accounts_contact_2` (`PrimaryRepID`),
  KEY `FK_accounts_organization` (`OrganizationID`),
  KEY `FK_accounts_address` (`PrimaryAddressID`),
  KEY `FK_accounts_account` (`ParentAccountID`),
  KEY `FK_accounts_picklistgroup` (`PickListGroupID`),
  KEY `FK_accounts_branch` (`BranchID`),
  KEY `Index 12` (`AccountNo`),
  KEY `Index 13` (`CompanyName`),
  CONSTRAINT `FK_accounts_account` FOREIGN KEY (`ParentAccountID`) REFERENCES `accounts` (`RowID`),
  CONSTRAINT `FK_accounts_address` FOREIGN KEY (`PrimaryAddressID`) REFERENCES `address` (`RowID`),
  CONSTRAINT `FK_accounts_branch` FOREIGN KEY (`BranchID`) REFERENCES `branches` (`RowID`),
  CONSTRAINT `FK_accounts_contact` FOREIGN KEY (`PrimaryContactID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_accounts_createdby` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_accounts_lastupdby` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_accounts_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_accounts_picklistgroup` FOREIGN KEY (`PickListGroupID`) REFERENCES `picklistgroup` (`RowID`),
  CONSTRAINT `FK_accounts_primaryrep` FOREIGN KEY (`PrimaryRepID`) REFERENCES `contacts` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
