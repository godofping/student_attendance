using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Seatassignments
    {
        int seatassignmentid;
        int studentsubjectenrolledid;
        int seatid;

        public int Seatassignmentid { get => seatassignmentid; set => seatassignmentid = value; }
        public int Studentsubjectenrolledid { get => studentsubjectenrolledid; set => studentsubjectenrolledid = value; }
        public int Seatid { get => seatid; set => seatid = value; }
    }
}
