using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Transactions
{
    public class Attendances
    {
        public DataTable CheckIfHasAttendance(EL.Transactions.Attendances attendanceEL)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from attendances where studentsubjectenrollmentid = @studentsubjectenrollmentid and ";

                cmd.Parameters.AddWithValue("@studentsubjectenrollmentid", attendanceEL.Studentsubjectenrollmentid);
                return methods.executeQuery(cmd);
            }
        }


        public long Insert(EL.Transactions.Attendances attendanceEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into attendances set studentsubjectenrollmentid = @studentsubjectenrollmentid, attendanceintime = @attendanceintime, attendanceouttime = @attendanceouttime, status = @status";

                cmd.Parameters.AddWithValue("@studentsubjectenrollmentid", attendanceEL.Studentsubjectenrollmentid);
                cmd.Parameters.AddWithValue("@attendanceintime", attendanceEL.Attendanceintime);
                cmd.Parameters.AddWithValue("@attendanceouttime", attendanceEL.Attendanceouttime);
                cmd.Parameters.AddWithValue("@status", attendanceEL.Status);
                return methods.executeNonQueryLong(cmd);
            }
        }
    }
}
