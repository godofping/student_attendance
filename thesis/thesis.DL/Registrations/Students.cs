using MySql.Data.MySqlClient;
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
            keyword = methods.EscapeString(keyword);
            return methods.executeQuery("select * from students_view where studentidnumber like '" + keyword + "%' or studentfirstname like '" + keyword + "%' or studentmiddlename like '" + keyword + "%' or studentlastname like '" + keyword + "%' or yearlevel like '" + keyword + "%' order by studentlastname asc");
        }

        public DataTable List(EL.Registrations.Students studentEL)
        {
            return methods.executeQuery("select * from students where studentid <> '" + studentEL.Studentid + "'  and studentidnumber = '" + studentEL.Studentidnumber + "' and studentfirstname = '" + studentEL.Studentfirstname + "' and studentmiddlename = '" + studentEL.Studentmiddlename + "' and studentlastname = '" + studentEL.Studentlastname + "' and yearlevel = '" + studentEL.Yearlevel + "' and studentrfid = '" + studentEL.Studentid + "' ");
        }

        public EL.Registrations.Students Select(EL.Registrations.Students studentEL)
        {
            DataTable dt = methods.executeQuery("select * from students where studentid = '" + studentEL.Studentid + "'");

            if (dt.Rows.Count > 0)
            {
                studentEL.Studentid = Convert.ToInt32(dt.Rows[0]["studentid"]);
                studentEL.Studentidnumber = dt.Rows[0]["studentidnumber"].ToString();
                studentEL.Studentfirstname = dt.Rows[0]["studentfirstname"].ToString();
                studentEL.Studentmiddlename = dt.Rows[0]["studentmiddlename"].ToString();
                studentEL.Studentlastname = dt.Rows[0]["studentlastname"].ToString();
                studentEL.Yearlevel = dt.Rows[0]["yearlevel"].ToString();
                studentEL.Studentrfid = dt.Rows[0]["studentrfid"].ToString();
                studentEL.Studentimage = (byte[])dt.Rows[0]["studentimage"];

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
                cmd.CommandText = "insert into students set studentidnumber = @studentidnumber, studentfirstname = @studentfirstname, studentmiddlename = @studentmiddlename, studentlastname = @studentlastname, yearlevel = @yearlevel, studentrfid = @studentrfid, studentimage = @studentimage";

                cmd.Parameters.Add("@studentidnumber", studentEL.Studentidnumber);
                cmd.Parameters.Add("@studentfirstname", studentEL.Studentfirstname);
                cmd.Parameters.Add("@studentmiddlename", studentEL.Studentmiddlename);
                cmd.Parameters.Add("@studentlastname", studentEL.Studentlastname);
                cmd.Parameters.Add("@yearlevel", studentEL.Yearlevel);
                cmd.Parameters.Add("@studentrfid", studentEL.Studentrfid);
                cmd.Parameters.Add("@studentimage", studentEL.Studentimage);
                return methods.test(cmd);
            } 
        }

        public Boolean Update(EL.Registrations.Students studentEL)
        {
            studentEL.Studentidnumber = methods.EscapeString(studentEL.Studentidnumber);
            studentEL.Studentfirstname = methods.EscapeString(studentEL.Studentfirstname);
            studentEL.Studentmiddlename = methods.EscapeString(studentEL.Studentmiddlename);
            studentEL.Studentlastname = methods.EscapeString(studentEL.Studentlastname);
            return methods.executeNonQueryBool("update students set studentidnumber = '" + studentEL.Studentidnumber + "', studentfirstname = '" + studentEL.Studentfirstname + "', studentmiddlename = '" + studentEL.Studentmiddlename + "', studentlastname = '" + studentEL.Studentlastname + "', yearlevel = '" + studentEL.Yearlevel + "', studentrfid = '" + studentEL.Studentrfid + "', studentimage = '" + studentEL.Studentimage + "'  where studentid = '" + studentEL.Studentid + "'");
        }

        public Boolean Delete(EL.Registrations.Students studentEL)
        {
            return methods.executeNonQueryBool("delete from students where studentid = '" + studentEL.Studentid + "'");
        }
    }
}
