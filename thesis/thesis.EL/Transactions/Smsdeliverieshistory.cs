using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Transactions
{
    public class Smsdeliverieshistory
    {
        int smsdeliveryhistoryid;
        int attendanceid;
        string deliverydatetime;
        string deliverystatus;

        public int Smsdeliveryhistoryid { get => smsdeliveryhistoryid; set => smsdeliveryhistoryid = value; }
        public int Attendanceid { get => attendanceid; set => attendanceid = value; }
        public string Deliverydatetime { get => deliverydatetime; set => deliverydatetime = value; }
        public string Deliverystatus { get => deliverystatus; set => deliverystatus = value; }
    }
}
