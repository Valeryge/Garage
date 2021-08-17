using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlate;
        private float m_EnergyPercent;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        public Engine Engine
        {
            get { return m_Engine;  }
        }

        public Vehicle(VehicleFactory.VehicleProperties i_Properties, string i_LicensePlate)
        {
            if (i_Properties.m_IsElectric)
            {
                m_Engine = new ElectricEngine(i_Properties.m_TankSize);
            } else
            {
                m_Engine = new GasEngine(i_Properties.m_TankSize, i_Properties.m_FuelType);
            }
        }

    }
}
