using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_TankSize): base(i_TankSize)
        {
        }

        public void Charge(float i_HoursToCharge)
        {
            if (i_HoursToCharge + m_CurrentEnergyAmount <= m_MaxEnergyAmount)
            {
                m_CurrentEnergyAmount += i_HoursToCharge;
            } else
            {
                throw new ValueOutOfRangeException(String.Format("Battery overload- can charge only up to {0}", MaxEnergyAmount), 0, MaxEnergyAmount);
            }
        }

        public string GetData()
        {
            string data = String.Format("Current Capacity: {0}, Max capacity: {1}", m_CurrentEnergyAmount, m_MaxEnergyAmount);

            return data;
        }
    }
}
