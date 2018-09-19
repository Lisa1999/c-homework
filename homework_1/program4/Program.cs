using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入两个数字:");
            string s1 = "";
            string s2 = "";
            double m = 0;
            double n = 0;
            s1 = Console.ReadLine();
            s2 = Console.ReadLine();
            m = Double.Parse(s1);
            n = Double.Parse(s2);
            Console.WriteLine("他们的乘积是：" + (m * n));
        }
    }
}
