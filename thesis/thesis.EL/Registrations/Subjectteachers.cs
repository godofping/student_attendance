using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Subjectteachers
    {
        int subjectteacherid;
        int employeeid;
        int subjectid;

        public int Subjectteacherid { get => subjectteacherid; set => subjectteacherid = value; }
        public int Employeeid { get => employeeid; set => employeeid = value; }
        public int Subjectid { get => subjectid; set => subjectid = value; }
    }
}
