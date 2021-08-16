using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.GarageManager;
using static Ex03.GarageLogic.GasEngine;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public struct VehicleProperties
        {
            public int m_NumOfWheels;
            public float m_MaxPressure;
            public float m_TankSize;
            public FuelType m_FuelType;

            public VehicleProperties(int i_NumOfWheels,float i_MaxPressure, float i_TankSize, FuelType i_Type)
            {
                m_NumOfWheels = i_NumOfWheels;
                m_MaxPressure = i_MaxPressure;
                m_TankSize = i_TankSize;
                m_FuelType = i_Type;
            }
        }

     
        

        Dictionary<VehicleType, VehicleProperties> m_SupportedVehiclesInGarage = new Dictionary<VehicleType, VehicleProperties>();

        VehicleFactory()
        {
            initSupportedVehicles();
        }

        private void initSupportedVehicles()
        {
            m_SupportedVehiclesInGarage.Add(VehicleType.GasMotorcycle, new VehicleProperties(2, 30f, 6f, FuelType.Octan95));
            m_SupportedVehiclesInGarage.Add(VehicleType.ElectricMotorcycle, new VehicleProperties(2, 30f, 1.8f, FuelType.None));
            m_SupportedVehiclesInGarage.Add(VehicleType.GasCar, new VehicleProperties(4, 32f, 45f, FuelType.Octan95));
            m_SupportedVehiclesInGarage.Add(VehicleType.ElectricCar, new VehicleProperties(4, 32f, 3.2f, FuelType.None));
            m_SupportedVehiclesInGarage.Add(VehicleType.Truck, new VehicleProperties(16, 26f, 120f, FuelType.Soler));
        }

        //TODO switch case
        public Vehicle CreateVehicle(int i_TypeNumber, string i_LicensePlate)
        {
            return null;
        }
    }
}
