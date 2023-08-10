/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP VIEW IF EXISTS `vw_picklistreport`;
DROP TABLE IF EXISTS `vw_picklistreport`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `vw_picklistreport` AS select coalesce(date_format(`o`.`OrderDate`,'%m/%d/%Y'),'') AS `orderdate`,coalesce(`c1`.`CodeName`,'') AS `COALESCE(c1.codename,'')`,coalesce(date_format(`o`.`TargetDate`,'%m/%d/%Y'),'') AS `COALESCE(DATE_FORMAT(o.targetdate,'%m/%d/%Y'),'')`,coalesce(date_format(`o`.`EndDate`,'%m/%d/%Y'),'') AS `COALESCE(DATE_FORMAT(o.enddate,'%m/%d/%Y'),'')`,coalesce(`b`.`SRP`,0.00) AS `COALESCE(b.srp,0.00)`,coalesce(`p`.`UnitPrice`,0.00) AS `COALESCE(p.unitprice,0.00)`,coalesce(`o`.`ReferenceNumber`,'') AS `pono`,coalesce(`br`.`BranchName`,'') AS `COALESCE(br.branchname,'')`,coalesce(`br`.`BranchCode`,'') AS `COALESCE(br.branchcode,'')`,`p`.`ProductCode` AS `productcode`,`c`.`ColorName` AS `colorname`,`pcs`.`Size` AS `size`,coalesce(`pcs`.`SeasonCode`,'') AS `COALESCE(pcs.seasoncode,'')`,coalesce((select coalesce(`plo`.`RowID`,0) from `picklistorders` `plo` where `plo`.`OrderItemID` = `bi`.`RowID` and `plo`.`Status` <> 'Inactive' and `plo`.`Status` <> 'Cancelled'),0) AS `picklistid`,coalesce((select coalesce(sum(`pli`.`QtyPicked`),0) from `picklistorderitems` `pli` where `pli`.`OrganizationID` = `bi`.`OrganizationID` and `pli`.`PickListOrderID` = `picklistid` and `pli`.`Status` <> 'Inactive' and `pli`.`Status` <> 'Cancelled'),0) AS `picklistqty`,coalesce((select coalesce(`po`.`PrintOrder`,0) from `printorder` `po` where `po`.`OrganizationID` = `bi`.`OrganizationID` and `po`.`PrintValue` = coalesce(`pcs`.`Size`,0.0)),0) AS `printorder`,coalesce(`pcs`.`SKU`,'') AS `COALESCE(pcs.sku,'')`,coalesce(`b`.`SKU`,'') AS `COALESCE(b.sku,'')`,`p`.`Image` AS `image`,coalesce(`bi`.`Tags`,'') AS `COALESCE(bi.tags,'')`,`bi`.`OrganizationID` AS `organizationid`,`bi`.`ItemType` AS `itemtype`,`bi`.`Status` AS `bistatus`,`o`.`AccountID` AS `accountid`,`pc`.`RowID` AS `pcrowid`,`bi`.`OrderID` AS `orderid`,coalesce(`ba`.`BrandName`,'') AS `COALESCE(ba.brandname,'')`,coalesce(`ca`.`CategoryName`,'') AS `COALESCE(ca.categoryname,'')` from (((((((((((`orderitems` `bi` left join `orders` `o` on(`bi`.`OrderID` = `o`.`RowID`)) left join `combinecodings` `cc` on(`o`.`CombineCodingID` = `cc`.`RowID`)) left join `codings` `c1` on(`cc`.`CodingIDA` = `c1`.`RowID`)) left join `branches` `br` on(`o`.`BranchID` = `br`.`RowID`)) left join `productbundles` `b` on(`bi`.`ProductBundleID` = `b`.`RowID`)) left join `productcolorsizes` `pcs` on(`bi`.`ProductColorSizeID` = `pcs`.`RowID`)) left join `productcolors` `pc` on(`pcs`.`ProductColorID` = `pc`.`RowID`)) left join `colors` `c` on(`pc`.`ColorID` = `c`.`RowID`)) left join `products` `p` on(`pc`.`ProductID` = `p`.`RowID`)) left join `brands` `ba` on(`b`.`BrandID` = `ba`.`RowID`)) left join `categories` `ca` on(`b`.`CategoryID` = `ca`.`RowID`)) ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
