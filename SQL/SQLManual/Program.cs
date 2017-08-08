using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQLManual
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                try
                {
                    conn.Open();

                    SqlTransaction transaction = conn.BeginTransaction("Transaccion");

                    SqlCommand commandCreate = new SqlCommand(queryBuilder.BuildCreateQuery(), conn);
                    commandCreate.Transaction = transaction;
                    commandCreate.Parameters.AddWithValue("@TABLENAME", Config.TABLE_NAME_EMPLEADO);
                    commandCreate.ExecuteNonQuery();

                    SqlCommand commandInsert = new SqlCommand(queryBuilder.BuildInsertQuery(), conn);
                    commandInsert.Transaction = transaction;
                    commandInsert.Parameters.AddWithValue("@ID", id);
                    commandInsert.Parameters.AddWithValue("@NAME", "Jorge");
                    commandInsert.ExecuteNonQuery();

                    SqlCommand commandInsert2 = new SqlCommand(queryBuilder.BuildInsertQuery(), conn);
                    commandInsert2.Transaction = transaction;
                    commandInsert2.Parameters.AddWithValue("@ID", id2);
                    commandInsert2.Parameters.AddWithValue("@NAME", "Javi");
                    commandInsert2.ExecuteNonQuery();

                    SqlCommand commandUpdate = new SqlCommand(queryBuilder.BuildUpdateQuery(), conn);
                    commandUpdate.Transaction = transaction;
                    commandUpdate.Parameters.AddWithValue("@NAME", "Nombre Actualizado");
                    commandUpdate.Parameters.AddWithValue("@ID", id);
                    commandUpdate.ExecuteNonQuery();

                    SqlCommand commandDelete = new SqlCommand(queryBuilder.BuildDeleteQueryByName(), conn);
                    commandDelete.Transaction = transaction;
                    commandDelete.Parameters.AddWithValue("@NAME", "Nombre Actualizado");
                    commandDelete.ExecuteNonQuery();

                    transaction.Commit();

                    SqlCommand commandSelect = new SqlCommand(queryBuilder.BuildSelectQuery(), conn);
                    commandSelect.CommandText = queryBuilder.BuildSelectQuery();
                    PrintSelectResults(commandSelect);

                    //SqlCommand commandRemove = new SqlCommand(queryBuilder.BuildRemoveQuery(), conn);
                    //commandRemove.ExecuteNonQuery();                    
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error en la conexion o accion:"+ex.Message);
                }
                catch (Exception e)
                {
                    throw new Exception("A saber que esta pasando:" + e.Message);
                }
            };
        }

        private static void PrintSelectResults(SqlCommand command)
        {
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}", reader[0]));
            }
            Console.ReadLine();
        }

    }
}
