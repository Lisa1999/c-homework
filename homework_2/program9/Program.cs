using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace program9
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            for (int i = 2; i <= 100; i++)
            {
                list.Add(i);
            }
            for (int i = 2; i <= 100; i++)
            {
                for (int j = i + 2; j <= 100; j++)
                {
                    if (j % i == 0)
                        list.Remove(j);
                }
            }
            Console.WriteLine("2到100的所有素数：");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }

        }
    }
}
