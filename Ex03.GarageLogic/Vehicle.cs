using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicensePlate;
        protected float m_EnergyPercent;
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;
        protected readonly VehicleFactory.VehicleType r_Type;

        public VehicleFactory.VehicleType VehicleType
        {
            get { return r_Type;  }
        }

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

        public void SetTiresPressure(string i_Pressure)
        {
            int number;
            bool success = int.TryParse(i_Pressure, out number);

            if (success)
            {
                foreach (Wheel wheel in m_Wheels)
                {
                    wheel.Pressure = number;
                }
            }
            else
            {
                throw new FormatException("Not a number");
            }
        }

        protected void setCurrentEnergyAmount(string i_Amount)
        {
            float number;
            bool success = float.TryParse(i_Amount, out number);

            if (success)
            {
                m_Engine.CurrentEnergyAmount = number;
            }
            else
            {
                throw new FormatException("Not a number");
            }
        }

    }
}
