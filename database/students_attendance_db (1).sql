-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 06, 2020 at 04:09 PM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `students_attendance_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `attendances`
--

CREATE TABLE `attendances` (
  `attendanceid` int(6) NOT NULL,
  `subjectsscheduleid` int(6) DEFAULT NULL,
  `seatassignmentid` int(6) DEFAULT NULL,
  `attendancedatetime` datetime DEFAULT NULL,
  `inorout` varchar(20) DEFAULT NULL,
  `status` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `computers`
--

CREATE TABLE `computers` (
  `computerid` int(6) NOT NULL,
  `computer` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `contactphonenumbers`
--

CREATE TABLE `contactphonenumbers` (
  `contactphonenumberid` int(6) NOT NULL,
  `studentid` int(6) DEFAULT NULL,
  `relationid` int(6) DEFAULT NULL,
  `contactphonenumber` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `courses`
--

CREATE TABLE `courses` (
  `courseid` int(6) NOT NULL,
  `coursecode` varchar(60) DEFAULT NULL,
  `coursedescription` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `employeeid` int(6) NOT NULL,
  `employeefirstname` varchar(60) DEFAULT NULL,
  `employeemiddlename` varchar(60) DEFAULT NULL,
  `employeelastname` varchar(60) DEFAULT NULL,
  `username` varchar(60) DEFAULT NULL,
  `password` varchar(60) DEFAULT NULL,
  `accountlevel` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `relations`
--

CREATE TABLE `relations` (
  `relationid` int(6) NOT NULL,
  `relation` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `rooms`
--

CREATE TABLE `rooms` (
  `roomid` int(6) NOT NULL,
  `computerid` int(6) DEFAULT NULL,
  `room` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `seatassignments`
--

CREATE TABLE `seatassignments` (
  `seatassignmentid` int(6) NOT NULL,
  `studentsubjectenrolledid` int(6) DEFAULT NULL,
  `seatid` int(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `seats`
--

CREATE TABLE `seats` (
  `seatid` int(6) NOT NULL,
  `seat` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `smsdeliverieshistory`
--

CREATE TABLE `smsdeliverieshistory` (
  `smsdeliveryhistoryid` int(6) NOT NULL,
  `attendanceid` int(6) DEFAULT NULL,
  `deliverydatetime` datetime DEFAULT NULL,
  `deliverystatus` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `studentid` int(6) NOT NULL,
  `courseid` int(6) DEFAULT NULL,
  `studentidnumber` varchar(20) DEFAULT NULL,
  `studentfirstname` varchar(60) DEFAULT NULL,
  `studentmiddlename` varchar(60) DEFAULT NULL,
  `studentlastname` varchar(60) DEFAULT NULL,
  `rfid` varchar(200) DEFAULT NULL,
  `imagelocation` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `studentsubjectsenrolled`
--

CREATE TABLE `studentsubjectsenrolled` (
  `studentsubjectenrolledid` int(6) NOT NULL,
  `studentid` int(6) DEFAULT NULL,
  `subjectscheduleid` int(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `subjects`
--

CREATE TABLE `subjects` (
  `subjectid` int(6) NOT NULL,
  `subjectcode` varchar(20) DEFAULT NULL,
  `subjectdescription` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `subjectsschedules`
--

CREATE TABLE `subjectsschedules` (
  `subjectscheduleid` int(6) NOT NULL,
  `subjectid` int(6) DEFAULT NULL,
  `employeeid` int(6) DEFAULT NULL,
  `roomid` int(6) DEFAULT NULL,
  `start` datetime DEFAULT NULL,
  `end` datetime DEFAULT NULL,
  `monday` tinyint(1) DEFAULT NULL,
  `tuesday` tinyint(1) DEFAULT NULL,
  `wednesday` tinyint(1) DEFAULT NULL,
  `thursday` tinyint(1) DEFAULT NULL,
  `friday` tinyint(1) DEFAULT NULL,
  `saturday` tinyint(1) DEFAULT NULL,
  `sunday` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `attendances`
--
ALTER TABLE `attendances`
  ADD PRIMARY KEY (`attendanceid`),
  ADD KEY `FK_attendances` (`subjectsscheduleid`),
  ADD KEY `FK_attendances1` (`seatassignmentid`);

--
-- Indexes for table `computers`
--
ALTER TABLE `computers`
  ADD PRIMARY KEY (`computerid`);

--
-- Indexes for table `contactphonenumbers`
--
ALTER TABLE `contactphonenumbers`
  ADD PRIMARY KEY (`contactphonenumberid`),
  ADD KEY `FK_contactphonenumbers1` (`studentid`),
  ADD KEY `FK_contactphonenumbers` (`relationid`);

--
-- Indexes for table `courses`
--
ALTER TABLE `courses`
  ADD PRIMARY KEY (`courseid`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`employeeid`);

--
-- Indexes for table `relations`
--
ALTER TABLE `relations`
  ADD PRIMARY KEY (`relationid`);

--
-- Indexes for table `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`roomid`),
  ADD KEY `FK_rooms` (`computerid`);

--
-- Indexes for table `seatassignments`
--
ALTER TABLE `seatassignments`
  ADD PRIMARY KEY (`seatassignmentid`),
  ADD KEY `FK_seatassignments` (`studentsubjectenrolledid`),
  ADD KEY `FK_seatassig1nments` (`seatid`);

--
-- Indexes for table `seats`
--
ALTER TABLE `seats`
  ADD PRIMARY KEY (`seatid`);

--
-- Indexes for table `smsdeliverieshistory`
--
ALTER TABLE `smsdeliverieshistory`
  ADD PRIMARY KEY (`smsdeliveryhistoryid`),
  ADD KEY `FK_smsdeliverieshistory` (`attendanceid`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`studentid`),
  ADD KEY `FK_students` (`courseid`);

--
-- Indexes for table `studentsubjectsenrolled`
--
ALTER TABLE `studentsubjectsenrolled`
  ADD PRIMARY KEY (`studentsubjectenrolledid`),
  ADD KEY `FK_studentsubjectsenrolled` (`subjectscheduleid`),
  ADD KEY `FK_studentsubjectsenrolle1d` (`studentid`);

--
-- Indexes for table `subjects`
--
ALTER TABLE `subjects`
  ADD PRIMARY KEY (`subjectid`);

--
-- Indexes for table `subjectsschedules`
--
ALTER TABLE `subjectsschedules`
  ADD PRIMARY KEY (`subjectscheduleid`),
  ADD KEY `FK_subjectsschedules1` (`subjectid`),
  ADD KEY `FK_subjectsschedules3` (`roomid`),
  ADD KEY `FK_subjectsschedules` (`employeeid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `attendances`
--
ALTER TABLE `attendances`
  MODIFY `attendanceid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `computers`
--
ALTER TABLE `computers`
  MODIFY `computerid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `contactphonenumbers`
--
ALTER TABLE `contactphonenumbers`
  MODIFY `contactphonenumberid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `courses`
--
ALTER TABLE `courses`
  MODIFY `courseid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `employeeid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `relations`
--
ALTER TABLE `relations`
  MODIFY `relationid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `roomid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `seatassignments`
--
ALTER TABLE `seatassignments`
  MODIFY `seatassignmentid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `seats`
--
ALTER TABLE `seats`
  MODIFY `seatid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `smsdeliverieshistory`
--
ALTER TABLE `smsdeliverieshistory`
  MODIFY `smsdeliveryhistoryid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `studentid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `studentsubjectsenrolled`
--
ALTER TABLE `studentsubjectsenrolled`
  MODIFY `studentsubjectenrolledid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `subjects`
--
ALTER TABLE `subjects`
  MODIFY `subjectid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `subjectsschedules`
--
ALTER TABLE `subjectsschedules`
  MODIFY `subjectscheduleid` int(6) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `attendances`
--
ALTER TABLE `attendances`
  ADD CONSTRAINT `FK_attendances` FOREIGN KEY (`subjectsscheduleid`) REFERENCES `subjectsschedules` (`subjectscheduleid`),
  ADD CONSTRAINT `FK_attendances1` FOREIGN KEY (`seatassignmentid`) REFERENCES `seatassignments` (`seatassignmentid`);

--
-- Constraints for table `contactphonenumbers`
--
ALTER TABLE `contactphonenumbers`
  ADD CONSTRAINT `FK_contactphonenumbers` FOREIGN KEY (`relationid`) REFERENCES `relations` (`relationid`),
  ADD CONSTRAINT `FK_contactphonenumbers1` FOREIGN KEY (`studentid`) REFERENCES `students` (`studentid`);

--
-- Constraints for table `rooms`
--
ALTER TABLE `rooms`
  ADD CONSTRAINT `FK_rooms` FOREIGN KEY (`computerid`) REFERENCES `computers` (`computerid`);

--
-- Constraints for table `seatassignments`
--
ALTER TABLE `seatassignments`
  ADD CONSTRAINT `FK_seatassig1nments` FOREIGN KEY (`seatid`) REFERENCES `seats` (`seatid`),
  ADD CONSTRAINT `FK_seatassignments` FOREIGN KEY (`studentsubjectenrolledid`) REFERENCES `studentsubjectsenrolled` (`studentsubjectenrolledid`);

--
-- Constraints for table `smsdeliverieshistory`
--
ALTER TABLE `smsdeliverieshistory`
  ADD CONSTRAINT `FK_smsdeliverieshistory` FOREIGN KEY (`attendanceid`) REFERENCES `attendances` (`attendanceid`);

--
-- Constraints for table `students`
--
ALTER TABLE `students`
  ADD CONSTRAINT `FK_students` FOREIGN KEY (`courseid`) REFERENCES `courses` (`courseid`);

--
-- Constraints for table `studentsubjectsenrolled`
--
ALTER TABLE `studentsubjectsenrolled`
  ADD CONSTRAINT `FK_studentsubjectsenrolle1d` FOREIGN KEY (`studentid`) REFERENCES `students` (`studentid`),
  ADD CONSTRAINT `FK_studentsubjectsenrolled` FOREIGN KEY (`subjectscheduleid`) REFERENCES `subjectsschedules` (`subjectscheduleid`);

--
-- Constraints for table `subjectsschedules`
--
ALTER TABLE `subjectsschedules`
  ADD CONSTRAINT `FK_subjectsschedules` FOREIGN KEY (`employeeid`) REFERENCES `employees` (`employeeid`),
  ADD CONSTRAINT `FK_subjectsschedules1` FOREIGN KEY (`subjectid`) REFERENCES `subjects` (`subjectid`),
  ADD CONSTRAINT `FK_subjectsschedules3` FOREIGN KEY (`roomid`) REFERENCES `rooms` (`roomid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
