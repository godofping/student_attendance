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
        public EL.Transactions.Attendances Select(EL.Transactions.Attendances attendanceEL)
        {

            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from attendances where studentsubjectenrollmentid = @studentsubjectenrollmentid and @createdat between @attendanceintime and @attendanceouttime";

                cmd.Parameters.AddWithValue("@studentsubjectenrollmentid", attendanceEL.Studentsubjectenrollmentid);
                cmd.Parameters.AddWithValue("@attendanceintime", attendanceEL.Attendanceintime);
                cmd.Parameters.AddWithValue("@attendanceouttime", attendanceEL.Attendanceouttime);
                cmd.Parameters.AddWithValue("@createdat", attendanceEL.Createdat);

                dt = methods.executeQuery(cmd);
            }

            if (dt.Rows.Count > 0)
            {
                attendanceEL.Attendanceid = Convert.ToInt32(dt.Rows[0]["attendanceid"]);
                attendanceEL.Studentsubjectenrollmentid = Convert.ToInt32(dt.Rows[0]["studentsubjectenrollmentid"]);
                attendanceEL.Attendanceintime = dt.Rows[0]["attendanceintime"].ToString();
                attendanceEL.Attendanceouttime = dt.Rows[0]["attendanceouttime"].ToString();
                attendanceEL.Createdat = dt.Rows[0]["createdat"].ToString();
                attendanceEL.Status = dt.Rows[0]["status"].ToString();


                return attendanceEL;
            }
            else
            {
                return null;
            }
        }


        public DataTable CheckIfHasAttendance(EL.Transactions.Attendances attendanceEL)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from attendances where studentsubjectenrollmentid = @studentsubjectenrollmentid and @createdat between @attendanceintime and @attendanceouttime";

                cmd.Parameters.AddWithValue("@studentsubjectenrollmentid", attendanceEL.Studentsubjectenrollmentid);
                cmd.Parameters.AddWithValue("@attendanceintime", attendanceEL.Attendanceintime);
                cmd.Parameters.AddWithValue("@attendanceouttime", attendanceEL.Attendanceouttime);
                cmd.Parameters.AddWithValue("@createdat", attendanceEL.Createdat);
                return methods.executeQuery(cmd);
            }
        }


        public DataTable ListAttendanceAdmin(EL.Transactions.Attendances attendanceEL)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select attendanceid, studentsubjectenrollmentid, createdat, subjectscheduleid, studentfullname, attendanceintime, attendanceouttime,status from students_attendance_view where subjectscheduleid = @subjectscheduleid and createdat between @attendanceintime and @attendanceouttime and (studentfullname like @status or status like @status) order by studentfullname";

                cmd.Parameters.AddWithValue("@subjectscheduleid", attendanceEL.Studentsubjectenrollmentid);
                cmd.Parameters.AddWithValue("@attendanceintime", attendanceEL.Attendanceintime);
                cmd.Parameters.AddWithValue("@attendanceouttime", attendanceEL.Attendanceouttime);
                cmd.Parameters.AddWithValue("@status", attendanceEL.Status + "%");
                return methods.executeQuery(cmd);
            }
        }


        public DataTable List()
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from students_attendance_view";
                return methods.executeQuery(cmd);
            }
        }

        public DataTable ListAttendanceByDate(EL.Transactions.Attendances attendanceEL)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from students_attendance_view where subjectscheduleid = @subjectscheduleid and createdat like @createdat order by studentfullname";

                cmd.Parameters.AddWithValue("@subjectscheduleid", attendanceEL.Studentsubjectenrollmentid);
                cmd.Parameters.AddWithValue("@createdat", "%" + attendanceEL.Createdat + "%");
                return methods.executeQuery(cmd);
            }
        }

        public long Insert(EL.Transactions.Attendances attendanceEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into attendances set studentsubjectenrollmentid = @studentsubjectenrollmentid, attendanceintime = @attendanceintime, attendanceouttime = @attendanceouttime, createdat = @createdat, status = @status";

                cmd.Parameters.AddWithValue("@studentsubjectenrollmentid", attendanceEL.Studentsubjectenrollmentid);
                cmd.Parameters.AddWithValue("@attendanceintime", attendanceEL.Attendanceintime);
                cmd.Parameters.AddWithValue("@attendanceouttime", attendanceEL.Attendanceouttime);
                cmd.Parameters.AddWithValue("@createdat", attendanceEL.Createdat);
                cmd.Parameters.AddWithValue("@status", attendanceEL.Status);
                return methods.executeNonQueryLong(cmd);
            }
        }


        public Boolean AttendanceIn(EL.Transactions.Attendances attendanceEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update attendances set attendanceintime = @attendanceintime, status = @status where attendanceid = @attendanceid";

                cmd.Parameters.AddWithValue("@attendanceid", attendanceEL.Attendanceid);
                cmd.Parameters.AddWithValue("@attendanceintime", attendanceEL.Attendanceintime);
                cmd.Parameters.AddWithValue("@status", attendanceEL.Status);
                return methods.executeNonQueryBool(cmd);
            }
        }

        public Boolean AttendanceOut(EL.Transactions.Attendances attendanceEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update attendances set attendanceouttime = @attendanceouttime, status = @status where attendanceid = @attendanceid";

                cmd.Parameters.AddWithValue("@attendanceid", attendanceEL.Attendanceid);
                cmd.Parameters.AddWithValue("@attendanceouttime", attendanceEL.Attendanceouttime);
                cmd.Parameters.AddWithValue("@status", attendanceEL.Status);
                return methods.executeNonQueryBool(cmd);
            }
        }
    }
}
