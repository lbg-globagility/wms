/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `RESET_INVENTORY`;
DELIMITER //
CREATE PROCEDURE `RESET_INVENTORY`(
	IN `inventoryId` INT
)
BEGIN

UPDATE productinventorylocation pil
INNER JOIN rackshelfcolumn r ON r.RowID=pil.RackShelfColumnID AND r.InventoryLocationID=IFNULL(inventoryId, r.InventoryLocationID)
SET pil.TotalAvailableQty=0,
pil.TotalAllocatedQty=0,
pil.TotalReserveQty=0,
pil.TotalDamageQty=0,
pil.TotalSupplierProblemQty=0,
pil.TotalInRepairQty=0,
pil.TotalToReceiveQty=0,
pil.RunningTotalQty=0,

r.AvailableQty=0,
r.DistributedQty=0,
r.ReservedQty=0,
r.DamagedQty=0,
r.InRepairQty=0,
r.SupplierProblemQty=0,

pil.LastUpd=CURRENT_TIMESTAMP(),
pil.LastUpdBy=IFNULL(pil.LastUpdBy, pil.CreatedBy),
r.LastUpd=CURRENT_TIMESTAMP(),
r.LastUpdBy=IFNULL(r.LastUpdBy, r.CreatedBy)

WHERE pil.RowID IS NOT NULL
;

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
