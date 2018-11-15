using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class OrderDetail
    {
        public long Id { get; set; }
        public Goods Goods { get; set; }
        public uint Quantity { get; set; }
        public OrderDetail() { }
        public OrderDetail(long id, Goods goods, uint quantity)
        {
            this.Id = id;
            this.Goods = goods;
            this.Quantity = quantity;
        }
        public override string ToString()
        {
            string result = "";
            result += $"orderDetailId:{Id}:";
            result += Goods + $", quantity:{Quantity}";
            return result;
        }
        public override int GetHashCode()
        {
            var hashCode = 1522631281;
            String gname = Goods == null ? "" : (Goods.Name == null ? "" : Goods.Name);
            hashCode = hashCode * -1521134295 + gname.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null &&
                Goods.Equals(detail.Goods) &&
                Quantity == detail.Quantity;
        }

    }
}
