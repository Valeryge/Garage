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

        //TODO return bool if already exists
        public bool AddVehicleToGarage(string i_LicensePlate, string i_CustomerName, string i_CustomerPhone, int i_VehicleType)
        {
            bool added = false;

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
                added = true;
            }

            return added;
        }


        //TODO change to int
        public StringBuilder GetSortedLicensePlates(int i_State)
        {
            StringBuilder licensePlates = new StringBuilder();
            

            foreach (KeyValuePair<string, CustomerCard> entry in m_CustomerCards)
            {
                if ((CustomerCard.RepairState)i_State == entry.Value.VehicleState)
                {
                    licensePlates.Append(entry.Key);
                    licensePlates.Append("\n");
                }
            }

            return licensePlates;
        }

        public void AddGasCar()
        {
            
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

        private bool isValidFuelType(int i_FuelType)
        {
            bool isValid = false;

            if (Enum.IsDefined(typeof(VehicleFactory.FuelType), i_FuelType))
            {
                isValid = true;
            }

            return isValid;
        }

        public bool IsVehicleInGarage(string i_LisencePlate)
        {
            return m_CustomerCards.ContainsKey(i_LisencePlate);
        }

        private bool isValidVehicleType(int i_Type)
        {
            bool isValid = false;

            if (Enum.IsDefined(typeof(VehicleFactory.VehicleType), i_Type))
            {
                isValid = true;
            }

            return isValid;
        }
    }   
}
