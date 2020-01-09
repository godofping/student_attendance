using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Registrations
{
    public class Courses
    {
        DL.Registrations.Courses courseDL = new DL.Registrations.Courses();
        public DataTable List(String keyword)
        {
            return courseDL.List(keyword);
        }

        public DataTable List(EL.Registrations.Courses courseEL)
        {
            return courseDL.List(courseEL);
        }

        public EL.Registrations.Courses Select(EL.Registrations.Courses courseEL)
        {
            return courseDL.Select(courseEL);
        }

        public long Insert(EL.Registrations.Courses courseEL)
        {
            return courseDL.Insert(courseEL);
        }

        public Boolean Update(EL.Registrations.Courses courseEL)
        {
            return courseDL.Update(courseEL);
        }

        public Boolean Delete(EL.Registrations.Courses courseEL)
        {
            return courseDL.Delete(courseEL);    
        }
    }
}
