using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class Customer
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public Customer() { }
        public Customer(uint id, string name) { Id = id; Name = name; }
        public override string ToString()
        {
            return $"customerId:{Id},customerName :{Name}";
        }

    }
}
