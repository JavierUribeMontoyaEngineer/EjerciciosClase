using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sql = @"select * from tabla 
                      where id = @id";
            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = pepito; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            try
            {
                Console.WriteLine("Abrir conexion");
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
                Console.ReadLine();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
