using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        GarageManager m_GarageManager;

        public UserInterface()
        {
            m_GarageManager = new GarageManager();
        }

        public void showMenu()
        {
            bool isWorking = true;

            while (isWorking)
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
                serviceChoice = Utils.GetNumberFromUser(1, 8, "Invalid menu choice");

                switch (serviceChoice)
                {
                    case 1:
                        AddVehicleToGarage();
                        break;
                    case 2:
                        PrintAllVichelsPlateNumbers();
                        break;
                    case 3:
                        ChangeVehicleStatus();
                        break;
                    case 4:
                        InflateAirWheels();
                        break;
                    case 5:
                        AddFuelToVichel();
                        break;
                    case 6:
                        ChargeVehicle();
                        break;
                    case 7:
                        PrintVehicle();
                        break;
                    case 8:
                        isWorking = false;
                        Console.WriteLine("Good bye");
                        break;
                }
                bool a = true;
                System.Console.Clear();
            }
        }

        private void PrintVehicle()
        {
            string licencePlate = GetLicensePlateNumber(out bool found);
            if (found)
            {
                Dictionary<string, object> data = m_GarageManager.GetVehicleData(licencePlate);
                if (data == null)
                {
                    Console.WriteLine("Vichel data not found");
                }
                else
                {
                    foreach (KeyValuePair<string, object> entry in data)
                    {
                        Console.WriteLine("{0}: {1}", entry.Key, entry.Value.ToString());
                    }
                }
            }
            else
            {
                PrintVichelDidntFound();
            }
        }

        private void ChargeVehicle()
        {
            string licencePlate = GetLicensePlateNumber(out bool found);
            if (found)
            {
                Console.WriteLine("Enter charge minutes to add:");
                int chargeMinutes = Utils.GetNumberFromUser(0, "Invalid charge minutes");
                try
                {
                    m_GarageManager.ChargeElectricVehicle(licencePlate, chargeMinutes);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                PrintVichelDidntFound();
            }
        }

        private void AddFuelToVichel()
        {

            string licencePlate = GetLicensePlateNumber(out bool found);
            if (found)
            {
                Console.WriteLine("Enter fuel type:");
                PrintFuelOptionsString();
                int fuelType = Utils.GetNumberFromUser(1,
                  Enum.GetValues(typeof(GarageLogic.VehicleFactory.FuelType)).Length,
                  "Invalid fuel option");
                Console.WriteLine("Enter fuel amount to add (liters):");
                float fuleToAdd = Utils.GetFloatFromUser(0, "Invalid fuel number");
                try
                {
                    m_GarageManager.FuelGasDrivenVehicle(licencePlate, fuelType, fuleToAdd);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                PrintVichelDidntFound();
            }
        }

        private void InflateAirWheels()
        {
            string licencePlate = GetLicensePlateNumber(out bool found);
            if (found)
            {
                Console.WriteLine("Enter vehicle air presure number:");
                float pressure = Utils.GetFloatFromUser(0, "Air Presurre cannot be negative");
                try
                {
                    m_GarageManager.AddPressureToTires(licencePlate, pressure);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                PrintVichelDidntFound();
            }
        }

        private void ChangeVehicleStatus()
        {
            string licencePlate = GetLicensePlateNumber(out bool found);
            if (found)
            {
                Console.WriteLine("Enter new vehicle status:");
                PrintRepairStates();
                int newRepairState = Utils.GetNumberFromUser(1,
                    Enum.GetValues(typeof(GarageLogic.CustomerCard.RepairState)).Length,
                    "Invalid repair state");
                try
                {
                    m_GarageManager.ChangeVehicleRepairState(licencePlate, newRepairState);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                PrintVichelDidntFound();
            }
        }
     
        private void PrintAllVichelsPlateNumbers()
        {
            Console.WriteLine("Enter new filter status:");
            Console.WriteLine("0 - All");
            PrintRepairStates();
            int repairStatus = Utils.GetNumberFromUser(0,
              Enum.GetValues(typeof(GarageLogic.CustomerCard.RepairState)).Length,
              "Invalid repair state");
            List<string> plates = repairStatus == 0 ? m_GarageManager.GetAllLicensePlates() : m_GarageManager.GetSortedLicensePlates(repairStatus);
            if (plates == null || plates.Count == 0)
            {
                Console.WriteLine("No vichel found in this status");
            }
            else
            {
                foreach (string plate in plates)
                {
                    Console.WriteLine(plate);
                }
            }
        }

        private void AddVehicleToGarage()
        {
            string licensePlate = GetLicensePlateNumber(out bool alreadyExists);
            if (alreadyExists)
            {
                try
                {
                    m_GarageManager.ChangeVehicleRepairState(licensePlate, 1);
                    Console.WriteLine("Changed repair status to in repair");
                }catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Please enter vehicle type: ");
                PrintVehicleTypeOptionsString();
                int vehicleType = Utils.GetNumberFromUser(0, Enum.GetValues(typeof(GarageLogic.VehicleFactory.VehicleType)).Length, "Invalid vichel type");
                Console.WriteLine("Please enter customer name");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter customer phone");
                string phone = Console.ReadLine();

                m_GarageManager.AddVehicleToGarage(licensePlate, name, phone, vehicleType);
                List<string> sharedAttributes = m_GarageManager.GetSharedPropertyNames();

                foreach (string attribute in sharedAttributes)
                {
                    bool toContinue = true;
                    PrintAttributeRequest(attribute);
                    while (toContinue)
                    {
                        string input = Console.ReadLine();
                        try
                        {
                            m_GarageManager.SetSharedVehicleProperty(licensePlate, new KeyValuePair<string, string>(attribute, input));
                            toContinue = false;
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                    }
                    
                }

                List<string> uniqueAttributes = m_GarageManager.GetUniqueDataFields(vehicleType);

                foreach (string attribute in uniqueAttributes)
                {
                    bool toContinue = true;
                    PrintAttributeRequest(attribute);
                    while (toContinue)
                    {
                        try
                        {
                            string attributeValue = Console.ReadLine();
                            m_GarageManager.SetProperty(licensePlate, new KeyValuePair<string, string>(attribute, attributeValue));
                            toContinue = false;
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                    }
                }
            }
        }

        private void PrintAttributeRequest(string attribute)
        {
            Console.WriteLine(String.Format("Please enter {0}\n", attribute));
            if(attribute == "color")
            {
                PrintColorOptionsString();
            }
        }

        private string GetLicensePlateNumber(out bool io_found)
        {
            Console.WriteLine("Enter vehicle license plate number:");
            string licensePlate = Console.ReadLine();
            io_found = m_GarageManager.IsVehicleInGarage(licensePlate);
            return licensePlate;
        }

        private void PrintVichelDidntFound()
        {
            Console.WriteLine("Didn't find a vichel with this plate number");
        }

        private void PrintVehicleTypeOptionsString()
        {
            Utils.PrintEnumValues(typeof(GarageLogic.VehicleFactory.VehicleType));
        }

        private void PrintColorOptionsString()
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