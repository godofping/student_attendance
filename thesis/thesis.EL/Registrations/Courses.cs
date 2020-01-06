using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Courses
    {
        int courseid;
        string coursecode;
        string coursedescription;

        public int Courseid { get => courseid; set => courseid = value; }
        public string Coursecode { get => coursecode; set => coursecode = value; }
        public string Coursedescription { get => coursedescription; set => coursedescription = value; }
    }
}
