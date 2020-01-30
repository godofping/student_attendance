using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Registrations
{
    public class Employees
    {
        DL.Registrations.Employees employeeDL = new DL.Registrations.Employees();

        public DataTable Login(EL.Registrations.Employees employeeEL)
        {
            return employeeDL.Login(employeeEL);
        }

        public DataTable List(String keyword)
        {
            return employeeDL.List(keyword);
        }

        public DataTable List(EL.Registrations.Employees employeeEL)
        {
            return employeeDL.List(employeeEL);
        }

        public DataTable List()
        {
            return employeeDL.List();
        }

        public EL.Registrations.Employees Select(EL.Registrations.Employees employeeEL)
        {
            return employeeDL.Select(employeeEL);
        }

        public long Insert(EL.Registrations.Employees employeeEL)
        {
            return employeeDL.Insert(employeeEL);
        }

        public Boolean Update(EL.Registrations.Employees employeeEL)
        {
            return employeeDL.Update(employeeEL);
        }

        public Boolean Delete(EL.Registrations.Employees employeeEL)
        {
            return employeeDL.Delete(employeeEL);
        }
    }
}
