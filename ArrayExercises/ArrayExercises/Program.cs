using System;

namespace ArrayExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = ArrayHelper.ReadArray();
            int[] sortedArrayDesc = ArrayHelper.SelectionSort(array, SortDirection.Descending);
            int[] sortedArrayAsc = ArrayHelper.SelectionSort(array, SortDirection.Ascending);

            ArrayHelper.PrintArray(sortedArrayAsc);
            ArrayHelper.PrintArray(sortedArrayDesc);
        }
    }
}
