using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Registrations
{
    public class Subjects
    {
        public DataTable List(String keyword)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from subjects where subjectcode like @keyword or subjectdescription like @keyword order by subjectcode, subjectdescription asc";

                cmd.Parameters.AddWithValue("@keyword", keyword + "%");
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List(EL.Registrations.Subjects subjectEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from subjects where subjectid <> @subjectid and subjectcode = @subjectcode and subjectdescription = @subjectdescription";

                cmd.Parameters.AddWithValue("@subjectid", subjectEL.Subjectid);
                cmd.Parameters.AddWithValue("@subjectcode", subjectEL.Subjectcode);
                cmd.Parameters.AddWithValue("@subjectdescription", subjectEL.Subjectdescription);
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List()
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT *, CONCAT(subjectcode, ' - ', subjectdescription) AS SUBJECT FROM subjects ORDER BY subject";


                return methods.executeQuery(cmd);
            }
        }

        public EL.Registrations.Subjects Select(EL.Registrations.Subjects subjectEL)
        {
            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from subjects where subjectid = @subjectid";

                cmd.Parameters.AddWithValue("@subjectid", subjectEL.Subjectid);
                dt = methods.executeQuery(cmd);
            }

            if (dt.Rows.Count > 0)
            {
                subjectEL.Subjectid = Convert.ToInt32(dt.Rows[0]["subjectid"]);
                subjectEL.Subjectcode = dt.Rows[0]["subjectcode"].ToString();
                subjectEL.Subjectdescription = dt.Rows[0]["subjectdescription"].ToString();

                return subjectEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Subjects subjectEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into subjects set subjectcode = @subjectcode, subjectdescription = @subjectdescription";

                cmd.Parameters.AddWithValue("@subjectcode", subjectEL.Subjectcode);
                cmd.Parameters.AddWithValue("@subjectdescription", subjectEL.Subjectdescription);
                return methods.executeNonQueryLong(cmd);
            }
        }

        public Boolean Update(EL.Registrations.Subjects subjectEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update subjects set subjectcode = @subjectcode, subjectdescription = @subjectdescription  where subjectid = @subjectid";

                cmd.Parameters.AddWithValue("@subjectid", subjectEL.Subjectid);
                cmd.Parameters.AddWithValue("@subjectcode", subjectEL.Subjectcode);
                cmd.Parameters.AddWithValue("@subjectdescription", subjectEL.Subjectdescription);
                return methods.executeNonQueryBool(cmd);
            }
        }

        public Boolean Delete(EL.Registrations.Subjects subjectEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "delete from subjects where subjectid = @subjectid";

                cmd.Parameters.AddWithValue("@subjectid", subjectEL.Subjectid);
                return methods.executeNonQueryBool(cmd);
            }
        }
    }
}
