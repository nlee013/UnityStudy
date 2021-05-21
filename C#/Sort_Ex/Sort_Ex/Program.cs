using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"My : {Sqrt(2)}");
            //Console.WriteLine($"Math.Sqrt : {Math.Sqrt(2)}");
            int[] a = { 4, 8, 5, 7, 2, 23 };
            var sorted = SelectionSort(a);
            foreach (var v in sorted)
            {
                Console.WriteLine(v);
            }


            //int temp = 0;
            //for (int i = 0; i < data.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < data.Length; j++)
            //    {
            //        if (data[i] > data[j])
            //        {
            //            temp = data[i];
            //            data[i] = data[j];
            //            data[j] = temp;
            //        }
            //    }
            //}

            //for (int i = 0; i < data.Length; i++)
            //{
            //    Console.Write($"{data[i]}" + " ");
            //}
        }

        //static int[] SelectionSort<T>(T[] a)
        //{
        //    bool[] used = new bool[a.Length];

        //    for (int i = 0; i < used.Length; i++)
        //    {
        //        used[i] = false;
        //    }

        //    int[] result = new int[a.Length];


        //    for (int j = 0; j < a.Length; j++)
        //    {
        //        // Find Minimum
        //        int min = int.MaxValue;
        //        int minIndex = -1;

        //        for (int i = 0; i < a.Length; i++)
        //        {
        //            if (a[i] < min && used[i] == false)
        //            {
        //                min = a[i];
        //                minIndex = i;
        //            }
        //        }
        //        used[minIndex] = true;
        //        result[j] = min;
        //    }

        //    return result;
        //}
        //static T[] SelectionSort2<T>(T[] data) where T : IComparable
        //{

        //    for (int i = 0; i < data.Length - 1; i++)
        //    {
        //        var temp=0;
        //        for (int j = i + 1; j < data.Length; j++)
        //        {
        //            if (data[i] > data[j])
        //            {
        //                temp = data[i];
        //                data[i] = data[j];
        //                data[j] = temp;
        //            }
        //        }
        //    }
        //    return data;
        //}
        static double Sqrt(double t)
        {
            double Xn = 1;
            for (int i = 0; i < 10; i++)
            {
                Xn = Xn - (Xn * Xn - t) / (2 * Xn);
            }

            return Xn;
        }

    }
}
