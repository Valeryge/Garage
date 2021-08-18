using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public bool m_IsDangeSubstances;
        public float m_MaxWeight;

        public Truck(VehicleFactory.VehicleProperties i_Properties, string i_LicensePlate) : base(i_Properties, i_LicensePlate)
        {
        }

        public void SetProperty(KeyValuePair<string, string> i_Pair)
        {
            switch (i_Pair.Key)
            {
                case "isDangerSubstance":
                    SetIsDangerSubstances(i_Pair.Value);
                    break;
                case "maxWeight":
                    setMaxWeight(i_Pair.Value);
                    break;
                case "gasAmount":
                    SetCurrentEnergyAmount(i_Pair.Value);
                    break;
            }
        }

        private void setMaxWeight(string i_Weight)
        {
            bool success = int.TryParse(i_Weight, out int number);

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

        public void SetIsDangerSubstances(string i_IsDanger)
        {
            switch(i_IsDanger)
            {
                case "0":
                    m_IsDangeSubstances = false;
                    break;
                case "1":
                    m_IsDangeSubstances = true;
                    break;
                default:
                    throw new ArgumentException("Enter 1 for yes and 0 for true");
            }
        }

        public Dictionary<string, object> GetTruckData()
        {
            Dictionary<string, object> data = GetVehicleData();

            data.Add("Has Dangerous substances", m_IsDangeSubstances);
            data.Add("Max weight", m_MaxWeight);

            return data;
        }
    }
}
