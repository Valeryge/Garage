using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicensePlate;
        protected List<Wheel> m_Wheels = new List<Wheel>();
        protected Engine m_Engine;
        protected readonly VehicleFactory.eVehicleType r_Type;
        private bool m_IsElectric;

        public string LicensePlate
        {
            set
            {
                m_LicensePlate = value;
            }
        }
        public VehicleFactory.eVehicleType VehicleType
        {
            get
            {
                return r_Type;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public Vehicle(VehicleFactory.VehicleProperties i_Properties, string i_LicensePlate)
        {
            m_LicensePlate = i_LicensePlate;
            if (i_Properties.m_IsElectric)
            {
                m_Engine = new ElectricEngine(i_Properties.m_TankSize);
            } 
            else
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

        public float EnergyPercentage
        {
            get
            {
                float percentage = 0;
                if (m_Engine != null)
                {
                    percentage = m_Engine.GetEnergyPercent();
                }

                return percentage;
            }
        }

        protected void SetCurrentEnergyAmount(string i_Amount)
        {
            bool success = float.TryParse(i_Amount, out float number);

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
                case "air in tires":
                    SetTiresPressure(i_Pair.Value);
                    break;
                case "wheel manufacture":
                    setWheelsManufacture(i_Pair.Value);
                    break;
            }
        }

        private void setWheelsManufacture(string i_Manufacture)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.Manufacture = i_Manufacture;
            }
        }

        public void SetTiresPressure(string i_Pressure)
        {
            bool success = int.TryParse(i_Pressure, out int number);

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

        public void AddPressureToTires()
        {
            foreach (Wheel wheel in m_Wheels) 
            {
                wheel.SetPressureToMax();
            }
        }

        public Dictionary<string, object> GetVehicleData()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            int wheelIndex = 1;

            data.Add("License Plate", m_LicensePlate);
            data.Add("Type", r_Type);
            data.Add("Model Name", m_ModelName);
            data.Add("Energy Percent", this.EnergyPercentage);
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
