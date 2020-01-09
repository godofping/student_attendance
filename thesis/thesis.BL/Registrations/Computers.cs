using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Registrations
{
    public class Computers
    {
        DL.Registrations.Computers computerDL = new DL.Registrations.Computers();

        public DataTable List(String keyword)
        {
            return computerDL.List(keyword);
        }

        public EL.Registrations.Computers Select(EL.Registrations.Computers computerEL)
        {
            return computerDL.Select(computerEL);
        }

        public long Insert(EL.Registrations.Computers computerEL)
        {
            return computerDL.Insert(computerEL);
        }

        public Boolean Update(EL.Registrations.Computers computerEL)
        {
            return computerDL.Update(computerEL);
        }

        public Boolean Delete(EL.Registrations.Computers computerEL)
        {
            return computerDL.Delete(computerEL);    
        }
    }
}
