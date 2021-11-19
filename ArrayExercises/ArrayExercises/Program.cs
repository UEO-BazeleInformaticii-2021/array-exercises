using System;

namespace ArrayExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4 };
            PrintArray(array);
        }

        static void PrintArray(int[] array)
        {
            if (array is null)
            {
                Console.WriteLine("Array is null");
                return;
            }

            Console.Write("Array=");
            for (int i = 0; i < array.Length; i++)
            {
                int element = array[i];
                Console.Write(element);
                if (i < array.Length - 1)
                {
                    Console.Write(",");
                }
            }

            Console.WriteLine();
        }

        static int[] ReadArray()
        {
            // 1) Citesc nr de elemente
            int nrElemente = ReadNumber("Nr de elemente", 3, 0);

            int[] array = new int[nrElemente];

            // 2) Pentru fiecare pozitie (element) trebuie sa citesc valoarea
            for (int i = 0; i < nrElemente; i++)
            {
                array[i] = ReadNumber($"element[{i}]=", 3, 0);
            }

            return array;
        }

        static int ReadNumber(string label, int maxTries, int defaultValue)
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
