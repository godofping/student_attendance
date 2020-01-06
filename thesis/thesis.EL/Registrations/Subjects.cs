using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Subjects
    {
        int subjectid;
        string subjectcode;
        string subjectdescription;

        public int Subjectid { get => subjectid; set => subjectid = value; }
        public string Subjectcode { get => subjectcode; set => subjectcode = value; }
        public string Subjectdescription { get => subjectdescription; set => subjectdescription = value; }
    }
}
