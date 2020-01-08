using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Studentsubjectsenrolled
    {
        int studentsubjectenrolledid;
        int studentid;
        int subjectscheduleid;
        int seatid;

        public int Studentsubjectenrolledid { get => studentsubjectenrolledid; set => studentsubjectenrolledid = value; }
        public int Studentid { get => studentid; set => studentid = value; }
        public int Subjectscheduleid { get => subjectscheduleid; set => subjectscheduleid = value; }
        public int Seatid { get => seatid; set => seatid = value; }
    }
}
