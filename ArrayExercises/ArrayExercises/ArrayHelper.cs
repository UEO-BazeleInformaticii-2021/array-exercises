using System;

namespace ArrayExercises
{
    public static class ArrayHelper
    {
        public static int[] BubbleSort(int[] array, SortDirection sort)
        {
            // 5 3 2 0 100
            // 3 5 2 0 100
            // 3 2 5 0 100
            // 2 3 5 0 100

            // incepem de la primul element
            // incepem si iteram array-ul

            // Cazul: sortare ascendenta
            // la fiecare pas testam: elementul curent < elementul urmator?
            //      DA => all good, pot merge mai departe
            //      NU => interschimbam elementul curent cu elementul urmator
            //            o iau inapoi de la capat

            int[] sortedArray = Clone(array);

            bool hasChanges = true;
            do
            {
                // bucla de repetari
                for (int i = 0; i < sortedArray.Length - 1; i++)
                {
                    switch (sort)
                    {
                        case SortDirection.Descending:
                            hasChanges = sortedArray[i] < sortedArray[i + 1];
                            break;

                        case SortDirection.Ascending:
                        default:
                            hasChanges = sortedArray[i] > sortedArray[i + 1];
                            break;
                    }

                    if (hasChanges)
                    {
                        int aux = sortedArray[i];
                        sortedArray[i] = sortedArray[i + 1];
                        sortedArray[i + 1] = aux;
                        break;
                    }
                }
            }
            while (hasChanges);

            return sortedArray;
        }

        public static int[] SelectionSort(int[] array, SortDirection sort)
        {
            // 5 3 2 0 100
            // Cazul: sortare ascendenta

            // 0 5 3 2 100

            // pornesc o iterare incepand de la primul element => capat
            // la fiecare pas, incerc sa aduc pe pozitia curenta minimul din sub-vectorul care ramane pana la capat

            int[] sortedArray = Clone(array);

            for (int i = 0; i < sortedArray.Length - 1; i++) // pozitia curenta pe care aduc minimul
            {

                for (int j = i + 1; j < sortedArray.Length; j++)
                // trebuie sa iterez sub-vectorul care incepe de la elementul urmator pozitiei curente
                // si merge pana la capatul vectorului
                {
                    bool hasChanges;
                    switch (sort)
                    {
                        case SortDirection.Descending:
                            hasChanges = sortedArray[i] < sortedArray[j];
                            break;

                        case SortDirection.Ascending:
                        default:
                            hasChanges = sortedArray[i] > sortedArray[j];
                            break;
                    }

                    if (hasChanges)
                    {
                        int aux = sortedArray[i];
                        sortedArray[i] = sortedArray[j];
                        sortedArray[j] = aux;
                    }
                }
            }

            return sortedArray;
        }

        public static int Min(int[] array)
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

        public static void PrintArray(int[] array)
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

        public static int[] ReadArray()
        {
            // 1) Citesc nr de elemente
            int nrElemente = ConsoleHelper.ReadNumber("Nr de elemente=", 3, 0);

            int[] array = new int[nrElemente];

            // 2) Pentru fiecare pozitie (element) trebuie sa citesc valoarea
            for (int i = 0; i < nrElemente; i++)
            {
                array[i] = ConsoleHelper.ReadNumber($"element[{i}]=", 3, 0);
            }

            return array;
        }

        public static int[] Clone(int[] array)
        {
            if (array is null)
            {
                return new int[0];
            }

            int[] clone = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                clone[i] = array[i];
            }

            return clone;
        }

        public static int[,] ReadMatrix()
        {
            // citesc nr de linii
            int rowsCount = ConsoleHelper.ReadNumber("Nr de linii=", 3, 0);

            // citesc nr de coloane
            int colsCount = ConsoleHelper.ReadNumber("Nr de coloane=", 3, 0);

            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int element = ConsoleHelper.ReadNumber($"Element[{row},{col}]=", 3, 0);
                    matrix[row, col] = element;
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            if (matrix is null)
            {
                Console.WriteLine("Matrix is null");
                return;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col],6}");
                }

                Console.WriteLine();
            }
        }

        public static int[,] Sum(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1 is null)
            {
                Console.WriteLine($"{nameof(matrix1)} is null, cannot calculate sum!");
                return new int[0, 0];
            }

            if (matrix2 is null)
            {
                Console.WriteLine($"{nameof(matrix2)} is null, cannot calculate sum!");
                return new int[0, 0];
            }

            // calculate dimensions of matrix1
            int rowsCount1 = matrix1.GetLength(0);
            int colsCount1 = matrix1.GetLength(1);

            // calculate dimensions of matrix2
            int rowsCount2 = matrix2.GetLength(0);
            int colsCount2 = matrix2.GetLength(1);

            if (rowsCount1 != rowsCount2 || colsCount1 != colsCount2)
            {
                Console.WriteLine($"Dimensions of the two matrices are not the same, cannot calculate sum!");
                return new int[0, 0];
            }

            int[,] sum = new int[rowsCount1, colsCount1];
            for (int row = 0; row < rowsCount1; row++)
            {
                for (int col = 0; col < colsCount1; col++)
                {
                    sum[row, col] = matrix1[row, col] + matrix2[row, col];
                }
            }

            return sum;
        }
    }
}
