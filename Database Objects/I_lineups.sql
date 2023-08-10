/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP FUNCTION IF EXISTS `I_lineups`;
DELIMITER //
CREATE FUNCTION `I_lineups`(`I_OrganizationID` INT(11), `I_Created` DATETIME, `I_CreatedBy` INT(11), `I_LastUpdBy` INT(11), `I_ContactID` INT(11), `I_PackingListID` INT(11), `I_DeliveryTruckShiftID` INT(11), `I_OrderID` INT(11), `I_LineUpDate` DATE, `I_DeliveryHours` VARCHAR(100), `I_LineUpNo` VARCHAR(50), `I_DeliveryNo` VARCHAR(50), `I_Status` VARCHAR(50), `I_Comments` VARCHAR(100), `I_DeliveryAddress` VARCHAR(250)) RETURNS int(10)
BEGIN

DECLARE newLineUpID INT(11);

INSERT INTO lineups
(
	OrganizationID,
	Created,
	CreatedBy,
	LastUpdBy,
	ContactID,
	PackingListID,
	DeliveryTruckShiftID,
	OrderID,
	LineUpDate,
	DeliveryHours,
	LineUpNo,
	DeliveryNo,
	`Status`,
	Comments,
	DeliveryAddress
)
VALUES
(
	I_OrganizationID,
	I_Created,
	I_CreatedBy,
	I_LastUpdBy,
	I_ContactID,
	I_PackingListID,
	I_DeliveryTruckShiftID,
	I_OrderID,
	I_LineUpDate,
	I_DeliveryHours,
	I_LineUpNo,
	I_DeliveryNo,
	I_Status,
	I_Comments,
	I_DeliveryAddress
);

SELECT @@Identity AS ID INTO newLineUpID;
RETURN newLineUpID;

END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
