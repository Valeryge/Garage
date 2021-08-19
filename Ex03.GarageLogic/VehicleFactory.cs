using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public enum eFuelType
        {
            None = 0,
            Octan98 = 1,
            Octan95 = 2,
            Soler = 3
        }

        public enum eVehicleType
        {
            GasCar = 1,
            ElectricCar = 2,
            GasMotorcycle = 3,
            ElectricMotorcycle = 4,
            Truck = 5
        }

        public Dictionary<eVehicleType, VehicleProperties> m_SupportedVehiclesInGarage = new Dictionary<eVehicleType, VehicleProperties>();
        public Dictionary<eVehicleType, List<string>> m_UniqueDataDictionary = new Dictionary<eVehicleType, List<string>>();
        public List<string> m_SharedPropertiesNames = new List<string>(new [] { "model name", "air in tires", "wheel manufacture" });

        public List<string> SharedPropertiesNames
        {
            get
            {
                return m_SharedPropertiesNames;
            }
        }

        public class VehicleProperties
        {
            public int m_NumOfWheels;
            public float m_MaxPressure;
            public float m_TankSize;
            public eFuelType m_FuelType;
            public bool m_IsElectric;
            public eVehicleType m_VehicleType;

            public VehicleProperties(int i_NumOfWheels,float i_MaxPressure, float i_TankSize, eFuelType i_FuelType, bool i_IsElectric, eVehicleType i_VehicleType)
            {
                m_NumOfWheels = i_NumOfWheels;
                m_MaxPressure = i_MaxPressure;
                m_TankSize = i_TankSize;
                m_FuelType = i_FuelType;
                m_IsElectric = i_IsElectric;
                m_VehicleType = i_VehicleType;
            }
        }

        public VehicleFactory()
        {
            initSupportedVehicles();
            initVehicleExtraData();
        }

        private void initSupportedVehicles()
        {
            m_SupportedVehiclesInGarage.Add(eVehicleType.GasMotorcycle, new VehicleProperties(2, 30f, 6f, eFuelType.Octan95, false, eVehicleType.GasMotorcycle));
            m_SupportedVehiclesInGarage.Add(eVehicleType.ElectricMotorcycle, new VehicleProperties(2, 30f, 1.8f, eFuelType.None, true, eVehicleType.ElectricMotorcycle));
            m_SupportedVehiclesInGarage.Add(eVehicleType.GasCar, new VehicleProperties(4, 32f, 45f, eFuelType.Octan95, false, eVehicleType.GasCar));
            m_SupportedVehiclesInGarage.Add(eVehicleType.ElectricCar, new VehicleProperties(4, 32f, 3.2f, eFuelType.None, true, eVehicleType.ElectricCar));
            m_SupportedVehiclesInGarage.Add(eVehicleType.Truck, new VehicleProperties(16, 26f, 120f, eFuelType.Soler, false, eVehicleType.Truck));
        }

        private void initVehicleExtraData()
        {
            m_UniqueDataDictionary.Add(eVehicleType.GasCar, new List<string>(new[] { "color", "numberOfDoors", "gasAmount" }));
            m_UniqueDataDictionary.Add(eVehicleType.ElectricCar, new List<string>(new [] { "color", "number Of Doors", "current Battery" }));
            m_UniqueDataDictionary.Add(eVehicleType.GasMotorcycle, new List<string>(new [] { "license Type", "engine Volume", "current Battery"}));
            m_UniqueDataDictionary.Add(eVehicleType.ElectricMotorcycle, new List<string>(new [] { "license Type", "engine Volume", "gas Amount"}));
            m_UniqueDataDictionary.Add(eVehicleType.Truck, new List<string>(new [] { "if holds dangerous substences", "max Weight", "gas Amount" }));
        }

        public Vehicle CreateVehicle(int i_Type, string i_LicensePlate)
        {
            eVehicleType type = (eVehicleType)i_Type;

            m_SupportedVehiclesInGarage.TryGetValue(type, out VehicleProperties vehicleProperties);
            switch (type)
            {
                case eVehicleType.ElectricCar:
                case eVehicleType.GasCar:
                    return new Car(vehicleProperties, i_LicensePlate);
                case eVehicleType.ElectricMotorcycle:
                case eVehicleType.GasMotorcycle:
                    return new Motorcycle(vehicleProperties, i_LicensePlate);
                case eVehicleType.Truck:
                    return new Truck(vehicleProperties, i_LicensePlate);
                default:
                    return null;
            }
        }

        public List<string> GetUniqueDataFields(eVehicleType i_Type)
        {
            return m_UniqueDataDictionary[i_Type];
        }
    }
}
