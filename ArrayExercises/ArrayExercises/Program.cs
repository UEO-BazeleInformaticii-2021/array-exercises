using System;

namespace ArrayExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 = ArrayHelper.ReadMatrix();
            int[,] matrix2 = ArrayHelper.ReadMatrix();
            int[,] sum = ArrayHelper.Sum(matrix1, matrix2);

            Console.WriteLine("--------------------------");

            ArrayHelper.PrintMatrix(sum);
        }

        static void Exercises_With_UnidimensionalArrays()
        {
            int[] array = ArrayHelper.ReadArray();
            int[] sortedArrayAsc = ArrayHelper.SelectionSort(array, SortDirection.Ascending);
            if (object.ReferenceEquals(array, sortedArrayAsc))
            {
                Console.WriteLine("Asc sort array has the same address with original array!");
            }

            int[] sortedArrayDesc = ArrayHelper.SelectionSort(array, SortDirection.Descending);
            if (object.ReferenceEquals(array, sortedArrayDesc))
            {
                Console.WriteLine("Desc sort array has the same address with original array!");
            }

            ArrayHelper.PrintArray(sortedArrayAsc);
            ArrayHelper.PrintArray(sortedArrayDesc);
        }
    }
}
