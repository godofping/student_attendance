using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis.BL.Registrations
{
    public class Buildings
    {
        DL.Registrations.Buildings buildingDL = new DL.Registrations.Buildings();
        public DataTable List(String keyword)
        {
            return buildingDL.List(keyword);
        }

        public DataTable List(EL.Registrations.Buildings buildingEL)
        {
            return buildingDL.List(buildingEL);
        }

        public EL.Registrations.Buildings Select(EL.Registrations.Buildings buildingEL)
        {
            return buildingDL.Select(buildingEL);
        }

        public long Insert(EL.Registrations.Buildings buildingEL)
        {
            return buildingDL.Insert(buildingEL);
        }

        public Boolean Update(EL.Registrations.Buildings buildingEL)
        {
            return buildingDL.Update(buildingEL);
        }

        public Boolean Delete(EL.Registrations.Buildings buildingEL)
        {
            return buildingDL.Delete(buildingEL);
        }
    }
}
