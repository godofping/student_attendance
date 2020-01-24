using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Employees
    {
        int employeeid;
        string employeefirstname;
        string employeemiddlename;
        string employeelastname;
        string username;
        string password;
        string accounttype;

        public int Employeeid { get => employeeid; set => employeeid = value; }
        public string Employeefirstname { get => employeefirstname; set => employeefirstname = value; }
        public string Employeemiddlename { get => employeemiddlename; set => employeemiddlename = value; }
        public string Employeelastname { get => employeelastname; set => employeelastname = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Accounttype { get => accounttype; set => accounttype = value; }
    }
}
