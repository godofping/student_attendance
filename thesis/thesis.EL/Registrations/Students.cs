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
        string studentidnumber;
        string studentfirstname;
        string studentmiddlename;
        string studentlastname;
        string yearlevel;
        string studentphonenumber;
        string studentrfid;
        byte[] studentimage;
        string studentcontactperson;
        string studentcontactpersonphonenumber;

        public int Studentid { get => studentid; set => studentid = value; }
        public string Studentidnumber { get => studentidnumber; set => studentidnumber = value; }
        public string Studentfirstname { get => studentfirstname; set => studentfirstname = value; }
        public string Studentmiddlename { get => studentmiddlename; set => studentmiddlename = value; }
        public string Studentlastname { get => studentlastname; set => studentlastname = value; }
        public string Yearlevel { get => yearlevel; set => yearlevel = value; }
        public string Studentphonenumber { get => studentphonenumber; set => studentphonenumber = value; }
        public string Studentrfid { get => studentrfid; set => studentrfid = value; }
        public byte[] Studentimage { get => studentimage; set => studentimage = value; }
        public string Studentcontactperson { get => studentcontactperson; set => studentcontactperson = value; }
        public string Studentcontactpersonphonenumber { get => studentcontactpersonphonenumber; set => studentcontactpersonphonenumber = value; }
    }
}
