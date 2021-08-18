using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_MaxEnergyAmount;
        protected float m_CurrentEnergyAmount;

        public Engine(float i_MaxEnergyAmount)
        {
            m_MaxEnergyAmount = i_MaxEnergyAmount;
            m_CurrentEnergyAmount = 0;
        }

        public float CurrentEnergyAmount
        {
            get { return m_CurrentEnergyAmount;  }
            set 
            {
                if (value >= 0 && value <= m_MaxEnergyAmount)
                {
                    m_CurrentEnergyAmount = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("Energy amount is out of range", 0, m_MaxEnergyAmount);
                }
            }
        }
        
        public float MaxEnergyAmount
        {
            get { return m_MaxEnergyAmount;  }
            set { m_MaxEnergyAmount = value; }
        }


        public float GetEnergyPercent()
        {
            return m_CurrentEnergyAmount / m_MaxEnergyAmount * 100;
        }
    }
}
