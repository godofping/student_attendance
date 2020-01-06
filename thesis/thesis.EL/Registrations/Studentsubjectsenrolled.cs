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

        public int Studentsubjectenrolledid { get => studentsubjectenrolledid; set => studentsubjectenrolledid = value; }
        public int Studentid { get => studentid; set => studentid = value; }
        public int Subjectscheduleid { get => subjectscheduleid; set => subjectscheduleid = value; }
    }
}
