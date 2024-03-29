﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            AA,
            BB,
            A,
            B1
        }

        public eLicenseType m_LicenseType;
        public int m_EngineVolume;

        public Motorcycle(VehicleFactory.VehicleProperties i_Properties, string i_LicensePlate) : base(i_Properties, i_LicensePlate)
        {
        }

        public void SetProperty(KeyValuePair<string, string> i_Pair)
        {
            switch (i_Pair.Key)
            {
                case "license Type":
                    SetLicenseType(i_Pair.Value);
                    break;
                case "engine Volume":
                    setEngineVolume(i_Pair.Value);
                    break;
                case "gas Amount":
                case "current Battery":
                    SetCurrentEnergyAmount(i_Pair.Value);
                    break;
            }
        }

        private void setEngineVolume(string i_Volume)
        {
            bool success = int.TryParse(i_Volume, out int number);

            if (success)
            {
                if (number > 0)
                {
                    m_EngineVolume = number;
                } 
                else
                {
                    throw new ArgumentException("Volume cant be negative");
                }
            }
            else
            {
                throw new FormatException("Not a number");
            }
        }

        public void SetLicenseType(string i_Type)
        {
            bool success = int.TryParse(i_Type, out int number);

            if (success)
            {
                if (isValidLicenseType(number))
                {
                    m_LicenseType = (eLicenseType)number;
                }
                else
                {
                    throw new ArgumentException("Not Valid License type Enum");
                }
            }
            else
            {
                throw new FormatException("Not a number");
            }
        }

        private bool isValidLicenseType(int i_Type)
        {
            return Enum.IsDefined(typeof(eLicenseType), i_Type);
        }

        public Dictionary<string, object> GetMotorcycleData()
        {
            Dictionary<string, object> data = GetVehicleData();

            data.Add("License Type", m_LicenseType);
            data.Add("Engine Volume", m_EngineVolume);

            return data;
        }
    }
}
