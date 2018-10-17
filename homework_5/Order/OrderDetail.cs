using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class OrderDetail
    {
        //OrderDetail Id,Good,Quantity,Money
        public uint Id { get; set; }
        public Goods Goods { get; set; }
        public uint Quantity { get; set; }
        public double Money { get; set; }
        public OrderDetail(uint id, Goods goods, uint quantity)
        {
            Id = id;
            Goods = goods;
            Quantity = quantity;
            Money = goods.Price * quantity;
        }
        public override bool Equals(object obj)
        {
            var od = obj as OrderDetail;
            return (od != null && Goods.Id == od.Goods.Id && Quantity == od.Quantity);
        }
        public override int GetHashCode()
        {
            var hashcode = 12345;
            hashcode = hashcode * hashcode + Goods.GetHashCode();
            hashcode = hashcode * hashcode + Quantity.GetHashCode();
            return hashcode;
        }
    }

}
