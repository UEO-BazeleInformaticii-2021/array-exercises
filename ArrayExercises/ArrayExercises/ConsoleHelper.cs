using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExercises
{
    public static class ConsoleHelper
    {
        public static int ReadNumber(string label, int maxTries, int defaultValue)
        {
            int currentTry = 0;
            do
            {
                Console.Write(label);
                string valueAsString = Console.ReadLine();
                int valueAsNumber;
                bool isNumber = int.TryParse(valueAsString, out valueAsNumber);

                if (isNumber)
                {
                    return valueAsNumber;
                }

                currentTry++;
                Console.WriteLine($"The value '{valueAsString}' doen't represent a valid number, please try again ...");
            }
            while (currentTry < maxTries);

            return defaultValue;
        }
    }
}
