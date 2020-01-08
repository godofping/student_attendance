using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Seats
    {
        int seatid;
        int roomid;
        string seat;

        public int Seatid { get => seatid; set => seatid = value; }
        public int Roomid { get => roomid; set => roomid = value; }
        public string Seat { get => seat; set => seat = value; }
    }
}
