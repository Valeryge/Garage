using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private VehicleFactory m_Factory = new VehicleFactory();
        public Dictionary<string, CustomerCard> m_CustomerCards = new Dictionary<string, CustomerCard>();

        public GarageManager() { }

        public void AddVehicleToGarage(string i_LicensePlate, string i_CustomerName, string i_CustomerPhone, int i_VehicleType)
        {
            if (IsVehicleInGarage(i_LicensePlate))
            {
                m_CustomerCards.TryGetValue(i_LicensePlate, out CustomerCard card);
                card.VehicleState = CustomerCard.eRepairState.InProgress;
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
            m_CustomerCards.TryGetValue(i_LicensePlate, out CustomerCard card);
            if (card != null)
            {
                card.VehicleState = (CustomerCard.eRepairState)i_RepairState;
            } else
            {
                throw new ArgumentException("Vehicle not in garage");
            }
        }

        public Dictionary<string, object> GetVehicleData(string i_LicensePlate)
        {
            Dictionary<string, object> data = null;

            m_CustomerCards.TryGetValue(i_LicensePlate, out CustomerCard card);
            switch (card.Vehicle.VehicleType)
            {
                case VehicleFactory.eVehicleType.ElectricCar:
                case VehicleFactory.eVehicleType.GasCar:
                    data = (card.Vehicle as Car).GetCarData();
                    break;
                case VehicleFactory.eVehicleType.ElectricMotorcycle:
                case VehicleFactory.eVehicleType.GasMotorcycle:
                    data = (card.Vehicle as Motorcycle).GetMotorcycleData();
                    break;
                case VehicleFactory.eVehicleType.Truck:
                    data = (card.Vehicle as Truck).GetTruckData();
                    break;
            }

            return data;
        }

        public void SetProperty(string i_LicensePlate, KeyValuePair<string, string> i_Pair)
        {
            m_CustomerCards.TryGetValue(i_LicensePlate, out CustomerCard card);
            if(card != null)
            {
                switch(card.Vehicle.VehicleType)
                {
                    case VehicleFactory.eVehicleType.ElectricCar:
                    case VehicleFactory.eVehicleType.GasCar:
                        (card.Vehicle as Car).SetProperty(i_Pair);
                        break;
                    case VehicleFactory.eVehicleType.ElectricMotorcycle:
                    case VehicleFactory.eVehicleType.GasMotorcycle:
                        (card.Vehicle as Motorcycle).SetProperty(i_Pair);
                        break;
                    case VehicleFactory.eVehicleType.Truck:
                        (card.Vehicle as Truck).SetProperty(i_Pair);
                        break;
                }
            }
            else
            {
                //TODO : deal if card is null ?
            }
        }

        public void SetSharedVehicleProperty(string i_LicensePlate, KeyValuePair<string, string> i_Pair)
        {
            m_CustomerCards.TryGetValue(i_LicensePlate, out CustomerCard card);
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
            return m_Factory.GetUniqueDataFields((VehicleFactory.eVehicleType)i_LicenseType);
        }

        public List<string> GetSortedLicensePlates(int i_State)
        {
            List<string> plates = new List<string>();

            foreach (KeyValuePair<string, CustomerCard> entry in m_CustomerCards)
            {
                if ((CustomerCard.eRepairState)i_State == entry.Value.VehicleState)
                {
                    plates.Add(entry.Key);
                }
            }

            return plates;
        }

        
        public void ChargeElectricVehicle(string i_LicensePlate, int i_MinutesForCharge)
        {
            m_CustomerCards.TryGetValue(i_LicensePlate, out CustomerCard card);
            if(card != null)
            {
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
            else
            {
                //TODO : deal if card is null ?
            }
        }

        public void FuelGasDrivenVehicle(string i_LicensePlate, int i_FuelType, float i_LitresToFill)
        {
            m_CustomerCards.TryGetValue(i_LicensePlate, out CustomerCard card);
            if(card != null)
            {
                GasEngine engine = card.Vehicle.Engine as GasEngine;

                if (engine == null)
                {
                    throw new ArgumentException(String.Format("{0} is not electric", i_LicensePlate));
                }

                if (card != null)
                {
                    engine.AddFuel(i_LitresToFill, (VehicleFactory.eFuelType)i_FuelType);
                }
                else
                {
                    throw new ArgumentException(String.Format("{0} is not in garage", i_LicensePlate));
                }
            }
            else
            {
                //TODO : deal if card is null ?
            }
        }

        //TODO: chnage in UI - delete 2nd paraeter
        public void AddPressureToTires(string i_LicensePlate)
        {
            m_CustomerCards.TryGetValue(i_LicensePlate, out CustomerCard card);
            if (card != null)
            {
                card.Vehicle.AddPressureToTires();
            }
            else
            {
                //TODO : deal if card is null ?
            }
        }

        public bool IsVehicleInGarage(string i_LicensePlate)
        {
            return m_CustomerCards.ContainsKey(i_LicensePlate);
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
    }   
}
