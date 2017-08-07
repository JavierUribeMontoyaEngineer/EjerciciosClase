using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid id = Guid.NewGuid();
            var catalog = Config.DB_NAME;
            var createQuery = @"if not exists(select * from sysobjects where name = @TableName and xtype='U') 
                                CREATE TABLE EmpleadoBueno2 ( EmpleadoId2 uniqueidentifier  not null, FirstName varchar(25)
                                CONSTRAINT PK_TransactionHistoryArchive_EmpleadoId2 PRIMARY KEY CLUSTERED (EmpleadoId2));";
            var insertQueryText = "INSERT INTO EmpleadoBueno2 (EmpleadoId2,FIRSTNAME) VALUES (@ID, @Name);";
            var selectQuery = "SELECT FIRSTNAME FROM EmpleadoBueno2";

            SqlConnection connection = null;
            using (connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog =" + catalog + "; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
            using (SqlCommand commandCreate = new SqlCommand(createQuery, connection))
            using (SqlCommand commandInsert = new SqlCommand(insertQueryText, connection))
            using (SqlCommand commandSelect = new SqlCommand(selectQuery, connection))
            {
                try
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    Console.WriteLine("Conexion abierta");
                    SqlTransaction transaction = connection.BeginTransaction("Transaccion");
                    commandCreate.Transaction = transaction;
                    commandInsert.Transaction = transaction;
                    commandSelect.Transaction = transaction;
                    command.Transaction = transaction;

                    commandCreate.Parameters.AddWithValue("@TableName", Config.TABLE_NAME_EMPLEADO);
                    commandCreate.ExecuteNonQuery();

                    Console.WriteLine("Tabla creada");
                    commandInsert.Parameters.AddWithValue("@ID", id);
                    commandInsert.Parameters.AddWithValue("@Name", "Javi");
                    commandInsert.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO EmpleadoBueno2 (EmpleadoId2,FIRSTNAME) VALUES (@ID, @Name);";
                    commandInsert.Parameters.AddWithValue("@ID", id);
                    commandInsert.Parameters.AddWithValue("@Name", "Jorge");
                    command.ExecuteNonQuery();
                    Console.WriteLine("Tabla insertada");
                    transaction.Commit();
                    commandSelect.Parameters.AddWithValue("@param", Config.TABLE_NAME_EMPLEADO);
                    var reader = commandSelect.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                    Console.ReadLine();
                }
                catch (SqlException e)
                {
                   throw new Exception("Error al conectar con la BD");
                }
            };
        }

    }
}
