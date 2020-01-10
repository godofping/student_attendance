using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Subjectsschedules
    {
        int subjectscheduleid;
        int subjectid;
        int employeeid;
        int roomid;
        string subjecttype;
        string start;
        string end;
        int monday;
        int tuesday;
        int wednesday;
        int thursday;
        int friday;
        int saturday;
        int sunday;

        public int Subjectscheduleid { get => subjectscheduleid; set => subjectscheduleid = value; }
        public int Subjectid { get => subjectid; set => subjectid = value; }
        public int Employeeid { get => employeeid; set => employeeid = value; }
        public int Roomid { get => roomid; set => roomid = value; }
        public string Subjecttype { get => subjecttype; set => subjecttype = value; }
        public string Start { get => start; set => start = value; }
        public string End { get => end; set => end = value; }
        public int Monday { get => monday; set => monday = value; }
        public int Tuesday { get => tuesday; set => tuesday = value; }
        public int Wednesday { get => wednesday; set => wednesday = value; }
        public int Thursday { get => thursday; set => thursday = value; }
        public int Friday { get => friday; set => friday = value; }
        public int Saturday { get => saturday; set => saturday = value; }
        public int Sunday { get => sunday; set => sunday = value; }
        
    }
}
