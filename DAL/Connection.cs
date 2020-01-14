using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class Connection
    {
        public string ConnectionString = @"Server=mssql.fhict.local;Database=dbi409996;User Id = dbi409996; Password=Frikandel1;";
        public SqlConnection SqlConnection { get { return new SqlConnection(ConnectionString); } }
    }
}
