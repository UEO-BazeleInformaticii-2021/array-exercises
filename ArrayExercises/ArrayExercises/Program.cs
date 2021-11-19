using System;

namespace ArrayExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = ReadArray();
            PrintArray(array);
        }

        static int Min(int[] array)
        {
            if ((array is null) || (array.Length == 0))
            {
                return int.MinValue;
            }

            // 1. alegem ca si minim primul element din vector
            int min = array[0];

            // 2. iteram vectorul si la fiecare pas testam elementul curent cu minimul curent
            //     a) elementul curent < minimul => noul minim = elementul curent
            //     b) elementul curent > minimul => all good, merg mai departe
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
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
            int nrElemente = ReadNumber("Nr de elemente=", 3, 0);

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
