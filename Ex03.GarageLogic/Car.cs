using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum CarColor
        {
            Black,
            White,
            Red,
            Silver
        }

        public CarColor m_Color;
        public int m_NumOfDoors;

        public Car()
        {
        }


        public CarColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }
     
    }
}
