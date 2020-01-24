using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace thesis.DL.Registrations
{
    public class Computers
    {
        public DataTable List(String keyword)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from computers where computer like @keyword order by computer asc";

                cmd.Parameters.AddWithValue("@keyword", keyword + "%");
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List(EL.Registrations.Computers computerEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from computers where computerid <> @computerid and computer = @computer";

                cmd.Parameters.AddWithValue("@computerid", computerEL.Computerid);
                cmd.Parameters.AddWithValue("@computer", computerEL.Computer);
                return methods.executeQuery(cmd);
            }
        }

        public DataTable Availables(EL.Registrations.Computers computerEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM computers WHERE computerid NOT IN (SELECT computerid FROM rooms) OR computerid = @computerid";
                
                cmd.Parameters.AddWithValue("@computerid", computerEL.Computerid);
                return methods.executeQuery(cmd);
            }
        }

        public EL.Registrations.Computers Select(EL.Registrations.Computers computerEL)
        {
            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from computers where computerid = @computerid";

                cmd.Parameters.AddWithValue("@computerid", computerEL.Computerid);
                dt =  methods.executeQuery(cmd);
            }

            if (dt.Rows.Count > 0)
            {
                computerEL.Computerid = Convert.ToInt32(dt.Rows[0]["computerid"]);
                computerEL.Computer = dt.Rows[0]["computer"].ToString();

                return computerEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Computers computerEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into computers set computer = @computer";

                cmd.Parameters.AddWithValue("@computer", computerEL.Computer);
                return methods.executeNonQueryLong(cmd);
            } 
        }

        public Boolean Update(EL.Registrations.Computers computerEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update computers set computer = @computer where computerid = @computerid";

                cmd.Parameters.AddWithValue("@computerid", computerEL.Computerid);
                cmd.Parameters.AddWithValue("@computer", computerEL.Computer);
                return methods.executeNonQueryBool(cmd);
            }
        }

        public Boolean Delete(EL.Registrations.Computers computerEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "delete from computers where computerid = @computerid";

                cmd.Parameters.AddWithValue("@computerid", computerEL.Computerid);
                return methods.executeNonQueryBool(cmd);
            }
        }

        public Boolean Set(EL.Registrations.Computers computerEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update computers set issmsserver = 1 where computerid = @computerid; update computers set issmsserver = 0 where computerid <> @computerid ";

                cmd.Parameters.AddWithValue("@computerid", computerEL.Computerid);
                return methods.executeNonQueryBool(cmd);
            }
        }
    }
}
