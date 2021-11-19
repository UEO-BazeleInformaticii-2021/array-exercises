using System;

namespace ArrayExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
        }
    }
}
