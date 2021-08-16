using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public enum VehicleType
        {
            GasCar = 1,
            ElectricCar = 2,
            GasMotorcycle = 3,
            ElectricMotorcycle = 4,
            Truck = 5
        }

        public enum RepairState
        {
            InProgress = 0,
            Fixed = 1,
            Paid = 2
        }

        private Dictionary<string, Customer> m_CustomerCards = new Dictionary<string, Customer>();


        public void Charge(string plate, int hours)
        {
            Customer customer = m_CustomerCards[plate];
            if (customer.Vehicle.Type == VehicleType.ElectricCar)
            {
                (customer.Vehicle as ElectricCar).Engine.Charge(hours);
            }
            else if (customer.Vehicle.Type == VehicleType.ElectricMotorcycle)
            {
                (customer.Vehicle as ElectricMotorcycle).Engine.Charge(hours);
            }
            else
            {
                throw new Exception("The vehicle type is not electric");
            }

        }


        public void addGasCar()
        {

        }

        public void addElectricCar()
        {

        }

        public void addGasMotorcycle()
        {

        }

        public void addElectricMotorcycle()
        {

        }

        public void addTrack()
        {

        }

    }   
}
