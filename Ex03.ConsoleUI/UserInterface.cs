using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        private GarageManager m_GarageManager;

        public UserInterface()
        {
            m_GarageManager = new GarageManager();
        }

        public void ShowMenu()
        {
            bool isWorking = true;

            while (isWorking)
            {
                int serviceChoice;

                Console.WriteLine("Welcome!");
                Console.WriteLine("Service Menu");
                Console.WriteLine("========================");
                Console.WriteLine("(1) Add vehicle to the garage");
                Console.WriteLine("(2) Show & Filter vehicles in the garage");
                Console.WriteLine("(3) Change vehicle state in garage");
                Console.WriteLine("(4) Blow wheels to max");
                Console.WriteLine("(5) Fuel gas vehicle");
                Console.WriteLine("(6) Charge electric vehicle");
                Console.WriteLine("(7) Show full vehicle details");
                Console.WriteLine("(8) Exit");
                Console.WriteLine("========================");
                Console.WriteLine("Press your choice :");
                serviceChoice = Utils.GetNumberFromUser(1, 8, "Invalid menu choice");
                switch (serviceChoice)
                {
                    case 1:
                        addVehicleToGarage();
                        break;
                    case 2:
                        printAllVehiclesPlateNumbers();
                        break;
                    case 3:
                        changeVehicleStatus();
                        break;
                    case 4:
                        inflateAirWheels();
                        break;
                    case 5:
                        addFuelToVehicle();
                        break;
                    case 6:
                        chargeVehicle();
                        break;
                    case 7:
                        printVehicle();
                        break;
                    case 8:
                        isWorking = false;
                        Console.WriteLine("Good bye");
                        break;
                }

                Console.WriteLine("\n\nPress any key to clear screen");
                Console.ReadKey();
                System.Console.Clear();
            }
        }

        private void printVehicle()
        {
            string licensePlate = getLicensePlateNumber(out bool found);
            if (found)
            {
                Dictionary<string, object> data = m_GarageManager.GetVehicleData(licensePlate);
                if (data == null)
                {
                    Console.WriteLine("Vehicle data not found");
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
                printVehicleDidNotFound();
            }
        }

        private void chargeVehicle()
        {
            string licensePlate = getLicensePlateNumber(out bool found);
            if (found)
            {
                Console.WriteLine("Enter charge minutes to add:");
                int chargeMinutes = Utils.GetNumberFromUser(0, "Invalid charge minutes");
                try
                {
                    m_GarageManager.ChargeElectricVehicle(licensePlate, chargeMinutes);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                printVehicleDidNotFound();
            }
        }

        private void addFuelToVehicle()
        {
            string licensePlate = getLicensePlateNumber(out bool found);
            if (found)
            {
                Console.WriteLine("Enter fuel type:");
                printFuelOptionsString();
                int fuelType = Utils.GetNumberFromUser(1,
                  Enum.GetValues(typeof(GarageLogic.VehicleFactory.eFuelType)).Length,
                  "Invalid fuel option");
                Console.WriteLine("Enter fuel amount to add (liters):");
                float fuelToAdd = Utils.GetFloatFromUser(0, "Invalid fuel number");
                try
                {
                    m_GarageManager.FuelGasDrivenVehicle(licensePlate, fuelType, fuelToAdd);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                printVehicleDidNotFound();
            }
        }

        private void inflateAirWheels()
        {
            string licensePlate = getLicensePlateNumber(out bool found);

            if (found)
            {
                try
                {
                    m_GarageManager.AddPressureToTires(licensePlate);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                printVehicleDidNotFound();
            }
        }

        private void changeVehicleStatus()
        {
            string licensePlate = getLicensePlateNumber(out bool found);
            if (found)
            {
                Console.WriteLine("Enter new vehicle status:");
                printRepairStates();
                int newRepairState = Utils.GetNumberFromUser(1,
                    Enum.GetValues(typeof(GarageLogic.CustomerCard.eRepairState)).Length,
                    "Invalid repair state");
                try
                {
                    m_GarageManager.ChangeVehicleRepairState(licensePlate, newRepairState);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                printVehicleDidNotFound();
            }
        }
     
        private void printAllVehiclesPlateNumbers()
        {
            Console.WriteLine("Enter new filter status:");
            Console.WriteLine("0 - All");
            printRepairStates();
            int repairStatus = Utils.GetNumberFromUser(0,
              Enum.GetValues(typeof(GarageLogic.CustomerCard.eRepairState)).Length,
              "Invalid repair state");
            List<string> plates = repairStatus == 0 ? m_GarageManager.GetAllLicensePlates() : m_GarageManager.GetSortedLicensePlates(repairStatus);
            if (plates == null || plates.Count == 0)
            {
                Console.WriteLine("No vehicles found");
            }
            else
            {
                Console.WriteLine("Found vehicles:");
                foreach (string plate in plates)
                {
                    Console.WriteLine(plate);
                }
            }
        }

        private void addVehicleToGarage()
        {
            string licensePlate = getLicensePlateNumber(out bool alreadyExists);
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
                printVehicleTypeOptionsString();
                int vehicleType = Utils.GetNumberFromUser(0, Enum.GetValues(typeof(GarageLogic.VehicleFactory.eVehicleType)).Length, "Invalid vehicle type");
                Console.WriteLine("Please enter customer name");
                string name = Console.ReadLine();
                string phone = getPhoneNumber();

                m_GarageManager.AddVehicleToGarage(licensePlate, name, phone, vehicleType);
                List<string> sharedAttributes = m_GarageManager.GetSharedPropertyNames();

                foreach (string attribute in sharedAttributes)
                {
                    bool toContinue = true;
                    printAttributeRequest(attribute);
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
                    printAttributeRequest(attribute);
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

        private string getPhoneNumber()
        {
            bool valid = false;
            string phone = "";
            Console.WriteLine("Please enter customer phone");
            while (!valid)
            {
                phone = Console.ReadLine();
                if(phone.Length > 0 && Int32.TryParse(phone,out int number))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid phone number, please try again");
                }
            }
            return phone;
        }

        private void printAttributeRequest(string attribute)
        {
            Console.WriteLine(String.Format("Please enter {0}\n", attribute));
            if(attribute == "color")
            {
                printColorOptionsString();
            }

            if (attribute == "if holds dangerous substences")
            {
                Console.WriteLine("Press 1 for YES\n press 0 for NO");
            }

            if (attribute == "license Type")
            {
                printLicenseTypeOptions();
            }
        }

        private string getLicensePlateNumber(out bool io_found)
        {
            Console.WriteLine("Enter vehicle license plate number:");
            string licensePlate = Console.ReadLine();
            io_found = m_GarageManager.IsVehicleInGarage(licensePlate);
            return licensePlate;
        }

        private void printVehicleDidNotFound()
        {
            Console.WriteLine("Vehicle not in garage");
        }

        private void printVehicleTypeOptionsString()
        {
            Utils.PrintEnumValues(typeof(GarageLogic.VehicleFactory.eVehicleType));
        }

        private void printColorOptionsString()
        {
            Utils.PrintEnumValues(typeof(GarageLogic.Car.eColor));
        }

        private void printLicenseTypeOptions()
        {
            Utils.PrintEnumValues(typeof(GarageLogic.Motorcycle.eLicenseType));
        }

        private void printFuelOptionsString()
        {
            Utils.PrintEnumValues(typeof(GarageLogic.VehicleFactory.eFuelType));
        }

        private void printRepairStates()
        {
            Utils.PrintEnumValues(typeof(GarageLogic.CustomerCard.eRepairState));
        }
    }
}