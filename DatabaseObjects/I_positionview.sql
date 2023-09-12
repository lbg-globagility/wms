/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `I_positionview`;
DELIMITER //
CREATE PROCEDURE `I_positionview`(IN `I_OrganizationID` INT(11), IN `I_Created` DATETIME, IN `I_CreatedBy` INT(11), IN `I_LastUpd` DATETIME, IN `I_LastUpdBy` INT(11)
, IN `I_PositionID` INT(11), IN `I_ViewID` INT(11), IN `I_Creates` CHAR(1), IN `I_Updates` CHAR(1), IN `I_Disable` CHAR(1), IN `I_ReadOnly` CHAR(1), IN `I_Remarks` VARCHAR(100))
BEGIN 
INSERT INTO positionviews
(
	OrganizationID,
	Created,
	CreatedBy,
	LastUpd,
	LastUpdBy,
	PositionID,
	ViewID,
	Creates,
	Updates,
	Disable,
	ReadOnly,
	Remarks
)
VALUES
(
	I_OrganizationID,
	I_Created,
	I_CreatedBy,
	I_LastUpd,
	I_LastUpdBy,
	I_PositionID,
	I_ViewID,
	I_Creates,
	I_Updates,
	I_Disable,
	I_ReadOnly,
	I_Remarks
);
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
