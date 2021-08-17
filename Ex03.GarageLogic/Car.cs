using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum Color
        {
            Black,
            White,
            Red,
            Silver
        }

        public Color m_Color;
        public int m_NumOfDoors;

        public Car(VehicleFactory.VehicleProperties i_Properties, string i_LicensePlate): base(i_Properties, i_LicensePlate)
        {

        }
    }
}
