using DAL.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Context
{
    public class GameContext : IGameContext
    {

        private readonly Connection con;

        public GameContext()
        {
            con = new Connection();
        }
        public DataSet GetGame(string gameName)
        {
            DataSet dataSet = new DataSet();
            
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                        new SqlCommand(
                            "SELECT * FROM Game WHERE Name = @name", con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("name", gameName));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataSet);
                }
                con.SqlConnection.Close();
                return dataSet;
            
        }
    }
}
