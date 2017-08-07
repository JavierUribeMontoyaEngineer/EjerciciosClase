using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLManual
{
    class QueryBuilder
    {

        public string BuildCreateQuery()
        {
            var createQuery = @"if not exists(select * from sysobjects where name = @TABLENAME and type = 'U')
                                CREATE TABLE EMPLEADO ( 
                                    EmpleadoId uniqueidentifier not null,
                                    FirstName varchar(25) CONSTRAINT PK_EmpleadoId PRIMARY KEY CLUSTERED (EmpleadoId)
                                );";
            return createQuery;
        }

        public string BuildInsertQuery()
        {
            var insertQuery = @"INSERT INTO EMPLEADO (EmpleadoId,FIRSTNAME) 
                                VALUES (@ID, @NAME);";
            return insertQuery;
        }

        public string BuildSelectQuery()
        {
            var selectQuery = "SELECT FIRSTNAME FROM EMPLEADO;";
            return selectQuery;
        }

        public string BuildUpdateQuery()
        {
            var updateQuery = @"UPDATE EMPLEADO 
                                SET FIRSTNAME = @NAME
                                WHERE EmpleadoId = @ID;";
            return updateQuery;
        }

        public string BuildDeleteQueryByName()
        {
            var deleteQuery = @"DELETE FROM EMPLEADO 
                                WHERE FirstName = @Name;";
            return deleteQuery;
        }

        public string BuildRemoveQuery()
        {
            var removeQuery = @"DROP TABLE EMPLEADO;";
            return removeQuery;
        }
    }
}
