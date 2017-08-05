using System;
using System.Collections.Generic;
using System.Linq;
namespace PruebasExtra
{
    class Program
    {
        static void Main(string[] args)
        {
            var packages = new List<Package>()
            {
                new Package(){Id=21,Speed=20},
                new Package(){Id=2,Speed=30},
                new Package(){Id=28,Speed=40},

            };
            var cities = new List<Ciudad>()
            {
                new Ciudad(){Id = 1, Name="Murcia"},
                new Ciudad(){Id=2,Name="Madrid"},
                new Ciudad(){Id=3,Name="Albacete"}
            };
            var packetFalse = new Package() { Id = 33, Speed = 22 };
            var customers = new List<Customer>()
            {
                new Customer(){FirstName="Javier",LastName="King",IdCity=1,Id=21,Packet=packetFalse,
                    MonthlyDiscount =20,StartCompanyDate=new DateTime(2017,1,1),State="Spain"},
                 new Customer(){FirstName="Manolo",LastName="Uribe",IdCity=2,Id=1,Packet=packages[1],
                    MonthlyDiscount =20,StartCompanyDate=new DateTime(2017,1,1),State="Spain"},
                  new Customer(){FirstName="Juan",LastName="Ronaldo",IdCity=1,Id=5,Packet=packages[2],
                    MonthlyDiscount =20,StartCompanyDate=new DateTime(2005,1,1),State="Spain"},
                   new Customer(){FirstName="Alberto",LastName="King",IdCity=3,Id=3,Packet=packages[1],
                    MonthlyDiscount =20,StartCompanyDate=new DateTime(2006,1,1),State="Spain" }
            };
            // var customersQuery = customers.Where(c=>c.LastName=="King");
            /*var customersQuery = from c in customers
                                 where c.LastName == "King"
                                 select c.FirstName;
            Console.WriteLine(String.Join("\n", customersQuery));
             var customersQuery = customers.Where(c => c.MonthlyDiscount < 30);
            var fechaComparar = new DateTime(2007,1,1);
            var customersQuery = from c in customers
                                 where c.StartCompanyDate < fechaComparar
                                 select c.FirstName;*/
            //var customersQuery = customers.Where(c => c.Packet.Id == 21 || c.Packet.Id == 28);
            var customersQuery = from c in customers
                                 join p in packages
                                 on c.Packet.Id equals p.Id into grp
                                 from c_joined in grp.DefaultIfEmpty()                                                            
                                 select new
                                 {
                                     Name = c.FirstName,
                                     IdPacket = c_joined.Id,
                                     Speed = c_joined.Speed
                                 };
            Console.WriteLine(String.Join("\n", customersQuery));
            Console.ReadLine();
        }


    }
}
