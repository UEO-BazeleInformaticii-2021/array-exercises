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

            bool hasChanges = true;
            do
            {
                // bucla de repetari
                for (int i = 0; i < array.Length - 1; i++)
                {
                    switch (sort)
                    {
                        case SortDirection.Descending:
                            hasChanges = array[i] < array[i + 1];
                            break;

                        case SortDirection.Ascending:
                        default:
                            hasChanges = array[i] > array[i + 1];
                            break;
                    }

                    if (hasChanges)
                    {
                        int aux = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = aux;
                        break;
                    }
                }
            }
            while (hasChanges);

            return array;
        }

        public static int[] SelectionSort(int[] array, SortDirection sort)
        {
            // 5 3 2 0 100
            // Cazul: sortare ascendenta

            // 0 5 3 2 100

            // pornesc o iterare incepand de la primul element => capat
            // la fiecare pas, incerc sa aduc pe pozitia curenta minimul din sub-vectorul care ramane pana la capat

            for (int i = 0; i < array.Length - 1; i++) // pozitia curenta pe care aduc minimul
            {

                for (int j = i + 1; j < array.Length; j++)
                // trebuie sa iterez sub-vectorul care incepe de la elementul urmator pozitiei curente
                // si merge pana la capatul vectorului
                {
                    bool hasChanges;
                    switch (sort)
                    {
                        case SortDirection.Descending:
                            hasChanges = array[i] < array[j];
                            break;

                        case SortDirection.Ascending:
                        default:
                            hasChanges = array[i] > array[j];
                            break;
                    }

                    if (hasChanges)
                    {
                        int aux = array[i];
                        array[i] = array[j];
                        array[j] = aux;
                    }
                }
            }

            return array;
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
    }
}
