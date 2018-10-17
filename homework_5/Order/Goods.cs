using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Goods
    {
        private double price;
        public Goods(uint id, string name, double value)
        {
            Id = id; Name = name; price = value;
        }
        public uint Id
        { get; set; }
        public string Name
        { get; set; }
        public double Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("price must up to 0");
                }
            }
        }
        public override string ToString()
        {
            return ($"GoodsID:{Id},GoodsName:{Name},GoodsValue:{price}");
        }

    }
}
