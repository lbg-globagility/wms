/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `productbundleitems`;
CREATE TABLE IF NOT EXISTS `productbundleitems` (
  `RowID` int(11) NOT NULL AUTO_INCREMENT,
  `OrganizationID` int(11) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT current_timestamp(),
  `CreatedBy` int(11) DEFAULT NULL,
  `LastUpd` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  `LastUpdBy` int(11) DEFAULT NULL,
  `ProductBundleID` int(11) NOT NULL,
  `ProductColorSizeID` int(11) NOT NULL,
  `QtyAvailable` int(10) DEFAULT 0,
  `Status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`RowID`),
  UNIQUE KEY `Index_bundleproducts` (`ProductBundleID`,`ProductColorSizeID`,`OrganizationID`),
  KEY `FK_organizationid_organization` (`OrganizationID`),
  KEY `FK_createdby_createdby` (`CreatedBy`),
  KEY `FK_lastupdby_lastupdby` (`LastUpdBy`),
  KEY `FK_productbundleid` (`ProductBundleID`),
  KEY `FK_productcolorsizeid` (`ProductColorSizeID`),
  CONSTRAINT `productlistitems_ibfk_1` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `productlistitems_ibfk_2` FOREIGN KEY (`LastUpdBy`) REFERENCES `users` (`RowID`),
  CONSTRAINT `productlistitems_ibfk_3` FOREIGN KEY (`OrganizationID`) REFERENCES `organizations` (`RowID`),
  CONSTRAINT `productlistitems_ibfk_4` FOREIGN KEY (`ProductBundleID`) REFERENCES `productbundles` (`RowID`),
  CONSTRAINT `productlistitems_ibfk_5` FOREIGN KEY (`ProductColorSizeID`) REFERENCES `productcolorsizes` (`RowID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
