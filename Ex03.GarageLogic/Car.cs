using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            Black = 1,
            White = 2,
            Red = 3,
            Silver = 4
        }

        public eColor m_Color;
        public int m_NumOfDoors;
       
        public Car(VehicleFactory.VehicleProperties i_Properties, string i_LicensePlate): base(i_Properties, i_LicensePlate)
        {
        }

        private void setColor(string i_Color)
        {
            int number;
            bool success = int.TryParse(i_Color, out number);

            if (success)
            {
                if (isValidColor(number))
                {
                    m_Color = (eColor)number;
                } else
                {
                    throw new ArgumentException("Not Valid Color Enum");
                }
            } else
            {
                throw new FormatException("Not a number");
            }
        }

        private void setNumOfDoors(string i_NumOfDoors)
        {
            int number;
            bool success = int.TryParse(i_NumOfDoors, out number);

            if (success)
            {
                if (number >= 2 && number <= 5)
                {
                    m_NumOfDoors = number;
                }
                else
                {
                    throw new ArgumentException("Not Valid num of doors");
                }
            }
            else
            {
                throw new FormatException("Not a number");
            }
        }

        public void SetProperty(KeyValuePair<string, string> i_Pair)
        {
            switch (i_Pair.Key)
            {
                case "color":
                    setColor(i_Pair.Value);
                    break;
                case "numberOfDoors":
                    setNumOfDoors(i_Pair.Value);
                    break;
                case "currentBattery":
                case "gasAmount":
                    SetCurrentEnergyAmount(i_Pair.Value);
                    break;
            } 
        }

        private bool isValidColor(int i_Color)
        {
            return Enum.IsDefined(typeof(eColor), i_Color);
        }

        public Dictionary<string, object> GetCarData()
        {
            Dictionary<string, object> data = GetVehicleData();

            data.Add("Color", m_Color);
            data.Add("Number of doors", m_NumOfDoors);

            return data;
        }
    }
}
