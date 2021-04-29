using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static void OutpuArrayInfo(Array arr)
        {
            Console.WriteLine("배열의 차원 수 : " + arr.Rank); // Rank 프로퍼티
            Console.WriteLine("배열의 요소 수   : " + arr.Length); // Length 프로퍼ㅌ;
            Console.WriteLine();
        }

        private static void OutputArrayElements(string title, Array arr)
        {
            Console.WriteLine("[" + title + "]");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr.GetValue(i) + ","); // GetValue 인스턴스 메서드
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            bool[,] boolArray = new bool[,] { { true, false }, { false, false } }; // bool 2차원 배열로 { true, false }, { false, false }의 배열 요소를 받음
            OutpuArrayInfo(boolArray); // 배열의 차원수, 요소 수를 보여줌

            int[] intArray = new int[] { 5, 4, 3, 2, 1, 0 };
            OutpuArrayInfo(intArray);

            OutputArrayElements("원본 intArray", intArray);
            Array.Sort(intArray); // Sort 정적 메서드
            OutputArrayElements("Array.Sort 후 intArray", intArray);

            int[] copyArray = new int[intArray.Length];
            Array.Copy(intArray, copyArray, intArray.Length); // Copy 정적 메서드

            OutputArrayElements("intArray로부터 복사된 copyArray", copyArray);
        }
    }
}
