using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            serviceChoice = GetValidServiceChoice();

            switch (serviceChoice)
            {
                case 1:
                    {
                        AddVehicleToGarage();
                    }
                case 2:
                    {

                    }
                case 3:
                    {

                    }
                case 4:
                    {

                    }
                case 5:
                    {

                    }
                case 6:
                    {

                    }
                case 7:
                    {

                    }
            }
        }

        private void AddVehicleToGarage()
        {
            Console.WriteLine("Enter vehicle licence plate number:");
            string licencePlate = Console.ReadLine();
            bool isVehicleExist = IsVehicleInGarage(licencePlate);
            if (isVehicleExist)
            {
                Console.WriteLine("The vehicle already in the garage...");
            }
            else
            {
                Console.WriteLine("Choose the vehicle type from following :");
                Console.WriteLine("(1) ");
                Console.WriteLine("(2) Show & Filter cars in the garage");
                Console.WriteLine("(3) Change car state in garage");
                Console.WriteLine("(4) Blow weels to max");
                Console.WriteLine("(5) Fule gas vehicle");

            }
        }

        private bool IsVehicleInGarage(string licencePlate)
        {
            throw new NotImplementedException();
        }

        private int GetValidServiceChoice()
        {
            throw new NotImplementedException();
        }
    }
}
