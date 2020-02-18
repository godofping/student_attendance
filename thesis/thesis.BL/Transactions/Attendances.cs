using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Transactions
{
    public class Attendances
    {
        DL.Transactions.Attendances attendanceDL = new DL.Transactions.Attendances();

        public DataTable CheckIfHasAttendance(EL.Transactions.Attendances attendanceEL)
        {
            return attendanceDL.CheckIfHasAttendance(attendanceEL);
        }

        public long Insert(EL.Transactions.Attendances attendanceEL)
        {
            return attendanceDL.Insert(attendanceEL);
        }
    }
}
