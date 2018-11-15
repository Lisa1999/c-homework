using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class Order1
    {
        public long Id { get; set; }
        public Customer Customer { get; set; }
        public double Amount
        {
            get
            {
                return Details.Sum(d => d.Goods.Price * d.Quantity);
            }
        }

        //public List<OrderDetail> details = new List<OrderDetail>();
        public List<OrderDetail> Details
        {
            get; set;
        }
        public Order1() { }

        public Order1(long orderId, Customer customer)
        {
            Id = orderId;
            Customer = customer;
            Details = new List<OrderDetail>();
        }
        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            Details.Add(orderDetail);
        }
        public void RemoveDetails(long orderDetailId)
        {
            Details.RemoveAll(d => d.Id == orderDetailId);
        }
        public override string ToString()
        {
            string result = "-------------------";
            result += $"orderId:{Id},customer:({Customer.Name}),Amount:{Amount} ";
            Details.ForEach(od => result += "\n\t" + od);
            result += "\n-----------------";
            return result;
        }
    }
}
