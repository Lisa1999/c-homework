using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Order myorder = new Order();
            Program pro = new Program();
            //初始化订单
            OrderDetail od1 = new OrderDetail("老人与海", "001", "gyh", "10", "24");
            OrderDetail od2 = new OrderDetail("围城", "002", "csy", "5", "56");
            OrderDetail od3 = new OrderDetail("读者", "003", "gyt", "4", "37");
            //添加订单
            pro.addOrder(myorder, od1);
            pro.addOrder(myorder, od2);
            pro.addOrder(myorder, od3);
            //删除订单
            pro.deleteOrder(myorder, od1);
            int index = pro.findIndex(myorder, "读者");
            //修改订单
            pro.changeOrder(myorder, index, 0, "格林童话");
            //打印订单
            pro.printOrder(myorder);


        }
        //添加订单
        public void addOrder(Order order, OrderDetail od)
        {
            order.OrderList.Add(od);
        }
        //删除订单
        public void deleteOrder(Order order, OrderDetail od)
        {
            try
            {
                order.OrderList.Remove(od);
            }
            catch (Exception e)
            {
                Console.WriteLine("订单为空无法删除!");
            }

        }
        //修改订单
        public void changeOrder(Order order, int index, int key, string s)
        {
            try
            {
                order.OrderList[index].myDictionary[key] = s;
            }
            catch (Exception e)
            {
                Console.WriteLine("键值不合理!");
            }
        }
        public int findIndex(Order order, string s)
        {
            for (int i = 0; i < order.OrderList.Count; i++)
            {
                if (order.OrderList[i].myDictionary[0] == s || order.OrderList[i].myDictionary[1] == s || order.OrderList[i].myDictionary[2] == s)
                    return i;
            }
            return -1;

        }
        public void printOrder(Order order)
        {
            foreach (OrderDetail od in order.OrderList)
            {
                Console.WriteLine(od.myDictionary[0] + "" + od.myDictionary[1] + " " + od.myDictionary[2] + " " + od.myDictionary[3] + " " + od.myDictionary[4]);
            }
        }

    }
    class Order
    {
        public List<OrderDetail> OrderList = new List<OrderDetail>();//订单列表
    }
    class OrderDetail
    {
        public Dictionary<int, string> myDictionary = new Dictionary<int, string>();
        public OrderDetail(string name = "", string id = "", string clientName = "", string num = "", string price = "")
        {
            myDictionary[0] = name;          //商品名称
            myDictionary[1] = id;            //商品订单号
            myDictionary[2] = clientName;    //客户名称
            myDictionary[3] = num;           //订购数量
            myDictionary[4] = price;         //商品价格
        }
        public OrderDetail ShallowCopy()
        {
            return (OrderDetail)this.MemberwiseClone();
        }
    }
}
