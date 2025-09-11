/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `GetListToPack2`;
DELIMITER //
CREATE PROCEDURE `GetListToPack2`(
	IN `_orgId` INT,
	IN `_orderId` INT,
	IN `_packinglistId` INT,
	IN `_isView` INT
)
BEGIN


IF _isView THEN
	
	SELECT
	oi.rowid, COALESCE(oi.productcolorsizeid,0), COALESCE(oi.productbundleid,0), COALESCE(c.colorvalue,''), COALESCE(p.productcode,''), COALESCE(b.bundlename,''), COALESCE(c.colorname,''), COALESCE(pcs.size,''), COALESCE(pcs.seasoncode,''),(IFNULL(oi.qtyordered,0) - SUM(IFNULL(palco.QtyInCarton, 0))), COALESCE(pcs.sku,''), COALESCE(b.sku,''), COALESCE(oi.unitofmeasure,''), COALESCE(oi.itemtype,''), COALESCE(oi.remarks,''), COALESCE(oi.`status`,''), COALESCE(DATE_FORMAT(oi.packeddate,'%d-%b-%Y'),''), COALESCE(CONCAT(COALESCE(pa.firstname,''),' ', COALESCE(pa.middlename,''),' ', COALESCE(pa.lastname,''),' ', COALESCE(pa.suffix,''),' - ', COALESCE(pa.contactno,'')),''), COALESCE(oi.srp,''), COALESCE(oi.tags,''), COALESCE(oi.sku,''), IFNULL(oi.QtyOrdered,0) `QtyOrdered`, IFNULL(palco.QtyInCarton, 0) `QtyInCarton`, SUM(IFNULL(palco2.QtyInCarton, 0)) `QtyInCarton2`
	
	/*FROM picklist pil
	INNER JOIN picklistorders pilo ON pilo.PickListID=pil.RowID AND pilo.`Status` NOT IN ('Cancelled', 'Inactive')
	INNER JOIN picklistorderitems piloi ON piloi.PickListOrderID=pilo.RowID AND piloi.`Status` NOT IN ('Cancelled', 'Inactive')
	
	INNER JOIN orders o ON o.RowID=pilo.OrderID AND o.`Status` != 'Cancelled'
	AND o.RowID=_orderId
	#AND o.OrderNumber=2395 # 2459 2459
	
	INNER JOIN orderitems oi ON oi.RowID=pilo.OrderItemID AND oi.OrderID=o.RowID
	
	LEFT JOIN packinglist pal ON pal.OrderID=o.RowID AND pal.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglistcartons palc ON palc.PackingListID=pal.RowID AND palc.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglistcartonitems palco ON palco.OrderItemID=oi.RowID AND palco.PackingListCartonID=palc.RowID AND palco.`Status` NOT IN ('Cancelled')
	
	LEFT JOIN lineups lu1 ON lu1.PackingListID = pal.RowID AND lu1.`Status` NOT IN ('Cancelled')
	
	LEFT JOIN packinglist pal2 ON pal2.RowID = lu1.PackingListID AND pal2.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglistcartons palc2 ON pal2.RowID = palc2.PackingListID AND palc2.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglistcartonitems palco2 ON palco2.OrderItemID=oi.RowID AND palco2.PackingListCartonID = palc2.RowID AND palco2.`Status` NOT IN ('Cancelled')
	
	INNER JOIN accounts a ON a.RowID=o.AccountID
	
	LEFT JOIN productbundles b ON oi.productbundleid = b.rowid
	LEFT JOIN productcolorsizes pcs ON oi.productcolorsizeid = pcs.rowid
	LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid
	LEFT JOIN colors c ON pc.colorid = c.rowid
	LEFT JOIN products p ON pc.productid = p.rowid
	LEFT JOIN contacts pa ON oi.packedby = pa.rowid
	
	WHERE pil.`Status` NOT IN ('Cancelled', 'Inactive')
	AND IF(pal.RowID IS NULL, TRUE, IFNULL(palco.QtyInCarton, 0) > 0)
#	AND IFNULL(lu1.`Status`, '') NOT IN ('Confirmed Delivery')
	
	AND pil.OrganizationID=_orgId
	
	GROUP BY pilo.OrderItemID*/
	FROM picklist pil
	INNER JOIN picklistorders pilo ON pilo.PickListID=pil.RowID AND pilo.`Status` NOT IN ('Cancelled', 'Inactive') AND pilo.`Status`='Verified'
	INNER JOIN picklistorderitems piloi ON piloi.PickListOrderID=pilo.RowID AND piloi.`Status` NOT IN ('Cancelled', 'Inactive') AND piloi.`Status`=pilo.`Status`
	
	INNER JOIN orders o ON o.RowID=pilo.OrderID AND o.`Status` != 'Cancelled'
	AND o.RowID=_orderId
	#AND o.OrderNumber=2395 # 2459 2459
	
	INNER JOIN orderitems oi ON oi.RowID=pilo.OrderItemID AND oi.OrderID=o.RowID
	
	INNER JOIN packinglist pal ON pal.OrderID=o.RowID AND pal.`Status` NOT IN ('Cancelled') AND pal.RowID=_packinglistId
	LEFT JOIN packinglistcartons palc ON palc.PackingListID=pal.RowID AND palc.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglistcartonitems palco ON palco.OrderItemID=oi.RowID AND palco.PackingListCartonID=palc.RowID AND palco.`Status` NOT IN ('Cancelled')
	
	LEFT JOIN lineups lu1 ON lu1.PackingListID = pal.RowID AND lu1.`Status` NOT IN ('Cancelled')
	
#	LEFT JOIN packinglist pal2 ON pal2.RowID = lu1.PackingListID AND pal2.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglist pal2 ON pal2.RowID != pal.RowID AND pal2.OrderID = pal.OrderID AND pal2.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglistcartons palc2 ON pal2.RowID = palc2.PackingListID AND palc2.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglistcartonitems palco2 ON palco2.OrderItemID=oi.RowID AND palco2.PackingListCartonID = palc2.RowID AND palco2.`Status` NOT IN ('Cancelled')
	
	INNER JOIN accounts a ON a.RowID=o.AccountID
	
	LEFT JOIN productbundles b ON oi.productbundleid = b.rowid
	LEFT JOIN productcolorsizes pcs ON oi.productcolorsizeid = pcs.rowid
	LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid
	LEFT JOIN colors c ON pc.colorid = c.rowid
	LEFT JOIN products p ON pc.productid = p.rowid
	LEFT JOIN contacts pa ON oi.packedby = pa.rowid
	
	WHERE pil.`Status` NOT IN ('Cancelled', 'Inactive')
	AND IF(pal.RowID IS NULL, TRUE, IFNULL(palco.QtyInCarton, 0) > 0)
#	AND IFNULL(lu1.`Status`, '') NOT IN ('Confirmed Delivery')
	
	AND pil.OrganizationID=_orgId
	
	GROUP BY pilo.OrderItemID
#	HAVING IF(FIND_IN_SET(0, GROUP_CONCAT(IFNULL(lu1.RowID, 0))) > 0, SUM(IFNULL(palco.QtyInCarton, 0)) < MIN(piloi.QtyPicked), SUM(IFNULL(palco.QtyInCarton, 0) + IFNULL(palco2.QtyInCarton, 0)) < MIN(piloi.QtyPicked))
	;

ELSE
	
	SELECT
	oi.rowid, COALESCE(oi.productcolorsizeid,0), COALESCE(oi.productbundleid,0), COALESCE(c.colorvalue,''), COALESCE(p.productcode,''), COALESCE(b.bundlename,''), COALESCE(c.colorname,''), COALESCE(pcs.size,''), COALESCE(pcs.seasoncode,''),(IFNULL(oi.qtyordered,0) - SUM(IFNULL(palco.QtyInCarton, 0))), COALESCE(pcs.sku,''), COALESCE(b.sku,''), COALESCE(oi.unitofmeasure,''), COALESCE(oi.itemtype,''), COALESCE(oi.remarks,''), COALESCE(oi.`status`,''), COALESCE(DATE_FORMAT(oi.packeddate,'%d-%b-%Y'),''), COALESCE(CONCAT(COALESCE(pa.firstname,''),' ', COALESCE(pa.middlename,''),' ', COALESCE(pa.lastname,''),' ', COALESCE(pa.suffix,''),' - ', COALESCE(pa.contactno,'')),''), COALESCE(oi.srp,''), COALESCE(oi.tags,''), COALESCE(oi.sku,''), IFNULL(oi.QtyOrdered,0) `QtyOrdered`, 0 `QtyInCarton`, SUM(IFNULL(palco.QtyInCarton, 0)) `QtyInCarton2`
	
	, pil.RowID `PickListId`
	, pil.PickListNo
	, pilo.`Status`
	, piloi.`Status`
	
	FROM picklist pil
	INNER JOIN picklistorders pilo ON pilo.PickListID=pil.RowID AND pilo.`Status` NOT IN ('Cancelled', 'Inactive') AND pilo.`Status`='Verified'
	INNER JOIN picklistorderitems piloi ON piloi.PickListOrderID=pilo.RowID AND piloi.`Status` NOT IN ('Cancelled', 'Inactive') AND piloi.`Status`=pilo.`Status`
	
	INNER JOIN orders o ON o.RowID=pilo.OrderID AND o.`Status` != 'Cancelled'
	AND o.RowID=_orderId
	#AND o.OrderNumber=2395 # 2459 2459
	
	INNER JOIN orderitems oi ON oi.RowID=pilo.OrderItemID AND oi.OrderID=o.RowID
	
	LEFT JOIN packinglist pal ON pal.OrderID=o.RowID AND pal.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglistcartons palc ON palc.PackingListID=pal.RowID AND palc.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglistcartonitems palco ON palco.OrderItemID=oi.RowID AND palco.PackingListCartonID=palc.RowID AND palco.`Status` NOT IN ('Cancelled')
	
	LEFT JOIN lineups lu1 ON lu1.PackingListID = pal.RowID AND lu1.`Status` NOT IN ('Cancelled')
	
	LEFT JOIN packinglist pal2 ON pal2.RowID = lu1.PackingListID AND pal2.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglistcartons palc2 ON pal2.RowID = palc2.PackingListID AND palc2.`Status` NOT IN ('Cancelled')
	LEFT JOIN packinglistcartonitems palco2 ON palco2.OrderItemID=oi.RowID AND palco2.PackingListCartonID = palc2.RowID AND palco2.`Status` NOT IN ('Cancelled')
	
	INNER JOIN accounts a ON a.RowID=o.AccountID
	
	LEFT JOIN productbundles b ON oi.productbundleid = b.rowid
	LEFT JOIN productcolorsizes pcs ON oi.productcolorsizeid = pcs.rowid
	LEFT JOIN productcolors pc ON pcs.productcolorid = pc.rowid
	LEFT JOIN colors c ON pc.colorid = c.rowid
	LEFT JOIN products p ON pc.productid = p.rowid
	LEFT JOIN contacts pa ON oi.packedby = pa.rowid
	
	WHERE pil.`Status` NOT IN ('Cancelled', 'Inactive')
	AND IF(pal.RowID IS NULL, TRUE, IFNULL(palco.QtyInCarton, 0) > 0)
	AND IFNULL(lu1.`Status`, '') NOT IN ('Confirmed Delivery')
	
	AND pil.OrganizationID=_orgId
	
	GROUP BY pilo.OrderItemID
	HAVING IF(FIND_IN_SET(0, GROUP_CONCAT(IFNULL(lu1.RowID, 0))) > 0, SUM(IFNULL(palco.QtyInCarton, 0)) < MIN(piloi.QtyPicked), SUM(IFNULL(palco.QtyInCarton, 0) + IFNULL(palco2.QtyInCarton, 0)) < MIN(piloi.QtyPicked))
	
	/*#WHERE ((i.QtyInCarton + IFNULL(ii.QtyInCarton, 0)) MOD i.QtyPicked) != 0 AND (i.QtyInCarton MOD i.QtyPicked) BETWEEN 1 AND i.QtyPicked
	GROUP BY i.OrderItemID
	HAVING SUM(i.QtyInCarton + IFNULL(ii.QtyInCarton, 0)) < MIN(i.QtyPicked)*/
	;

END IF;

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
