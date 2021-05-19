using System;

namespace overflow_ex
{
    class Program
    {
        static void Main(string[] args)
        {
            //    var i = int.MaxValue;
            //    Console.WriteLine(i);
            //    i++;
            //    Console.WriteLine(i);

            //long i = 0xFFFFFFFF;
            //int j = (int)i;
            //uint u = 0xffffffff;
            //Console.WriteLine();

            //var d1 = 1.234567e0;
            //var d2 = 1.234567e3;
            //Console.WriteLine(d1);
            //Console.WriteLine(d2);

            //float f = 0.0f;
            //for (var i = 0; i < 1000; i++)
            //{
            //    f += 0.001f;
            //}

            //var epsiolon = 1e-100f;
            //Console.WriteLine(epsiolon);

            //var test = float.PositiveInfinity * 0.0;

            //var i = 1;
            //Console.WriteLine(i / 0);

            //var f = 1.0;
            //Console.WriteLine(f / 0);

            //if(func1() && func2())
            //{
            //     Console.WriteLine("IF");
            //}
            //else
            //{
            //     Console.WriteLine("Else");
            //}

            //var s3 = 3 + "HEllo";
            //var s4 = 3 + 2+ "HEllo" + 6+5;


            //var a = 2;
            //var b = 3;
            //var c = a * b;
            //Console.WriteLine($"{a} * {b} = {c}");

            var i1 = int.Parse("123");
            try
            {

                var i2 = int.Parse("Abc");
            }
            catch
            {
                Console.WriteLine("Error");
            }
            var i3 = 0;
            var ok = int.TryParse("123", out i1);
            ok = int.TryParse("Abc", out i3);
              
        }

        //static bool func1()
        //{
        //    Console.WriteLine("func1");
        //    return false;
        //}

        //static bool func2()
        //{
        //    Console.WriteLine("func2");
        //    return true;
        //}
    }
}
