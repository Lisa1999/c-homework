using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Customer
    {
        //Id,Name,Customer,ToString
        public uint Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public Customer(uint id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return $"customersId:{Id},customersName:{Name}";
        }
    }
}
