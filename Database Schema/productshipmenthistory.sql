/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `productshipmenthistory`;
CREATE TABLE IF NOT EXISTS `productshipmenthistory` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `ProductID` int(11) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `LastUpdBy` int(11) DEFAULT NULL,
  `OrganizationID` int(11) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT current_timestamp(),
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `ShipmentCount` int(11) DEFAULT NULL,
  `ShipmentDate` date DEFAULT NULL,
  `LotNo` varchar(50) DEFAULT NULL,
  `BatchNo` varchar(50) DEFAULT NULL,
  `CartonNo` varchar(50) DEFAULT NULL,
  `InvoiceNo` int(11) DEFAULT NULL COMMENT 'InvoiceNo from OrderItem (manually entered) - this is the shipment''s/suppliers invoice #',
  PRIMARY KEY (`RowID`),
  KEY `FK_productshipmenthistory_product` (`ProductID`),
  KEY `FK_productshipmenthistory_organization` (`OrganizationID`),
  KEY `FK_productshipmenthistory_user` (`CreatedBy`),
  KEY `FK_productshipmenthistory_user_2` (`LastUpdBy`),
  CONSTRAINT `FK_productshipmenthistory_organization` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `FK_productshipmenthistory_product` FOREIGN KEY (`ProductID`) REFERENCES `products` (`RowID`),
  CONSTRAINT `FK_productshipmenthistory_user` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `FK_productshipmenthistory_user_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Contains the history of the shipments from suppliers';

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
