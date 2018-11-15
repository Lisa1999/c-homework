using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Order
{
    public class OrderService
    {
        public List<Order1> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }
        public Dictionary<long, Order1> orderDict;
        public OrderService()
        {
            orderDict = new Dictionary<long, Order1>();
        }
        public void AddOrder(Order1 order)
        {
            if (orderDict.ContainsKey(order.Id))
                throw new Exception($"Order is already existed!");
            orderDict[order.Id] = order;
        }
        public void RemoveOrder(long orderId)
        {
            orderDict.Remove(orderId);
        }
        public Order1 GetById(long orderId)
        {
            if (orderDict.ContainsKey(orderId))
            {
                return orderDict[orderId];
            }
            return null;
        }
        /// <summary>
        /// 按商品名字查找
        /// </summary>
        /// <param name="goodsname"></param>
        /// <returns></returns>
        public List<Order1> QueryByGoodsName(string goodsname)
        {
            var query = orderDict.Values.Where(order => order.Details.Where(d => d.Goods.Name == goodsname).Count() > 0);
            return query.ToList();
        }
        /// <summary>
        /// 按顾客姓名查找
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public List<Order1> QueryByCustomerName(string customerName)
        {
            var query = orderDict.Values.Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }
        /// <summary>
        /// 按价格查找
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public List<Order1> QueryByPrice(double price)
        {
            var query = orderDict.Values.Where(order => order.Amount > price);
            return query.ToList();
        }
        /// <summary>
        /// 更新顾客
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="newcustomer"></param>
        public void UpdateCustomer(long orderId, Customer newcustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newcustomer;
            }
            else
            {
                throw new Exception($"order-{orderId}is not existed!");
            }
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public string Export()
        {
            DateTime time = System.DateTime.Now;
            string fileName = "orders" + time.Year + "_ " + time.Month + "_ " + time.Day + "_ " + time.Hour + "_ " + time.Minute + "_ " + time.Second + "_ " + ".xml";
            Export(fileName);
            return fileName;
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="fileName"></param>
        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order1>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, orderDict.Values.ToList());
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Order1> Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order1>));
            if (Path.GetExtension(path) != ".xml")
                throw new ArgumentException("It's not xml file!");
            List<Order1> result = new List<Order1>();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order1> temp = (List<Order1>)xs.Deserialize(fs);
                temp.ForEach(order =>
                {
                    if (!orderDict.Keys.Contains(order.Id))
                    {
                        orderDict[order.Id] = order;
                        result.Add(order);
                    }
                });
            }
            return result;
        }
    }
}
