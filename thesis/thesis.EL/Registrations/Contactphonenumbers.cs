using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Contactphonenumbers
    {
        int contactphonenumberid;
        int studentid;
        int relationid;
        string contactphonenumber;

        public int Contactphonenumberid { get => contactphonenumberid; set => contactphonenumberid = value; }
        public int Studentid { get => studentid; set => studentid = value; }
        public int Relationid { get => relationid; set => relationid = value; }
        public string Contactphonenumber { get => contactphonenumber; set => contactphonenumber = value; }
    }
}
