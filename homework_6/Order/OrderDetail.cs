using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class OrderDetail
    {
        public uint Id { get; set; }
        public Goods Goods { get; set; }
        public double Money { get; set; }
        public uint Quantity { get; set; }
        public OrderDetail() { }
        public OrderDetail(uint id, Goods goods, uint quantity)
        {
            Id = id;
            Goods = goods;
            Money = Goods.Price * Quantity;
            Quantity = quantity;
        }
        public override bool Equals(object obj)
        {
            var od = obj as OrderDetail;
            return od != null && Quantity == od.Quantity && Goods.Id == od.Goods.Id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
            var hashcode = 12345;
            hashcode = hashcode * hashcode + Goods.GetHashCode();
            hashcode = hashcode * hashcode + Quantity.GetHashCode();
            return hashcode;
        }
        public override string ToString()
        {
            string result = "";
            result += $"orderId:{Id}:";
            result += Goods + ",quantity:{Quantity}";
            return result;
        }
    }
}
