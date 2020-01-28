using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Studentssubjectenrollment
    {
        int studentsubjectenrollmentid;
        int studentid;
        int subjectscheduleid;
        int seatid;
        int isdrop;

        public int Studentsubjectenrollmentid { get => studentsubjectenrollmentid; set => studentsubjectenrollmentid = value; }
        public int Studentid { get => studentid; set => studentid = value; }
        public int Subjectscheduleid { get => subjectscheduleid; set => subjectscheduleid = value; }
        public int Seatid { get => seatid; set => seatid = value; }
        public int Isdrop { get => isdrop; set => isdrop = value; }
    }
}
