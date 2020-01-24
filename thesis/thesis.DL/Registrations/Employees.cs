using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.DL.Registrations
{
    public class Employees
    {
        public DataTable List(String keyword)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from employees where employeefirstname like @keyword or employeemiddlename like @keyword or employeelastname like @keyword or username like @keyword or accounttype like @keyword order by employeelastname,  employeefirstname, employeemiddlename asc";

                cmd.Parameters.AddWithValue("@keyword", keyword + "%");
                return methods.executeQuery(cmd);
            }
        }

        public DataTable List(EL.Registrations.Employees employeeEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from employees where employeeid <> @employeeid and employeelastname = @employeelastname and employeefirstname = @employeefirstname and employeemiddlename = @employeemiddlename and username = @username and accounttype = @accounttype";

                cmd.Parameters.AddWithValue("@employeeid", employeeEL.Employeeid);
                cmd.Parameters.AddWithValue("@employeelastname", employeeEL.Employeelastname);
                cmd.Parameters.AddWithValue("@employeefirstname", employeeEL.Employeefirstname);
                cmd.Parameters.AddWithValue("@employeemiddlename", employeeEL.Employeemiddlename);
                cmd.Parameters.AddWithValue("@username", employeeEL.Username);
                cmd.Parameters.AddWithValue("@accounttype", employeeEL.Accounttype);
                
                return methods.executeQuery(cmd);
            }
        }

        public EL.Registrations.Employees Select(EL.Registrations.Employees employeeEL)
        {
            DataTable dt = null;

            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from employees where employeeid = @employeeid";

                cmd.Parameters.AddWithValue("@employeeid", employeeEL.Employeeid);
                dt = methods.executeQuery(cmd);
            }

            if (dt.Rows.Count > 0)
            {
                employeeEL.Employeeid = Convert.ToInt32(dt.Rows[0]["employeeid"]);
                employeeEL.Employeelastname = dt.Rows[0]["employeelastname"].ToString();
                employeeEL.Employeefirstname = dt.Rows[0]["employeefirstname"].ToString();
                employeeEL.Employeemiddlename = dt.Rows[0]["employeemiddlename"].ToString();
                employeeEL.Username = dt.Rows[0]["username"].ToString();
                employeeEL.Password = dt.Rows[0]["password"].ToString();
                employeeEL.Accounttype = dt.Rows[0]["accounttype"].ToString();

                return employeeEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Employees employeeEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into employees set employeelastname = @employeelastname, employeefirstname = @employeefirstname, employeemiddlename = @employeemiddlename, username = @username, password = @password, accounttype = @accounttype";

                cmd.Parameters.AddWithValue("@employeelastname", employeeEL.Employeelastname);
                cmd.Parameters.AddWithValue("@employeefirstname", employeeEL.Employeefirstname);
                cmd.Parameters.AddWithValue("@employeemiddlename", employeeEL.Employeemiddlename);
                cmd.Parameters.AddWithValue("@username", employeeEL.Username);
                cmd.Parameters.AddWithValue("@password", employeeEL.Password);
                cmd.Parameters.AddWithValue("@accounttype", employeeEL.Accounttype);
                return methods.executeNonQueryLong(cmd);
            }
        }

        public Boolean Update(EL.Registrations.Employees employeeEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "update employees set employeelastname = @employeelastname, employeefirstname = @employeefirstname, employeemiddlename = @employeemiddlename, username = @username, password = @password, accounttype = @accounttype where employeeid = @employeeid";

                cmd.Parameters.AddWithValue("@employeeid", employeeEL.Employeeid);
                cmd.Parameters.AddWithValue("@employeelastname", employeeEL.Employeelastname);
                cmd.Parameters.AddWithValue("@employeefirstname", employeeEL.Employeefirstname);
                cmd.Parameters.AddWithValue("@employeemiddlename", employeeEL.Employeemiddlename);
                cmd.Parameters.AddWithValue("@username", employeeEL.Username);
                cmd.Parameters.AddWithValue("@password", employeeEL.Password);
                cmd.Parameters.AddWithValue("@accounttype", employeeEL.Accounttype);

                return methods.executeNonQueryBool(cmd);
            }
        }

        public Boolean Delete(EL.Registrations.Employees employeeEL)
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "delete from employees where employeeid = @employeeid";

                cmd.Parameters.AddWithValue("@employeeid", employeeEL.Employeeid);
                return methods.executeNonQueryBool(cmd);
            }
        }
    }
}
