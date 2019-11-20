using DAL.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace DAL.Context
{
    public class GameContext : IGameContext
    {

        private readonly Connection con;

        public GameContext()
        {
            con = new Connection();
        }
        public Game GetGame(string gameName)
        {
            Game game = new Game();
            try { 
            con.SqlConnection.Open();
            using (SqlCommand cmd =
                    new SqlCommand(
                        "SELECT * FROM Game WHERE Name = @name", con.SqlConnection)
            )
            {
                cmd.Parameters.Add(new SqlParameter("name", gameName));
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    game = new Game(Convert.ToInt32(dataRow["GameId"]), Convert.ToString(dataRow["Name"]), Convert.ToString(dataRow["Description"]));
                }
            }
            con.SqlConnection.Close();
            }
            catch
            {
                throw new Exception("DatabaseError");
            }
            return game;
        }

        public bool AddGame(Game game)
        {
            try
            {
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                    new SqlCommand(
                        "INSERT INTO Game (Name, Description) VALUES(@name, @description) SELECT SCOPE_IDENTITY()", con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("name", game.Name));
                    cmd.Parameters.Add(new SqlParameter("description", game.Description));
                    game.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                con.SqlConnection.Close();
            }
            catch
            {
                throw new Exception("DatabaseError");
            }
            return true;
        }

        public List<Game> SearchGames(string searchQuery)
        {
            List<Game> games = new List<Game>();
            try
            {
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                    new SqlCommand(
                        "SELECT * FROM Game WHERE Name LIKE '%'+@searchTerm+'%'",
                        con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("searchTerm", searchQuery));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        Game game = new Game(Convert.ToInt32(dataRow["GameId"]), Convert.ToString(dataRow["Name"]), Convert.ToString(dataRow["Description"]));
                        games.Add(game);
                    }
                    con.SqlConnection.Close();
                }
            }
            catch
            {
                throw new Exception("Database Error");
            }
                return games;
            
        }

        public bool GameAlreadyExists(string gameName)
        {
            try
            {
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                    new SqlCommand(
                        "SELECT * FROM Game WHERE Name = @name", con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("name", gameName));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        con.SqlConnection.Close();
                        return true;
                    }
                }
                con.SqlConnection.Close();
            }
            catch
            {
                throw new Exception("DatabaseError");
            }
            return false;
        }

        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();
            try
            {
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                    new SqlCommand(
                        "SELECT * FROM Game ORDER BY Name Asc",
                        con.SqlConnection)
                )
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        Game game = new Game(Convert.ToInt32(dataRow["GameId"]), Convert.ToString(dataRow["Name"]), Convert.ToString(dataRow["Description"]));
                        games.Add(game);
                    }
                    con.SqlConnection.Close();
                }
            }
            catch
            {
                throw new Exception("Database Error");
            }
            return games;
        }
    }
}
