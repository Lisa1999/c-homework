using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数：");
            int m = Int32.Parse(Console.ReadLine());
            int i = 2;
            while (m > 2)
            {
                if (m % i == 0)
                {
                    m /= i;
                    if (m >= 2)
                    {
                        Console.Write(i + "*");
                    }
                    else Console.Write(i);
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
