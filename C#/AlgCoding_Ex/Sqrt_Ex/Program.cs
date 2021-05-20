using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqrt_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            // 스왑
            int a = 30;
            int b = 20;
            Console.WriteLine($"Swap Before => a={a}, b={b}");
            Swap(ref a, ref b);
            Console.WriteLine($"Swap After => a={a}, b={b}");
            Console.WriteLine();
            Console.WriteLine("=======================");



            // 최솟값 구하기
            int[] data = { 6, 4, 2, 5, 8, 15, 3, 8, 7, 10 };

            int min = data[0];

            for (int i = 0; i < data.Length; i++)
            {
                if (min > data[i])
                {
                    min = data[i];
                }
            }
            Console.WriteLine($"최솟 값 : {min}");
            Console.WriteLine();
            Console.WriteLine("=======================");


            // 덧셈
            int sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i];
            }
            Console.WriteLine($"Data Sum : {sum}");
            Console.WriteLine();
            Console.WriteLine("=======================");

            // 짝수값만 덧셈
            int EvenSum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if(data[i] % 2 == 0)
                {
                    EvenSum += data[i];
                }
            }
            Console.WriteLine($"Data EvenSum : {EvenSum}");
            Console.WriteLine();
            Console.WriteLine("=======================");


            // Contain 사용연습
            //string str = "Heollo World!";
            //string target = "W";

            //if(str.Contains(target))
            //{
            //    Console.WriteLine($"{target}을 찾았습니다.");
            //}
            //else
            //{
            //    Console.WriteLine($"{target}을 찾지 못 했습니다.");
            //}
            //Console.WriteLine();
            //Console.WriteLine("=======================");

            // Contain 알고리즘
            int aa = 1, bb = 2;
            (a, b) = (b, a);

            Console.WriteLine();

            // AddSub
            Console.WriteLine(AddSub(2, 3));

            // Root 계산
            Console.WriteLine(Root(1,-6,3));

        }

        static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        static (int, int) AddSub(int a, int b)
        {
            return (a + b, a - b);
        }

        static (float, float) Root(int ra, int rb, int rc)
        {
            var temp = Math.Sqrt(rb * rb - 4 * ra * rc);
            return ((float)(-rb + temp) / (2 * ra), (float)(-rb - temp) / (2 * ra));
        }

        static int Minn(int[] a)
        {
            int result = int.MaxValue;
            foreach(var v in a)
            {
                if(v < result)
                {
                    result = v;
                }
            }
            return result;
        }

    }
//namespace ConsoleApp3
//    {
//        class Program
//        {
//            static void Main(string[] args)
//            {

//                int[] a = { 5, 3, 2, 8, 9 };
//                int b = 2;
//                for (int i = 0; i < a.Length; i++)
//                {
//                    Write(a[i]);
//                }
//                Write("{");
//                foreach (var v in a)
//                {
//                    Write(v + " ");
//                }
//                Write("}");
//                WriteLine();
//                WriteLine("Min 계산하기");
//                WriteLine(": " + Min(a));
//                WriteLine("Sum 계산하기");
//                WriteLine(": " + Sum(a));
//                WriteLine("Mean 계산하기");
//                WriteLine(": " + Mean(new int[] { 1, 2, 3, 4, 5 }));
//                WriteLine("EvenSum 계산하기");
//                WriteLine(": " + EvenSum(new int[] { 2, 45, 587, 98, 45 }));
//                WriteLine("EvenEvenSum 계산하기");
//                WriteLine(": " + EvenEvenSum(a));
//                WriteLine($"Contains({a},{b}) 계산하기");
//                WriteLine(": " + Contains(a, b));
//            }
//            static (int, int) AddSub(int a, int b)
//            {
//                return (a + b, a - b);
//            }
//            static void Swap(int a, int b)
//            {
//                int temp;
//                temp = a;
//                a = b;
//                b = temp;
//            }
//            static int Min(int[] values)
//            {
//                int temp = int.MaxValue;
//                for (int i = 0; i < values.Length; i++)
//                {
//                    if (values[i] < temp)
//                        temp = values[i];
//                }
//                return temp;
//            }
//            static int Sum(int[] values)
//            {
//                int sum = 0;
//                for (int i = 0; i < values.Length; i++)
//                {
//                    sum += values[i];
//                }
//                return sum;
//            }

//            static float Mean(int[] values)
//            {
//                float mean = 0f;
//                int sum = 0;
//                for (int i = 0; i < values.Length; i++)
//                {
//                    sum = sum + values[i];
//                }
//                mean = (float)sum / (float)values.Length;
//                return mean;
//            }
//            static int EvenSum(int[] values)
//            {
//                int temp = 0;
//                for (int i = 0; i < values.Length; i++)
//                {
//                    if (values[i] % 2 == 0)
//                    {
//                        temp += values[i];
//                    }
//                }
//                return temp;
//            }
//            static int EvenEvenSum(int[] values)
//            {
//                int temp = 0;
//                for (int i = 0; i < values.Length; i++)
//                {
//                    if (i % 2 == 0)
//                    {
//                        temp += values[i];
//                    }
//                }
//                return temp;
//            }
//            static bool Contains(int[] values, int value)
//            {
//                int temp = 0;
//                for (int i = 0; i < values.Length; i++)
//                {
//                    if (values[i] == value)
//                        temp++;
//                }
//                return temp == 0 ? false : true;
//            }
//            static (double, double) Roots(float a, float b, float c)
//            {
//                var temp = Math.Sqrt(b * b - 4 * a * c);
//                return ((-b + temp) / (2 * a), (-b - temp) / (2 * a));
//            }
//        }
//    }


}
