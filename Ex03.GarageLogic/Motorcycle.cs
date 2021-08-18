using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum LicenseType
        {
            AA, BB, A, B1
        }

        public LicenseType m_LicenseType;
        public int m_EngineVolume;

        public Motorcycle(VehicleFactory.VehicleProperties i_Properties, string i_LicensePlate) : base(i_Properties, i_LicensePlate)
        {
        }

        public void SetProperty(KeyValuePair<string, string> i_Pair)
        {
            switch (i_Pair.Key)
            {
                case "licenseType":
                    setLicenseType(i_Pair.Value);
                    break;
                case "engineVolume":
                    setEngineVolume(i_Pair.Value);
                    break;
                case "gasAmount":
                case "currentBattary":
                    setCurrentEnergyAmount(i_Pair.Value);
                    break;
            }
        }

        private void setEngineVolume(string i_Volume)
        {
            int number;
            bool success = int.TryParse(i_Volume, out number);

            if (success)
            {
                if (number > 0)
                {
                    m_EngineVolume = number;
                } else
                {
                    throw new ArgumentException("Volume cant be negative");
                }
            }
            else
            {
                throw new FormatException("Not a number");
            }
        }

        private void setLicenseType(string i_Type)
        {
            int number;
            bool success = int.TryParse(i_Type, out number);

            if (success)
            {
                if (isValidLicenseType(number))
                {
                    m_LicenseType = (LicenseType)number;
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
            bool isValid = false;

            if (Enum.IsDefined(typeof(LicenseType), i_Type))
            {
                isValid = true;
            }

            return isValid;
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
