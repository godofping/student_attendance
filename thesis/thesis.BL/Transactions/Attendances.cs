﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Transactions
{
    public class Attendances
    {
        DL.Transactions.Attendances attendanceDL = new DL.Transactions.Attendances();


        public EL.Transactions.Attendances Select(EL.Transactions.Attendances attendanceEL)
        {

            return attendanceDL.Select(attendanceEL);
        }

        public DataTable CheckIfHasAttendance(EL.Transactions.Attendances attendanceEL)
        {
            return attendanceDL.CheckIfHasAttendance(attendanceEL);
        }

        public DataTable CountAbsents(EL.Transactions.Attendances attendanceEL)
        {
            return attendanceDL.CountAbsents(attendanceEL);
        }

        public DataTable ListAttendance(EL.Transactions.Attendances attendanceEL)
        {
            return attendanceDL.ListAttendance(attendanceEL);
        }

        public DataTable List()
        {
            return attendanceDL.List();
        }

        public DataTable ListAttendanceByDate(EL.Transactions.Attendances attendanceEL)
        {

            return attendanceDL.ListAttendanceByDate(attendanceEL);
        }

        public long Insert(EL.Transactions.Attendances attendanceEL)
        {
            return attendanceDL.Insert(attendanceEL);
        }

        public Boolean AttendanceIn(EL.Transactions.Attendances attendanceEL)
        {
            return attendanceDL.AttendanceIn(attendanceEL);
        }

        public Boolean AttendanceOut(EL.Transactions.Attendances attendanceEL)
        {
            return attendanceDL.AttendanceOut(attendanceEL);
        }
    }
}
