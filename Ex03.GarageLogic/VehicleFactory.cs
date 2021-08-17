﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        private Dictionary<VehicleType, VehicleProperties> m_SupportedVehiclesInGarage = new Dictionary<VehicleType, VehicleProperties>();
        private Dictionary<VehicleType, List<string>> m_UniqueDataDitionary = new Dictionary<VehicleType, List<string>>();

        public class VehicleProperties
        {
            public int m_NumOfWheels;
            public float m_MaxPressure;
            public float m_TankSize;
            public FuelType m_FuelType;
            public bool m_IsElectric;

            public VehicleProperties(int i_NumOfWheels,float i_MaxPressure, float i_TankSize, FuelType i_Type, bool i_IsElectric)
            {
                m_NumOfWheels = i_NumOfWheels;
                m_MaxPressure = i_MaxPressure;
                m_TankSize = i_TankSize;
                m_FuelType = i_Type;
                m_IsElectric = i_IsElectric;
            }
        }

        public enum FuelType
        {
            None = 0,
            Octan98 = 1,
            Octan95 = 2,
            Soler = 3
        }

        public enum VehicleType
        {
            GasCar = 1,
            ElectricCar = 2,
            GasMotorcycle = 3,
            ElectricMotorcycle = 4,
            Truck = 5
        }

        public VehicleFactory()
        {
            initSupportedVehicles();
            initVehicleExtraData();
        }

        private void initSupportedVehicles()
        {
            m_SupportedVehiclesInGarage.Add(VehicleType.GasMotorcycle, new VehicleProperties(2, 30f, 6f, FuelType.Octan95, false));
            m_SupportedVehiclesInGarage.Add(VehicleType.ElectricMotorcycle, new VehicleProperties(2, 30f, 1.8f, FuelType.None, true));
            m_SupportedVehiclesInGarage.Add(VehicleType.GasCar, new VehicleProperties(4, 32f, 45f, FuelType.Octan95, false));
            m_SupportedVehiclesInGarage.Add(VehicleType.ElectricCar, new VehicleProperties(4, 32f, 3.2f, FuelType.None, true));
            m_SupportedVehiclesInGarage.Add(VehicleType.Truck, new VehicleProperties(16, 26f, 120f, FuelType.Soler, false));
        }

        private void initVehicleExtraData()
        {
            m_UniqueDataDitionary.Add(VehicleType.GasCar, new List<string>(new string[] { "color", "numberOfDoors", "gasAmount" }));
            m_UniqueDataDitionary.Add(VehicleType.ElectricCar, new List<string>(new string[] { "color", "numberOfDoors", "currentBattery" }));
            m_UniqueDataDitionary.Add(VehicleType.GasMotorcycle, new List<string>(new string[] { "licenseType", "engineVolume", "currentBattary" }));
            m_UniqueDataDitionary.Add(VehicleType.ElectricMotorcycle, new List<string>(new string[] { "licenseType", "engineVolume", "gasAmount" }));
            m_UniqueDataDitionary.Add(VehicleType.Truck, new List<string>(new string[] { "isDangerSubstance", "maxWeight" }));
        }

        public Vehicle CreateVehicle(int i_Type, string i_LicensePlate)
        {
            VehicleProperties vehicleProperties;
            VehicleType type = (VehicleType)i_Type;

            m_SupportedVehiclesInGarage.TryGetValue(type, out vehicleProperties);
            switch (type)
            {
                case VehicleType.ElectricCar:
                case VehicleType.GasCar:
                    return new Car(vehicleProperties, i_LicensePlate);
                case VehicleType.ElectricMotorcycle:
                case VehicleType.GasMotorcycle:
                    return new Motorcycle(vehicleProperties, i_LicensePlate);
                case VehicleType.Truck:
                    return new Car(vehicleProperties, i_LicensePlate);
                default:
                    return null;
            }
        }

        public List<string> GetUniqueDataFields(VehicleType i_Type)
        {
            return m_UniqueDataDitionary[i_Type];
        }
    }
}
