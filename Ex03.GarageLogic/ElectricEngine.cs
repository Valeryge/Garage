using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine
    {
        private float m_WorkingHoursLeft;
        private float m_MaxBatteryLife;

        public ElectricEngine(float i_TankSize, float i_CurrentCapacity)
        {
            m_MaxBatteryLife = i_TankSize;
            m_WorkingHoursLeft = i_CurrentCapacity;
        }

        public float GetEnergyPercent()
        {
            return m_WorkingHoursLeft / m_MaxBatteryLife * 100;
        }

        public void Charge(float i_HoursToCharge)
        {
            if (i_HoursToCharge + m_WorkingHoursLeft <= m_MaxBatteryLife)
            {
                m_WorkingHoursLeft += i_HoursToCharge;
            } else
            {
                //TODO: Expetion
            }
        }
    }
}
