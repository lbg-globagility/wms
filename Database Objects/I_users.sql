/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `I_users`;
DELIMITER //
CREATE PROCEDURE `I_users`(IN `I_OrganizationID` INT(11), IN `I_Created` DATETIME, IN `I_CreatedBy` INT(11), IN `I_LastUpd` DATETIME, IN `I_LastUpdBy` INT(11), IN `I_UserID` VARCHAR(50), IN `I_Password` VARCHAR(50), IN `I_PositionID` INT(11), IN `I_FirstName` VARCHAR(50), IN `I_MiddleName` VARCHAR(50), IN `I_LastName` VARCHAR(50), IN `I_EmailAddress` VARCHAR(50), IN `I_Status` VARCHAR(50), IN `I_Comments` VARCHAR(500))
BEGIN
INSERT INTO users
(
	OrganizationID,
	Created,
	CreatedBy,
	LastUpd,
	LastUpdBy,
	UserID,
	`Password`,
	PositionID,
	FirstName,
	MiddleName,
	LastName,
	EmailAddress,
	`Status`,
	Comments
)
VALUES
(
	I_OrganizationID,
	I_Created,
	I_CreatedBy,
	I_LastUpd,
	I_LastUpdBy,
	I_UserID,
	I_Password,
	I_PositionID,
	I_FirstName,
	I_MiddleName,
	I_LastName,
	I_EmailAddress,
	I_Status,
	I_Comments
);
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
