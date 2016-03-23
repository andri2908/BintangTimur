CREATE DATABASE  IF NOT EXISTS `sys_pos_bintangtimur` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `sys_pos_bintangtimur`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: sys_pos_bintangtimur
-- ------------------------------------------------------
-- Server version	5.5.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `account_credit`
--

DROP TABLE IF EXISTS `account_credit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account_credit` (
  `credit_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `credit_sales_id` int(10) unsigned NOT NULL,
  `credit_duedate` date NOT NULL,
  `credit_nominal` double NOT NULL,
  `credit_paid` tinyint(4) unsigned DEFAULT NULL,
  PRIMARY KEY (`credit_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account_credit`
--

LOCK TABLES `account_credit` WRITE;
/*!40000 ALTER TABLE `account_credit` DISABLE KEYS */;
/*!40000 ALTER TABLE `account_credit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `account_debt`
--

DROP TABLE IF EXISTS `account_debt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account_debt` (
  `debt_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `debt_purchase_id` int(10) unsigned NOT NULL,
  `debt_duedate` date NOT NULL,
  `debt_nominal` double NOT NULL,
  `debt_paid` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`debt_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account_debt`
--

LOCK TABLES `account_debt` WRITE;
/*!40000 ALTER TABLE `account_debt` DISABLE KEYS */;
/*!40000 ALTER TABLE `account_debt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `account_journal`
--

DROP TABLE IF EXISTS `account_journal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account_journal` (
  `journal_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `account_id` smallint(5) unsigned NOT NULL,
  `journal_date` date NOT NULL,
  `account_nominal` double NOT NULL,
  `branch_id` tinyint(3) unsigned NOT NULL,
  `journal_description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`journal_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account_journal`
--

LOCK TABLES `account_journal` WRITE;
/*!40000 ALTER TABLE `account_journal` DISABLE KEYS */;
/*!40000 ALTER TABLE `account_journal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `credit`
--

DROP TABLE IF EXISTS `credit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `credit` (
  `CREDIT_ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SALES_INVOICE` varchar(30) DEFAULT NULL,
  `PM_INVOICE` varchar(30) DEFAULT NULL,
  `CREDIT_DUE_DATE` date DEFAULT NULL,
  `CREDIT_NOMINAL` double DEFAULT '0',
  `CREDIT_PAID` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`CREDIT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `credit`
--

LOCK TABLES `credit` WRITE;
/*!40000 ALTER TABLE `credit` DISABLE KEYS */;
/*!40000 ALTER TABLE `credit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `daily_journal`
--

DROP TABLE IF EXISTS `daily_journal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `daily_journal` (
  `journal_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `account_id` smallint(5) unsigned NOT NULL,
  `journal_datetime` date NOT NULL,
  `journal_nominal` double NOT NULL,
  `branch_id` tinyint(3) unsigned DEFAULT NULL,
  `journal_description` varchar(100) DEFAULT NULL,
  `user_id` tinyint(3) unsigned NOT NULL,
  `pm_id` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`journal_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `daily_journal`
--

LOCK TABLES `daily_journal` WRITE;
/*!40000 ALTER TABLE `daily_journal` DISABLE KEYS */;
/*!40000 ALTER TABLE `daily_journal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `debt`
--

DROP TABLE IF EXISTS `debt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `debt` (
  `DEBT_ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PURCHASE_INVOICE` varchar(30) DEFAULT NULL,
  `DEBT_DUE_DATE` date DEFAULT NULL,
  `DEBT_NOMINAL` double DEFAULT '0',
  `DEBT_PAID` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`DEBT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `debt`
--

LOCK TABLES `debt` WRITE;
/*!40000 ALTER TABLE `debt` DISABLE KEYS */;
/*!40000 ALTER TABLE `debt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_account`
--

DROP TABLE IF EXISTS `master_account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_account` (
  `id` smallint(6) NOT NULL AUTO_INCREMENT,
  `account_id` int(10) unsigned NOT NULL,
  `account_name` varchar(50) NOT NULL,
  `account_type_id` tinyint(3) unsigned NOT NULL,
  `account_active` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `account_name_UNIQUE` (`account_name`),
  UNIQUE KEY `account_id_UNIQUE` (`account_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_account`
--

LOCK TABLES `master_account` WRITE;
/*!40000 ALTER TABLE `master_account` DISABLE KEYS */;
INSERT INTO `master_account` VALUES (1,1,'PENDAPATAN TUNAI PENJUALAN',1,1),(2,2,'PENDAPATAN BCA PENJUALAN',1,1),(3,3,'PIUTANG PENJUALAN',1,1),(4,4,'BEBAN GAJI PUSAT',2,1),(5,5,'BEBAN LISTRIK PUSAT',2,1),(6,6,'BEBAN AIR',2,1),(7,7,'PENDAPATAN LAIN-LAIN',1,1),(8,8,'BEBAN LAIN-LAIN',2,1),(9,10,'BEBAN',2,1);
/*!40000 ALTER TABLE `master_account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_account_type`
--

DROP TABLE IF EXISTS `master_account_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_account_type` (
  `account_type_id` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `account_type_name` varchar(45) NOT NULL,
  PRIMARY KEY (`account_type_id`),
  UNIQUE KEY `account_type_name_UNIQUE` (`account_type_name`),
  UNIQUE KEY `account_type_id_UNIQUE` (`account_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_account_type`
--

LOCK TABLES `master_account_type` WRITE;
/*!40000 ALTER TABLE `master_account_type` DISABLE KEYS */;
INSERT INTO `master_account_type` VALUES (1,'DEBET'),(2,'KREDIT');
/*!40000 ALTER TABLE `master_account_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_branch`
--

DROP TABLE IF EXISTS `master_branch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_branch` (
  `BRANCH_ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `BRANCH_NAME` varchar(50) NOT NULL,
  `BRANCH_ADDRESS_1` varchar(50) DEFAULT NULL,
  `BRANCH_ADDRESS_2` varchar(50) DEFAULT NULL,
  `BRANCH_ADDRESS_CITY` varchar(50) DEFAULT NULL,
  `BRANCH_TELEPHONE` varchar(15) DEFAULT NULL,
  `BRANCH_IP4` varchar(15) NOT NULL,
  `BRANCH_ACTIVE` tinyint(1) unsigned DEFAULT NULL,
  PRIMARY KEY (`BRANCH_ID`),
  UNIQUE KEY `BRANCH_NAME_UNIQUE` (`BRANCH_NAME`),
  UNIQUE KEY `BRANCH_IP4_UNIQUE` (`BRANCH_IP4`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_branch`
--

LOCK TABLES `master_branch` WRITE;
/*!40000 ALTER TABLE `master_branch` DISABLE KEYS */;
/*!40000 ALTER TABLE `master_branch` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_category`
--

DROP TABLE IF EXISTS `master_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_category` (
  `CATEGORY_ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `CATEGORY_NAME` varchar(50) DEFAULT NULL,
  `CATEGORY_DESCRIPTION` varchar(100) DEFAULT NULL,
  `CATEGORY_ACTIVE` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`CATEGORY_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_category`
--

LOCK TABLES `master_category` WRITE;
/*!40000 ALTER TABLE `master_category` DISABLE KEYS */;
/*!40000 ALTER TABLE `master_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_customer`
--

DROP TABLE IF EXISTS `master_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_customer` (
  `CUSTOMER_ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `CUSTOMER_FULL_NAME` varchar(50) DEFAULT NULL,
  `CUSTOMER_ADDRESS1` varchar(50) DEFAULT NULL,
  `CUSTOMER_ADDRESS2` varchar(50) DEFAULT NULL,
  `CUSTOMER_ADDRESS_CITY` varchar(50) DEFAULT NULL,
  `CUSTOMER_PHONE` varchar(15) DEFAULT NULL,
  `CUSTOMER_FAX` varchar(15) DEFAULT NULL,
  `CUSTOMER_EMAIL` varchar(50) DEFAULT NULL,
  `CUSTOMER_ACTIVE` tinyint(3) unsigned DEFAULT NULL,
  `CUSTOMER_JOINED_DATE` date DEFAULT NULL,
  `CUSTOMER_TOTAL_SALES_COUNT` int(11) DEFAULT NULL,
  `CUSTOMER_GROUP` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`CUSTOMER_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_customer`
--

LOCK TABLES `master_customer` WRITE;
/*!40000 ALTER TABLE `master_customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `master_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_group`
--

DROP TABLE IF EXISTS `master_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_group` (
  `GROUP_ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `GROUP_USER_NAME` varchar(50) NOT NULL,
  `GROUP_USER_DESCRIPTION` varchar(100) NOT NULL,
  `GROUP_USER_ACTIVE` tinyint(1) unsigned NOT NULL,
  PRIMARY KEY (`GROUP_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_group`
--

LOCK TABLES `master_group` WRITE;
/*!40000 ALTER TABLE `master_group` DISABLE KEYS */;
INSERT INTO `master_group` VALUES (1,'GLOBAL_ADMIN','GLOBAL ADMIN GROUP',1),(2,'NORMAL USER','NORMAL USER',1);
/*!40000 ALTER TABLE `master_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_location`
--

DROP TABLE IF EXISTS `master_location`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_location` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `LOCATION_NAME` varchar(45) DEFAULT NULL,
  `LOCATION_TOTAL_QTY` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_location`
--

LOCK TABLES `master_location` WRITE;
/*!40000 ALTER TABLE `master_location` DISABLE KEYS */;
INSERT INTO `master_location` VALUES (1,'TOKO',0),(2,'GUDANG',0);
/*!40000 ALTER TABLE `master_location` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_module`
--

DROP TABLE IF EXISTS `master_module`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_module` (
  `MODULE_ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `MODULE_NAME` varchar(50) DEFAULT NULL,
  `MODULE_DESCRIPTION` varchar(100) DEFAULT NULL,
  `MODULE_FEATURES` tinyint(3) unsigned DEFAULT NULL,
  `MODULE_ACTIVE` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`MODULE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_module`
--

LOCK TABLES `master_module` WRITE;
/*!40000 ALTER TABLE `master_module` DISABLE KEYS */;
/*!40000 ALTER TABLE `master_module` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_product`
--

DROP TABLE IF EXISTS `master_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_product` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_BARCODE` int(10) unsigned DEFAULT NULL,
  `PRODUCT_NAME` varchar(50) DEFAULT NULL,
  `PRODUCT_DESCRIPTION` varchar(100) DEFAULT NULL,
  `PRODUCT_BASE_PRICE` double DEFAULT NULL,
  `PRODUCT_RETAIL_PRICE` double DEFAULT NULL,
  `PRODUCT_BULK_PRICE` double DEFAULT NULL,
  `PRODUCT_WHOLESALE_PRICE` double DEFAULT NULL,
  `PRODUCT_PHOTO_1` varchar(50) DEFAULT NULL,
  `UNIT_ID` smallint(5) unsigned DEFAULT NULL,
  `PRODUCT_STOCK_QTY` double DEFAULT NULL,
  `PRODUCT_LIMIT_STOCK` double DEFAULT NULL,
  `PRODUCT_SHELVES` varchar(5) DEFAULT NULL,
  `PRODUCT_ACTIVE` tinyint(3) unsigned DEFAULT NULL,
  `PRODUCT_BRAND` varchar(50) DEFAULT NULL,
  `PRODUCT_IS_SERVICE` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PRODUCT_ID_UNIQUE` (`PRODUCT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_product`
--

LOCK TABLES `master_product` WRITE;
/*!40000 ALTER TABLE `master_product` DISABLE KEYS */;
/*!40000 ALTER TABLE `master_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_supplier`
--

DROP TABLE IF EXISTS `master_supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_supplier` (
  `SUPPLIER_ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `SUPPLIER_FULL_NAME` varchar(50) DEFAULT NULL,
  `SUPPLIER_ADDRESS1` varchar(50) DEFAULT NULL,
  `SUPPLIER_ADDRESS2` varchar(50) DEFAULT NULL,
  `SUPPLIER_ADDRESS_CITY` varchar(50) DEFAULT NULL,
  `SUPPLIER_PHONE` varchar(15) DEFAULT NULL,
  `SUPPLIER_FAX` varchar(15) DEFAULT NULL,
  `SUPPLIER_EMAIL` varchar(50) DEFAULT NULL,
  `SUPPLIER_ACTIVE` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`SUPPLIER_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_supplier`
--

LOCK TABLES `master_supplier` WRITE;
/*!40000 ALTER TABLE `master_supplier` DISABLE KEYS */;
/*!40000 ALTER TABLE `master_supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_unit`
--

DROP TABLE IF EXISTS `master_unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_unit` (
  `UNIT_ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `UNIT_NAME` varchar(50) DEFAULT NULL,
  `UNIT_DESCRIPTION` varchar(100) DEFAULT NULL,
  `UNIT_ACTIVE` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`UNIT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_unit`
--

LOCK TABLES `master_unit` WRITE;
/*!40000 ALTER TABLE `master_unit` DISABLE KEYS */;
/*!40000 ALTER TABLE `master_unit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `master_user`
--

DROP TABLE IF EXISTS `master_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `master_user` (
  `ID` tinyint(3) unsigned NOT NULL AUTO_INCREMENT,
  `USER_NAME` varchar(15) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `USER_PASSWORD` varchar(15) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `USER_FULL_NAME` varchar(50) DEFAULT NULL,
  `USER_PHONE` varchar(15) DEFAULT NULL,
  `USER_ACTIVE` tinyint(1) unsigned DEFAULT NULL,
  `GROUP_ID` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `USER_NAME_UNIQUE` (`USER_NAME`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_user`
--

LOCK TABLES `master_user` WRITE;
/*!40000 ALTER TABLE `master_user` DISABLE KEYS */;
INSERT INTO `master_user` VALUES (1,'admin','admin','ADMIN','1',1,1);
/*!40000 ALTER TABLE `master_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment_credit`
--

DROP TABLE IF EXISTS `payment_credit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment_credit` (
  `payment_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `credit_id` int(11) NOT NULL,
  `payment_date` date NOT NULL,
  `pm_id` tinyint(3) NOT NULL,
  `payment_nominal` double NOT NULL,
  `payment_description` varchar(100) DEFAULT NULL,
  `payment_confirmed` tinyint(3) DEFAULT NULL,
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment_credit`
--

LOCK TABLES `payment_credit` WRITE;
/*!40000 ALTER TABLE `payment_credit` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment_credit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment_debt`
--

DROP TABLE IF EXISTS `payment_debt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment_debt` (
  `payment_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `debt_id` int(11) NOT NULL,
  `payment_date` date NOT NULL,
  `pm_id` tinyint(3) NOT NULL,
  `payment_nominal` double NOT NULL,
  `payment_description` varchar(100) DEFAULT NULL,
  `payment_confirmed` tinyint(3) DEFAULT NULL,
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment_debt`
--

LOCK TABLES `payment_debt` WRITE;
/*!40000 ALTER TABLE `payment_debt` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment_debt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment_method`
--

DROP TABLE IF EXISTS `payment_method`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment_method` (
  `pm_id` tinyint(4) NOT NULL AUTO_INCREMENT,
  `pm_name` varchar(15) NOT NULL,
  `pm_description` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`pm_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment_method`
--

LOCK TABLES `payment_method` WRITE;
/*!40000 ALTER TABLE `payment_method` DISABLE KEYS */;
INSERT INTO `payment_method` VALUES (1,'TUNAI','TUNAI'),(2,'TRANSFER','TRANSFER BANK'),(3,'KARTU KREDIT','KARTU KREDIT'),(4,'KARTU DEBIT','KARTU DEBIT'),(5,'BG','BILYET GIRO'),(6,'CEK','CEK');
/*!40000 ALTER TABLE `payment_method` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_adjustment`
--

DROP TABLE IF EXISTS `product_adjustment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_adjustment` (
  `ID` int(10) unsigned zerofill NOT NULL,
  `PRODUCT_ID` varchar(30) DEFAULT NULL,
  `PRODUCT_ADJUSTMENT_DATE` date DEFAULT NULL,
  `PRODUCT_OLD_STOCK_QTY` double DEFAULT NULL,
  `PRODUCT_NEW_STOCK_QTY` double DEFAULT NULL,
  `PRODUCT_ADJUSTMENT_DESCRIPTION` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_adjustment`
--

LOCK TABLES `product_adjustment` WRITE;
/*!40000 ALTER TABLE `product_adjustment` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_adjustment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_category`
--

DROP TABLE IF EXISTS `product_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_category` (
  `PRODUCT_ID` varchar(50) NOT NULL,
  `CATEGORY_ID` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY (`PRODUCT_ID`,`CATEGORY_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_category`
--

LOCK TABLES `product_category` WRITE;
/*!40000 ALTER TABLE `product_category` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_location`
--

DROP TABLE IF EXISTS `product_location`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_location` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `LOCATION_ID` int(10) unsigned DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_LOCATION_QTY` double unsigned DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_location`
--

LOCK TABLES `product_location` WRITE;
/*!40000 ALTER TABLE `product_location` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_location` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_loss`
--

DROP TABLE IF EXISTS `product_loss`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_loss` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PL_DATETIME` date DEFAULT NULL,
  `PRODUCT_ID` int(10) unsigned DEFAULT NULL,
  `PRODUCT_QTY` double DEFAULT NULL,
  `NEW_PRODUCT_ID` int(10) unsigned DEFAULT NULL,
  `NEW_PRODUCT_QTY` double DEFAULT NULL,
  `TOTAL_LOSS` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_loss`
--

LOCK TABLES `product_loss` WRITE;
/*!40000 ALTER TABLE `product_loss` DISABLE KEYS */;
/*!40000 ALTER TABLE `product_loss` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products_mutation_detail`
--

DROP TABLE IF EXISTS `products_mutation_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products_mutation_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PM_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_BASE_PRICE` double DEFAULT NULL,
  `PRODUCT_QTY` double DEFAULT NULL,
  `PM_SUBTOTAL` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products_mutation_detail`
--

LOCK TABLES `products_mutation_detail` WRITE;
/*!40000 ALTER TABLE `products_mutation_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `products_mutation_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products_mutation_header`
--

DROP TABLE IF EXISTS `products_mutation_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products_mutation_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PM_INVOICE` varchar(30) DEFAULT NULL,
  `BRANCH_ID_FROM` tinyint(3) unsigned DEFAULT NULL,
  `BRANCH_ID_TO` tinyint(3) unsigned DEFAULT NULL,
  `PM_DATETIME` date DEFAULT NULL,
  `PM_TOTAL` double DEFAULT NULL,
  `RO_INVOICE` varchar(30) DEFAULT NULL,
  `PM_RECEIVED` tinyint(4) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products_mutation_header`
--

LOCK TABLES `products_mutation_header` WRITE;
/*!40000 ALTER TABLE `products_mutation_header` DISABLE KEYS */;
/*!40000 ALTER TABLE `products_mutation_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products_received_detail`
--

DROP TABLE IF EXISTS `products_received_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products_received_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PR_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_BASE_PRICE` double DEFAULT NULL,
  `PRODUCT_QTY` double DEFAULT NULL,
  `PRODUCT_ACTUAL_QTY` double DEFAULT NULL,
  `PR_SUBTOTAL` varchar(45) DEFAULT NULL,
  `PRODUCT_PRICE_CHANGE` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products_received_detail`
--

LOCK TABLES `products_received_detail` WRITE;
/*!40000 ALTER TABLE `products_received_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `products_received_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products_received_header`
--

DROP TABLE IF EXISTS `products_received_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products_received_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PR_INVOICE` varchar(30) DEFAULT NULL,
  `PR_FROM` tinyint(3) unsigned DEFAULT NULL,
  `PR_TO` tinyint(3) unsigned DEFAULT NULL,
  `PR_DATE` date DEFAULT NULL,
  `PR_TOTAL` double DEFAULT NULL,
  `PM_INVOICE` varchar(30) DEFAULT NULL,
  `PURCHASE_INVOICE` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PR_INVOICE_UNIQUE` (`PR_INVOICE`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products_received_header`
--

LOCK TABLES `products_received_header` WRITE;
/*!40000 ALTER TABLE `products_received_header` DISABLE KEYS */;
/*!40000 ALTER TABLE `products_received_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_detail`
--

DROP TABLE IF EXISTS `purchase_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PURCHASE_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_PRICE` double DEFAULT NULL,
  `PRODUCT_QTY` double DEFAULT NULL,
  `PURCHASE_SUBTOTAL` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_detail`
--

LOCK TABLES `purchase_detail` WRITE;
/*!40000 ALTER TABLE `purchase_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchase_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_header`
--

DROP TABLE IF EXISTS `purchase_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PURCHASE_INVOICE` varchar(30) DEFAULT NULL,
  `SUPPLIER_ID` smallint(5) unsigned DEFAULT NULL,
  `PURCHASE_DATETIME` date DEFAULT NULL,
  `PURCHASE_TOTAL` double DEFAULT NULL,
  `PURCHASE_TERM_OF_PAYMENT` tinyint(3) unsigned DEFAULT NULL,
  `PURCHASE_TERM_OF_PAYMENT_DATE` date DEFAULT NULL,
  `PURCHASE_PAID` tinyint(3) unsigned DEFAULT NULL,
  `PURCHASE_SENT` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PURCHASE_INVOICE_UNIQUE` (`PURCHASE_INVOICE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_header`
--

LOCK TABLES `purchase_header` WRITE;
/*!40000 ALTER TABLE `purchase_header` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchase_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request_order_detail`
--

DROP TABLE IF EXISTS `request_order_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request_order_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RO_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_BASE_PRICE` double DEFAULT NULL,
  `RO_QTY` double DEFAULT NULL,
  `RO_SUBTOTAL` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_order_detail`
--

LOCK TABLES `request_order_detail` WRITE;
/*!40000 ALTER TABLE `request_order_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `request_order_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request_order_header`
--

DROP TABLE IF EXISTS `request_order_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request_order_header` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `RO_INVOICE` varchar(30) DEFAULT NULL,
  `RO_BRANCH_ID_FROM` tinyint(3) unsigned DEFAULT NULL,
  `RO_BRANCH_ID_TO` tinyint(3) unsigned DEFAULT NULL,
  `RO_DATETIME` date DEFAULT NULL,
  `RO_TOTAL` double DEFAULT NULL,
  `RO_EXPIRED` date DEFAULT NULL,
  `RO_ACTIVE` tinyint(4) DEFAULT NULL,
  `RO_EXPORTED` tinyint(4) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `RO_INVOICE_UNIQUE` (`RO_INVOICE`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_order_header`
--

LOCK TABLES `request_order_header` WRITE;
/*!40000 ALTER TABLE `request_order_header` DISABLE KEYS */;
/*!40000 ALTER TABLE `request_order_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `return_purchase_detail`
--

DROP TABLE IF EXISTS `return_purchase_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `return_purchase_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RP_ID` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_BASEPRICE` double DEFAULT '0',
  `PRODUCT_QTY` double DEFAULT '0',
  `RP_DESCRIPTION` varchar(100) DEFAULT NULL,
  `RP_SUBTOTAL` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `return_purchase_detail`
--

LOCK TABLES `return_purchase_detail` WRITE;
/*!40000 ALTER TABLE `return_purchase_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `return_purchase_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `return_purchase_header`
--

DROP TABLE IF EXISTS `return_purchase_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `return_purchase_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RP_ID` varchar(30) DEFAULT NULL,
  `SUPPLIER_ID` smallint(5) unsigned DEFAULT NULL,
  `RP_DATE` date DEFAULT NULL,
  `RP_TOTAL` double DEFAULT '0',
  `RP_PROCESSED` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `RP_INVOICE_UNIQUE` (`RP_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `return_purchase_header`
--

LOCK TABLES `return_purchase_header` WRITE;
/*!40000 ALTER TABLE `return_purchase_header` DISABLE KEYS */;
/*!40000 ALTER TABLE `return_purchase_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `return_sales_detail`
--

DROP TABLE IF EXISTS `return_sales_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `return_sales_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RS_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_SALES_PRICE` double DEFAULT '0',
  `PRODUCT_SALES_QTY` double DEFAULT '0',
  `PRODUCT_RETURN_QTY` double DEFAULT '0',
  `RS_DESCRIPTION` varchar(100) DEFAULT NULL,
  `RS_SUBTOTAL` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `return_sales_detail`
--

LOCK TABLES `return_sales_detail` WRITE;
/*!40000 ALTER TABLE `return_sales_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `return_sales_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `return_sales_header`
--

DROP TABLE IF EXISTS `return_sales_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `return_sales_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `RS_INVOICE` varchar(30) DEFAULT NULL,
  `SALES_INVOICE` varchar(30) DEFAULT NULL,
  `CUSTOMER_ID` smallint(5) unsigned DEFAULT NULL,
  `RS_DATETIME` date DEFAULT NULL,
  `RS_TOTAL` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `return_sales_header`
--

LOCK TABLES `return_sales_header` WRITE;
/*!40000 ALTER TABLE `return_sales_header` DISABLE KEYS */;
/*!40000 ALTER TABLE `return_sales_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_detail`
--

DROP TABLE IF EXISTS `sales_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sales_detail` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SALES_INVOICE` varchar(30) DEFAULT NULL,
  `PRODUCT_ID` varchar(50) DEFAULT NULL,
  `PRODUCT_SALES_PRICE` double DEFAULT '0',
  `PRODUCT_QTY` double DEFAULT '0',
  `PRODUCT_DISC1` double DEFAULT '0',
  `PRODUCT_DISC2` double DEFAULT '0',
  `PRODUCT_DISC_RP` double DEFAULT '0',
  `SALES_SUBTOTAL` double DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_detail`
--

LOCK TABLES `sales_detail` WRITE;
/*!40000 ALTER TABLE `sales_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `sales_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_header`
--

DROP TABLE IF EXISTS `sales_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sales_header` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SALES_INVOICE` varchar(30) DEFAULT NULL,
  `CUSTOMER_ID` smallint(5) unsigned DEFAULT '0',
  `SALES_DATE` date DEFAULT NULL,
  `SALES_TOTAL` double DEFAULT '0',
  `SALES_DISCOUNT_FINAL` double DEFAULT '0',
  `SALES_TOP` tinyint(3) unsigned DEFAULT '0',
  `SALES_TOP_DATE` date DEFAULT NULL,
  `SALES_PAID` tinyint(3) unsigned DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `SALES_INVOICE_UNIQUE` (`SALES_INVOICE`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_header`
--

LOCK TABLES `sales_header` WRITE;
/*!40000 ALTER TABLE `sales_header` DISABLE KEYS */;
/*!40000 ALTER TABLE `sales_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_config`
--

DROP TABLE IF EXISTS `sys_config`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sys_config` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `NO_FAKTUR` varchar(30) NOT NULL DEFAULT '',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_config`
--

LOCK TABLES `sys_config` WRITE;
/*!40000 ALTER TABLE `sys_config` DISABLE KEYS */;
INSERT INTO `sys_config` VALUES (1,'SLO001');
/*!40000 ALTER TABLE `sys_config` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unit_convert`
--

DROP TABLE IF EXISTS `unit_convert`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unit_convert` (
  `CONVERT_UNIT_ID_1` smallint(5) unsigned NOT NULL,
  `CONVERT_UNIT_ID_2` smallint(5) unsigned NOT NULL,
  `CONVERT_MULTIPLIER` float DEFAULT NULL,
  PRIMARY KEY (`CONVERT_UNIT_ID_1`,`CONVERT_UNIT_ID_2`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit_convert`
--

LOCK TABLES `unit_convert` WRITE;
/*!40000 ALTER TABLE `unit_convert` DISABLE KEYS */;
/*!40000 ALTER TABLE `unit_convert` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_access_management`
--

DROP TABLE IF EXISTS `user_access_management`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_access_management` (
  `ID` smallint(5) unsigned NOT NULL AUTO_INCREMENT,
  `GROUP_ID` tinyint(3) unsigned DEFAULT NULL,
  `MODULE_ID` smallint(5) unsigned DEFAULT NULL,
  `USER_ACCESS_OPTION` tinyint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_access_management`
--

LOCK TABLES `user_access_management` WRITE;
/*!40000 ALTER TABLE `user_access_management` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_access_management` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-03-23 11:26:15
