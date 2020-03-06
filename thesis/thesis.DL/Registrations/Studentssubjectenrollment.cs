using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Registrations
{
    public class Studentssubjectenrollment
    {
        public DataTable List(int id)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from studentssubjectenrollment_view where subjectscheduleid = @id";

                cmd.Parameters.AddWithValue("@id", id);
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List(EL.Registrations.Studentssubjectenrollment studentsubjectenrollmentEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from studentssubjectenrollment where studentsubjectenrollmentid <> @studentsubjectenrollmentid and studentid = @studentid and subjectscheduleid = @subjectscheduleid and seatid = @seatid and isdrop = @isdrop";

                cmd.Parameters.AddWithValue("@studentsubjectenrollmentid", studentsubjectenrollmentEL.Studentsubjectenrollmentid);
                cmd.Parameters.AddWithValue("@studentid", studentsubjectenrollmentEL.Studentid);
                cmd.Parameters.AddWithValue("@subjectscheduleid", studentsubjectenrollmentEL.Subjectscheduleid);
                cmd.Parameters.AddWithValue("@seatid", studentsubjectenrollmentEL.Seatid);
                cmd.Parameters.AddWithValue("@isdrop", studentsubjectenrollmentEL.Isdrop);
                return methods.executeQuery(cmd);
            }
        }


        public DataTable ListOfStudents(EL.Registrations.Studentssubjectenrollment studentsubjectenrollmentEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from studentssubjectenrollment where subjectscheduleid = @subjectscheduleid";

                cmd.Parameters.AddWithValue("@studentsubjectenrollmentid", studentsubjectenrollmentEL.Studentsubjectenrollmentid);
                cmd.Parameters.AddWithValue("@studentid", studentsubjectenrollmentEL.Studentid);
                cmd.Parameters.AddWithValue("@subjectscheduleid", studentsubjectenrollmentEL.Subjectscheduleid);
                cmd.Parameters.AddWithValue("@seatid", studentsubjectenrollmentEL.Seatid);
                cmd.Parameters.AddWithValue("@isdrop", studentsubjectenrollmentEL.Isdrop);
                return methods.executeQuery(cmd);
            }
        }

        public DataTable ListOfStudentsSeatAssignment(int id)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select studentfullname, seat,studentimage from studentssubjectenrollment_view where subjectscheduleid = @subjectscheduleid order by studentfullname asc";

                cmd.Parameters.AddWithValue("@subjectscheduleid", id);

                return methods.executeQuery(cmd);
            }
        }

        public EL.Registrations.Studentssubjectenrollment Select(EL.Registrations.Studentssubjectenrollment studentsubjectenrollmentEL)
        {
            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from studentssubjectenrollment where buildingid = @buildingid";

                cmd.Parameters.AddWithValue("@studentsubjectenrollmentid", studentsubjectenrollmentEL.Studentsubjectenrollmentid);
                dt = methods.executeQuery(cmd);
            }

            if (dt.Rows.Count > 0)
            {
                studentsubjectenrollmentEL.Studentsubjectenrollmentid = Convert.ToInt32(dt.Rows[0]["studentsubjectenrollmentid"]);
                studentsubjectenrollmentEL.Studentid = Convert.ToInt32(dt.Rows[0]["studentid"]);
                studentsubjectenrollmentEL.Subjectscheduleid = Convert.ToInt32(dt.Rows[0]["subjectscheduleid"]);
                studentsubjectenrollmentEL.Seatid = Convert.ToInt32(dt.Rows[0]["seatid"]);
                studentsubjectenrollmentEL.Isdrop = Convert.ToInt32(dt.Rows[0]["isdrop"]);

                return studentsubjectenrollmentEL;
            }
            else
            {
                return null;
            }
        }


        public EL.Registrations.Studentssubjectenrollment ReturnDetails(int studentid, int subjectscheduleid)
        {
            DataTable dt = null;
            var studentsubjectenrollmentEL = new EL.Registrations.Studentssubjectenrollment();

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from studentssubjectenrollment where studentid = @studentid and subjectscheduleid = @subjectscheduleid";

                cmd.Parameters.AddWithValue("@studentid", studentid);
                cmd.Parameters.AddWithValue("@subjectscheduleid", subjectscheduleid);
                dt = methods.executeQuery(cmd);
            }

            if (dt.Rows.Count > 0)
            {
                studentsubjectenrollmentEL.Studentsubjectenrollmentid = Convert.ToInt32(dt.Rows[0]["studentsubjectenrollmentid"]);
                studentsubjectenrollmentEL.Studentid = Convert.ToInt32(dt.Rows[0]["studentid"]);
                studentsubjectenrollmentEL.Subjectscheduleid = Convert.ToInt32(dt.Rows[0]["subjectscheduleid"]);
                studentsubjectenrollmentEL.Seatid = Convert.ToInt32(dt.Rows[0]["seatid"]);
                studentsubjectenrollmentEL.Isdrop = Convert.ToInt32(dt.Rows[0]["isdrop"]);

                return studentsubjectenrollmentEL;
            }
            else
            {
                return null;
            }
        }

        public bool IfStudentEnrolled(int id)
        {
            

            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from studentssubjectenrollment where studentid = @id";

                cmd.Parameters.AddWithValue("@id", id);
                dt = methods.executeQuery(cmd);
            }

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public long Insert(EL.Registrations.Studentssubjectenrollment studentsubjectenrollmentEL)
        { 
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into studentssubjectenrollment set studentid = @studentid, subjectscheduleid = @subjectscheduleid, seatid = @seatid, isdrop = @isdrop";

                cmd.Parameters.AddWithValue("@studentid", studentsubjectenrollmentEL.Studentid);
                cmd.Parameters.AddWithValue("@subjectscheduleid", studentsubjectenrollmentEL.Subjectscheduleid);
                cmd.Parameters.AddWithValue("@seatid", studentsubjectenrollmentEL.Seatid);
                cmd.Parameters.AddWithValue("@isdrop", studentsubjectenrollmentEL.Isdrop);

                return methods.executeNonQueryLong(cmd);
            }
        }

        public Boolean Update(EL.Registrations.Studentssubjectenrollment studentsubjectenrollmentEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update studentssubjectenrollment set studentid = @studentid, subjectscheduleid = @subjectscheduleid, seatid = @seatid, isdrop = @isdrop where studentsubjectenrollmentid = @studentsubjectenrollmentid";

                cmd.Parameters.AddWithValue("@studentsubjectenrollmentid", studentsubjectenrollmentEL.Studentsubjectenrollmentid);
                cmd.Parameters.AddWithValue("@studentid", studentsubjectenrollmentEL.Studentid);
                cmd.Parameters.AddWithValue("@subjectscheduleid", studentsubjectenrollmentEL.Subjectscheduleid);
                cmd.Parameters.AddWithValue("@seatid", studentsubjectenrollmentEL.Seatid);
                cmd.Parameters.AddWithValue("@isdrop", studentsubjectenrollmentEL.Isdrop);
                return methods.executeNonQueryBool(cmd);
            }
        }

        public Boolean Delete(EL.Registrations.Studentssubjectenrollment studentsubjectenrollmentEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "delete from studentssubjectenrollment where studentsubjectenrollmentid = @studentsubjectenrollmentid";

                cmd.Parameters.AddWithValue("@studentsubjectenrollmentid", studentsubjectenrollmentEL.Studentsubjectenrollmentid);
                return methods.executeNonQueryBool(cmd);
            }
        }
    }
}
