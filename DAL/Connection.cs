using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class Connection
    {
        public Connection()
        {
            SqlConnection = new SqlConnection(@"Server=mssql.fhict.local;Database=dbi409996;User Id=dbi409996;Password=Frikandel1;");
        }
        internal SqlConnection SqlConnection { get; }
    }
}
