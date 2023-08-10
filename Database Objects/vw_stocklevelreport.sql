/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP VIEW IF EXISTS `vw_stocklevelreport`;
DROP TABLE IF EXISTS `vw_stocklevelreport`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `vw_stocklevelreport` AS select `pcs`.`RowID` AS `rowid`,coalesce(`p`.`ProductCode`,'') AS `productcode`,coalesce(`c`.`ColorName`,'') AS `colorname`,coalesce(`pcs`.`Size`,0.0) AS `COALESCE(pcs.size,0.0)`,coalesce(`pcs`.`SeasonCode`,'') AS `COALESCE(pcs.seasoncode,'')`,coalesce(`p`.`UnitPrice`,0.00) AS `COALESCE(p.unitprice,0.00)`,coalesce(`pcs`.`SKU`,'') AS `COALESCE(pcs.sku,'')`,coalesce(`b`.`BrandName`,'') AS `brandname`,(select coalesce(sum(`pil`.`TotalAvailableQty`),0) from `productinventorylocation` `pil` where `pil`.`OrganizationID` = `pcs`.`OrganizationID` and `pil`.`ProductColorSizeID` = `pcs`.`RowID`) AS `totalavailableqty`,(select coalesce(`printorder`.`PrintOrder`,0) from `printorder` where `printorder`.`OrganizationID` = `pcs`.`OrganizationID` and `printorder`.`PrintValue` = coalesce(`pcs`.`Size`,0.0)) AS `printorder`,`p`.`Image` AS `image`,`pcs`.`OrganizationID` AS `organizationid`,`p`.`BrandID` AS `brandid`,`p`.`CategoryID` AS `categoryid` from (((((`productcolorsizes` `pcs` left join `productcolors` `pc` on(`pcs`.`ProductColorID` = `pc`.`RowID`)) left join `colors` `c` on(`pc`.`ColorID` = `c`.`RowID`)) left join `products` `p` on(`pc`.`ProductID` = `p`.`RowID`)) left join `companies` `v` on(`p`.`CompanyID` = `v`.`RowID`)) left join `brands` `b` on(`p`.`BrandID` = `b`.`RowID`)) ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
