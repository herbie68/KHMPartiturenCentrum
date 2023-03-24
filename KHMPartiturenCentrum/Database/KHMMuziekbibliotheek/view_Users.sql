/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP TABLE IF EXISTS `view_Users`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `view_Users` AS select `u`.`Id` AS `Id`,`u`.`EMail` AS `EMail`,`u`.`UserName` AS `UserName`,`u`.`Password` AS `Password`,`u`.`RoleId` AS `RoleId`,`u`.`Fullname` AS `FullName`,`r`.`RoleOrder` AS `RoleOrder`,`r`.`RoleName` AS `RoleName`,`r`.`Description` AS `RoleDescription`,`u`.`CoverSheetFolder` AS `CoverSheetFolder` from (`Users` `u` join `UserRoles` `r` on(`u`.`RoleId` = `r`.`Id`));

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
