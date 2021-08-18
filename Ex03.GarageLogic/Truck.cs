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

        public void SetProperty(KeyValuePair<string, string> i_Pair)
        {
            switch (i_Pair.Key)
            {
                case "isDangerSubstance":
                    setIsDangerSubstence(i_Pair.Value);
                    break;
                case "maxWeight":
                    setMaxWeight(i_Pair.Value);
                    break;
                case "gasAmount":
                    setCurrentEnergyAmount(i_Pair.Value);
                    break;
            }
        }

        private void setMaxWeight(string i_Weight)
        {
            int number;
            bool success = int.TryParse(i_Weight, out number);

            if (success)
            {
                if (number > 0)
                {
                    m_MaxWeight = number;
                }
                else
                {
                    throw new ArgumentException("Max Weight cant be negative");
                }
            }
            else
            {
                throw new FormatException("Not a number");
            }
        }

        private void setIsDangerSubstence(string i_IsDanger)
        {
            if (i_IsDanger == "0")
            {
                m_IsDangerSubstence = false;
            } else if (i_IsDanger == "1")
            {
                m_IsDangerSubstence = true;
            } else
            {
                throw new ArgumentException("Enter 1 for yes and 0 for true");
            }
        }

        public Dictionary<string, object> GetTruckData()
        {
            Dictionary<string, object> data = GetVehicleData();

            data.Add("Has Dangerous substences", m_IsDangerSubstence);
            data.Add("Max weight", m_MaxWeight);

            return data;
        }
    }
}
