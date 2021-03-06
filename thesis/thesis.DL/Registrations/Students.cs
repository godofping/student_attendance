﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Registrations
{
    public class Students
    {
        public DataTable List(String keyword)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from students_view where studentidnumber like @keyword or studentfullname like @keyword or yearlevel like @keyword order by studentfullname asc";

                cmd.Parameters.AddWithValue("@keyword", keyword + "%");
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List(EL.Registrations.Students studentEL)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from students where studentid <> @studentid  and studentidnumber = @studentidnumber and studentfirstname = @studentfirstname and studentmiddlename = @studentmiddlename and studentlastname = @studentlastname and yearlevel = @yearlevel and studentphonenumber = @studentphonenumber and studentrfid = @studentrfid and studentcontactperson = @studentcontactperson and studentcontactpersonphonenumber = @studentcontactpersonphonenumber";

                cmd.Parameters.AddWithValue("@studentid", studentEL.Studentid);
                cmd.Parameters.AddWithValue("@studentidnumber", studentEL.Studentidnumber);
                cmd.Parameters.AddWithValue("@studentfirstname", studentEL.Studentfirstname);
                cmd.Parameters.AddWithValue("@studentmiddlename", studentEL.Studentmiddlename);
                cmd.Parameters.AddWithValue("@studentlastname", studentEL.Studentlastname);
                cmd.Parameters.AddWithValue("@yearlevel", studentEL.Yearlevel);
                cmd.Parameters.AddWithValue("@studentphonenumber", studentEL.Studentphonenumber);
                cmd.Parameters.AddWithValue("@studentrfid", studentEL.Studentrfid);
                cmd.Parameters.AddWithValue("@studentimage", studentEL.Studentimage);
                cmd.Parameters.AddWithValue("@studentcontactperson", studentEL.Studentcontactperson);
                cmd.Parameters.AddWithValue("@studentcontactpersonphonenumber", studentEL.Studentcontactpersonphonenumber);
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List(int id)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from students_view where studentid not in (select studentid from studentssubjectenrollment where subjectscheduleid = @id)";
                cmd.Parameters.AddWithValue("@id", id);
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List()
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from students_complete_view order by studentfullname";

                return methods.executeQuery(cmd);
            }
        }

        public EL.Registrations.Students Select(EL.Registrations.Students studentEL)
        {
            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select* from students where studentid = @studentid";

                cmd.Parameters.AddWithValue("@studentid", studentEL.Studentid);
                dt =  methods.executeQuery(cmd);
            }




            if (dt.Rows.Count > 0)
            {
                studentEL.Studentid = Convert.ToInt32(dt.Rows[0]["studentid"]);
                studentEL.Studentidnumber = dt.Rows[0]["studentidnumber"].ToString();
                studentEL.Studentfirstname = dt.Rows[0]["studentfirstname"].ToString();
                studentEL.Studentmiddlename = dt.Rows[0]["studentmiddlename"].ToString();
                studentEL.Studentlastname = dt.Rows[0]["studentlastname"].ToString();
                studentEL.Yearlevel = dt.Rows[0]["yearlevel"].ToString();
                studentEL.Studentphonenumber = dt.Rows[0]["studentphonenumber"].ToString();
                studentEL.Studentrfid = dt.Rows[0]["studentrfid"].ToString();
                studentEL.Studentimage = (byte[])dt.Rows[0]["studentimage"];
                studentEL.Studentcontactperson = dt.Rows[0]["studentcontactperson"].ToString();
                studentEL.Studentcontactpersonphonenumber = dt.Rows[0]["studentcontactpersonphonenumber"].ToString();

                return studentEL;
            }
            else
            {
                return null;
            }
        }

        public DataTable CheckRFIDAdd(EL.Registrations.Students studentEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select studentrfid from students where studentrfid = @studentrfid";
                cmd.Parameters.AddWithValue("@studentrfid", studentEL.Studentrfid);
                return methods.executeQuery(cmd);
            }
        }

        public DataTable CheckRFIDEdit(EL.Registrations.Students studentEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select studentrfid from students where studentrfid = @studentrfid and studentid <> @studentid";
                cmd.Parameters.AddWithValue("@studentid", studentEL.Studentid);
                cmd.Parameters.AddWithValue("@studentrfid", studentEL.Studentrfid);
                return methods.executeQuery(cmd);
            }
        }

        public EL.Registrations.Students SelectByRFID(int id)
        {
            var studentEL = new EL.Registrations.Students();

            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select* from students where studentrfid = @id";

                cmd.Parameters.AddWithValue("@id", id);
                dt = methods.executeQuery(cmd);
            }


            if (dt.Rows.Count > 0)
            {
                studentEL.Studentid = Convert.ToInt32(dt.Rows[0]["studentid"]);
                studentEL.Studentidnumber = dt.Rows[0]["studentidnumber"].ToString();
                studentEL.Studentfirstname = dt.Rows[0]["studentfirstname"].ToString();
                studentEL.Studentmiddlename = dt.Rows[0]["studentmiddlename"].ToString();
                studentEL.Studentlastname = dt.Rows[0]["studentlastname"].ToString();
                studentEL.Yearlevel = dt.Rows[0]["yearlevel"].ToString();
                studentEL.Studentphonenumber = dt.Rows[0]["studentphonenumber"].ToString();
                studentEL.Studentrfid = dt.Rows[0]["studentrfid"].ToString();
                studentEL.Studentimage = (byte[])dt.Rows[0]["studentimage"];
                studentEL.Studentcontactperson = dt.Rows[0]["studentcontactperson"].ToString();
                studentEL.Studentcontactpersonphonenumber = dt.Rows[0]["studentcontactpersonphonenumber"].ToString();

                return studentEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Students studentEL)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into students set studentidnumber = @studentidnumber, studentfirstname = @studentfirstname, studentmiddlename = @studentmiddlename, studentlastname = @studentlastname, yearlevel = @yearlevel, studentphonenumber = @studentphonenumber, studentrfid = @studentrfid, studentimage = @studentimage, studentcontactperson = @studentcontactperson, studentcontactpersonphonenumber = @studentcontactpersonphonenumber";

                cmd.Parameters.AddWithValue("@studentidnumber", studentEL.Studentidnumber);
                cmd.Parameters.AddWithValue("@studentfirstname", studentEL.Studentfirstname);
                cmd.Parameters.AddWithValue("@studentmiddlename", studentEL.Studentmiddlename);
                cmd.Parameters.AddWithValue("@studentlastname", studentEL.Studentlastname);
                cmd.Parameters.AddWithValue("@yearlevel", studentEL.Yearlevel);
                cmd.Parameters.AddWithValue("@studentphonenumber", studentEL.Studentphonenumber);
                cmd.Parameters.AddWithValue("@studentrfid", studentEL.Studentrfid);
                cmd.Parameters.AddWithValue("@studentimage", studentEL.Studentimage);
                cmd.Parameters.AddWithValue("@studentcontactperson", studentEL.Studentcontactperson);
                cmd.Parameters.AddWithValue("@studentcontactpersonphonenumber", studentEL.Studentcontactpersonphonenumber);
                return methods.executeNonQueryLong(cmd);
            } 
        }

        public Boolean Update(EL.Registrations.Students studentEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update students set studentidnumber = @studentidnumber, studentfirstname = @studentfirstname, studentmiddlename = @studentmiddlename, studentlastname = @studentlastname, yearlevel = @yearlevel, studentphonenumber = @studentphonenumber, studentrfid = @studentrfid, studentimage = @studentimage, studentcontactperson = @studentcontactperson, studentcontactpersonphonenumber = @studentcontactpersonphonenumber where studentid = @studentid";

                cmd.Parameters.AddWithValue("@studentid", studentEL.Studentid);
                cmd.Parameters.AddWithValue("@studentidnumber", studentEL.Studentidnumber);
                cmd.Parameters.AddWithValue("@studentfirstname", studentEL.Studentfirstname);
                cmd.Parameters.AddWithValue("@studentmiddlename", studentEL.Studentmiddlename);
                cmd.Parameters.AddWithValue("@studentlastname", studentEL.Studentlastname);
                cmd.Parameters.AddWithValue("@yearlevel", studentEL.Yearlevel);
                cmd.Parameters.AddWithValue("@studentphonenumber", studentEL.Studentphonenumber);
                cmd.Parameters.AddWithValue("@studentrfid", studentEL.Studentrfid);
                cmd.Parameters.AddWithValue("@studentimage", studentEL.Studentimage);
                cmd.Parameters.AddWithValue("@studentcontactperson", studentEL.Studentcontactperson);
                cmd.Parameters.AddWithValue("@studentcontactpersonphonenumber", studentEL.Studentcontactpersonphonenumber);
                return methods.executeNonQueryBool(cmd);
            }
        }

        public Boolean Delete(EL.Registrations.Students studentEL)
        {

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "delete from students where studentid = @studentid";

                cmd.Parameters.AddWithValue("@studentid", studentEL.Studentid);
                return methods.executeNonQueryBool(cmd);
            }

        }
    }
}
