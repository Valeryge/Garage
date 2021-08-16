using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public bool m_IsDangerSubstence;
        public float m_MaxWeight;

        public Truck(VehicleFactory.VehicleProperties i_Properties, string i_LicensePlate) : base(i_Properties, i_LicensePlate)
        {

        }
    }
}
