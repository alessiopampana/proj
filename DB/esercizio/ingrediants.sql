-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versione server:              5.7.20-log - MySQL Community Server (GPL)
-- S.O. server:                  Win64
-- HeidiSQL Versione:            11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dump della struttura di tabella esercizio.ingrediants
DROP TABLE IF EXISTS `ingrediants`;
CREATE TABLE IF NOT EXISTS `ingrediants` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `SweetID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Amount` double DEFAULT NULL,
  `UnitOfMeasure` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE,
  UNIQUE KEY `SweetID_Name` (`SweetID`,`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- Dump dei dati della tabella esercizio.ingrediants: ~2 rows (circa)
DELETE FROM `ingrediants`;
/*!40000 ALTER TABLE `ingrediants` DISABLE KEYS */;
/*!40000 ALTER TABLE `ingrediants` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
