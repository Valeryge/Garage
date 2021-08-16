using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        string m_ModelName;
        string m_LicensePlate;
        float m_EnergyPercent;
        List<Wheel> m_Wheels;
        GarageManager.VehicleType m_VehicleType;

        public Vehicle()
        {

        }


        public GarageManager.VehicleType Type
        {
            get { return m_VehicleType; }
        }
    }
}
