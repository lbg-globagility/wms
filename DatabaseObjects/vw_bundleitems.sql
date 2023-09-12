/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP VIEW IF EXISTS `vw_bundleitems`;
DROP TABLE IF EXISTS `vw_bundleitems`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `vw_bundleitems` AS select `bi`.`RowID` AS `rowid`,coalesce(`bi`.`ProductColorSizeID`,0) AS `COALESCE(bi.productcolorsizeid,0)`,coalesce(`c`.`ColorValue`,'') AS `COALESCE(c.colorvalue,'')`,coalesce(`bi`.`QtyAvailable`,0) AS `COALESCE(bi.qtyavailable,0)`,`p`.`ProductCode` AS `productcode`,`c`.`ColorName` AS `colorname`,`pcs`.`Size` AS `size`,coalesce(`pcs`.`SeasonCode`,'') AS `COALESCE(pcs.seasoncode,'')`,coalesce(`pcs`.`SKU`,'') AS `COALESCE(pcs.sku,'')`,coalesce(`pb`.`SRP`,0.00) AS `COALESCE(pb.srp,0.00)`,(select coalesce(sum(`pil`.`TotalAvailableQty`),0) from `productinventorylocation` `pil` where `pil`.`OrganizationID` = `bi`.`OrganizationID` and `pil`.`ProductColorSizeID` = `bi`.`ProductColorSizeID`) AS `TotalAvailableQty`,(select coalesce(sum(`pil`.`TotalAllocatedQty`),0) from `productinventorylocation` `pil` where `pil`.`OrganizationID` = `bi`.`OrganizationID` and `pil`.`ProductColorSizeID` = `bi`.`ProductColorSizeID`) AS `TotalAllocatedQty`,(select coalesce(sum(`pil`.`TotalReserveQty`),0) from `productinventorylocation` `pil` where `pil`.`OrganizationID` = `bi`.`OrganizationID` and `pil`.`ProductColorSizeID` = `bi`.`ProductColorSizeID`) AS `TotalReserveQty`,coalesce(`pb`.`UnitOfMeasure`,'') AS `COALESCE(pb.unitofmeasure,'')`,`bi`.`OrganizationID` AS `organizationid`,`bi`.`ProductBundleID` AS `productbundleid`,`bi`.`Status` AS `bistatus`,`pb`.`SKU` AS `sku` from (((((`productbundleitems` `bi` left join `productcolorsizes` `pcs` on(`bi`.`ProductColorSizeID` = `pcs`.`RowID`)) left join `productcolors` `pc` on(`pcs`.`ProductColorID` = `pc`.`RowID`)) left join `colors` `c` on(`pc`.`ColorID` = `c`.`RowID`)) left join `products` `p` on(`pc`.`ProductID` = `p`.`RowID`)) left join `productbundles` `pb` on(`bi`.`ProductBundleID` = `pb`.`RowID`)) ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
