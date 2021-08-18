using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        VehicleFactory m_Factory = new VehicleFactory();
        public Dictionary<string, CustomerCard> m_CustomerCards = new Dictionary<string, CustomerCard>();

        public GarageManager() { }

        public void AddVehicleToGarage(string i_LicensePlate, string i_CustomerName, string i_CustomerPhone, int i_VehicleType)
        {
            if (IsVehicleInGarage(i_LicensePlate))
            {
                CustomerCard card;
                m_CustomerCards.TryGetValue(i_LicensePlate, out card);
                card.VehicleState = CustomerCard.RepairState.InProgress;
            }
            else
            {
                Vehicle vehicle = m_Factory.CreateVehicle(i_VehicleType, i_LicensePlate);
                m_CustomerCards[i_LicensePlate] = new CustomerCard(vehicle, i_CustomerName, i_CustomerPhone);
                vehicle.LicensePlate = i_LicensePlate;
            }
        }

        public void ChangeVehicleRepairState(string i_LicensePlate, int i_RepairState)
        {
            CustomerCard card;

            m_CustomerCards.TryGetValue(i_LicensePlate, out card);
            if (card != null)
            {
                card.VehicleState = (CustomerCard.RepairState)i_RepairState;
            } else
            {
                throw new ArgumentException("Vehicle not in garage");
            }
        }

        public Dictionary<string, object> GetVehicleData(string i_LicensePlate)
        {
            Dictionary<string, object> data = null;
            CustomerCard card;

            m_CustomerCards.TryGetValue(i_LicensePlate, out card);
            switch (card.Vehicle.VehicleType)
            {
                case VehicleFactory.VehicleType.ElectricCar:
                case VehicleFactory.VehicleType.GasCar:
                    data = (card.Vehicle as Car).GetCarData();
                    break;
                case VehicleFactory.VehicleType.ElectricMotorcycle:
                case VehicleFactory.VehicleType.GasMotorcycle:
                    data = (card.Vehicle as Motorcycle).GetMotorcycleData();
                    break;
                case VehicleFactory.VehicleType.Truck:
                    data = (card.Vehicle as Truck).GetTruckData();
                    break;
            }

            return data;
        }

        public void SetProperty(string i_LicensePlate, KeyValuePair<string, string> i_Pair)
        {
            CustomerCard card;

            m_CustomerCards.TryGetValue(i_LicensePlate, out card);
            switch (card.Vehicle.VehicleType)
            {
                case VehicleFactory.VehicleType.ElectricCar:
                case VehicleFactory.VehicleType.GasCar:
                    (card.Vehicle as Car).SetProperty(i_Pair);
                    break;
                case VehicleFactory.VehicleType.ElectricMotorcycle:
                case VehicleFactory.VehicleType.GasMotorcycle:
                    (card.Vehicle as Motorcycle).SetProperty(i_Pair);
                    break;
                case VehicleFactory.VehicleType.Truck:
                    (card.Vehicle as Truck).SetProperty(i_Pair);
                    break;
            }
        }

        public void SetSharedVehicleProperty(string i_LicensePlate, KeyValuePair<string, string> i_Pair)
        {
            CustomerCard card;

            m_CustomerCards.TryGetValue(i_LicensePlate, out card);
            if (card != null)
            {
                card.Vehicle.SetSharedProperty(i_Pair);
            } else
            {
                throw new ArgumentException("Vehicle not in garage");
            }
        }

        public List<string> GetSharedPropertyNames()
        {
            return m_Factory.SharedPropertiesNames;
        }

        public List<string> GetUniqueDataFields(int i_LicenseType)
        {
            return m_Factory.GetUniqueDataFields((VehicleFactory.VehicleType)i_LicenseType);
        }

        public List<string> GetSortedLicensePlates(int i_State)
        {
            List<string> plates = new List<string>();

            foreach (KeyValuePair<string, CustomerCard> entry in m_CustomerCards)
            {
                if ((CustomerCard.RepairState)i_State == entry.Value.VehicleState)
                {
                    plates.Add(entry.Key);
                }
            }

            return plates;
        }

        
        public void ChargeElectricVehicle(string i_LicensePlate, int i_MinutesForCharge)
        {
            CustomerCard card = null;

            m_CustomerCards.TryGetValue(i_LicensePlate, out card);
            ElectricEngine engine = card.Vehicle.Engine as ElectricEngine;
            if (engine == null)
            {
                throw new ArgumentException(String.Format("{0} is not electric", i_LicensePlate));
            }

            if (card != null)
            {
                engine.Charge((float)(i_MinutesForCharge / 60));
            } else
            {
                throw new ArgumentException(String.Format("{0} is not in garage", i_LicensePlate));
            }
        }

        public void FuelGasDrivenVehicle(string i_LicensePlate, int i_FuelType, float i_LitresToFill)
        {
            CustomerCard card = null;

            m_CustomerCards.TryGetValue(i_LicensePlate, out card);
            GasEngine engine = card.Vehicle.Engine as GasEngine;

            if (engine == null)
            {
                throw new ArgumentException(String.Format("{0} is not electric", i_LicensePlate));
            }

            if (card != null)
            {
                engine.AddFuel(i_LitresToFill, (VehicleFactory.FuelType)i_FuelType);
            }
            else
            {
                throw new ArgumentException(String.Format("{0} is not in garage", i_LicensePlate));
            }
        }

        //TODO: chnage in UI - delete 2nd paraeter
        public void AddPressureToTires(string i_LicensePlate)
        {
            CustomerCard card;

            m_CustomerCards.TryGetValue(i_LicensePlate, out card);
            if (card != null)
            {
                card.Vehicle.AddPressureToTires();
            }
        }

        public bool IsVehicleInGarage(string i_LisencePlate)
        {
            return m_CustomerCards.ContainsKey(i_LisencePlate);
        }

        public List<string> GetAllLicensePlates()
        {
            List<string> plates = new List<string>();

            foreach (KeyValuePair<string, CustomerCard> entry in m_CustomerCards)
            {
                plates.Add(entry.Key);
            }

            return plates;
        }

        public StringBuilder GetVehicleTypeOptionsString() {
            StringBuilder values = new StringBuilder();

            foreach (int type in Enum.GetValues(typeof(VehicleFactory.VehicleType)))
            {
                String name = Enum.GetName(typeof(VehicleFactory.VehicleType), type);
                String line = String.Format("{0} - {1}\n", type, name);
                values.Append(line);
            }

            return values;
        }

        public StringBuilder GetColorOptionsString()
        {
            StringBuilder values = new StringBuilder();

            foreach (int type in Enum.GetValues(typeof(Car.Color)))
            {
                String name = Enum.GetName(typeof(Car.Color), type);
                String line = String.Format("{0} - {1}\n", type, name);
                values.Append(line);
            }

            return values;
        }

        public StringBuilder GetFuelOptionsString()
        {
            StringBuilder values = new StringBuilder();

            foreach (int type in Enum.GetValues(typeof(VehicleFactory.FuelType)))
            {
                String name = Enum.GetName(typeof(VehicleFactory.FuelType), type);
                String line = String.Format("{0} - {1}\n", type, name);
                values.Append(line);
            }

            return values;
        }
    }   
}
