using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Transactions
{
    public class Sms
    {
        DL.Transactions.Sms smsDL = new DL.Transactions.Sms();

        public DataTable List()
        {

            return smsDL.List();

        }
        public long Insert(EL.Transactions.Sms smsEL)
        {
            return smsDL.Insert(smsEL);
        }

        public Boolean Update(EL.Transactions.Sms smsEL)
        {
            return smsDL.Update(smsEL);
        }
    }
}
