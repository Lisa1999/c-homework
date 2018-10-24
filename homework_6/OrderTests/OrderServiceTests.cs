using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        /// <summary>
        /// 正确的添加
        /// </summary>
        [TestMethod()]
        public void AddOrderTest1()
        {
            //检测正确输入
            Customer customer1 = new Customer(1, "gyt");
            Goods greentea = new Goods(1, "GreenTea", 3.0);
            OrderDetail orderDetail1 = new OrderDetail(1, greentea, 3);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetail1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            //检测正确结果
            Dictionary<uint, Order> result = new Dictionary<uint, Order>();
            result[1] = order1;
            CollectionAssert.AreEqual(os.Dic, result);
        }
        /// <summary>
        ///错误的添加
        /// </summary>
        [ExpectedException(typeof(Exception))]
        [TestMethod()]
        public void AddOrderTest2()
        {
            Customer customer1 = new Customer(1, "csy");
            Goods noodles = new Goods(1, "noodles", 8.0);
            OrderDetail orderDetail1 = new OrderDetail(1, noodles, 10);
            Order order2 = new Order(1, customer1);
            order2.AddDetail(orderDetail1);
            OrderService os = new OrderService();
            //重复添加
            os.AddOrder(order2);
            os.AddOrder(order2);
        }
        /// <summary>
        /// 正确的移出
        /// </summary>
        [TestMethod()]
        public void RemoveOrderTest1()
        {
            Customer customer1 = new Customer(1, "cyy");
            Goods apple = new Goods(1, "apple", 9);
            OrderDetail orderDetail1 = new OrderDetail(1, apple, 90);
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer1);
            order1.AddDetail(orderDetail1);
            order2.AddDetail(orderDetail1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.RemoveOrder(1);
            Dictionary<uint, Order> result = new Dictionary<uint, Order>();
            result[2] = order2;
            CollectionAssert.AreEqual(os.Dic, result);

        }
        /// <summary>
        /// 错误的移出
        /// </summary>
        [ExpectedException(typeof(Exception))]
        [TestMethod()]
        public void RemoveOrderTest2()
        {
            OrderService os = new OrderService();
            os.RemoveOrder(1);
        }
        [TestMethod()]
        public void GetOrderByIdTest1()
        {
            Customer customer1 = new Customer(1, "cyy");
            Goods apple = new Goods(1, "apple", 9);
            OrderDetail orderDetail1 = new OrderDetail(1, apple, 90);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetail1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            Order order = os.GetOrderById(1);
            Assert.AreEqual(order1, order);
        }
        /// <summary>
        /// 错误的获取菜单
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void GetOrderByIdTest2()
        {
            Customer customer1 = new Customer(1, "cyy");
            Goods apple = new Goods(1, "apple", 9);
            OrderDetail orderDetail1 = new OrderDetail(1, apple, 90);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetail1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.GetOrderById(2);
        }
        /// <summary>
        /// 正确通过名字获得菜单
        /// </summary>
        [TestMethod()]
        public void GetOrderByNameTest1()
        {
            Customer customer1 = new Customer(1, "cyy");
            Goods apple = new Goods(1, "apple", 9);
            OrderDetail orderDetail1 = new OrderDetail(1, apple, 90);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetail1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> list = os.GetOrderByName("cyy");
            List<Order> result = new List<Order> { order1 };
            
            CollectionAssert.AreEqual(result, list);

        }
        /// <summary>
        /// 错误的输入
        /// </summary>
        [TestMethod()]
        public void GetOrderByNameTest2()
        {
            Customer customer1 = new Customer(1, "cyy");
            Goods apple = new Goods(1, "apple", 9);
            OrderDetail orderDetail1 = new OrderDetail(1, apple, 90);
            Order order1 = new Order(1, customer1);
            order1.AddDetail(orderDetail1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> list = os.GetOrderByName("orange");
            int result = 0;
            Assert.AreEqual(result, list.Count);
        }

        [ExpectedException(typeof(FileNotFoundException))]
        [TestMethod()]
        public void ImportTest()
        {
            OrderService os = new OrderService();
            os.Import("abcd.Xml");
        }
    }
}