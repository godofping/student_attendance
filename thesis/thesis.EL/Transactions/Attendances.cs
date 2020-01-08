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
        int studentsubjectenrolledid;
        string attendancedatetime;
        string inorout;
        string status;

        public int Attendanceid { get => attendanceid; set => attendanceid = value; }
        public int Studentsubjectenrolledid { get => studentsubjectenrolledid; set => studentsubjectenrolledid = value; }
        public string Attendancedatetime { get => attendancedatetime; set => attendancedatetime = value; }
        public string Inorout { get => inorout; set => inorout = value; }
        public string Status { get => status; set => status = value; }
    }
}
