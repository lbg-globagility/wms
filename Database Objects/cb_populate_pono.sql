/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP PROCEDURE IF EXISTS `cb_populate_pono`;
DELIMITER //
CREATE PROCEDURE `cb_populate_pono`(IN `P_OrganizationID` INT(10), IN `P_Type` VARCHAR(50))
BEGIN
IF P_Type = 'PO' THEN

SELECT o.ordernumber
FROM orders o
WHERE
o.ordertype = 'PO' AND o.organizationid = P_OrganizationID AND o.`status` = 'New'
ORDER BY o.ordernumber;

ELSEIF P_Type = 'Pull-Out' THEN
	
SELECT o.ordernumber
FROM orders o
WHERE
o.ordertype = 'Pull-Out' AND o.organizationid = P_OrganizationID AND o.`status` = 'New'
ORDER BY o.ordernumber;

ELSEIF P_Type = 'Return' THEN

SELECT o.ordernumber
FROM orders o
WHERE
o.ordertype = 'Return' AND o.organizationid = P_OrganizationID AND o.`status` = 'New'
ORDER BY o.ordernumber;

END IF;
END//
DELIMITER ;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
