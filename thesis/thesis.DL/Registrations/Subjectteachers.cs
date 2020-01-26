using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Registrations
{
    public class Subjectteachers
    {
        public DataTable List(String keyword)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from subjectteachers_view where subjectcode like @keyword or subjectdescription like @keyword or employeefullname like @keyword or accounttype like @keyword order by subjectcode, subjectdescription asc";

                cmd.Parameters.AddWithValue("@keyword", keyword + "%");
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List(EL.Registrations.Subjectteachers subjectteacherEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from subjectteachers_view where subjectteacherid <> @subjectteacherid and employeeid = @employeeid and subjectid = @subjectid";

                cmd.Parameters.AddWithValue("@employeeid", subjectteacherEL.Employeeid);
                cmd.Parameters.AddWithValue("@subjectid", subjectteacherEL.Subjectid);
                return methods.executeQuery(cmd);
            }
        }

        public EL.Registrations.Subjectteachers Select(EL.Registrations.Subjectteachers subjectteacherEL)
        {
            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from subjectteachers where subjectteacherid = @subjectteacherid";

                cmd.Parameters.AddWithValue("@subjectteacherid", subjectteacherEL.Subjectteacherid);
                dt = methods.executeQuery(cmd);
            }

            if (dt.Rows.Count > 0)
            {
                subjectteacherEL.Subjectteacherid = Convert.ToInt32(dt.Rows[0]["subjectteacherid"]);
                subjectteacherEL.Employeeid = Convert.ToInt32(dt.Rows[0]["employeeid"]);
                subjectteacherEL.Subjectid = Convert.ToInt32(dt.Rows[0]["subjectid"]);

                return subjectteacherEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Subjectteachers subjectteacherEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into subjectteachers set employeeid = @employeeid, subjectid = @subjectid";

                cmd.Parameters.AddWithValue("@employeeid", subjectteacherEL.Employeeid);
                return methods.executeNonQueryLong(cmd);
            }
        }

        public Boolean Update(EL.Registrations.Buildings buildingEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update buildings set building = @building where buildingid = @buildingid";

                cmd.Parameters.AddWithValue("@buildingid", buildingEL.Buildingid);
                cmd.Parameters.AddWithValue("@building", buildingEL.Building);
                return methods.executeNonQueryBool(cmd);
            }
        }

        public Boolean Delete(EL.Registrations.Buildings buildingEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "delete from buildings where buildingid = @buildingid";

                cmd.Parameters.AddWithValue("@buildingid", buildingEL.Buildingid);
                return methods.executeNonQueryBool(cmd);
            }
        }
    }
}
