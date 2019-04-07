-- MySQL dump 10.17  Distrib 10.3.13-MariaDB, for Linux (x86_64)
--
-- Host: localhost    Database: SICKROOM
-- ------------------------------------------------------
-- Server version	10.3.13-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `administrator`
--

DROP TABLE IF EXISTS `administrator`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `administrator` (
  `administratorNO` int(8) NOT NULL AUTO_INCREMENT,
  `password` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `administratorName` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`administratorNO`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administrator`
--

LOCK TABLES `administrator` WRITE;
/*!40000 ALTER TABLE `administrator` DISABLE KEYS */;
INSERT INTO `administrator` VALUES (1,'password','管理员');
/*!40000 ALTER TABLE `administrator` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `department` (
  `departmentName` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `departmentAddress` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `telephoneNO` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`departmentName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES ('中医科','中医科楼','000-0000008'),('五官科','五官科楼','000-0000005'),('传染科','传染科楼','000-00000009'),('儿科','儿科楼','000-0000004'),('内科','内科楼','000-0000000'),('医学影像科','医学影像科楼','000-00000010'),('外科','外科楼','000-0000001'),('妇产科','妇产科楼','000-0000002'),('男科','男科楼','000-0000003'),('皮肤性病科','皮肤性病科楼','000-0000007'),('肿瘤科','肿瘤科楼','000-0000006');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doctor`
--

DROP TABLE IF EXISTS `doctor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `doctor` (
  `doctorID` int(8) NOT NULL AUTO_INCREMENT,
  `password` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `doctorName` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `age` tinyint(4) DEFAULT NULL,
  `jobTitle` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `departmentName` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`doctorID`),
  KEY `departmentName` (`departmentName`),
  CONSTRAINT `doctor_ibfk_1` FOREIGN KEY (`departmentName`) REFERENCES `department` (`departmentName`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctor`
--

LOCK TABLES `doctor` WRITE;
/*!40000 ALTER TABLE `doctor` DISABLE KEYS */;
INSERT INTO `doctor` VALUES (1,'password','武大',30,'医士','内科'),(2,'password','武二',31,'住院医师','外科'),(3,'password','张三',32,'主治医师','妇产科'),(4,'password','李四',33,'副主任医师','男科'),(5,'password','王五',34,'主任医师','儿科'),(6,'password','马六',35,'医士','五官科'),(7,'password','陈七',36,'住院医师','肿瘤科'),(8,'password','王八',37,'主任医师','皮肤性病科'),(9,'password','江九',38,'副主任医师','中医科'),(10,'password','胡十',39,'主任医师','传染科'),(11,'password','习十一',40,'主任医师','医学影像科');
/*!40000 ALTER TABLE `doctor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patient`
--

DROP TABLE IF EXISTS `patient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `patient` (
  `medicalRecordNO` int(8) NOT NULL AUTO_INCREMENT,
  `password` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `patientName` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `gender` varchar(10) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `doctorID` int(8) DEFAULT NULL,
  `sickroomID` int(8) DEFAULT NULL,
  PRIMARY KEY (`medicalRecordNO`),
  KEY `doctorID` (`doctorID`),
  KEY `sickroomID` (`sickroomID`),
  CONSTRAINT `patient_ibfk_1` FOREIGN KEY (`doctorID`) REFERENCES `doctor` (`doctorID`),
  CONSTRAINT `patient_ibfk_2` FOREIGN KEY (`sickroomID`) REFERENCES `sickroom` (`sickroomID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patient`
--

LOCK TABLES `patient` WRITE;
/*!40000 ALTER TABLE `patient` DISABLE KEYS */;
INSERT INTO `patient` VALUES (1,'password','武病大','男',1,1),(2,'password','武病二','男',2,2),(3,'password','张病人','男',3,3),(4,'password','李病人','男',4,4),(5,'password','王病人','男',5,5),(6,'password','马病人','男',6,6),(7,'password','王病二','男',7,7),(8,'password','江病人','男',8,8),(9,'password','胡病人','男',9,9),(10,'password','习病人','男',10,10);
/*!40000 ALTER TABLE `patient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sickroom`
--

DROP TABLE IF EXISTS `sickroom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sickroom` (
  `sickroomID` int(8) NOT NULL AUTO_INCREMENT,
  `bedNO` int(8) DEFAULT NULL,
  `departmentName` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`sickroomID`),
  KEY `departmentName` (`departmentName`),
  CONSTRAINT `sickroom_ibfk_1` FOREIGN KEY (`departmentName`) REFERENCES `department` (`departmentName`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sickroom`
--

LOCK TABLES `sickroom` WRITE;
/*!40000 ALTER TABLE `sickroom` DISABLE KEYS */;
INSERT INTO `sickroom` VALUES (1,1,'内科'),(2,2,'外科'),(3,3,'妇产科'),(4,4,'男科'),(5,5,'儿科'),(6,6,'五官科'),(7,7,'肿瘤科'),(8,8,'皮肤性病科'),(9,9,'中医科'),(10,10,'传染科'),(11,11,'医学影像科');
/*!40000 ALTER TABLE `sickroom` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-04-07 10:45:35
