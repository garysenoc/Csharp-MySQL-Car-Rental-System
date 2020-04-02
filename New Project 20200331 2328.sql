-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.5.16


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema dbrentalcar
--

CREATE DATABASE IF NOT EXISTS dbrentalcar;
USE dbrentalcar;

--
-- Definition of table `tbadmin`
--

DROP TABLE IF EXISTS `tbadmin`;
CREATE TABLE `tbadmin` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(200) NOT NULL,
  `password` varchar(200) NOT NULL,
  `secquestion` varchar(200) NOT NULL,
  `secanswer` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbadmin`
--

/*!40000 ALTER TABLE `tbadmin` DISABLE KEYS */;
INSERT INTO `tbadmin` (`id`,`username`,`password`,`secquestion`,`secanswer`) VALUES 
 (1,'admin','admin','who me','sdf');
/*!40000 ALTER TABLE `tbadmin` ENABLE KEYS */;


--
-- Definition of table `tbcar`
--

DROP TABLE IF EXISTS `tbcar`;
CREATE TABLE `tbcar` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `model` varchar(500) NOT NULL,
  `brand` varchar(500) NOT NULL,
  `plate` varchar(500) NOT NULL,
  `price` varchar(500) NOT NULL,
  `cartype` varchar(500) NOT NULL,
  `pic` varchar(500) NOT NULL,
  `availability` varchar(500) NOT NULL,
  `engine` varchar(45) NOT NULL,
  `chase` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbcar`
--

/*!40000 ALTER TABLE `tbcar` DISABLE KEYS */;
INSERT INTO `tbcar` (`id`,`model`,`brand`,`plate`,`price`,`cartype`,`pic`,`availability`,`engine`,`chase`) VALUES 
 (1,'Rush','Toyota','PLX 123','1500','Automatic','C:\\Users\\Gary Lloyd Senoc\\Documents\\received_1841114849315327.jpeg','Available','123','abc'),
 (4,'Civic','Honda','QWR 290','2000','Automatic','C:\\Users\\Gary Lloyd Senoc\\Documents\\FB_IMG_15329381516070314.jpg','Available','12345','090876');
/*!40000 ALTER TABLE `tbcar` ENABLE KEYS */;


--
-- Definition of table `tbcustomer`
--

DROP TABLE IF EXISTS `tbcustomer`;
CREATE TABLE `tbcustomer` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(400) NOT NULL,
  `age` varchar(400) NOT NULL,
  `marital` varchar(400) NOT NULL,
  `nationality` varchar(400) NOT NULL,
  `home` varchar(400) NOT NULL,
  `contact` varchar(400) NOT NULL,
  `email` varchar(400) NOT NULL,
  `pic` varchar(400) NOT NULL,
  `model` varchar(400) NOT NULL,
  `brand` varchar(400) NOT NULL,
  `type` varchar(400) NOT NULL,
  `plate` varchar(400) NOT NULL,
  `price` varchar(400) NOT NULL,
  `overallprice` varchar(400) NOT NULL,
  `daytorent` varchar(400) NOT NULL,
  `returndate` varchar(400) NOT NULL,
  `returnstatus` varchar(400) NOT NULL,
  `rentday` varchar(400) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbcustomer`
--

/*!40000 ALTER TABLE `tbcustomer` DISABLE KEYS */;
INSERT INTO `tbcustomer` (`id`,`name`,`age`,`marital`,`nationality`,`home`,`contact`,`email`,`pic`,`model`,`brand`,`type`,`plate`,`price`,`overallprice`,`daytorent`,`returndate`,`returnstatus`,`rentday`) VALUES 
 (9,'asdfsd','fsd','safasd','sadf','asdf','asdf','asdf','','Rush','Toyota','Automatic','PLX 123','1500','4500','3','2019-04-08 15-22-47','Return',''),
 (11,'gary','12','d','dsf','asdfasd','sadf','asdf','','Rush','Toyota','Automatic','PLX 123','1500','1500','1','2019-04-06 15-34-13','Return',''),
 (13,'fsadf','asdf','dfa','asdf','asdf','asdf','asdf','','gary1','adasd','Automatic','PLX 1234','1200','1200','1','2019-04-06 15-36-25','Return',''),
 (15,'sdf','asdf','ssd','asdf','asdf','asdf','asdf','','gary1','adasd','Automatic','PLX 1234','1200','2400','2','2019-04-07 15-49-11','Return',''),
 (16,'sfsd','sdf','sdfgs','sfdg','sdfg','sfdg','sdfg','','Rush','Toyota','Automatic','PLX 123','1500','1500','1','2019-04-06 15-50-26','Return',''),
 (17,'Kaycee','12','Single','Filipino','Palawan','09293634848','gsasd@gmail.com','','gary1','adasd','Automatic','PLX 1234','1200','3600','3','2019-04-08 16-34-18','Return',''),
 (18,'rayg','19','Complicated','adf','asdf','09503587264','gsfgadgasf','','Rush','Toyota','Automatic','PLX 123','1500','1500','1','2019-04-06 16-46-25','Return','');
INSERT INTO `tbcustomer` (`id`,`name`,`age`,`marital`,`nationality`,`home`,`contact`,`email`,`pic`,`model`,`brand`,`type`,`plate`,`price`,`overallprice`,`daytorent`,`returndate`,`returnstatus`,`rentday`) VALUES 
 (19,'BAterna','12','Single','Filipino','Palawan','09503587264','gsenoc@gmail.com','C:\\Users\\Gary Lloyd Senoc\\Documents\\20181015_161025.jpg','Rush','Toyota','Automatic','PLX 123','1500','3000','2','2019-04-08 00-46-00','Return','now()'),
 (20,'BAterna','12','Single','Filipino','Palawan','09503587264','gsenoc@gmail.com','','Civic','Honda','Automatic','QWR 290','2000','38000','19','2019-04-25 00-56-49','Return','now()'),
 (21,'BAterna','12','Single','Filipino','Palawan','09503587264','gsenoc@gmail.com','','Rush','Toyota','Automatic','PLX 123','1500','3000','2','2019-04-08 01-04-15','Return','now()'),
 (22,'BAterna','12','Single','Filipino','Palawan','09503587264','gsenoc@gmail.com','','Civic','Honda','Automatic','QWR 290','2000','4000','2','2019-04-08 01-25-01','Return','now()'),
 (23,'fsadf','asdf','dfa','asdf','asdf','asdf','asdf','','Rush','Toyota','Automatic','PLX 123','1500','3000','2','2019-04-08 01-25-57','Return','now()');
/*!40000 ALTER TABLE `tbcustomer` ENABLE KEYS */;


--
-- Definition of table `tblog`
--

DROP TABLE IF EXISTS `tblog`;
CREATE TABLE `tblog` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user` varchar(200) NOT NULL,
  `activity` varchar(200) NOT NULL,
  `date` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblog`
--

/*!40000 ALTER TABLE `tblog` DISABLE KEYS */;
INSERT INTO `tblog` (`id`,`user`,`activity`,`date`) VALUES 
 (1,'ADMIN','Login','Friday, 05 April 2019 14:17:15'),
 (2,'asdf','',''),
 (3,'ADMIN','Login','Friday, 05 April 2019 14:55:41'),
 (4,'ADMIN','Login','Friday, 05 April 2019 18:02:54'),
 (5,'ADMIN','Login','Friday, 05 April 2019 18:37:30'),
 (6,'','Return Car','Friday, 05 April 2019 20:24:34'),
 (7,'','Delete Transaction','Friday, 05 April 2019 20:27:41'),
 (8,'','Delete Transaction','Friday, 05 April 2019 20:27:46'),
 (9,'','Delete Transaction','Friday, 05 April 2019 20:27:49'),
 (10,'Admin','Reset Password','Friday, 05 April 2019 21:04:10'),
 (11,'Admin','Login - Admin','Friday, 05 April 2019 21:05:36'),
 (12,'User','Login - User','Friday, 05 April 2019 21:05:57'),
 (13,'Admin','Login - Admin','Saturday, 06 April 2019 00:34:26'),
 (14,'Admin','Login - Admin','Saturday, 06 April 2019 00:37:13'),
 (15,'Admin','Login - Admin','Saturday, 06 April 2019 00:38:18'),
 (16,'Admin','Login - Admin','Saturday, 06 April 2019 00:39:48'),
 (17,'Admin','Login - Admin','Saturday, 06 April 2019 00:41:11'),
 (18,'Admin','Rent Car','Saturday, 06 April 2019 00:46:02');
INSERT INTO `tblog` (`id`,`user`,`activity`,`date`) VALUES 
 (19,'Admin','Return Car','Saturday, 06 April 2019 00:46:58'),
 (20,'Admin','Add Car','Saturday, 06 April 2019 00:48:14'),
 (21,'Admin','Update Car Info','Saturday, 06 April 2019 00:48:39'),
 (22,'Admin','Update Car Info','Saturday, 06 April 2019 00:49:02'),
 (23,'Admin','Delete Car record','Saturday, 06 April 2019 00:49:12'),
 (24,'Admin','Login - Admin','Saturday, 06 April 2019 00:50:48'),
 (25,'Admin','Update Customer Profile','Saturday, 06 April 2019 00:51:26'),
 (26,'Admin','Update Customer Profile','Saturday, 06 April 2019 00:51:34'),
 (27,'Admin','Delete record','Saturday, 06 April 2019 00:51:46'),
 (28,'Admin','Login - Admin','Saturday, 06 April 2019 00:53:37'),
 (29,'Admin','Rent Car','Saturday, 06 April 2019 00:56:51'),
 (30,'Admin','Login - Admin','Saturday, 06 April 2019 00:57:41'),
 (31,'Admin','Login - Admin','Saturday, 06 April 2019 01:01:40'),
 (32,'Admin','Delete record','Saturday, 06 April 2019 01:02:09'),
 (33,'Admin','Login - Admin','Saturday, 06 April 2019 01:02:44'),
 (34,'Admin','Return Car','Saturday, 06 April 2019 01:03:05');
INSERT INTO `tblog` (`id`,`user`,`activity`,`date`) VALUES 
 (35,'Admin','Login - Admin','Saturday, 06 April 2019 01:04:01'),
 (36,'Admin','Rent Car','Saturday, 06 April 2019 01:04:16'),
 (37,'Admin','Login - Admin','Saturday, 06 April 2019 01:06:13'),
 (38,'Admin','Delete record','Saturday, 06 April 2019 01:06:28'),
 (39,'Admin','Return Car','Saturday, 06 April 2019 01:06:38'),
 (40,'Admin','Rent Car','Saturday, 06 April 2019 01:07:00'),
 (41,'Admin','Return Car','Saturday, 06 April 2019 01:07:51'),
 (42,'Admin','Rent Car','Saturday, 06 April 2019 01:08:00'),
 (43,'Admin','Login - Admin','Saturday, 06 April 2019 01:08:35'),
 (44,'Admin','Login - Admin','Saturday, 06 April 2019 01:11:46'),
 (45,'Admin','Login - Admin','Saturday, 06 April 2019 01:12:58'),
 (46,'Admin','Login - Admin','Saturday, 06 April 2019 01:16:06'),
 (47,'Admin','Rent Car','Saturday, 06 April 2019 01:16:24'),
 (48,'Admin','Login - Admin','Saturday, 06 April 2019 01:19:00'),
 (49,'Admin','Login - Admin','Saturday, 06 April 2019 01:19:49'),
 (50,'Admin','Login - Admin','Saturday, 06 April 2019 01:21:49');
INSERT INTO `tblog` (`id`,`user`,`activity`,`date`) VALUES 
 (51,'Admin','Rent Car','Saturday, 06 April 2019 01:22:06'),
 (52,'Admin','Login - Admin','Saturday, 06 April 2019 01:24:07'),
 (53,'Admin','Login - Admin','Saturday, 06 April 2019 01:24:45'),
 (54,'Admin','Rent Car','Saturday, 06 April 2019 01:25:02'),
 (55,'Admin','Return Car','Saturday, 06 April 2019 01:25:20'),
 (56,'Admin','Rent Car','Saturday, 06 April 2019 01:25:58'),
 (57,'Admin','Login - Admin','Saturday, 06 April 2019 01:26:05'),
 (58,'Admin','Change Admin Username','Saturday, 06 April 2019 01:29:01'),
 (59,'Admin','Login - Admin','Saturday, 06 April 2019 01:29:32'),
 (60,'Admin','Login - Admin','Saturday, 06 April 2019 04:23:50'),
 (61,'Admin','Return Car','Saturday, 06 April 2019 04:37:55'),
 (62,'Admin','Delete All Transaction','Saturday, 06 April 2019 04:38:13'),
 (63,'Admin','Update Customer Profile','Saturday, 06 April 2019 23:05:28'),
 (64,'Admin','Login - Admin','Tuesday, 31 March 2020 23:23:45'),
 (65,'Admin','Login - Admin','Tuesday, 31 March 2020 23:26:14');
/*!40000 ALTER TABLE `tblog` ENABLE KEYS */;


--
-- Definition of table `tbtransaction`
--

DROP TABLE IF EXISTS `tbtransaction`;
CREATE TABLE `tbtransaction` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  `activity` varchar(200) NOT NULL,
  `brand` varchar(200) NOT NULL,
  `model` varchar(200) NOT NULL,
  `daytorent` varchar(200) NOT NULL,
  `pay` varchar(200) NOT NULL,
  `date` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbtransaction`
--

/*!40000 ALTER TABLE `tbtransaction` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbtransaction` ENABLE KEYS */;


--
-- Definition of table `tbuser`
--

DROP TABLE IF EXISTS `tbuser`;
CREATE TABLE `tbuser` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `secquestion` varchar(45) NOT NULL,
  `secanswer` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbuser`
--

/*!40000 ALTER TABLE `tbuser` DISABLE KEYS */;
INSERT INTO `tbuser` (`id`,`username`,`password`,`secquestion`,`secanswer`) VALUES 
 (1,'user','admin','who is me','gary');
/*!40000 ALTER TABLE `tbuser` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
