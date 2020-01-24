using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Registrations
{
    public class Buildings
    {
        public DataTable List(String keyword)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from buildings where building like @keyword order by building asc";

                cmd.Parameters.AddWithValue("@keyword", keyword + "%");
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List(EL.Registrations.Buildings buildingEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from buildings where buildingid <> @buildingid and building = @building";

                cmd.Parameters.AddWithValue("@buildingid", buildingEL.Buildingid);
                cmd.Parameters.AddWithValue("@building", buildingEL.Building);
                return methods.executeQuery(cmd);
            }
        }

        public EL.Registrations.Buildings Select(EL.Registrations.Buildings buildingEL)
        {
            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from buildings where buildingid = @buildingid";

                cmd.Parameters.AddWithValue("@buildingid", buildingEL.Buildingid);
                dt = methods.executeQuery(cmd);
            }

            if (dt.Rows.Count > 0)
            {
                buildingEL.Buildingid = Convert.ToInt32(dt.Rows[0]["buildingid"]);
                buildingEL.Building = dt.Rows[0]["building"].ToString();

                return buildingEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Buildings buildingEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into buildings set building = @building";

                cmd.Parameters.AddWithValue("@building", buildingEL.Building);
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
