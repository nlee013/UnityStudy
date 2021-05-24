using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Ex
{
    class MyStack<T>
    {
        const int maxSize = 5;
        private T[] arr = new T[maxSize];
        private int top;

        public MyStack()
        {
            top = 0;
        }

        public void Push(T val)
        {
            if(top < maxSize)
            {
                arr[top] = val;
                ++top;
            }
            else
            {
                Console.WriteLine("Stack Full");
                return;
            }
        }

        public T Pop()
        {
            if(top>0)
            {
                --top;
                return arr[top];
            }
            else
            {
                Console.WriteLine("Stack Empty");
                return default;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //MyStack<int> s = new MyStack<int>();
            //s.Push(1);
            //s.Push(2);
            //s.Push(3);
            //s.Push(4);
            //s.Push(5);
            //s.Pop();
            //s.Pop();
            //s.Pop();
            //s.Pop();
            //s.Pop();
            //s.Pop();

            Shape[] shapes = new Shape[4];
            shapes[0] = new Circle(1, 2, 5);
            shapes[1] = new Circle(3, 4, 15);
            shapes[2] = new Rectangle(1, 2, 5, 5);
            shapes[3] = new Rectangle(2, 3, 2, 1);
            Console.WriteLine($"Total Area :  {TotalArea(shapes)}");




        }

        static float TotalArea(Shape[] shapes)
        {
            float result = 0;
            foreach(var s in shapes)
            {
                //if(s is Circle)
                //{
                //    Circle c = s as Circle; // as는 오브젝트를 Circle로 캐스팅
                //    result += c.Area();
                //}
                //else if(s is Rectangle)
                //{
                //    Rectangle r = s as Rectangle; // as는 오브젝트를 Rectangle로 캐스팅
                //    result += r.Area();
                //}
                //

                result += s.Area(); // 상속으로 Shape을 가지고 있어서 가능

            }
            return result;
        }
    }

    class Circle : Shape
    {
        private float x, y, radius;
        public Circle(float x, float y, float radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        override public float Area()
        {
            return (float)Math.PI * radius * radius;
        }
    }
    class Rectangle : Shape
    {
        private float x, y, width, height;
        public Rectangle(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        override public float Area()
        {
            return width * height;
        }
    }

    class Shape
    {
        virtual public float Area()
        {
            return 0;
        }
    }

}
