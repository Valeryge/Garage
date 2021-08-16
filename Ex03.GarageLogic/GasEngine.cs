using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasEngine
    {
        public enum FuelType
        {
            None = 0,
            Octan98 = 1,
            Octan95 = 2,
            Soler = 3
        }

        private FuelType m_FuelType;
        private float m_CurrentCapacity;
        private float m_TankSize;

        public GasEngine(float i_TankSize, float i_CurrentCapacity, FuelType i_FuelType)
        {
            m_CurrentCapacity = i_CurrentCapacity;
            m_TankSize = i_TankSize;
            m_FuelType = i_FuelType;
        }

        public float GetEnergyPercent()
        {
            return m_CurrentCapacity / m_TankSize * 100;
        }

        public void AddFuel(float i_FuelAmount, FuelType i_Type)
        {
            if (i_FuelAmount + m_CurrentCapacity <= m_TankSize && i_Type == m_FuelType)
            {
                m_CurrentCapacity += i_FuelAmount;
            } else
            {
                // TODO: Expetion
            }
        }
    }
}
