using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLManual
{
    class Config
    {
        public static string DB_NAME = "Pizzeria";
        public static string TABLE_NAME_EMPLEADO = "Empleado";
        public static string CONNECTION_STRING = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Pizzeria; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
