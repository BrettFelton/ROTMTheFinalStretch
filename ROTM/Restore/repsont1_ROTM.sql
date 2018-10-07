-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Oct 07, 2018 at 07:22 PM
-- Server version: 5.7.21
-- PHP Version: 7.1.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `repsont1_ROTM`
--

-- --------------------------------------------------------

--
-- Table structure for table `access_level`
--

CREATE TABLE `access_level` (
  `Access_Level_ID` int(11) NOT NULL,
  `Access_Level_Name` varchar(50) NOT NULL,
  `Access_Level_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `access_level`
--

INSERT INTO `access_level` (`Access_Level_ID`, `Access_Level_Name`, `Access_Level_Description`) VALUES
(1, 'Full Access', 'Grants full access to the system'),
(2, 'Management only access', 'Grants access only to Management system'),
(3, 'Mobile only access', 'Grants only to the mobile system');

-- --------------------------------------------------------

--
-- Table structure for table `active_user`
--

CREATE TABLE `active_user` (
  `Active_User_ID` int(4) NOT NULL,
  `UserDateTime` datetime NOT NULL,
  `Login` tinyint(1) DEFAULT NULL,
  `logout` tinyint(1) DEFAULT NULL,
  `Employee_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `active_user`
--

INSERT INTO `active_user` (`Active_User_ID`, `UserDateTime`, `Login`, `logout`, `Employee_ID`) VALUES
(1, '2018-10-04 02:23:52', 1, 0, 26),
(2, '2018-10-04 04:26:39', 1, 0, 26),
(3, '2018-10-05 05:48:28', 1, 0, 26),
(4, '2018-10-05 05:56:21', 1, 0, 26),
(5, '2018-10-05 06:06:02', 1, 0, 26),
(6, '2018-10-05 06:44:01', 1, 0, 26),
(7, '2018-10-05 06:51:50', 1, 0, 26),
(8, '2018-10-05 06:59:23', 1, 0, 26),
(9, '2018-10-06 12:32:31', 1, 0, 26),
(10, '2018-10-06 12:34:32', 1, 0, 26),
(11, '2018-10-06 12:34:50', 1, 0, 26),
(12, '2018-10-06 01:40:09', 1, 0, 26),
(13, '2018-10-06 01:41:08', 1, 0, 26),
(14, '2018-10-06 01:44:31', 1, 0, 26),
(15, '2018-10-06 11:34:18', 1, 0, 26);

-- --------------------------------------------------------

--
-- Table structure for table `address`
--

CREATE TABLE `address` (
  `Address_ID` int(11) NOT NULL,
  `Street_Name` varchar(50) DEFAULT NULL,
  `Suburb` varchar(50) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `Province` varchar(50) DEFAULT NULL,
  `Country` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `address`
--

INSERT INTO `address` (`Address_ID`, `Street_Name`, `Suburb`, `City`, `Province`, `Country`) VALUES
(1, 'Park Street', 'Hatfield', 'Pretoria', 'Gauteng', 'South Africa'),
(6, 'Corner of Saal street and Achilles street', 'Zwavelpoort', 'Pretoria', 'Gauteng', 'South Africa'),
(7, 'Gauteng', 'South Africa', '127 Bronkhorst', 'New Muchleneuk', 'Pretoria'),
(8, 'best dam', 'country', 'Jimmy', 'john', 'bob'),
(9, 'street1', 'suburb1', 'city1', 'province1', 'country1'),
(19, 'Corner of Saal street and Achilles Street', 'Zwavelpoort', 'Pretoria', 'Gauteng', 'South Africa'),
(20, 'Achilles Street', 'Zwavelpoort', 'Pretoria', 'Gauteng', 'South Africa'),
(21, 'Corner of Saal and Achilles street', 'Zwavelpoort', 'Pretoria', 'Gauteng', 'South Africa'),
(22, 'Corner of Lynnwood road and Rissik Street', 'Hatfield', 'Pretoria', 'Gauteng', 'South Africa'),
(23, 'Rissik Street', 'Hatfield', 'Pretoria', 'Gauteng', 'South Africa'),
(32, '6 Munday Ave', 'Morninghill', 'Germiston', 'Gauteng', 'South Africa'),
(48, 'Corner of Atterbury Road and Solomon Mahlangu road', 'Garsfontein', 'Pretoria', 'Gauteng', 'South Africa'),
(49, 'Corner of Saal and Achilles street', 'Zwavelpoort', 'Pretoria', 'Gauteng', 'South Africa'),
(50, '4 Olea Cres', 'Bedfordview', 'Germiston', 'Gauteng', 'South Africa'),
(51, '6 Munday Ave', 'Morninghill', 'Germiston', 'Gauteng', 'South Africa'),
(52, '6 Munday Ave', 'Morninghill', 'Germiston', 'Gauteng', 'South Africa'),
(57, 'IT Building', 'Lunnon Rd', 'Hillcrest', 'Gauteng', '0083'),
(58, 'spur', 'Brooklyn', 'Pretoria', 'gauteng', 'south Africa'),
(59, '301 Queen Wilhelmina Ave', 'Groenkloof', 'Pretoria', 'Gauteng', 'South Africa'),
(60, 'Corner of Jacqueline drive and Windsor road', 'Garsfontein', 'Pretoria', 'Gauteng', 'South Africa'),
(61, '11 Olea crescent', 'Morninghill', 'Johannessburg', 'Gauteng', 'south Africa'),
(62, 'spur', 'Brooklyn', 'Pretoria', 'gauteng', 'south Africa'),
(63, 'Ring Road', 'Hillcrest', 'Pretoria', 'Gauteng', 'South Africa'),
(64, '23 cachet road', 'lambton', 'germistion', 'gauteng', 'south africa'),
(65, 'a', 'a', 'a', 'a', 'a'),
(68, 'd', 'd', 'd', 'd', 'd'),
(69, 'a', 'a', 'a', 'a', 'a'),
(70, 'a', 'a', 'a', 'a', 'a'),
(71, 'a', 'a', 'a', 'a', 'a'),
(72, 'a', 'a', 'a', 'a', 'a'),
(73, 'a', 'a', 'a', 'a', 'a'),
(74, 'a', 'a', 'a', 'a', 'a'),
(75, 's', 'a', 'a', 'a', 'a'),
(76, 'Saal St', 'Zwavelpoort', 'Pretoria', 'Gauteng', 'South Africa'),
(77, 'Olea Cres', 'Morninghill', 'Germiston', 'Gauteng', 'South Africa'),
(78, '18 Numida Park', 'Ifafi', 'Hartbeespoort', 'North West', 'South Africa'),
(79, 'The', 'Boy', 'Who', 'Lived', 'Unit'),
(81, 'Park Street', 'Hatfield', 'Pretoria', 'Gauteng', 'South Africa'),
(82, 'tgg', 'ghh', 'fghh', 'cvhj', 'cghjk'),
(83, '3 Sodium St', 'Dersley', 'Springs', 'Gauteng', 'South Africa'),
(84, '23 cachet road', 'lambton', 'germiston', 'gauteng', 'south Africa'),
(85, '4 Olea Cres', 'Bedfordview', 'Germiston', 'Gauteng', 'South Africa');

-- --------------------------------------------------------

--
-- Table structure for table `attendance`
--

CREATE TABLE `attendance` (
  `Training_Course_Instance_ID` int(11) NOT NULL,
  `Employee_ID` int(11) NOT NULL,
  `Replied_Going` tinyint(1) NOT NULL DEFAULT '0',
  `Actual_Attendance` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `attendance`
--

INSERT INTO `attendance` (`Training_Course_Instance_ID`, `Employee_ID`, `Replied_Going`, `Actual_Attendance`) VALUES
(3, 25, 1, 1),
(11, 26, 1, 0),
(20, 26, 1, 0),
(21, 26, 1, 0),
(23, 26, 1, 1),
(3, 28, 1, 0),
(20, 28, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `audit_trail`
--

CREATE TABLE `audit_trail` (
  `Audit_Trail_ID` int(11) NOT NULL,
  `Employee_ID` int(11) DEFAULT NULL,
  `Trail_DateTime` datetime DEFAULT NULL,
  `Trail_Description` varchar(255) DEFAULT NULL,
  `Deleted_Record` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `audit_trail`
--

INSERT INTO `audit_trail` (`Audit_Trail_ID`, `Employee_ID`, `Trail_DateTime`, `Trail_Description`, `Deleted_Record`) VALUES
(10, 26, '2018-10-03 09:51:12', 'Deleted Client and associated client contacts', '19 Johns bakery johnsBak@gmail.com'),
(11, 26, '2018-10-06 02:21:48', 'Deleted Client and associated client contacts', '13 Bretts Pawn store brett@gmail.com'),
(12, 35, '2018-10-06 00:00:00', 'Deleted Access Level', '4 Test Test');

-- --------------------------------------------------------

--
-- Table structure for table `booking`
--

CREATE TABLE `booking` (
  `Booking_ID` int(11) NOT NULL,
  `Booking_Name` varchar(50) DEFAULT NULL,
  `Booking_Date` date DEFAULT NULL,
  `Booking_Start_Time` time DEFAULT NULL,
  `Booking_End_Time` time DEFAULT NULL,
  `Booking_Type_ID` int(11) DEFAULT NULL,
  `Client_Contact_ID` int(11) DEFAULT NULL,
  `Employee_ID` int(11) DEFAULT NULL,
  `Address_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `booking`
--

INSERT INTO `booking` (`Booking_ID`, `Booking_Name`, `Booking_Date`, `Booking_Start_Time`, `Booking_End_Time`, `Booking_Type_ID`, `Client_Contact_ID`, `Employee_ID`, `Address_ID`) VALUES
(3, 'test', '2018-10-06', '11:00:00', '12:00:00', 3, 13, 26, 19),
(4, 'Marketing for Coding as a sport', '2018-10-07', '12:00:00', '14:00:00', 4, 1, 26, 6),
(11, 'Meeting with Chad', '2018-09-06', '07:30:00', '08:30:00', 3, 1, 23, 6),
(12, 'Meeting with Sam', '2018-09-06', '09:00:00', '10:00:00', 2, 2, 23, 8),
(13, 'Netball meeting with Jenny', '2018-09-11', '09:00:00', '10:00:00', 2, 11, 23, 7),
(14, 'Archery meeting with Peter', '2018-09-11', '10:00:00', '11:00:00', 2, 4, 23, 1),
(15, 'Meeting with Moses', '2018-09-13', '12:00:00', '13:00:00', 3, 5, 23, 1),
(16, 'Skips Marketing meeting', '2018-09-12', '10:00:00', '11:00:00', 4, 3, 23, 1),
(17, 'Affies IT', '2018-09-14', '09:00:00', '10:00:00', 1, 6, 23, 1),
(18, 'Something Fishy meeting', '2018-09-14', '14:00:00', '15:00:00', 1, 1, 23, 8),
(20, 'Coding with the Team', '2018-09-08', '18:36:00', '17:37:00', 1, 1, 23, 19),
(21, 'ERL Skips', '2018-09-09', '09:30:00', '08:30:00', 3, 3, 23, 19),
(22, 'Braai With Edd', '2018-09-08', '19:00:00', '20:00:00', 4, 3, 23, 21),
(23, 'Netball Meeting', '2018-09-08', '13:19:00', '14:26:00', 3, 11, 23, 22),
(24, 'Affies IT clothes', '2018-09-08', '17:00:00', '16:00:00', 1, 6, 23, 23),
(27, 'Coding Meeting', '2018-09-09', '12:30:00', '13:30:00', 2, 5, 23, 48),
(28, 'Braai with Family', '2018-09-09', '15:30:00', '16:30:00', 2, 9, 23, 21),
(29, 'ayyyy', '2018-09-11', '06:12:00', '06:14:00', 1, 1, 26, 58),
(30, 'ERL Skips meeting', '2018-09-11', '08:30:00', '09:30:00', 3, 3, 23, 6),
(31, 'Tuks Netball meeting', '2018-09-11', '10:00:00', '11:00:00', 2, 11, 23, 22),
(33, 'inf demo', '2018-09-11', '07:00:00', '09:00:00', 1, 7, 34, 58),
(34, 'another test', '2018-09-23', '16:37:00', '17:37:00', 1, 12, 26, 64),
(41, 'a', '2018-09-23', '20:00:00', '20:01:00', 1, 1, 26, 65),
(42, 'a', '2018-09-23', '20:08:00', '20:09:00', 1, 1, 26, 65),
(43, 'b', '2018-09-23', '22:36:00', '22:37:00', 1, 1, 26, 65),
(44, 'A', '2018-09-23', '23:46:00', '23:47:00', 1, 1, 26, 65),
(45, 'a', '2018-09-24', '00:03:00', '00:04:00', 1, 1, 26, 75),
(46, 'Beer Time', '2018-09-24', '22:00:00', '23:00:00', 2, 3, 23, 76),
(47, 'golf shirts', '2018-10-04', '16:58:00', '19:59:00', 1, 2, 28, 82),
(48, 'my dudes', '2018-10-07', '13:42:00', '13:44:00', 1, 2, 26, 64);

-- --------------------------------------------------------

--
-- Table structure for table `booking_instance`
--

CREATE TABLE `booking_instance` (
  `Booking_Instance_ID` int(11) NOT NULL,
  `Instance_Comments` text,
  `Instance_Start_Time` time DEFAULT NULL,
  `Instance_End_Time` time DEFAULT NULL,
  `Booking_ID` int(11) DEFAULT NULL,
  `Quote_ID` int(11) DEFAULT NULL,
  `Address_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `booking_instance`
--

INSERT INTO `booking_instance` (`Booking_Instance_ID`, `Instance_Comments`, `Instance_Start_Time`, `Instance_End_Time`, `Booking_ID`, `Quote_ID`, `Address_ID`) VALUES
(1, NULL, '09:00:00', '10:00:00', 11, 1, 8),
(15, 'bite me', '20:04:00', '20:04:00', 3, NULL, 32),
(20, 'hate this', '21:18:00', '21:19:00', 3, NULL, 32),
(21, 'sd', '23:25:00', '23:26:00', 3, NULL, 32),
(22, 'a', '23:30:00', '23:30:00', 3, NULL, 32),
(23, '3', '23:35:00', '23:35:00', 3, NULL, 32),
(24, 'a', '13:15:00', '13:16:00', 3, NULL, 50),
(25, 'Was a fun meeting', '13:23:00', '13:23:00', 27, NULL, 32),
(26, 'a', '14:43:00', '14:43:00', 3, NULL, 32),
(27, 'Appointment is completed. Need to go look up on sport related products for the client', '16:08:00', '16:11:00', 27, NULL, 32),
(28, 'Meeting went well. Submitted a quote for followup', '16:16:00', '16:17:00', 27, NULL, 32),
(29, 'Submitted a quote for the new work boots and overalls', '16:43:00', '16:44:00', 21, NULL, 32),
(30, 'i like meetings', '22:48:00', '22:48:00', 4, NULL, 32),
(31, 'test agaib', '15:40:00', '15:40:00', 3, NULL, 57),
(32, 'ay', '06:16:00', '06:16:00', 29, NULL, 59),
(33, 'ddd', '08:00:00', '08:01:00', 33, NULL, 63),
(34, 'He likes craft beer but he is still my brother. So i still love him.', '21:24:00', '21:25:00', 46, NULL, 77),
(35, '', '21:21:00', '21:22:00', 47, NULL, 83),
(36, '', '23:34:00', '23:35:00', 3, NULL, 50);

-- --------------------------------------------------------

--
-- Table structure for table `booking_reminders`
--

CREATE TABLE `booking_reminders` (
  `Booking_ID` int(11) NOT NULL,
  `Reminder_ID` int(11) NOT NULL,
  `Reminder_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `booking_reminders`
--

INSERT INTO `booking_reminders` (`Booking_ID`, `Reminder_ID`, `Reminder_Description`) VALUES
(11, 2, 'Remember to leave early');

-- --------------------------------------------------------

--
-- Table structure for table `booking_type`
--

CREATE TABLE `booking_type` (
  `Booking_Type_ID` int(11) NOT NULL,
  `Booking_Type_Name` varchar(50) DEFAULT NULL,
  `Booking_Type_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `booking_type`
--

INSERT INTO `booking_type` (`Booking_Type_ID`, `Booking_Type_Name`, `Booking_Type_Description`) VALUES
(1, 'Corporate', 'A booking that will handle a corporate type topic'),
(2, 'Sport', 'A booking that will handle a sport type topic'),
(3, 'PPE', 'A booking that will handle a ppe type topic'),
(4, 'Exposure', 'A booking that will handle a exposure type topic'),
(5, 'INF 370', 'Marking');

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE `client` (
  `Client_ID` int(11) NOT NULL,
  `Client_Name` varchar(50) DEFAULT NULL,
  `Client_Cellphone` char(10) DEFAULT NULL,
  `Client_Email` varchar(255) DEFAULT NULL,
  `Client_Rating_ID` int(11) DEFAULT NULL,
  `Client_Type_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`Client_ID`, `Client_Name`, `Client_Cellphone`, `Client_Email`, `Client_Rating_ID`, `Client_Type_ID`) VALUES
(1, 'ERL Skips', '0733180345', 'ERLSkips@gmail.com', 2, 3),
(3, 'Jims fish', '0214597848', 'Jims fish@gmail', 1, 1),
(4, 'Big Al\'s Traders', '0837659896', 'Info@bigals.com', 2, 3),
(5, 'Moses Metal Work', '0964267286', 'mosesmetal@gmail.com', 3, 2),
(6, 'Tuks Netball', '0124207070', 'Netball@tuks.com', 1, 1),
(8, 'Hoerskool Waterkloof', '0120933949', 'sport@klofies.co.za', 2, 1),
(9, 'Hoerskool Hugenote', '012883746', 'sport@hugenote.co.za', 3, 1),
(10, 'Affies Rugby', '0128873645', 'rugby@affies.co.za', 2, 1),
(11, 'Affies Personeel', '0128873645', 'bestuur@affies.co.za', 2, 1),
(12, 'Pukke Rugby', '0159287828', 'sport@pukke.co.za', 3, 1);

-- --------------------------------------------------------

--
-- Table structure for table `client_contact`
--

CREATE TABLE `client_contact` (
  `Client_Contact_ID` int(11) NOT NULL,
  `Contact_Name` varchar(50) DEFAULT NULL,
  `Contact_Surname` varchar(50) DEFAULT NULL,
  `Contact_Phone` char(10) DEFAULT NULL,
  `Contact_Email` varchar(255) DEFAULT NULL,
  `Client_Contact_Type_ID` int(11) DEFAULT NULL,
  `Client_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `client_contact`
--

INSERT INTO `client_contact` (`Client_Contact_ID`, `Contact_Name`, `Contact_Surname`, `Contact_Phone`, `Contact_Email`, `Client_Contact_Type_ID`, `Client_ID`) VALUES
(1, 'Jim', 'Preston', '0842974847', 'jim@gmail.com', 3, 3),
(2, 'Aurora', 'Lane', '0154787273', 'aurora.lane@hotmail.com', 4, 1),
(3, 'Edward', 'Loxton', '0733180345', 'Edward@gmail.com', 3, 1),
(4, 'Peter', 'Parker', '0129987364', 'spiderman@gmail.com', 1, 4),
(5, 'Moses', 'Mong', '0823376541', 'moses.mong@gmail.com', 3, 5),
(6, 'Kenneth', 'Holder', '0823847765', 'kenny.holder@affies.co.za', 1, 11),
(7, 'Sarel', 'Visagie', '0823847703', 'Sarelv@affies.co.za', 2, 10),
(9, 'Barry', 'Labuschagne', '0119287635', 'barrylab@gmail.co.za', 1, 9),
(10, 'Max', 'Verstappen', '014886528', 'madmax@gmail.com', 2, 12),
(11, 'Jennifer', 'Botha', '012778034', 'jennyb@gmail.com', 2, 6),
(12, 'Miggie', 'Husgen', '0823948872', 'michaelhus@gmail.com', 1, 8),
(13, 'Johnny', 'Loxton', '0730123733', 'johnglox@gmail.com', 3, 1);

-- --------------------------------------------------------

--
-- Table structure for table `client_contact_type`
--

CREATE TABLE `client_contact_type` (
  `Client_Contact_Type_ID` int(11) NOT NULL,
  `Type_Name` varchar(50) DEFAULT NULL,
  `Type_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `client_contact_type`
--

INSERT INTO `client_contact_type` (`Client_Contact_Type_ID`, `Type_Name`, `Type_Description`) VALUES
(1, 'Corporate', 'A contact that deals mostly in corporate gifts and products'),
(2, 'Sport', 'A contact that mostly deals in sporting equipment and products'),
(3, 'PPE', 'A contact that deals mostly in PPE products'),
(4, 'Exposure', 'A contact that deals mostly in exposure and marketing related products');

-- --------------------------------------------------------

--
-- Table structure for table `client_mailinglist`
--

CREATE TABLE `client_mailinglist` (
  `Client_ID` int(11) NOT NULL,
  `Mailing_List_ID` int(11) NOT NULL,
  `Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `client_mailinglist`
--

INSERT INTO `client_mailinglist` (`Client_ID`, `Mailing_List_ID`, `Description`) VALUES
(1, 1, 'Hope this works'),
(3, 2, 'Jims Fisheries Staff management team'),
(4, 2, 'Staff management team'),
(6, 1, 'Tuks netball management team'),
(8, 1, 'Waterkloof sport management team'),
(9, 1, 'Hugenote sport management team'),
(10, 1, 'Affies rugby management team'),
(11, 2, 'Affies Staff management team'),
(12, 1, 'Pukke rugby management team');

-- --------------------------------------------------------

--
-- Table structure for table `client_rating`
--

CREATE TABLE `client_rating` (
  `Client_Rating_ID` int(11) NOT NULL,
  `Rating_Name` varchar(50) DEFAULT NULL,
  `Rating_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `client_rating`
--

INSERT INTO `client_rating` (`Client_Rating_ID`, `Rating_Name`, `Rating_Description`) VALUES
(1, 'A', 'Client spends a lot; Highest rating'),
(2, 'B', 'Client spends moderate amount; Intermediate rating'),
(3, 'C', 'Client spends smaller amount; Low rating');

-- --------------------------------------------------------

--
-- Table structure for table `client_type`
--

CREATE TABLE `client_type` (
  `Client_Type_ID` int(11) NOT NULL,
  `Client_Type_Name` varchar(50) DEFAULT NULL,
  `Client_Type_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `client_type`
--

INSERT INTO `client_type` (`Client_Type_ID`, `Client_Type_Name`, `Client_Type_Description`) VALUES
(1, 'School', 'A school that can have many different associated contacts'),
(2, 'Individual', 'An individual contact who isn\'t apart of a company'),
(3, 'Company', 'A company that can have many different contacts');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `Employee_ID` int(11) NOT NULL,
  `Employee_Name` varchar(50) DEFAULT NULL,
  `Employee_Surname` varchar(50) DEFAULT NULL,
  `Employee_Email` varchar(255) DEFAULT NULL,
  `Employee_Home_Phone` char(10) DEFAULT NULL,
  `Employee_Cellphone` char(10) DEFAULT NULL,
  `Employee_RSA_ID` char(13) DEFAULT NULL,
  `Employee_Avatar` varchar(255) DEFAULT NULL,
  `Employee_Type_ID` int(11) DEFAULT NULL,
  `Encrypted_Password` varchar(256) DEFAULT NULL,
  `Gender_ID` int(11) DEFAULT NULL,
  `Address_ID` int(11) DEFAULT NULL,
  `Title_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`Employee_ID`, `Employee_Name`, `Employee_Surname`, `Employee_Email`, `Employee_Home_Phone`, `Employee_Cellphone`, `Employee_RSA_ID`, `Employee_Avatar`, `Employee_Type_ID`, `Encrypted_Password`, `Gender_ID`, `Address_ID`, `Title_ID`) VALUES
(5, 'Brett', 'Felton', 'bmfelton@live.com', '0715535917', '0715535917', '9607185047084', 'brock-1.jpg', 1, '5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8', 1, 1, 1),
(23, 'John', 'Loxton', 'johnglox@gmail.com', '0730123733', '0730123733', '0987654321123', 'noaa-20180913-n-msa.png', 2, '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8', 1, 6, 1),
(24, 'Willem', 'du Toit', 'wilemdt90@gmail.com', '0126544750', '0843700003', '9507065044081', NULL, 2, '601f1889667efaebb33b8c12572835da3f027f78', NULL, 7, NULL),
(25, 'Chad', 'fox', 'chadfox95@gmail.com', '1111111111', '0842974847', '1234567891011', NULL, 2, 'a64e551cc0e8973b0b5416c7273cba14e05cec12', NULL, NULL, NULL),
(26, 'c', 'c', 'a', '1111111112', '1111111112', '1234567891012', NULL, 2, '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8', NULL, 9, NULL),
(28, 'Sam', 'Jonker', 'sampiejonker@gmail.com', '0124830234', '0731230337', '0987654352761', NULL, 2, '20EABE5D64B0E216796E834F52D61FD0B70332FC', 1, 48, 5),
(29, 'v', 'v', 'v', '0123456789', '0123456789', '0123456791011', NULL, 2, '2395a39cd8db2543f2b248dee57d93a17f253f30', NULL, 12, NULL),
(31, 'test', 'test', 'test@email.com', '0715535917', '0715535917', '0987654321123', NULL, 1, '5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8', 4, 19, 1),
(34, 'Frikkie', 'Van der merve', 'frikkie@gmail.com', '0824522434', '0842345442', '0875423451278', NULL, 1, '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8', NULL, 61, NULL),
(35, 'Brett', 'Felton', 'brettmfelton@gmail.com', '0715535917', '0715535917', '9607185047084', 'brock-1.jpg', 1, '5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8', 1, 78, 1);

-- --------------------------------------------------------

--
-- Table structure for table `employee_client`
--

CREATE TABLE `employee_client` (
  `Client_ID` int(11) NOT NULL,
  `Employee_ID` int(11) NOT NULL,
  `Relationship_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee_client`
--

INSERT INTO `employee_client` (`Client_ID`, `Employee_ID`, `Relationship_Description`) VALUES
(5, 23, 'Is a client of');

-- --------------------------------------------------------

--
-- Table structure for table `employee_mailinglist`
--

CREATE TABLE `employee_mailinglist` (
  `Employee_ID` int(11) NOT NULL,
  `Mailing_List_ID` int(11) NOT NULL,
  `Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee_mailinglist`
--

INSERT INTO `employee_mailinglist` (`Employee_ID`, `Mailing_List_ID`, `Description`) VALUES
(5, 1, 'Hope this works'),
(23, 1, 'Sport info for clients');

-- --------------------------------------------------------

--
-- Table structure for table `employee_milestone`
--

CREATE TABLE `employee_milestone` (
  `Employee_ID` int(11) NOT NULL,
  `Milestone_ID` int(11) NOT NULL,
  `Reason_Milestone` varchar(256) DEFAULT NULL,
  `Milestone_Progress` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee_milestone`
--

INSERT INTO `employee_milestone` (`Employee_ID`, `Milestone_ID`, `Reason_Milestone`, `Milestone_Progress`) VALUES
(5, 3, 'To hit monthly performance', 2),
(5, 4, 'To hit monthly performance', 3),
(5, 6, 'To hit monthly performance', 1),
(23, 3, 'Test', 0),
(23, 5, 'NEeds to sellmore products and show more catalogues', 0),
(26, 6, 'Needs to promote new promotions and advertise with video to more clients', 33);

-- --------------------------------------------------------

--
-- Table structure for table `employee_type`
--

CREATE TABLE `employee_type` (
  `Employee_Type_ID` int(11) NOT NULL,
  `Type_Name` varchar(50) NOT NULL,
  `Type_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee_type`
--

INSERT INTO `employee_type` (`Employee_Type_ID`, `Type_Name`, `Type_Description`) VALUES
(1, 'Manager', 'A manager is in charge of a group of employees'),
(2, 'Sales Rep', 'A sales rep is a type of employee that deals with clients'),
(3, 'Temp employee', 'Temporary employees are employees that are only temporarily employed');

-- --------------------------------------------------------

--
-- Table structure for table `gender`
--

CREATE TABLE `gender` (
  `Gender_ID` int(11) NOT NULL,
  `Gender` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `gender`
--

INSERT INTO `gender` (`Gender_ID`, `Gender`) VALUES
(1, 'Male'),
(4, 'Female'),
(5, 'Other');

-- --------------------------------------------------------

--
-- Table structure for table `instructor`
--

CREATE TABLE `instructor` (
  `Instructor_ID` int(11) NOT NULL,
  `Instructor_Name` varchar(50) DEFAULT NULL,
  `Instructor_Surname` varchar(50) DEFAULT NULL,
  `Instructor_Email` varchar(255) DEFAULT NULL,
  `Instructor_Cellphone` char(10) DEFAULT NULL,
  `Employee_ID` int(11) DEFAULT NULL,
  `Instructor_Type_ID` int(11) DEFAULT NULL,
  `Title_ID` int(11) DEFAULT NULL,
  `Gender_ID` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `instructor`
--

INSERT INTO `instructor` (`Instructor_ID`, `Instructor_Name`, `Instructor_Surname`, `Instructor_Email`, `Instructor_Cellphone`, `Employee_ID`, `Instructor_Type_ID`, `Title_ID`, `Gender_ID`) VALUES
(1, 'John', 'Cena', 'youcant@seeme.com', '0821237561', 5, 3, 1, 1),
(2, 'Brett', 'Felton', 'bmfelton@live.com', '0715535917', 5, 4, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `instructor_type`
--

CREATE TABLE `instructor_type` (
  `Instructor_Type_ID` int(4) NOT NULL,
  `Instructor_Type_Name` varchar(50) NOT NULL,
  `Instrutor_Type_Description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `instructor_type`
--

INSERT INTO `instructor_type` (`Instructor_Type_ID`, `Instructor_Type_Name`, `Instrutor_Type_Description`) VALUES
(3, 'Supplier', 'The instructor is a supplier from  an external company'),
(4, 'Guest Speaker', 'A guest speaker on a specific external field for extra information on a topic');

-- --------------------------------------------------------

--
-- Table structure for table `mailing_list`
--

CREATE TABLE `mailing_list` (
  `Mailing_List_ID` int(11) NOT NULL,
  `Mailing_List_Name` varchar(50) DEFAULT NULL,
  `Mailing_List_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mailing_list`
--

INSERT INTO `mailing_list` (`Mailing_List_ID`, `Mailing_List_Name`, `Mailing_List_Description`) VALUES
(1, 'Sport Mailing list', 'Mailing list for School Sports'),
(2, 'Corporate Mailing list', 'Mailing list for Corporate clients');

-- --------------------------------------------------------

--
-- Table structure for table `marketing`
--

CREATE TABLE `marketing` (
  `Marketing_ID` int(11) NOT NULL,
  `Marketing_Description` varchar(255) DEFAULT NULL,
  `Marketing_Image` blob,
  `Marketing_Type_ID` int(11) DEFAULT NULL,
  `Mailing_List_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `marketing`
--

INSERT INTO `marketing` (`Marketing_ID`, `Marketing_Description`, `Marketing_Image`, `Marketing_Type_ID`, `Mailing_List_ID`) VALUES
(1, 'Sport specials for October', NULL, 2, 1),
(2, 'Corporate clothing specials for October', NULL, 1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `marketing_type`
--

CREATE TABLE `marketing_type` (
  `Marketing_Type_ID` int(11) NOT NULL,
  `Marketing_Name` varchar(50) DEFAULT NULL,
  `Marketing_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `marketing_type`
--

INSERT INTO `marketing_type` (`Marketing_Type_ID`, `Marketing_Name`, `Marketing_Description`) VALUES
(1, 'Corporate', 'Marketing focusing on corporate products'),
(2, 'Sport', 'Marketing focusing on sports products'),
(3, 'PPE', 'Marketing focusing on ppe products'),
(4, 'Expoure', 'Marketing focusing on exposure products');

-- --------------------------------------------------------

--
-- Table structure for table `milestone`
--

CREATE TABLE `milestone` (
  `Milestone_ID` int(11) NOT NULL,
  `Milestone_Name` varchar(50) DEFAULT NULL,
  `Milestone_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `milestone`
--

INSERT INTO `milestone` (`Milestone_ID`, `Milestone_Name`, `Milestone_Description`) VALUES
(1, 'Monthly performance target', 'The basic performance target that a sales rep must strive to reach'),
(2, 'Yearly Performance target', 'The yearly performance target that a sales rep must strive to reach'),
(3, 'Weekly performance target', 'The weekly performance target that a sales rep must strive to reach'),
(4, 'Videos and Quotes', 'Employee must show more clients promotional videos and and must capture more quotes'),
(5, 'catalogue and products', 'Show them the new catalogue and the new products'),
(6, 'Promotions and Marketing Video', 'Employee needs to show more promotions and videos this month ');

-- --------------------------------------------------------

--
-- Table structure for table `notification`
--

CREATE TABLE `notification` (
  `Notification_ID` int(11) NOT NULL,
  `Notification_Name` varchar(50) DEFAULT NULL,
  `Notification_Text` varchar(500) DEFAULT NULL,
  `Notification_DateTime` datetime DEFAULT NULL,
  `Mailing_List_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `notification`
--

INSERT INTO `notification` (`Notification_ID`, `Notification_Name`, `Notification_Text`, `Notification_DateTime`, `Mailing_List_ID`) VALUES
(1, 'Sport Notification', 'Please check the latest sport info released in the marketing mail', '2018-09-07 09:00:00', 1);

-- --------------------------------------------------------

--
-- Table structure for table `quote`
--

CREATE TABLE `quote` (
  `Quote_ID` int(11) NOT NULL,
  `Quote_Name` varchar(50) DEFAULT NULL,
  `Quote_Ref_Num` varchar(50) DEFAULT NULL,
  `Quote_Date` date DEFAULT NULL,
  `Quote_Price` char(10) DEFAULT NULL,
  `Quote_Status_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `quote`
--

INSERT INTO `quote` (`Quote_ID`, `Quote_Name`, `Quote_Ref_Num`, `Quote_Date`, `Quote_Price`, `Quote_Status_ID`) VALUES
(1, 'Athletics equipment', '098767', '2018-09-04', 'R420,00', 1),
(2, 'sd', '78', '2018-10-03', '78', 1);

-- --------------------------------------------------------

--
-- Table structure for table `quote_status`
--

CREATE TABLE `quote_status` (
  `Quote_Status_ID` int(11) NOT NULL,
  `Status_Name` varchar(50) DEFAULT NULL,
  `Status_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `quote_status`
--

INSERT INTO `quote_status` (`Quote_Status_ID`, `Status_Name`, `Status_Description`) VALUES
(1, 'Valid', 'The quote is still valid'),
(2, 'Invalid', 'The quote is invalid'),
(3, 'Ordered', 'The quote has been ordered by the client');

-- --------------------------------------------------------

--
-- Table structure for table `registration_token`
--

CREATE TABLE `registration_token` (
  `Registration_Token_ID` int(11) NOT NULL,
  `Registration_Token` varchar(128) NOT NULL,
  `New_Email` varchar(255) DEFAULT NULL,
  `Access_Level_ID` int(11) DEFAULT NULL,
  `Employee_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `registration_token`
--

INSERT INTO `registration_token` (`Registration_Token_ID`, `Registration_Token`, `New_Email`, `Access_Level_ID`, `Employee_ID`) VALUES
(21, 'Aad2JAAa', 'test@email.com', 3, NULL),
(22, 'HQGCY5dv', 'johnglox@gmail.com', 1, 23),
(25, 'f3E5AmCX', 'chadfox95@gmail.com', 2, NULL),
(26, 'gKBX76mj', 'u16248971@tuks.co.za', 1, NULL),
(28, 'JOUX6kZR', 'sampiejonker@gmail.com', 1, NULL),
(32, 'H3yI+35H', 'bmfelton@live.com', 1, 5),
(34, 'YL4YAPwd', 'lizette.weilbach@up.ac.za', 3, NULL),
(36, 'GR4ZqhGQ', 'brettmfelton@gmail.com', 2, NULL),
(37, 'daccFLu/', 'xan3jorna@gmail.com', 1, NULL),
(38, 'siwIAnos', 'sampiejonker77@gmail.com', 1, NULL),
(39, 'tkmMAZCs', 'john@loxnet.co.za', 1, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `reminder`
--

CREATE TABLE `reminder` (
  `Reminder_ID` int(11) NOT NULL,
  `Reminder_Type_ID` int(11) DEFAULT NULL,
  `Reminder_DateTime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `reminder`
--

INSERT INTO `reminder` (`Reminder_ID`, `Reminder_Type_ID`, `Reminder_DateTime`) VALUES
(1, 1, '2018-09-06 07:00:00'),
(2, 1, '2018-09-06 08:00:00'),
(3, 1, '2018-09-07 08:00:00'),
(4, 2, '2018-09-07 09:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `reminder_type`
--

CREATE TABLE `reminder_type` (
  `Reminder_Type_ID` int(11) NOT NULL,
  `Reminder_Type_Name` varchar(50) DEFAULT NULL,
  `Reminder_Type_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `reminder_type`
--

INSERT INTO `reminder_type` (`Reminder_Type_ID`, `Reminder_Type_Name`, `Reminder_Type_Description`) VALUES
(1, 'Hour before', 'A reminder that goes off an hour before the appointment'),
(2, 'Day before', 'A reminder that goes off the day before the appointment'),
(3, 'Two days before', 'Exactly two days before the meeting reminder'),
(4, 'One week before', 'A reminder that displays exactly one week before the booking');

-- --------------------------------------------------------

--
-- Table structure for table `task`
--

CREATE TABLE `task` (
  `Task_ID` int(11) NOT NULL,
  `Task_Name` varchar(50) DEFAULT NULL,
  `Task_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `task`
--

INSERT INTO `task` (`Task_ID`, `Task_Name`, `Task_Description`) VALUES
(1, 'Show Marketing Video', 'The sales rep must show the XCO marketing'),
(5, 'Show Promotions', 'Show the client the latest promotional materials'),
(7, 'Follow up on Quote', 'Follow up on a previous quote that was ordered by the client'),
(8, 'Query from client', 'A Query that the client has about a product or product line'),
(9, 'Discuss New Products', 'Discuss the latest products in the product line that the client is interested in'),
(10, 'Show Catalogue', 'Show the year catalogue of all the product lines'),
(11, 'Show', 'All things ');

-- --------------------------------------------------------

--
-- Table structure for table `tasks_completed`
--

CREATE TABLE `tasks_completed` (
  `Task_ID` int(11) NOT NULL,
  `Booking_Instance_ID` int(11) NOT NULL,
  `Task_Comments` varchar(255) DEFAULT NULL,
  `Employee_ID` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tasks_completed`
--

INSERT INTO `tasks_completed` (`Task_ID`, `Booking_Instance_ID`, `Task_Comments`, `Employee_ID`) VALUES
(1, 1, 'Showed the marketing video to the client. He liked it', 26),
(1, 25, 'test task ', 26),
(1, 32, 'ay', 26),
(5, 22, 'showed him my **', 26),
(5, 23, '1', 26),
(5, 33, 'he like the video', 34),
(5, 34, 'He liked the craft beer : > (', 23),
(7, 23, '2', 26),
(8, 36, '', 26),
(9, 29, 'Went well', 23),
(9, 33, 'show him new shirts', 34),
(10, 28, 'Went well', 23);

-- --------------------------------------------------------

--
-- Table structure for table `task_milestone`
--

CREATE TABLE `task_milestone` (
  `Task_ID` int(11) NOT NULL,
  `Milestone_ID` int(11) NOT NULL,
  `Task_Repetion` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `task_milestone`
--

INSERT INTO `task_milestone` (`Task_ID`, `Milestone_ID`, `Task_Repetion`) VALUES
(1, 1, 8),
(1, 4, 10),
(1, 6, 10),
(5, 2, 10),
(5, 6, 5),
(8, 1, 6),
(9, 5, 10),
(10, 5, 10),
(11, 1, 4);

-- --------------------------------------------------------

--
-- Table structure for table `title`
--

CREATE TABLE `title` (
  `Title_ID` int(11) NOT NULL,
  `Title` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `title`
--

INSERT INTO `title` (`Title_ID`, `Title`) VALUES
(1, 'Mr'),
(2, 'Mrs.'),
(3, 'Ms.'),
(4, 'Dr.'),
(5, 'Prof.'),
(6, 'Ds.');

-- --------------------------------------------------------

--
-- Table structure for table `training_course`
--

CREATE TABLE `training_course` (
  `Training_Course_ID` int(11) NOT NULL,
  `Training_Course_Name` varchar(50) DEFAULT NULL,
  `Training_Course_Description` varchar(255) DEFAULT NULL,
  `Employee_ID` int(11) DEFAULT NULL,
  `Training_Course_Type_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `training_course`
--

INSERT INTO `training_course` (`Training_Course_ID`, `Training_Course_Name`, `Training_Course_Description`, `Employee_ID`, `Training_Course_Type_ID`) VALUES
(1, 'Advanced Sales training', 'To sharpen up your sales skills to the point where you are able to sell ice cubes to an eskimo in the north pole.', 23, 2),
(2, 'Efficient daily routines', 'This Course is introduced to sales reps that have trouble with managing their time efficiently.', 5, 4),
(3, 'Systems training', 'Training course to teach the sales rep more about the system that is at his or her disposal during his or her everyday schedule', 24, 5);

-- --------------------------------------------------------

--
-- Table structure for table `training_course_instance`
--

CREATE TABLE `training_course_instance` (
  `Training_Course_Instance_ID` int(11) NOT NULL,
  `Instance_Date` date DEFAULT NULL,
  `Instance_Start_Time` time DEFAULT NULL,
  `Instance_End_Time` time DEFAULT NULL,
  `Venue_ID` int(11) DEFAULT NULL,
  `Instructor_ID` int(11) DEFAULT NULL,
  `Training_Course_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `training_course_instance`
--

INSERT INTO `training_course_instance` (`Training_Course_Instance_ID`, `Instance_Date`, `Instance_Start_Time`, `Instance_End_Time`, `Venue_ID`, `Instructor_ID`, `Training_Course_ID`) VALUES
(3, '2018-10-08', '12:00:00', '13:00:00', 1, 1, 1),
(11, '2018-09-08', '10:00:00', '11:00:00', 1, 1, 1),
(17, '2018-09-08', '05:00:00', '06:00:00', 1, 1, 1),
(20, '2018-10-08', '06:01:00', '06:30:00', 1, 1, 2),
(21, '2018-09-30', '11:00:00', '12:00:00', 1, 1, 1),
(22, '2018-09-20', '12:00:00', '13:00:00', 2, 2, 2),
(23, '2018-10-06', '10:00:00', '11:02:00', 1, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `training_course_type`
--

CREATE TABLE `training_course_type` (
  `Training_Course_Type_ID` int(11) NOT NULL,
  `Course_Name` varchar(50) DEFAULT NULL,
  `Course_Description` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `training_course_type`
--

INSERT INTO `training_course_type` (`Training_Course_Type_ID`, `Course_Name`, `Course_Description`) VALUES
(1, 'Marketing', 'A training course aimed at improving the sales reps marketng skills'),
(2, 'Sales', 'A training course aimed at improving the sales reps selling skills'),
(3, 'New Product', 'A training course aimed at introducing new products'),
(4, 'Time Management', 'A training course aimed at improving the sales reps time management skills'),
(5, 'Systems Training', 'Training an employee on how to use specific software');

-- --------------------------------------------------------

--
-- Table structure for table `venue`
--

CREATE TABLE `venue` (
  `Venue_ID` int(11) NOT NULL,
  `Venue_Name` varchar(50) DEFAULT NULL,
  `Venue_Description` varchar(255) DEFAULT NULL,
  `Venue_Size` int(11) DEFAULT NULL,
  `Address_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `venue`
--

INSERT INTO `venue` (`Venue_ID`, `Venue_Name`, `Venue_Description`, `Venue_Size`, `Address_ID`) VALUES
(1, 'Louw Hall', 'The Louw hall on the TUKS Hatfield campus', 350, 1),
(2, 'Centenary', 'Bcom Residence', 100, 1),
(5, 'EMS', 'ems building', 300, 81);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `access_level`
--
ALTER TABLE `access_level`
  ADD PRIMARY KEY (`Access_Level_ID`);

--
-- Indexes for table `active_user`
--
ALTER TABLE `active_user`
  ADD PRIMARY KEY (`Active_User_ID`),
  ADD KEY `fk` (`Employee_ID`);

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`Address_ID`);

--
-- Indexes for table `attendance`
--
ALTER TABLE `attendance`
  ADD PRIMARY KEY (`Employee_ID`,`Training_Course_Instance_ID`),
  ADD KEY `Training_Course_Instance_ID` (`Training_Course_Instance_ID`);

--
-- Indexes for table `audit_trail`
--
ALTER TABLE `audit_trail`
  ADD PRIMARY KEY (`Audit_Trail_ID`),
  ADD KEY `Employee_ID` (`Employee_ID`);

--
-- Indexes for table `booking`
--
ALTER TABLE `booking`
  ADD PRIMARY KEY (`Booking_ID`),
  ADD KEY `Booking_Type_ID` (`Booking_Type_ID`),
  ADD KEY `Employee_ID` (`Employee_ID`),
  ADD KEY `Address_ID` (`Address_ID`),
  ADD KEY `Client_Contact_ID` (`Client_Contact_ID`) USING BTREE,
  ADD KEY `Client_Contact_ID_2` (`Client_Contact_ID`);

--
-- Indexes for table `booking_instance`
--
ALTER TABLE `booking_instance`
  ADD PRIMARY KEY (`Booking_Instance_ID`),
  ADD KEY `Quote_ID` (`Quote_ID`),
  ADD KEY `Booking_ID` (`Booking_ID`),
  ADD KEY `Address_ID` (`Address_ID`);

--
-- Indexes for table `booking_reminders`
--
ALTER TABLE `booking_reminders`
  ADD PRIMARY KEY (`Booking_ID`,`Reminder_ID`),
  ADD KEY `booking_reminders_ibfk_2` (`Reminder_ID`);

--
-- Indexes for table `booking_type`
--
ALTER TABLE `booking_type`
  ADD PRIMARY KEY (`Booking_Type_ID`);

--
-- Indexes for table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`Client_ID`),
  ADD KEY `Client_Rating_ID` (`Client_Rating_ID`),
  ADD KEY `Client_Type_ID` (`Client_Type_ID`);

--
-- Indexes for table `client_contact`
--
ALTER TABLE `client_contact`
  ADD PRIMARY KEY (`Client_Contact_ID`),
  ADD KEY `Client_Contact_Type_ID` (`Client_Contact_Type_ID`),
  ADD KEY `client_contact_ibfk_3` (`Client_ID`);

--
-- Indexes for table `client_contact_type`
--
ALTER TABLE `client_contact_type`
  ADD PRIMARY KEY (`Client_Contact_Type_ID`);

--
-- Indexes for table `client_mailinglist`
--
ALTER TABLE `client_mailinglist`
  ADD PRIMARY KEY (`Client_ID`,`Mailing_List_ID`),
  ADD KEY `Mailing_List_ID` (`Mailing_List_ID`);

--
-- Indexes for table `client_rating`
--
ALTER TABLE `client_rating`
  ADD PRIMARY KEY (`Client_Rating_ID`);

--
-- Indexes for table `client_type`
--
ALTER TABLE `client_type`
  ADD PRIMARY KEY (`Client_Type_ID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`Employee_ID`),
  ADD KEY `Employee_Type_ID` (`Employee_Type_ID`),
  ADD KEY `Gender_ID` (`Gender_ID`),
  ADD KEY `Address_ID` (`Address_ID`),
  ADD KEY `Title_ID` (`Title_ID`);

--
-- Indexes for table `employee_client`
--
ALTER TABLE `employee_client`
  ADD PRIMARY KEY (`Client_ID`,`Employee_ID`),
  ADD KEY `Employee_ID` (`Employee_ID`);

--
-- Indexes for table `employee_mailinglist`
--
ALTER TABLE `employee_mailinglist`
  ADD PRIMARY KEY (`Employee_ID`,`Mailing_List_ID`),
  ADD KEY `Mailing_List_ID` (`Mailing_List_ID`);

--
-- Indexes for table `employee_milestone`
--
ALTER TABLE `employee_milestone`
  ADD PRIMARY KEY (`Employee_ID`,`Milestone_ID`),
  ADD KEY `Milestone_ID` (`Milestone_ID`);

--
-- Indexes for table `employee_type`
--
ALTER TABLE `employee_type`
  ADD PRIMARY KEY (`Employee_Type_ID`);

--
-- Indexes for table `gender`
--
ALTER TABLE `gender`
  ADD PRIMARY KEY (`Gender_ID`);

--
-- Indexes for table `instructor`
--
ALTER TABLE `instructor`
  ADD PRIMARY KEY (`Instructor_ID`),
  ADD KEY `Employee_ID` (`Employee_ID`),
  ADD KEY `Title_ID` (`Title_ID`),
  ADD KEY `Instructor_Type_ID` (`Instructor_Type_ID`) USING BTREE,
  ADD KEY `Gender_ID` (`Gender_ID`);

--
-- Indexes for table `instructor_type`
--
ALTER TABLE `instructor_type`
  ADD PRIMARY KEY (`Instructor_Type_ID`);

--
-- Indexes for table `mailing_list`
--
ALTER TABLE `mailing_list`
  ADD PRIMARY KEY (`Mailing_List_ID`);

--
-- Indexes for table `marketing`
--
ALTER TABLE `marketing`
  ADD PRIMARY KEY (`Marketing_ID`),
  ADD KEY `Marketing_Type_ID` (`Marketing_Type_ID`),
  ADD KEY `Mailing_List_ID` (`Mailing_List_ID`);

--
-- Indexes for table `marketing_type`
--
ALTER TABLE `marketing_type`
  ADD PRIMARY KEY (`Marketing_Type_ID`);

--
-- Indexes for table `milestone`
--
ALTER TABLE `milestone`
  ADD PRIMARY KEY (`Milestone_ID`);

--
-- Indexes for table `notification`
--
ALTER TABLE `notification`
  ADD PRIMARY KEY (`Notification_ID`),
  ADD KEY `Mailing_List_ID` (`Mailing_List_ID`);

--
-- Indexes for table `quote`
--
ALTER TABLE `quote`
  ADD PRIMARY KEY (`Quote_ID`),
  ADD KEY `Quote_Status_ID` (`Quote_Status_ID`);

--
-- Indexes for table `quote_status`
--
ALTER TABLE `quote_status`
  ADD PRIMARY KEY (`Quote_Status_ID`);

--
-- Indexes for table `registration_token`
--
ALTER TABLE `registration_token`
  ADD PRIMARY KEY (`Registration_Token_ID`),
  ADD KEY `Access_Level_ID` (`Access_Level_ID`),
  ADD KEY `Employee_ID` (`Employee_ID`);

--
-- Indexes for table `reminder`
--
ALTER TABLE `reminder`
  ADD PRIMARY KEY (`Reminder_ID`),
  ADD KEY `Reminder_Type_ID` (`Reminder_Type_ID`);

--
-- Indexes for table `reminder_type`
--
ALTER TABLE `reminder_type`
  ADD PRIMARY KEY (`Reminder_Type_ID`);

--
-- Indexes for table `task`
--
ALTER TABLE `task`
  ADD PRIMARY KEY (`Task_ID`);

--
-- Indexes for table `tasks_completed`
--
ALTER TABLE `tasks_completed`
  ADD PRIMARY KEY (`Task_ID`,`Booking_Instance_ID`),
  ADD KEY `Booking_Instance_ID` (`Booking_Instance_ID`),
  ADD KEY `fk3` (`Employee_ID`);

--
-- Indexes for table `task_milestone`
--
ALTER TABLE `task_milestone`
  ADD PRIMARY KEY (`Task_ID`,`Milestone_ID`),
  ADD KEY `Milestone_ID` (`Milestone_ID`);

--
-- Indexes for table `title`
--
ALTER TABLE `title`
  ADD PRIMARY KEY (`Title_ID`);

--
-- Indexes for table `training_course`
--
ALTER TABLE `training_course`
  ADD PRIMARY KEY (`Training_Course_ID`),
  ADD KEY `Training_Course_Type_ID` (`Training_Course_Type_ID`),
  ADD KEY `Employee_ID` (`Employee_ID`);

--
-- Indexes for table `training_course_instance`
--
ALTER TABLE `training_course_instance`
  ADD PRIMARY KEY (`Training_Course_Instance_ID`),
  ADD KEY `Training_Course_ID` (`Training_Course_ID`),
  ADD KEY `Instructor_ID` (`Instructor_ID`),
  ADD KEY `Venue_ID` (`Venue_ID`);

--
-- Indexes for table `training_course_type`
--
ALTER TABLE `training_course_type`
  ADD PRIMARY KEY (`Training_Course_Type_ID`);

--
-- Indexes for table `venue`
--
ALTER TABLE `venue`
  ADD PRIMARY KEY (`Venue_ID`),
  ADD KEY `Address_ID` (`Address_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `access_level`
--
ALTER TABLE `access_level`
  MODIFY `Access_Level_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `active_user`
--
ALTER TABLE `active_user`
  MODIFY `Active_User_ID` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `address`
--
ALTER TABLE `address`
  MODIFY `Address_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=86;

--
-- AUTO_INCREMENT for table `audit_trail`
--
ALTER TABLE `audit_trail`
  MODIFY `Audit_Trail_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `booking`
--
ALTER TABLE `booking`
  MODIFY `Booking_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- AUTO_INCREMENT for table `booking_instance`
--
ALTER TABLE `booking_instance`
  MODIFY `Booking_Instance_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `booking_type`
--
ALTER TABLE `booking_type`
  MODIFY `Booking_Type_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `client`
--
ALTER TABLE `client`
  MODIFY `Client_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `client_contact`
--
ALTER TABLE `client_contact`
  MODIFY `Client_Contact_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `client_contact_type`
--
ALTER TABLE `client_contact_type`
  MODIFY `Client_Contact_Type_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `client_rating`
--
ALTER TABLE `client_rating`
  MODIFY `Client_Rating_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `client_type`
--
ALTER TABLE `client_type`
  MODIFY `Client_Type_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `Employee_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT for table `employee_type`
--
ALTER TABLE `employee_type`
  MODIFY `Employee_Type_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `gender`
--
ALTER TABLE `gender`
  MODIFY `Gender_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `instructor`
--
ALTER TABLE `instructor`
  MODIFY `Instructor_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `instructor_type`
--
ALTER TABLE `instructor_type`
  MODIFY `Instructor_Type_ID` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `mailing_list`
--
ALTER TABLE `mailing_list`
  MODIFY `Mailing_List_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `marketing`
--
ALTER TABLE `marketing`
  MODIFY `Marketing_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `marketing_type`
--
ALTER TABLE `marketing_type`
  MODIFY `Marketing_Type_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `milestone`
--
ALTER TABLE `milestone`
  MODIFY `Milestone_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `notification`
--
ALTER TABLE `notification`
  MODIFY `Notification_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `quote`
--
ALTER TABLE `quote`
  MODIFY `Quote_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `quote_status`
--
ALTER TABLE `quote_status`
  MODIFY `Quote_Status_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `registration_token`
--
ALTER TABLE `registration_token`
  MODIFY `Registration_Token_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `reminder`
--
ALTER TABLE `reminder`
  MODIFY `Reminder_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `reminder_type`
--
ALTER TABLE `reminder_type`
  MODIFY `Reminder_Type_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `task`
--
ALTER TABLE `task`
  MODIFY `Task_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `title`
--
ALTER TABLE `title`
  MODIFY `Title_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `training_course`
--
ALTER TABLE `training_course`
  MODIFY `Training_Course_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `training_course_instance`
--
ALTER TABLE `training_course_instance`
  MODIFY `Training_Course_Instance_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `training_course_type`
--
ALTER TABLE `training_course_type`
  MODIFY `Training_Course_Type_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `venue`
--
ALTER TABLE `venue`
  MODIFY `Venue_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `active_user`
--
ALTER TABLE `active_user`
  ADD CONSTRAINT `fk` FOREIGN KEY (`Employee_ID`) REFERENCES `employee` (`Employee_ID`);

--
-- Constraints for table `attendance`
--
ALTER TABLE `attendance`
  ADD CONSTRAINT `attendance_ibfk_1` FOREIGN KEY (`Employee_ID`) REFERENCES `employee` (`Employee_ID`),
  ADD CONSTRAINT `attendance_ibfk_2` FOREIGN KEY (`Training_Course_Instance_ID`) REFERENCES `training_course_instance` (`Training_Course_Instance_ID`);

--
-- Constraints for table `audit_trail`
--
ALTER TABLE `audit_trail`
  ADD CONSTRAINT `audit_trail_ibfk_1` FOREIGN KEY (`Employee_ID`) REFERENCES `employee` (`Employee_ID`);

--
-- Constraints for table `booking`
--
ALTER TABLE `booking`
  ADD CONSTRAINT `booking_ibfk_1` FOREIGN KEY (`Booking_Type_ID`) REFERENCES `booking_type` (`Booking_Type_ID`),
  ADD CONSTRAINT `booking_ibfk_3` FOREIGN KEY (`Employee_ID`) REFERENCES `employee` (`Employee_ID`),
  ADD CONSTRAINT `booking_ibfk_4` FOREIGN KEY (`Address_ID`) REFERENCES `address` (`Address_ID`),
  ADD CONSTRAINT `fk5` FOREIGN KEY (`Client_Contact_ID`) REFERENCES `client_contact` (`Client_Contact_ID`);

--
-- Constraints for table `booking_instance`
--
ALTER TABLE `booking_instance`
  ADD CONSTRAINT `booking_instance_ibfk_1` FOREIGN KEY (`Quote_ID`) REFERENCES `quote` (`Quote_ID`),
  ADD CONSTRAINT `booking_instance_ibfk_2` FOREIGN KEY (`Booking_ID`) REFERENCES `booking` (`Booking_ID`),
  ADD CONSTRAINT `booking_instance_ibfk_3` FOREIGN KEY (`Address_ID`) REFERENCES `address` (`Address_ID`);

--
-- Constraints for table `booking_reminders`
--
ALTER TABLE `booking_reminders`
  ADD CONSTRAINT `booking_reminders_ibfk_1` FOREIGN KEY (`Booking_ID`) REFERENCES `booking` (`Booking_ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `booking_reminders_ibfk_2` FOREIGN KEY (`Reminder_ID`) REFERENCES `reminder` (`Reminder_ID`);

--
-- Constraints for table `client`
--
ALTER TABLE `client`
  ADD CONSTRAINT `client_ibfk_1` FOREIGN KEY (`Client_Rating_ID`) REFERENCES `client_rating` (`Client_Rating_ID`),
  ADD CONSTRAINT `client_ibfk_2` FOREIGN KEY (`Client_Type_ID`) REFERENCES `client_type` (`Client_Type_ID`);

--
-- Constraints for table `client_contact`
--
ALTER TABLE `client_contact`
  ADD CONSTRAINT `client_contact_ibfk_1` FOREIGN KEY (`Client_Contact_Type_ID`) REFERENCES `client_contact_type` (`Client_Contact_Type_ID`),
  ADD CONSTRAINT `client_contact_ibfk_3` FOREIGN KEY (`Client_ID`) REFERENCES `client` (`Client_ID`) ON DELETE CASCADE;

--
-- Constraints for table `client_mailinglist`
--
ALTER TABLE `client_mailinglist`
  ADD CONSTRAINT `client_mailinglist_ibfk_1` FOREIGN KEY (`Client_ID`) REFERENCES `client` (`Client_ID`),
  ADD CONSTRAINT `client_mailinglist_ibfk_2` FOREIGN KEY (`Mailing_List_ID`) REFERENCES `mailing_list` (`Mailing_List_ID`);

--
-- Constraints for table `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`Employee_Type_ID`) REFERENCES `employee_type` (`Employee_Type_ID`),
  ADD CONSTRAINT `employee_ibfk_2` FOREIGN KEY (`Gender_ID`) REFERENCES `gender` (`Gender_ID`),
  ADD CONSTRAINT `employee_ibfk_3` FOREIGN KEY (`Address_ID`) REFERENCES `address` (`Address_ID`),
  ADD CONSTRAINT `employee_ibfk_4` FOREIGN KEY (`Title_ID`) REFERENCES `title` (`Title_ID`);

--
-- Constraints for table `employee_client`
--
ALTER TABLE `employee_client`
  ADD CONSTRAINT `employee_client_ibfk_1` FOREIGN KEY (`Employee_ID`) REFERENCES `employee` (`Employee_ID`),
  ADD CONSTRAINT `employee_client_ibfk_2` FOREIGN KEY (`Client_ID`) REFERENCES `client` (`Client_ID`);

--
-- Constraints for table `employee_mailinglist`
--
ALTER TABLE `employee_mailinglist`
  ADD CONSTRAINT `employee_mailinglist_ibfk_1` FOREIGN KEY (`Employee_ID`) REFERENCES `employee` (`Employee_ID`),
  ADD CONSTRAINT `employee_mailinglist_ibfk_2` FOREIGN KEY (`Mailing_List_ID`) REFERENCES `mailing_list` (`Mailing_List_ID`);

--
-- Constraints for table `employee_milestone`
--
ALTER TABLE `employee_milestone`
  ADD CONSTRAINT `employee_milestone_ibfk_1` FOREIGN KEY (`Employee_ID`) REFERENCES `employee` (`Employee_ID`),
  ADD CONSTRAINT `employee_milestone_ibfk_2` FOREIGN KEY (`Milestone_ID`) REFERENCES `milestone` (`Milestone_ID`);

--
-- Constraints for table `instructor`
--
ALTER TABLE `instructor`
  ADD CONSTRAINT `ins_FK-4` FOREIGN KEY (`Gender_ID`) REFERENCES `gender` (`Gender_ID`),
  ADD CONSTRAINT `instructor_ibfk_1` FOREIGN KEY (`Employee_ID`) REFERENCES `employee` (`Employee_ID`),
  ADD CONSTRAINT `instructor_ibfk_3` FOREIGN KEY (`Title_ID`) REFERENCES `title` (`Title_ID`),
  ADD CONSTRAINT `instructorfk_2` FOREIGN KEY (`Instructor_Type_ID`) REFERENCES `instructor_type` (`Instructor_Type_ID`);

--
-- Constraints for table `marketing`
--
ALTER TABLE `marketing`
  ADD CONSTRAINT `marketing_ibfk_1` FOREIGN KEY (`Marketing_Type_ID`) REFERENCES `marketing_type` (`Marketing_Type_ID`),
  ADD CONSTRAINT `marketing_ibfk_2` FOREIGN KEY (`Mailing_List_ID`) REFERENCES `mailing_list` (`Mailing_List_ID`);

--
-- Constraints for table `notification`
--
ALTER TABLE `notification`
  ADD CONSTRAINT `notification_ibfk_1` FOREIGN KEY (`Mailing_List_ID`) REFERENCES `mailing_list` (`Mailing_List_ID`);

--
-- Constraints for table `quote`
--
ALTER TABLE `quote`
  ADD CONSTRAINT `quote_ibfk_1` FOREIGN KEY (`Quote_Status_ID`) REFERENCES `quote_status` (`Quote_Status_ID`);

--
-- Constraints for table `registration_token`
--
ALTER TABLE `registration_token`
  ADD CONSTRAINT `registration_token_ibfk_1` FOREIGN KEY (`Access_Level_ID`) REFERENCES `access_level` (`Access_Level_ID`),
  ADD CONSTRAINT `registration_token_ibfk_2` FOREIGN KEY (`Employee_ID`) REFERENCES `employee` (`Employee_ID`);

--
-- Constraints for table `reminder`
--
ALTER TABLE `reminder`
  ADD CONSTRAINT `reminder_ibfk_1` FOREIGN KEY (`Reminder_Type_ID`) REFERENCES `reminder_type` (`Reminder_Type_ID`);

--
-- Constraints for table `tasks_completed`
--
ALTER TABLE `tasks_completed`
  ADD CONSTRAINT `fk3` FOREIGN KEY (`Employee_ID`) REFERENCES `employee` (`Employee_ID`),
  ADD CONSTRAINT `tasks_completed_ibfk_1` FOREIGN KEY (`Task_ID`) REFERENCES `task` (`Task_ID`),
  ADD CONSTRAINT `tasks_completed_ibfk_2` FOREIGN KEY (`Booking_Instance_ID`) REFERENCES `booking_instance` (`Booking_Instance_ID`);

--
-- Constraints for table `task_milestone`
--
ALTER TABLE `task_milestone`
  ADD CONSTRAINT `task_milestone_ibfk_1` FOREIGN KEY (`Task_ID`) REFERENCES `task` (`Task_ID`),
  ADD CONSTRAINT `task_milestone_ibfk_2` FOREIGN KEY (`Milestone_ID`) REFERENCES `milestone` (`Milestone_ID`);

--
-- Constraints for table `training_course`
--
ALTER TABLE `training_course`
  ADD CONSTRAINT `training_course_ibfk_1` FOREIGN KEY (`Training_Course_Type_ID`) REFERENCES `training_course_type` (`Training_Course_Type_ID`),
  ADD CONSTRAINT `training_course_ibfk_2` FOREIGN KEY (`Employee_ID`) REFERENCES `employee` (`Employee_ID`);

--
-- Constraints for table `training_course_instance`
--
ALTER TABLE `training_course_instance`
  ADD CONSTRAINT `training_course_instance_ibfk_1` FOREIGN KEY (`Training_Course_ID`) REFERENCES `training_course` (`Training_Course_ID`),
  ADD CONSTRAINT `training_course_instance_ibfk_2` FOREIGN KEY (`Instructor_ID`) REFERENCES `instructor` (`Instructor_ID`),
  ADD CONSTRAINT `training_course_instance_ibfk_3` FOREIGN KEY (`Venue_ID`) REFERENCES `venue` (`Venue_ID`);

--
-- Constraints for table `venue`
--
ALTER TABLE `venue`
  ADD CONSTRAINT `venue_ibfk_1` FOREIGN KEY (`Address_ID`) REFERENCES `address` (`Address_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
