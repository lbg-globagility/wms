/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `contracts`;
CREATE TABLE IF NOT EXISTS `contracts` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `Location_UnitCode` varchar(50) DEFAULT NULL COMMENT 'for Royal MP, defines which location and unit the lessee is interested in',
  `OrganizationID` int(11) DEFAULT NULL COMMENT 'Internal Company',
  `ContractNo` int(11) NOT NULL,
  `Area` decimal(10,2) DEFAULT NULL COMMENT 'area of the location/unit code in sq. m.',
  `AdditionalArea` decimal(10,2) DEFAULT 0.00,
  `LeaseTerm` varchar(50) DEFAULT NULL COMMENT 'lease term',
  `LeaseYears` int(11) DEFAULT NULL COMMENT 'lease in number of years',
  `LeaseMonths` int(11) DEFAULT NULL COMMENT 'lease in number of months',
  `QuoteID` int(11) DEFAULT NULL COMMENT 'before becoming a contract, a quote is created. links contract to quote',
  `CUSA` decimal(10,2) DEFAULT NULL COMMENT 'Common Use Service Area fee',
  `CUSAperSqM` decimal(10,2) DEFAULT NULL,
  `Aircon` varchar(50) DEFAULT NULL COMMENT 'LOV Type = "LEASE_RESP"- To be provided by Lessee or To be provided by Lessor',
  `Utilities` varchar(50) DEFAULT NULL COMMENT 'LOV Type = "LEASE_UTIL" - ',
  `DocumentaryStamp` varchar(50) DEFAULT NULL,
  `PercentageRate` varchar(200) DEFAULT NULL,
  `Escalated` char(1) DEFAULT NULL COMMENT 'Flag to determine if Contract has had renewal escalations already',
  `NextEscalationDate` date DEFAULT NULL COMMENT 'Date when the next Renewal Escalation will happen.',
  `Escalation` decimal(10,0) DEFAULT NULL COMMENT 'In percentage, escalation is the increase in rent (by %) annually',
  `Created` timestamp NULL DEFAULT current_timestamp(),
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `InterestPercent` decimal(10,2) DEFAULT NULL,
  `PenaltyPercent` decimal(10,2) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpdBy` int(11) DEFAULT NULL,
  `AdvanceRent` int(11) DEFAULT NULL COMMENT '# of months in advance rent collected applied to the first few months of lease term',
  `AdvanceRentEnding` int(11) DEFAULT 0 COMMENT '# of months in advance applied to end of the lease term',
  `SecurityDeposit` int(11) DEFAULT NULL COMMENT 'security deposit (in months) to be collected',
  `WaterDepositNoofMeter` int(11) DEFAULT NULL COMMENT '# of meters to be calculated for water deposit in 3rd billing',
  `ElectricalFeederline` varchar(200) DEFAULT NULL,
  `ConstructionBond` int(11) DEFAULT NULL COMMENT 'bond (in months) nneds to be collected for contruction. refundable deposit',
  `ConstructionPeriod` int(11) DEFAULT NULL COMMENT 'number of days allowed for contruction after commencement date',
  `LeasingManagerID` int(11) DEFAULT NULL COMMENT 'Leasing Manager from Organization. Linked to Contact ID.  To get this, link to OrganizationID, and from Organization, link to Contact',
  `Signage` varchar(100) DEFAULT NULL COMMENT 'Signage to be collected',
  `Parking` varchar(100) DEFAULT NULL COMMENT 'Parking fee to be collected',
  `RentalEffectiveDate` date DEFAULT NULL COMMENT 'Effective Date of Rent. when to start collecting rent.',
  `PermittedUse` varchar(1000) DEFAULT NULL COMMENT 'Permitted Use (nature of Business)',
  `RentalRate` decimal(10,2) DEFAULT NULL COMMENT 'Gross Rental Rate per month',
  `BasicRent` decimal(10,2) DEFAULT 0.00,
  `AdditionalBasicRent` decimal(10,2) DEFAULT 0.00,
  `RentalRatePerSqm` decimal(10,2) DEFAULT NULL COMMENT 'renta per sq. meter',
  `AdditionalRentalRatePerSqm` decimal(10,2) DEFAULT 0.00,
  `BalanceAmount` decimal(10,2) DEFAULT 0.00,
  `ElectricalDeposit` decimal(10,2) DEFAULT 0.00 COMMENT 'Electrical Deposit for 3rd billing',
  `LesseeID` int(11) DEFAULT 0 COMMENT 'who is going to rent the unit.  Links to Account, and from Account, the Contact associated to the account',
  `VAT` decimal(10,2) DEFAULT 0.00,
  `CommencementDate` date DEFAULT NULL COMMENT 'when the contract is to begin',
  `TerminationDate` date DEFAULT NULL,
  `AccountID` int(11) DEFAULT NULL COMMENT 'Tenant associated to this contract.',
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index 9` (`OrganizationID`,`ContractNo`),
  KEY `FK_contract_user` (`CreatedBy`),
  KEY `FK_contract_user_2` (`LastUpdBy`),
  KEY `FK_contract_contact` (`LeasingManagerID`),
  KEY `FK_contract_contact_2` (`LesseeID`),
  KEY `FK_contract_leasequote` (`QuoteID`),
  KEY `FK_contract_account` (`AccountID`),
  CONSTRAINT `FK_contract_account` FOREIGN KEY (`AccountID`) REFERENCES `accounts` (`RowID`),
  CONSTRAINT `FK_contract_contact` FOREIGN KEY (`LeasingManagerID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_contract_contact_2` FOREIGN KEY (`LesseeID`) REFERENCES `contacts` (`RowID`),
  CONSTRAINT `FK_contract_leasequote` FOREIGN KEY (`QuoteID`) REFERENCES `quote` (`RowID`),
  CONSTRAINT `FK_contract_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_contract_user` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_contract_user_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Contract table';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
