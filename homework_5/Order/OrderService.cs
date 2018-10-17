using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class OrderService
    {
        private Dictionary<uint, Order> dic;
        public OrderService()
        {
            dic = new Dictionary<uint, Order>();
        }
        public void AddOrder(Order order)
        {
            if (dic.ContainsKey(order.Id))
                throw new Exception("$the order { order.Id}has exist!");
            else
            {
                dic[order.Id] = order;
            }
        }
        public void RemoveOrder(uint order_id)
        {
            if (dic.ContainsKey(order_id))
                dic.Remove(order_id);
            else
                throw new Exception("$the order { order_id}doesn't exist!");
        }
        public Order GetOrderById(uint id)
        {
            return dic[id];
        }
        public List<Order> GetOrderByCustomer(string name)
        {
            var query = dic.Values.Where(s => s.Customer.Name == name);
            return query.ToList();
        }
        public List<Order> GetOrderByName(string name)
        {
            var query = from s in dic.Values
                        from d in s.list
                        where d.Goods.Name == name
                        select s;
            return query.ToList();
        }
        public List<Order> GetBigOrder()
        {
            var query = dic.Values.Where(s => s.OrderMoney >= 10000);
            return query.ToList();
        }
        public void UpDateOrder(uint OrderId, Customer newCustomer)
        {
            if (dic.ContainsKey(OrderId))
            {
                dic[OrderId].Customer = newCustomer;
            }
            else
                throw new Exception("$the order{OrderId} doesn't exist!!!");
        }
    }

}

