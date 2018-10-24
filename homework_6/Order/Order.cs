using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class Order
    {
        public List<OrderDetail> list = new List<OrderDetail>();
        public uint Id { get; set; }
        public Customer Customer { get; set; }
        public double OrderMoney { get; set; }
        public Order() { }
        public Order(uint orderId, Customer customer)
        {
            Id = orderId;
            Customer = customer;
            OrderMoney = 0;
        }
        public void AddDetail(OrderDetail od)
        {
            if (!list.Contains(od))
            {
                list.Add(od);
                OrderMoney += od.Money;
            }
            else
                throw new Exception($"OrderDetail {od.Id} has existed!");
        }
        public void RemoveDetail(uint detail_id)
        {
            foreach (OrderDetail od in list)
            {
                if (od.Id == detail_id)
                    OrderMoney -= od.Money;
                list.Remove(od);
            }
        }
        public override string ToString()
        {
            string result = "\n";
            result += $"orderId:{Id} customer:{Customer}";
            list.ForEach(od => result += "\n\t" + od);
            result += "\n--------------------------";
            return result;
        }
    }
}
