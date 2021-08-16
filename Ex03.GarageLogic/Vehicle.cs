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
        Engine m_Engine;
        List<Wheel> m_Wheels;

        public Vehicle(VehicleFactory.VehicleProperties i_Properties, string i_LicensePlate)
        {

        }

    }
}
