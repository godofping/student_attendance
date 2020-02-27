using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Transactions
{
    public class Sms
    {
        int smsid;
        int attendanceid;
        string message;
        string studentcontactperson;
        string studentcontactpersonphonenumber;
        string smsstatus;

        public int Smsid { get => smsid; set => smsid = value; }
        public int Attendanceid { get => attendanceid; set => attendanceid = value; }
        public string Message { get => message; set => message = value; }
        public string Studentcontactperson { get => studentcontactperson; set => studentcontactperson = value; }
        public string Studentcontactpersonphonenumber { get => studentcontactpersonphonenumber; set => studentcontactpersonphonenumber = value; }
        public string Smsstatus { get => smsstatus; set => smsstatus = value; }
    }
}
