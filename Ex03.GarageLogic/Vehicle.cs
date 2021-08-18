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
        protected List<Wheel> m_Wheels = new List<Wheel>();
        protected Engine m_Engine;
        protected readonly VehicleFactory.VehicleType r_Type;
        private bool m_IsElectric;

        public string LicensePlate
        {
            set { m_LicensePlate = value; }
        }
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

            for (int i = 0; i < i_Properties.m_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_Properties.m_MaxPressure));
            }

            r_Type = i_Properties.m_VehicleType;
            m_IsElectric = i_Properties.m_IsElectric;
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

        public void SetSharedProperty(KeyValuePair<string, string> i_Pair)
        {
            switch (i_Pair.Key)
            {
                case "model name":
                    m_ModelName = i_Pair.Value;
                    break;
                case "energy percentage":
                    setEnergyPercentage(i_Pair.Value);
                    break;
                case "air in tires":
                    SetTiresPressure(i_Pair.Value);
                    break;
                case "wheel manufactor":
                    setWheelsManufactor(i_Pair.Value);
                    break;
            }
        }

        private void setWheelsManufactor(string i_Manufactor)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.Manufactor = i_Manufactor;
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

        private void setEnergyPercentage(string i_Percentage)
        {
            //TODO : caculate
        }

        public void AddPressureToTires()
        {
            foreach (Wheel wheel in m_Wheels) {
                wheel.SetPressureToMax();
            }
        }

        public Dictionary<string, object> GetVehicleData()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            data.Add("License Plate", m_LicensePlate);
            data.Add("Model Name", m_ModelName);
            data.Add("Energy Percent", m_EnergyPercent);
            int wheelIndex = 1;
            foreach (Wheel wheel in m_Wheels)
            {
                data.Add(String.Format("Wheel Data {0}", wheelIndex), wheel.GetData());
                wheelIndex++;
            }

            data.Add("Engine", m_IsElectric ? (m_Engine as ElectricEngine).GetData() : (m_Engine as GasEngine).GetData());

            return data;
        }
    }
}
