using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        float m_TankSize;
        float m_CurrentCapacity;

        public Engine(float i_TankSize, float i_CurrentCapacity)
        {
            m_TankSize = i_TankSize;
            m_CurrentCapacity = i_CurrentCapacity;
        }

        public float GetEnergyPercent()
        {
            return m_CurrentCapacity / m_TankSize * 100;
        }
    }
}
