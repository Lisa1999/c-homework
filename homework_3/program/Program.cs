using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    interface Shape
    {
        void printArea();
    }
    //Triangle
    class Triangle : Shape
    {
        public Triangle()
        {
            Console.WriteLine("Please input three sides of the Triangle  :");
        }
        public void printArea()
        {
            string a = Console.ReadLine();
            double m = Double.Parse(a);
            string b = Console.ReadLine();
            double n = Double.Parse(b);
            string c = Console.ReadLine();
            double t = Double.Parse(c);
            double k = (m + n + t) / 2;
            double s = Math.Pow(k * (k - m) * (k - n) * (k - t), 0.5);
            Console.WriteLine("the area of the triangle is: " + s.ToString());
        }

    }
    class Round : Shape
    {
        public Round()
        {
            Console.WriteLine("Please input radius of the Round  :");
        }
        public void printArea()
        {
            string a = Console.ReadLine();
            double r = Double.Parse(a);
            double s = Math.PI * r * r;
            Console.WriteLine("the area of the round is: " + s.ToString());
        }

    }
    class Rectangle : Shape
    {
        public Rectangle()
        {
            Console.WriteLine("Please input length and width of the Rectangle  :");
        }
        public void printArea()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            double c = Double.Parse(a);
            double d = Double.Parse(b);
            double s = c * d;
            Console.WriteLine("the area of the rectangle is: " + s.ToString());
        }
    }

    class Square : Shape
    {
        public Square()
        {
            Console.WriteLine("Please input the length of side of the Rectangle  :");
        }
        public void printArea()
        {
            string a = Console.ReadLine();
            double c = Double.Parse(a);
            double s = c * c;
            Console.WriteLine("the area of square is: " + s.ToString());
        }
    }
    class ShapeFactory
    {
        public static Shape getShape(String type)
        {
            Shape shape = null;
            if (type.Equals("Triangle"))
            {
                shape = new Triangle();
                Console.WriteLine("This is a Triangle.");
            }
            else if (type.Equals("Round"))
            {
                shape = new Round();
                Console.WriteLine("This is a Round.");

            }
            else if (type.Equals("Rectangle"))
            {
                shape = new Rectangle();
                Console.WriteLine("This is a Rectangle.");
            }
            else if (type.Equals("Square"))
            {
                shape = new Square();
                Console.WriteLine("This is a Square.");
            }
            return shape;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape1 = ShapeFactory.getShape("Triangle");
            shape1.printArea();
            Shape shape2 = ShapeFactory.getShape("Round");
            shape2.printArea();
            Shape shape3 = ShapeFactory.getShape("Rectangle");
            shape3.printArea();
            Shape shape4 = ShapeFactory.getShape("Square");
            shape4.printArea();
        }
    }
}
