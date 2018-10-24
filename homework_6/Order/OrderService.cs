using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Xml.Schema;

namespace Order
{
    public class OrderService
    {
        private Dictionary<uint, Order> dic;
        public Dictionary<uint, Order> Dic
        {
            get { return dic; }
        }
        public OrderService()
        {
            dic = new Dictionary<uint, Order>();
        }
        public void AddOrder(Order order)
        {
            if (dic.ContainsKey(order.Id))
                throw new Exception($"Order:{order.Id}has existed!");
            else
                dic[order.Id] = order;

        }
        public void RemoveOrder(uint order_id)
        {
            if (!dic.ContainsKey(order_id))
                throw new Exception($"Order:{order_id}doesn't exist!");
            else
                dic.Remove(order_id);
        }
        public Order GetOrderById(uint order_id)
        {
            if (dic.ContainsKey(order_id))
                return dic[order_id];
            else
                throw new Exception($"Order:{order_id}doesn't exist!");

        }
        public List<Order> GetOrderByName(string name)
        {
            var query = dic.Values.Where(s => s.Customer.Name == name);
            return query.ToList();
        }
        public List<Order> GetBigOrder()
        {
            var query = dic.Values.Where(s => s.OrderMoney >= 10000);
            return query.ToList();
        }
        public void UpdateOrder(uint orderId, Customer newcustomer)
        {
            if (dic.ContainsKey(orderId))
                dic[orderId].Customer = newcustomer;
            else
                throw new Exception($"order:{orderId}does't exist!");
        }
        //序列化
        public void Export(object obj, string filename)
        {
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            using (FileStream fs = new FileStream(filename, FileMode.Create))
                ser.Serialize(fs, obj);
        }
        //反序列化
        public object Import(string filename)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                object obj2 = ser.Deserialize(fs);
                return obj2;
            }
        }



    }
}
