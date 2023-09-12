/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `M_U_Orders`;
DELIMITER //
CREATE PROCEDURE `M_U_Orders`(IN `U_RowID` INT(10), IN `U_LastUpd` DATETIME, IN `U_LastUpdBy` INT(10), IN `U_AccountID` INT(10), IN `U_OrderNumber` VARCHAR(100), IN `U_OrderDate` DATE, IN `U_TargetDate` DATE, IN `U_Comments` VARCHAR(100), IN `U_TotalAmount` DECIMAL(10,2), IN `U_ReceivedBy` VARCHAR(100), IN `U_ContactID` INT(11), IN `U_TimeArrived` TIME, IN `U_ReceivedBrands` VARCHAR(50), IN `U_ContainerNo` VARCHAR(50), IN `U_SealNo` VARCHAR(50), IN `U_ArrivedIn` VARCHAR(50))
BEGIN
UPDATE orders SET
	LastUpd = U_LastUpd,
	LastUpdBy = U_LastUpdBy,
	AccountID = U_AccountID,
	OrderNumber = U_OrderNumber,
	OrderDate = U_OrderDate,
	TargetDate = U_TargetDate,
	Comments = U_Comments,
	TotalAmount = U_TotalAmount,
	ReceivedBy = U_ReceivedBy,
	ContactID = U_ContactID,
	TimeArrived = U_TimeArrived,
	ReceivedBrands = U_ReceivedBrands,
	ContainerNo = U_ContainerNo,
	SealNo = U_SealNo,
	ArrivedIn = U_ArrivedIn
WHERE RowID = U_RowID;
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
