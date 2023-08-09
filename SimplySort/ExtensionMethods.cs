using System;
using System.Reflection.Metadata.Ecma335;

namespace SimplySort
{
    public static class ExtensionMethods
    {
        public static void BubbleSort(this int[] array)
        {
            for (int n = 0; n < array.Length; n++)
            {
                for (int sort = 0; sort < array.Length - 1 - n; sort++)
                {
                    if (array[sort] > array[sort + 1])
                    {
                        int temp = array[sort + 1];
                        array[sort + 1] = array[sort];
                        array[sort] = temp;
                    }
                }
            }
        }
        public static void BubbleSort(this List<int> list)
        {
            int[] sorted = list.ToArray();
            sorted.BubbleSort();
            list.Clear();
            list.AddRange(sorted);
        }

        public static void SelectionSort(this int[] array)
        {
            List<int> list = new List<int>();
            list.AddRange(array);
            list.SelectionSort();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = list[i];
            }
        }
        public static void SelectionSort(this List<int> list)
        {
            int iterations = list.Count;
            List<int> sorted = new List<int>();
            for (int i = 0; i < iterations; i++)
            {
                int smallest = list[0];
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] < smallest)
                        smallest = list[j];
                }
                list.Remove(smallest);
                sorted.Add(smallest);
            }
            list.Clear();
            list.AddRange(sorted);
        }

        public static void InsertionSort(this int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        int temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public static void InsertionSort(this List<int> list)
        {
            int[] sorted = list.ToArray();
            sorted.InsertionSort();
            list.Clear();
            list.AddRange(sorted);
        }

        public static void MergeSort(this int[] array)
        {
            int[] temp = Split(array);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = temp[i];
            }
        }
        public static void MergeSort(this List<int> list)
        {
            int[] sorted = list.ToArray();
            sorted.MergeSort();
            list.Clear();
            list.AddRange(sorted);
        }
        static int[] Split(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            int[] left = Split(array.Take(array.Length / 2).ToArray());
            int[] right = Split(array.Skip(array.Length / 2).ToArray());
            return Merge(left, right);
        }
        static int[] Merge(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];
            int indexL = 0;
            int indexR = 0;
            for (int i = 0; i < merged.Length; i++)
            {
                if (left.Length > indexL && right.Length > indexR)
                {
                    if (left[indexL] < right[indexR])
                    {
                        merged[i] = left[indexL];
                        indexL++;
                    }
                    else
                    {
                        merged[i] = right[indexR];
                        indexR++;
                    }
                }
                else if (left.Length > indexL)
                {
                    merged[i] = left[indexL];
                    indexL++;
                }
                else if (right.Length > indexR)
                {
                    merged[i] = right[indexR];
                    indexR++;
                }
            }
            return merged;
        }  
    }
}
