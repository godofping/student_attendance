using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.EL.Registrations
{
    public class Rooms
    {
        int roomid;
        int buildingid;
        int computerid;
        string room;

        public int Roomid { get => roomid; set => roomid = value; }
        public int Buildingid { get => buildingid; set => buildingid = value; }
        public int Computerid { get => computerid; set => computerid = value; }
        public string Room { get => room; set => room = value; }
    }
}
