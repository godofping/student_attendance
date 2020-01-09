using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Registrations
{
    public class Courses
    {
        public DataTable List(String keyword)
        {
            keyword = Helper.EscapeString(keyword);
            return Helper.executeQuery("select * from courses where coursecode like '" + keyword + "%' or coursedescription like '" + keyword + "%' order by coursecode asc");
        }

        public DataTable List(EL.Registrations.Courses courseEL)
        {
            return Helper.executeQuery("select * from courses where courseid <> '" + courseEL.Courseid + "' and coursecode = '" + courseEL.Coursecode + "' and coursedescription = '" + courseEL.Coursedescription + "'");
        }

        public EL.Registrations.Courses Select(EL.Registrations.Courses courseEL)
        {
            DataTable dt = Helper.executeQuery("select * from courses where courseid = '" + courseEL.Courseid + "'");

            if (dt.Rows.Count > 0)
            {
                courseEL.Courseid = Convert.ToInt32(dt.Rows[0]["courseid"]);
                courseEL.Coursecode = dt.Rows[0]["coursecode"].ToString();
                courseEL.Coursedescription = dt.Rows[0]["coursedescription"].ToString();

                return courseEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Courses courseEL)
        {
            courseEL.Coursecode = Helper.EscapeString(courseEL.Coursecode);
            courseEL.Coursedescription = Helper.EscapeString(courseEL.Coursedescription);
            return Helper.executeNonQueryLong("insert into courses (coursecode, coursedescription) values ('" + courseEL.Coursecode + "', '" + courseEL.Coursedescription + "')");
        }

        public Boolean Update(EL.Registrations.Courses courseEL)
        {
            courseEL.Coursecode = Helper.EscapeString(courseEL.Coursecode);
            courseEL.Coursedescription = Helper.EscapeString(courseEL.Coursedescription);
            return Helper.executeNonQueryBool("update courses set coursecode = '" + courseEL.Coursecode + "', coursedescription = '" + courseEL.Coursedescription + "' where courseid = '" + courseEL.Courseid + "'");
        }

        public Boolean Delete(EL.Registrations.Courses courseEL)
        {
            return Helper.executeNonQueryBool("delete from courses where courseid = '" + courseEL.Courseid + "'");
        }
    }
}
