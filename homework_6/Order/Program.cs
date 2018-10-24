using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer(1, "csy");
            Customer customer2 = new Customer(2, "gyt");
            Goods goods1 = new Goods(1, "宇宙新概念", 59.6);
            Goods goods2 = new Goods(2, "老子", 45.6);
            Goods goods3 = new Goods(3, "摆渡人", 43.3);
            OrderDetail orderDetail1 = new OrderDetail(1, goods1, 1000);
            OrderDetail orderDetail2 = new OrderDetail(2, goods2, 300);
            OrderDetail orderDetail3 = new OrderDetail(3, goods3, 500);
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer1);
            order1.AddDetail(orderDetail1);
            order2.AddDetail(orderDetail2);
            order3.AddDetail(orderDetail3);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
            Order[] order = new Order[10];
            int i = 0;
            foreach (Order od in os.Dic.Values)
                order[++i] = od;
            try
            {
                //Xml序列化并打印
                os.Export(order, "abc.Xml");
                string s = File.ReadAllText("abc.Xml");
                Console.WriteLine(s);
                //反序列化
                Order[] order_2 = os.Import("abc.Xml") as Order[];
                if (order_2 != null)
                {
                    foreach (Order od in order_2)
                        Console.WriteLine(od);
                }

            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
    }
}
