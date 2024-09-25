/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP VIEW IF EXISTS `vw_stocklevelreport`;
CREATE TABLE `vw_stocklevelreport` (
	`RowID` INT(11) NOT NULL,
	`productcode` VARCHAR(100) NULL COLLATE 'latin1_swedish_ci',
	`colorname` VARCHAR(50) NULL COLLATE 'latin1_swedish_ci',
	`size` DECIMAL(11,1) NOT NULL,
	`seasoncode` VARCHAR(50) NULL COLLATE 'latin1_swedish_ci',
	`unitprice` DECIMAL(10,2) NULL,
	`sku` VARCHAR(50) NULL COLLATE 'latin1_swedish_ci',
	`brandname` VARCHAR(100) NULL COLLATE 'latin1_swedish_ci',
	`totalavailableqty` DECIMAL(32,0) NULL,
	`printorder` INT(11) NULL,
	`image` LONGBLOB NULL,
	`organizationid` INT(11) NULL,
	`brandid` INT(11) NULL,
	`categoryid` INT(11) NULL
) ENGINE=MyISAM;

DROP VIEW IF EXISTS `vw_stocklevelreport`;
DROP TABLE IF EXISTS `vw_stocklevelreport`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `vw_stocklevelreport` AS SELECT pcs.RowID, COALESCE(p.ProductCode,'') `productcode`, COALESCE(c.ColorName,'') `colorname`, COALESCE(pcs.Size,0.0) `size`, COALESCE(pcs.SeasonCode,'') `seasoncode`, COALESCE(p.UnitPrice,0.00) `unitprice`, COALESCE(pcs.SKU,'') `sku`, COALESCE(b.BrandName,'') AS brandname,

(
SELECT COALESCE(SUM(pil.TotalAvailableQty),0)
FROM productinventorylocation pil
INNER JOIN rackshelfcolumn r ON r.RowID=pil.RackShelfColumnID AND r.Status='Active'
WHERE pil.OrganizationID = pcs.OrganizationID AND pil.ProductColorSizeID = pcs.RowID) AS totalavailableqty,

(
SELECT COALESCE(`printorder`.PrintOrder,0)
FROM `printorder`
WHERE `printorder`.OrganizationID = pcs.OrganizationID AND `printorder`.PrintValue = COALESCE(pcs.Size,0.0)) AS `printorder`,p.Image AS image,pcs.OrganizationID AS organizationid,p.BrandID AS brandid,p.CategoryID AS categoryid
FROM productcolorsizes pcs
LEFT JOIN productcolors pc ON pcs.ProductColorID = pc.RowID
LEFT JOIN colors c ON pc.ColorID = c.RowID
LEFT JOIN products p ON pc.ProductID = p.RowID
LEFT JOIN companies v ON p.CompanyID = v.RowID
LEFT JOIN brands b ON p.BrandID = b.RowID
WHERE pcs.`Status`='Active' ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
