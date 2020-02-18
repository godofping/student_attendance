using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Transactions
{
    public class Attendances
    {
        int attendanceid;
        int studentsubjectenrollmentid;
        string attendanceintime;
        string attendanceouttime;
        string status;

        public int Attendanceid { get => attendanceid; set => attendanceid = value; }
        public int Studentsubjectenrollmentid { get => studentsubjectenrollmentid; set => studentsubjectenrollmentid = value; }
        public string Attendanceintime { get => attendanceintime; set => attendanceintime = value; }
        public string Attendanceouttime { get => attendanceouttime; set => attendanceouttime = value; }
        public string Status { get => status; set => status = value; }
    }
}
