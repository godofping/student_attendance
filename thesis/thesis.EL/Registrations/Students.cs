using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Students
    {
        int studentid;
        int courseid;
        string studentidnumber;
        string studentfirstname;
        string studentmiddlename;
        string studentlastname;
        string rfid;
        string imagelocation;

        public int Studentid { get => studentid; set => studentid = value; }
        public int Courseid { get => courseid; set => courseid = value; }
        public string Studentidnumber { get => studentidnumber; set => studentidnumber = value; }
        public string Studentfirstname { get => studentfirstname; set => studentfirstname = value; }
        public string Studentmiddlename { get => studentmiddlename; set => studentmiddlename = value; }
        public string Studentlastname { get => studentlastname; set => studentlastname = value; }
        public string Rfid { get => rfid; set => rfid = value; }
        public string Imagelocation { get => imagelocation; set => imagelocation = value; }
    }
}
