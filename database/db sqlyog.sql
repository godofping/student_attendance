/*
SQLyog Ultimate v8.53 
MySQL - 5.5.5-10.1.38-MariaDB : Database - students_attendance_db
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`students_attendance_db` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `students_attendance_db`;

/*Table structure for table `admins` */

DROP TABLE IF EXISTS `admins`;

CREATE TABLE `admins` (
  `adminid` int(6) NOT NULL AUTO_INCREMENT,
  `adminusername` varchar(60) DEFAULT NULL,
  `adminpassword` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`adminid`),
  KEY `FK_admins` (`adminusername`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `admins` */

/*Table structure for table `attendances` */

DROP TABLE IF EXISTS `attendances`;

CREATE TABLE `attendances` (
  `attendanceid` int(6) NOT NULL AUTO_INCREMENT,
  `subjectsscheduleid` int(6) DEFAULT NULL,
  `seatassignmentid` int(6) DEFAULT NULL,
  `attendancedatetime` datetime DEFAULT NULL,
  `inorout` varchar(20) DEFAULT NULL,
  `status` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`attendanceid`),
  KEY `FK_attendances` (`subjectsscheduleid`),
  KEY `FK_attendances1` (`seatassignmentid`),
  CONSTRAINT `FK_attendances` FOREIGN KEY (`subjectsscheduleid`) REFERENCES `subjectsschedules` (`subjectscheduleid`),
  CONSTRAINT `FK_attendances1` FOREIGN KEY (`seatassignmentid`) REFERENCES `seatassignments` (`seatassignmentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `attendances` */

/*Table structure for table `computers` */

DROP TABLE IF EXISTS `computers`;

CREATE TABLE `computers` (
  `computerid` int(6) NOT NULL AUTO_INCREMENT,
  `computer` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`computerid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `computers` */

/*Table structure for table `contactphonenumbers` */

DROP TABLE IF EXISTS `contactphonenumbers`;

CREATE TABLE `contactphonenumbers` (
  `contactphonenumberid` int(6) NOT NULL AUTO_INCREMENT,
  `studentid` int(6) DEFAULT NULL,
  `contactphonenumber` varchar(60) DEFAULT NULL,
  `relationid` int(6) DEFAULT NULL,
  PRIMARY KEY (`contactphonenumberid`),
  KEY `FK_contactphonenumbers` (`relationid`),
  KEY `FK_contactphonenumbers1` (`studentid`),
  CONSTRAINT `FK_contactphonenumbers` FOREIGN KEY (`relationid`) REFERENCES `relations` (`relationid`),
  CONSTRAINT `FK_contactphonenumbers1` FOREIGN KEY (`studentid`) REFERENCES `students` (`studentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `contactphonenumbers` */

/*Table structure for table `courses` */

DROP TABLE IF EXISTS `courses`;

CREATE TABLE `courses` (
  `courseid` int(6) NOT NULL AUTO_INCREMENT,
  `coursecode` varchar(60) DEFAULT NULL,
  `coursedescription` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`courseid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `courses` */

/*Table structure for table `relations` */

DROP TABLE IF EXISTS `relations`;

CREATE TABLE `relations` (
  `relationid` int(6) NOT NULL AUTO_INCREMENT,
  `relation` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`relationid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `relations` */

/*Table structure for table `rooms` */

DROP TABLE IF EXISTS `rooms`;

CREATE TABLE `rooms` (
  `roomid` int(6) NOT NULL AUTO_INCREMENT,
  `computerid` int(6) DEFAULT NULL,
  `room` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`roomid`),
  KEY `FK_rooms` (`computerid`),
  CONSTRAINT `FK_rooms` FOREIGN KEY (`computerid`) REFERENCES `computers` (`computerid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `rooms` */

/*Table structure for table `seatassignments` */

DROP TABLE IF EXISTS `seatassignments`;

CREATE TABLE `seatassignments` (
  `seatassignmentid` int(6) NOT NULL AUTO_INCREMENT,
  `studentsubjectenrolledid` int(6) DEFAULT NULL,
  `seatid` int(6) DEFAULT NULL,
  PRIMARY KEY (`seatassignmentid`),
  KEY `FK_seatassignments` (`studentsubjectenrolledid`),
  KEY `FK_seatassig1nments` (`seatid`),
  CONSTRAINT `FK_seatassig1nments` FOREIGN KEY (`seatid`) REFERENCES `seats` (`seatid`),
  CONSTRAINT `FK_seatassignments` FOREIGN KEY (`studentsubjectenrolledid`) REFERENCES `studentsubjectsenrolled` (`studentsubjectenrolledid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `seatassignments` */

/*Table structure for table `seats` */

DROP TABLE IF EXISTS `seats`;

CREATE TABLE `seats` (
  `seatid` int(6) NOT NULL AUTO_INCREMENT,
  `seat` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`seatid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `seats` */

/*Table structure for table `smsdeliverieshistory` */

DROP TABLE IF EXISTS `smsdeliverieshistory`;

CREATE TABLE `smsdeliverieshistory` (
  `smsdeliveryhistoryid` int(6) NOT NULL AUTO_INCREMENT,
  `attendanceid` int(6) DEFAULT NULL,
  `deliverydatetime` datetime DEFAULT NULL,
  `deliverystatus` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`smsdeliveryhistoryid`),
  KEY `FK_smsdeliverieshistory` (`attendanceid`),
  CONSTRAINT `FK_smsdeliverieshistory` FOREIGN KEY (`attendanceid`) REFERENCES `attendances` (`attendanceid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `smsdeliverieshistory` */

/*Table structure for table `students` */

DROP TABLE IF EXISTS `students`;

CREATE TABLE `students` (
  `studentid` int(6) NOT NULL AUTO_INCREMENT,
  `courseid` int(6) DEFAULT NULL,
  `studentidnumber` varchar(20) DEFAULT NULL,
  `studentfirstname` varchar(60) DEFAULT NULL,
  `studentmiddlename` varchar(60) DEFAULT NULL,
  `studentlastname` varchar(60) DEFAULT NULL,
  `rfid` varchar(200) DEFAULT NULL,
  `imagelocation` text,
  PRIMARY KEY (`studentid`),
  KEY `FK_students` (`courseid`),
  CONSTRAINT `FK_students` FOREIGN KEY (`courseid`) REFERENCES `courses` (`courseid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `students` */

/*Table structure for table `studentsubjectsenrolled` */

DROP TABLE IF EXISTS `studentsubjectsenrolled`;

CREATE TABLE `studentsubjectsenrolled` (
  `studentsubjectenrolledid` int(6) NOT NULL AUTO_INCREMENT,
  `studentid` int(6) DEFAULT NULL,
  `subjectscheduleid` int(6) DEFAULT NULL,
  PRIMARY KEY (`studentsubjectenrolledid`),
  KEY `FK_studentsubjectsenrolled` (`subjectscheduleid`),
  KEY `FK_studentsubjectsenrolle1d` (`studentid`),
  CONSTRAINT `FK_studentsubjectsenrolle1d` FOREIGN KEY (`studentid`) REFERENCES `students` (`studentid`),
  CONSTRAINT `FK_studentsubjectsenrolled` FOREIGN KEY (`subjectscheduleid`) REFERENCES `subjectsschedules` (`subjectscheduleid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `studentsubjectsenrolled` */

/*Table structure for table `subjects` */

DROP TABLE IF EXISTS `subjects`;

CREATE TABLE `subjects` (
  `subjectid` int(6) NOT NULL AUTO_INCREMENT,
  `subjectcode` varchar(20) DEFAULT NULL,
  `subjectdescription` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`subjectid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `subjects` */

/*Table structure for table `subjectsschedules` */

DROP TABLE IF EXISTS `subjectsschedules`;

CREATE TABLE `subjectsschedules` (
  `subjectscheduleid` int(6) NOT NULL AUTO_INCREMENT,
  `subjectid` int(6) DEFAULT NULL,
  `teacherid` int(6) DEFAULT NULL,
  `roomid` int(6) DEFAULT NULL,
  `start` datetime DEFAULT NULL,
  `end` datetime DEFAULT NULL,
  `Monday` tinyint(1) DEFAULT NULL,
  `Tuesday` tinyint(1) DEFAULT NULL,
  `Wednesday` tinyint(1) DEFAULT NULL,
  `Thursday` tinyint(1) DEFAULT NULL,
  `Friday` tinyint(1) DEFAULT NULL,
  `Saturday` tinyint(1) DEFAULT NULL,
  `Sunday` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`subjectscheduleid`),
  KEY `FK_subjects` (`teacherid`),
  KEY `FK_subjectsschedules1` (`subjectid`),
  KEY `FK_subjectsschedules3` (`roomid`),
  CONSTRAINT `FK_subjects` FOREIGN KEY (`teacherid`) REFERENCES `teachers` (`teacherid`),
  CONSTRAINT `FK_subjectsschedules1` FOREIGN KEY (`subjectid`) REFERENCES `subjects` (`subjectid`),
  CONSTRAINT `FK_subjectsschedules3` FOREIGN KEY (`roomid`) REFERENCES `rooms` (`roomid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `subjectsschedules` */

/*Table structure for table `teachers` */

DROP TABLE IF EXISTS `teachers`;

CREATE TABLE `teachers` (
  `teacherid` int(6) NOT NULL AUTO_INCREMENT,
  `teacherfirstname` varchar(60) DEFAULT NULL,
  `teachermiddlename` varchar(60) DEFAULT NULL,
  `teacherlastname` varchar(60) DEFAULT NULL,
  `teacherusername` varchar(60) DEFAULT NULL,
  `teacherpassword` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`teacherid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `teachers` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
