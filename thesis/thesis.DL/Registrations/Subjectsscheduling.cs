using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace thesis.DL.Registrations
{
    public class Subjectsscheduling
    {

        public DataTable List(String keyword)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from subjectsscheduling_view where subject like @keyword or employeefullname like @keyword or roombuilding like @keyword or time like @keyword ";

                cmd.Parameters.AddWithValue("@keyword", keyword + "%");
                return methods.executeQuery(cmd);
            }

        }


        public DataTable List(String keyword, int id)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from subjectsscheduling_view where (subject like @keyword or employeefullname like @keyword or roombuilding like @keyword or time like @keyword ) and employeeid = @id";

                cmd.Parameters.AddWithValue("@keyword", keyword + "%");
                cmd.Parameters.AddWithValue("@id", id);
                return methods.executeQuery(cmd);
            }

        }



        public DataTable List(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from subjectsscheduling where subjectscheduleid <> @subjectscheduleid and subjectid = @subjectid and roomid = @roomid and employeeid = @employeeid and start = @start and end = @end and monday = @monday and tuesday = @tuesday and wednesday = @wednesday and thursday = @thursday and friday = @friday and saturday = @saturday and sunday = @sunday";

                cmd.Parameters.AddWithValue("@subjectscheduleid", subjectschedulingEL.Subjectscheduleid);
                cmd.Parameters.AddWithValue("@subjectid", subjectschedulingEL.Subjectid);
                cmd.Parameters.AddWithValue("@roomid", subjectschedulingEL.Roomid);
                cmd.Parameters.AddWithValue("@employeeid", subjectschedulingEL.Employeeid);
                cmd.Parameters.AddWithValue("@start", subjectschedulingEL.Start);
                cmd.Parameters.AddWithValue("@end", subjectschedulingEL.End);
                cmd.Parameters.AddWithValue("@monday", subjectschedulingEL.Monday);
                cmd.Parameters.AddWithValue("@tuesday", subjectschedulingEL.Tuesday);
                cmd.Parameters.AddWithValue("@wednesday", subjectschedulingEL.Wednesday);
                cmd.Parameters.AddWithValue("@thursday", subjectschedulingEL.Thursday);
                cmd.Parameters.AddWithValue("@friday", subjectschedulingEL.Friday);
                cmd.Parameters.AddWithValue("@saturday", subjectschedulingEL.Saturday);
                cmd.Parameters.AddWithValue("@sunday", subjectschedulingEL.Sunday);
                return methods.executeQuery(cmd);
            }
        }

        public DataTable ListTeacherSchedule(string val)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select subjectscheduleid, concat(subject, ' ', time, ' ', scheddays) as subjectschedule from subjectsschedule_converted_view where employeeid = @val";

                cmd.Parameters.AddWithValue("@val",val);

                return methods.executeQuery(cmd);
            }
        }

        public DataTable List()
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM subjects WHERE subjectid IN (SELECT subjectid FROM subjectsscheduling)";

                return methods.executeQuery(cmd);
            }

        }


        public DataTable GetInformation(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {

            using (var cmd = new MySqlCommand())
            {

                cmd.CommandText = "SELECT * FROM subjectsschedule_converted_view where subjectscheduleid = @subjectscheduleid";
                cmd.Parameters.AddWithValue("@subjectscheduleid", subjectschedulingEL.Subjectscheduleid);


                return methods.executeQuery(cmd);
            }

        }

        public DataTable CheckCurrentSchedule()
        {
            var day = DateTime.Now.ToString("dddd");
            var time = DateTime.Now.ToString("HH:mm:ss");


            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM subjectsschedule_converted_view WHERE scheddays like @day and @time between startc AND endc";
                cmd.Parameters.AddWithValue("@day", "%" + day + "%");
                cmd.Parameters.AddWithValue("@time", time);

                return methods.executeQuery(cmd);
            }

        }

        public EL.Registrations.Subjectsscheduling Select(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {

            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from subjectsscheduling where subjectscheduleid = @subjectscheduleid";

                cmd.Parameters.AddWithValue("@subjectscheduleid", subjectschedulingEL.Subjectscheduleid);

                dt = methods.executeQuery(cmd);
            }

            if (dt.Rows.Count > 0)
            {
                subjectschedulingEL.Subjectscheduleid = Convert.ToInt32(dt.Rows[0]["subjectscheduleid"]);
                subjectschedulingEL.Subjectid = Convert.ToInt32(dt.Rows[0]["subjectid"]);
                subjectschedulingEL.Roomid = Convert.ToInt32(dt.Rows[0]["roomid"]);
                subjectschedulingEL.Employeeid = Convert.ToInt32(dt.Rows[0]["employeeid"]);
                subjectschedulingEL.Start = dt.Rows[0]["start"].ToString();
                subjectschedulingEL.End = dt.Rows[0]["end"].ToString();
                subjectschedulingEL.Monday = Convert.ToInt32(dt.Rows[0]["monday"]);
                subjectschedulingEL.Tuesday = Convert.ToInt32(dt.Rows[0]["tuesday"]);
                subjectschedulingEL.Wednesday = Convert.ToInt32(dt.Rows[0]["wednesday"]);
                subjectschedulingEL.Thursday = Convert.ToInt32(dt.Rows[0]["thursday"]);
                subjectschedulingEL.Friday = Convert.ToInt32(dt.Rows[0]["friday"]);
                subjectschedulingEL.Saturday = Convert.ToInt32(dt.Rows[0]["saturday"]);
                subjectschedulingEL.Sunday = Convert.ToInt32(dt.Rows[0]["sunday"]);

                return subjectschedulingEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into subjectsscheduling set subjectid = @subjectid, roomid = @roomid, employeeid = @employeeid, start = @start, end = @end, monday = @monday, tuesday = @tuesday, wednesday = @wednesday, thursday = @thursday, friday = @friday, saturday = @saturday, sunday = @sunday";

                cmd.Parameters.AddWithValue("@subjectid", subjectschedulingEL.Subjectid);
                cmd.Parameters.AddWithValue("@roomid", subjectschedulingEL.Roomid);
                cmd.Parameters.AddWithValue("@employeeid", subjectschedulingEL.Employeeid);
                cmd.Parameters.AddWithValue("@start", subjectschedulingEL.Start);
                cmd.Parameters.AddWithValue("@end", subjectschedulingEL.End);
                cmd.Parameters.AddWithValue("@monday", subjectschedulingEL.Monday);
                cmd.Parameters.AddWithValue("@tuesday", subjectschedulingEL.Tuesday);
                cmd.Parameters.AddWithValue("@wednesday", subjectschedulingEL.Wednesday);
                cmd.Parameters.AddWithValue("@thursday", subjectschedulingEL.Thursday);
                cmd.Parameters.AddWithValue("@friday", subjectschedulingEL.Friday);
                cmd.Parameters.AddWithValue("@saturday", subjectschedulingEL.Saturday);
                cmd.Parameters.AddWithValue("@sunday", subjectschedulingEL.Sunday);


                return methods.executeNonQueryLong(cmd);
            }
        }

        public Boolean Update(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update subjectsscheduling set subjectid = @subjectid, roomid = @roomid, employeeid = @employeeid, start = @start, end = @end, monday = @monday, tuesday = @tuesday, wednesday = @wednesday, thursday = @thursday, friday = @friday, saturday = @saturday, sunday = @sunday where subjectscheduleid = @subjectscheduleid";

                cmd.Parameters.AddWithValue("@subjectscheduleid", subjectschedulingEL.Subjectscheduleid);
                cmd.Parameters.AddWithValue("@subjectid", subjectschedulingEL.Subjectid);
                cmd.Parameters.AddWithValue("@roomid", subjectschedulingEL.Roomid);
                cmd.Parameters.AddWithValue("@employeeid", subjectschedulingEL.Employeeid);
                cmd.Parameters.AddWithValue("@start", subjectschedulingEL.Start);
                cmd.Parameters.AddWithValue("@end", subjectschedulingEL.End);
                cmd.Parameters.AddWithValue("@monday", subjectschedulingEL.Monday);
                cmd.Parameters.AddWithValue("@tuesday", subjectschedulingEL.Tuesday);
                cmd.Parameters.AddWithValue("@wednesday", subjectschedulingEL.Wednesday);
                cmd.Parameters.AddWithValue("@thursday", subjectschedulingEL.Thursday);
                cmd.Parameters.AddWithValue("@friday", subjectschedulingEL.Friday);
                cmd.Parameters.AddWithValue("@saturday", subjectschedulingEL.Saturday);
                cmd.Parameters.AddWithValue("@sunday", subjectschedulingEL.Sunday);

                return methods.executeNonQueryBool(cmd);
            }
        }

        public Boolean Delete(EL.Registrations.Subjectsscheduling subjectschedulingEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "delete from subjectsscheduling where subjectscheduleid = @subjectscheduleid";

                cmd.Parameters.AddWithValue("@subjectscheduleid", subjectschedulingEL.Subjectscheduleid);
                return methods.executeNonQueryBool(cmd);
            }
        }
    }
}
