using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class Goods
    {
        private double price;
        public uint Id { get; set; }
        public string Name { get; set; }

        public Goods() { }
        public Goods(uint id, string name, double value)
        {
            this.Id = id;
            this.Name = name;
            this.price = value;
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value must >= 0!");
                price = value;
            }
        }
        public override string ToString()
        {
            return $"Id:{Id},Name:{Name},Value:{Price}";
        }
    }

}
