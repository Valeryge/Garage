using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public static class Utils
    {
     
        public static int GetNumberFromUser(int i_MinValue, int i_MaxValue, string i_ErrorMessage)
        {
            int value;
            while (true)
            {
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out value))
                {
                    if (value >= i_MinValue && value <= i_MaxValue)
                    {
                        break;
                    }
                }
                Console.WriteLine(i_ErrorMessage);
            }
            return value;
        }

        public static int GetNumberFromUser(int i_MinValue, string i_ErrorMessage)
        {
            return GetNumberFromUser(i_MinValue, Int32.MaxValue, i_ErrorMessage);
        }


        public static float GetFloatFromUser(float i_MinValue, string i_ErrorMessage)
        {
            float value;
            while (true)
            {
                string input = Console.ReadLine();

                if (float.TryParse(input, out value))
                {
                    if (value >= i_MinValue)
                    {
                        break;
                    }
                }
                Console.WriteLine(i_ErrorMessage);
            }
            return value;
        }

        public static void PrintEnumValues(Type i_EnumType)
        {
            StringBuilder values = new StringBuilder();

            foreach (int type in Enum.GetValues(i_EnumType))
            {
                String name = Enum.GetName(i_EnumType, type);
                String line = String.Format("{0} - {1}\n", type, name);
                values.Append(line);
            }

            Console.WriteLine(values);
        }

    }
}
