using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace thesis.DL
{
    public class Helper
    {
        public static string ConnectionString { get { return "Server=localhost;port=3306;UID=root;PWD=;database=students_attendance_db;Convert Zero Datetime=True"; } }
       

        public static long executeNonQueryLong(string _Query)
        {

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                long rslt = 0;
                MySqlCommand cmd = new MySqlCommand();
                MySqlTransaction trans = null;
                try
                {
                    cmd.CommandTimeout = 0;
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = _Query;
                    cmd.Connection = con;

                    trans = con.BeginTransaction();
                    try
                    {
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            rslt = cmd.LastInsertedId;
                        }
                        trans.Commit();

                    }
                    catch (Exception)
                    {
                        rslt = 0;
                        trans.Rollback();

                    }
                    return rslt;
                }
                finally
                {
                    trans = null;
                }
            }
        }

        public static bool executeNonQueryBool(String _Query)
        {
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                bool rslt = false;
                MySqlCommand cmd = new MySqlCommand();
                MySqlTransaction trans = null;
                try
                {
                    cmd.CommandTimeout = 0;
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = _Query;
                    cmd.Connection = con;

                    trans = con.BeginTransaction();
                    try
                    {
                        if (cmd.ExecuteNonQuery() >= 1)
                        {
                            rslt = true;
                        }
                        trans.Commit();

                    }
                    catch (Exception)
                    {
                        rslt = false;
                        trans.Rollback();
                       
                    }
                    return rslt;
                }
                finally
                {
                    trans = null;
                }
            }
        }
        public static System.Data.DataTable executeQuery(String _Query)
        {
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                DataTable dt = new DataTable();
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = _Query;
                    cmd.Connection = con;
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
