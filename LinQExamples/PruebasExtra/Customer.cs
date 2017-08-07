using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasExtra
{
    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartCompanyDate { get; set; }
        public string State { get; set; }
        public int IdCity { get; set; }
        public int MonthlyDiscount { get; set; }
        public Package Packet { get; set; }

      
    }

    class Package
    {
        public int Id { get; set; }
        public int Speed { get; set; }
    }

    class Ciudad
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
