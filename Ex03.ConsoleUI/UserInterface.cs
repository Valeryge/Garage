using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        public void startupGarage()
        {
            int serviceChoice;

            Console.WriteLine("Welcome!");
            Console.WriteLine("Service Manu");
            Console.WriteLine("========================");
            Console.WriteLine("(1) Add vehicle to the garage");
            Console.WriteLine("(2) Show & Filter cars in the garage");
            Console.WriteLine("(3) Change car state in garage");
            Console.WriteLine("(4) Blow weels to max");
            Console.WriteLine("(5) Fule gas vehicle"); 
            Console.WriteLine("(6) Charge electric vehicle");
            Console.WriteLine("(7) Show full vehicle details");
            Console.WriteLine("Press your choice :");
            serviceChoice = Utils.GetNumberFromUser(1,7,"Invalid menu choice");

            switch (serviceChoice)
            {
                case 1:
                    AddVehicleToGarage();
                    break;
                case 2:
                    PrintAllVichelsPlateNumbers();
                    break;
                case 3:
                    ChangeVichelStatus();
                    break;
                case 4:
                    InflateAirWheels();
                    break;
                case 5:
                    AddFuelToVichel();
                    break;
                case 6:
                    ChargeVichel();
                    break;
                case 7:
                    PrintVichel();
                    break;
            }
        }

        private void PrintVichel()
        {
            Console.WriteLine("Enter vichel licence plate number:");
            string licencePlate = Console.ReadLine();
            //todo: call garage manager
        }

        private void ChargeVichel()
        {
            Console.WriteLine("Enter vichel licence plate number:");
            string licencePlate = Console.ReadLine();
            Console.WriteLine("Enter charge minutes to add:");
            int chargeMinutes = Utils.GetNumberFromUser(0, "Invalid charge minutes");
            
            //todo: call garage manager
        }

        private void AddFuelToVichel()
        {
            Console.WriteLine("Enter vichel licence plate number:");
            string licencePlate = Console.ReadLine();
            Console.WriteLine("Enter fuel type:");
            PrintFuelOptionsString();
            int fuelType = Utils.GetNumberFromUser(1,
              Enum.GetValues(typeof(GarageLogic.VehicleFactory.FuelType)).Length,
              "Invalid fuel option");
            Console.WriteLine("Enter fuel amount to add (liters):");
            float fuleToAdd = Utils.GetFloatFromUser(0, "Invalid fuel number");

            //todo: send to garage manager
        }

        private void InflateAirWheels()
        {
            Console.WriteLine("Enter vichel licence plate number:");
            string licencePlate = Console.ReadLine();
            //todo: call garage manager

        }

        private void ChangeVichelStatus()
        {
            Console.WriteLine("Enter vichel licence plate number:");
            string licencePlate = Console.ReadLine();
            Console.WriteLine("Enter new vichel status:");
            PrintRepairStates();
            int newRepairState = Utils.GetNumberFromUser(1, 
                Enum.GetValues(typeof(GarageLogic.CustomerCard.RepairState)).Length,
                "Invalid repair state");

            //todo: call garage logic and change status
        }

        private void PrintAllVichelsPlateNumbers()
        {
            Console.WriteLine("Enter new filter status:");
            Console.WriteLine("0 - All");
            PrintRepairStates();
            int repairStatus = Utils.GetNumberFromUser(0,
              Enum.GetValues(typeof(GarageLogic.CustomerCard.RepairState)).Length,
              "Invalid repair state");
            //todo: get vichels plate numbers by filter
            //handle 0
            //print them
        }

        private void AddVehicleToGarage()
        {
            Console.WriteLine("Enter vehicle licence plate number:");
            string licencePlate = Console.ReadLine();
            bool isVehicleExist = IsVehicleInGarage(licencePlate);
            if (isVehicleExist)
            {
                //todo: print new status
            }
            else
            {
                Console.WriteLine("Please enter vichel type: ");
                PrintVehicleTypeOptionsString();
                int vichelType = Utils.GetNumberFromUser(0, Enum.GetValues(typeof(GarageLogic.VehicleFactory.VehicleType)).Length, "Invalid vichel type");
                Console.WriteLine("Please enter model name: ");
                string modelName = Console.ReadLine();
                Console.WriteLine("Please enter enery percentage: ");
                float energyPercentage = Utils.GetFloatFromUser(0, "Invalid energy percentage");
               
                List<GarageLogic.Wheel> wheels = GetWheelsFromUser();
                Dictionary<string, string> selected = new Dictionary<string, string>();

                GarageLogic.VehicleFactory factory = new GarageLogic.VehicleFactory();
                List<string> attributes = factory.GetUniqueDataFields((GarageLogic.VehicleFactory.VehicleType)vichelType);

                foreach (string attribute in attributes)
                {
                    Console.WriteLine(String.Format("Please enter {0}\n", attribute));
                    string attributeValue = Console.ReadLine();
                    selected.Add(attribute, attributeValue);
                }
            }
        }

        private List<Wheel> GetWheelsFromUser()
        {
            List<Wheel> wheels = new List<Wheel>();
            Console.WriteLine("Please enter number of wheels");
            //TODO: get wheels num based on vichel type and not user
            int numberOfWheels = Utils.GetNumberFromUser(2,"Invalid number of wheels");
            
            for(int i=0; i < numberOfWheels; i++)
            {
                Console.WriteLine("Please enter wheel manufacture name");
                string manufactorName = Console.ReadLine();
                Console.WriteLine("Please enter current air pressure");
                float airPressure = Utils.GetFloatFromUser(1,"Invalid number of air pressure");
                Console.WriteLine("Please enter max air pressure");
                float maxAirPressure = Utils.GetFloatFromUser(1, "Invalid number of max air pressure");

                Wheel wheel = new Wheel(manufactorName,airPressure,maxAirPressure);
                wheels.Add(wheel);
            }

            return wheels;
        }

        private bool IsVehicleInGarage(string licencePlate)
        {
            throw new NotImplementedException();
        }

        private int GetValidServiceChoice()
        {
            throw new NotImplementedException();
        }


        //public StringBuilder GetAllLicensePlatesString()
        //{
        //    StringBuilder licensePlates = new StringBuilder();

        //    foreach (KeyValuePair<string, GarageLogic.CustomerCard> entry in m_CustomerCards)
        //    {
        //        licensePlates.Append(entry.Key);
        //        licensePlates.Append("\n");
        //    }

        //    return licensePlates;
        //}

        public void PrintVehicleTypeOptionsString()
        {
            Utils.PrintEnumValues(typeof(GarageLogic.VehicleFactory.VehicleType));
        }

        public void PrintColorOptionsString()
        {
            Utils.PrintEnumValues(typeof(GarageLogic.Car.Color));
        }

        public void PrintFuelOptionsString()
        {
            Utils.PrintEnumValues(typeof(GarageLogic.VehicleFactory.FuelType));
        }

        public void PrintRepairStates()
        {
            Utils.PrintEnumValues(typeof(GarageLogic.CustomerCard.RepairState));
        }
    }
}
