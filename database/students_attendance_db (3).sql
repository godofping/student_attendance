-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 09, 2020 at 09:50 AM
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
  `studentsubjectenrolledid` int(6) DEFAULT NULL,
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

--
-- Dumping data for table `computers`
--

INSERT INTO `computers` (`computerid`, `computer`) VALUES
(1, 'COMPUTER 1'),
(2, 'COMPUTER 2'),
(3, 'COMPUTER 3'),
(13, 'tae1111'),
(14, 'a');

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

--
-- Dumping data for table `courses`
--

INSERT INTO `courses` (`courseid`, `coursecode`, `coursedescription`) VALUES
(1, 'bscs', 'comscie'),
(4, 'aa', 'asdasd');

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
  `accounttype` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `relations`
--

CREATE TABLE `relations` (
  `relationid` int(6) NOT NULL,
  `relation` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `relations`
--

INSERT INTO `relations` (`relationid`, `relation`) VALUES
(1, 'Father'),
(2, 'Mother'),
(3, 'Relatives'),
(4, 'Guardian'),
(6, 'Spouse'),
(7, 'Others'),
(9, 'aa');

-- --------------------------------------------------------

--
-- Table structure for table `rooms`
--

CREATE TABLE `rooms` (
  `roomid` int(6) NOT NULL,
  `computerid` int(6) DEFAULT NULL,
  `room` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`roomid`, `computerid`, `room`) VALUES
(1, 2, 'tae1'),
(2, 14, 'aa'),
(3, 1, 'asd');

-- --------------------------------------------------------

--
-- Stand-in structure for view `rooms_view`
-- (See below for the actual view)
--
CREATE TABLE `rooms_view` (
`roomid` int(6)
,`computerid` int(6)
,`room` varchar(60)
,`computer` varchar(60)
);

-- --------------------------------------------------------

--
-- Table structure for table `seats`
--

CREATE TABLE `seats` (
  `seatid` int(6) NOT NULL,
  `roomid` int(6) DEFAULT NULL,
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
  `subjectscheduleid` int(6) DEFAULT NULL,
  `seatid` int(6) DEFAULT NULL
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

-- --------------------------------------------------------

--
-- Structure for view `rooms_view`
--
DROP TABLE IF EXISTS `rooms_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `rooms_view`  AS  select `rooms`.`roomid` AS `roomid`,`rooms`.`computerid` AS `computerid`,`rooms`.`room` AS `room`,`computers`.`computer` AS `computer` from (`rooms` join `computers` on((`rooms`.`computerid` = `computers`.`computerid`))) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `attendances`
--
ALTER TABLE `attendances`
  ADD PRIMARY KEY (`attendanceid`),
  ADD KEY `FK_attendances1` (`studentsubjectenrolledid`);

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
-- Indexes for table `seats`
--
ALTER TABLE `seats`
  ADD PRIMARY KEY (`seatid`),
  ADD KEY `FK_seats` (`roomid`);

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
  ADD KEY `FK_studentsubjectsenrolle1d` (`studentid`),
  ADD KEY `FK_studentsubjectsenrolled3` (`seatid`);

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
  MODIFY `computerid` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `contactphonenumbers`
--
ALTER TABLE `contactphonenumbers`
  MODIFY `contactphonenumberid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `courses`
--
ALTER TABLE `courses`
  MODIFY `courseid` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `employeeid` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `relations`
--
ALTER TABLE `relations`
  MODIFY `relationid` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `roomid` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

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
  ADD CONSTRAINT `FK_attendances1` FOREIGN KEY (`studentsubjectenrolledid`) REFERENCES `studentsubjectsenrolled` (`studentsubjectenrolledid`);

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
-- Constraints for table `seats`
--
ALTER TABLE `seats`
  ADD CONSTRAINT `FK_seats` FOREIGN KEY (`roomid`) REFERENCES `rooms` (`roomid`);

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
  ADD CONSTRAINT `FK_studentsubjectsenrolled` FOREIGN KEY (`subjectscheduleid`) REFERENCES `subjectsschedules` (`subjectscheduleid`),
  ADD CONSTRAINT `FK_studentsubjectsenrolled3` FOREIGN KEY (`seatid`) REFERENCES `seats` (`seatid`);

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
