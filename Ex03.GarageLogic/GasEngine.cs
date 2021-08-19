using System;

namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        private VehicleFactory.eFuelType m_FuelType;

        public GasEngine(float i_TankSize, VehicleFactory.eFuelType i_FuelType): base(i_TankSize)
        {
            m_FuelType = i_FuelType;
            m_CurrentEnergyAmount = 0;
        }

        public void AddFuel(float i_FuelAmount, VehicleFactory.eFuelType i_Type)
        {
            if (i_Type != m_FuelType)
            {
                throw new ArgumentException("Incorrect fuel type");
            }
            else if (i_FuelAmount < 0 || i_FuelAmount + m_CurrentEnergyAmount > m_MaxEnergyAmount)
            {
                throw new ValueOutOfRangeException("Fuel amount is out of range", 0, CurrentEnergyAmount);
            } 
            else
            {
                m_CurrentEnergyAmount += i_FuelAmount;
            }
        }

        public string GetData()
        {
            string data = String.Format("Fuel Type: {0}, Current Capacity: {1}, Max capacity: {2}", m_FuelType, m_CurrentEnergyAmount, m_MaxEnergyAmount);

            return data;
        }
    }
}
