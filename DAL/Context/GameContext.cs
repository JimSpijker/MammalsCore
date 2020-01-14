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

        private readonly Connection connection;

        public GameContext(Connection connection)
        {
            this.connection = connection;
        }
        public Game GetGame(string gameName)
        {
            Game game = new Game();
            try
            {
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Game WHERE Name = @name", con);
                    cmd.Parameters.Add(new SqlParameter("name", gameName));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        game = new Game(Convert.ToInt32(dataRow["GameId"]), Convert.ToString(dataRow["Name"]), Convert.ToString(dataRow["Description"]));
                    }
                }
            }
            catch
            {
                throw new Exception("Had trouble connecting to server");
            }
            return game;
        }

        public bool AddGame(Game game)
        {
            try
            {
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Game (Name, Description) VALUES(@name, @description)", con);
                    cmd.Parameters.Add(new SqlParameter("name", game.Name));
                    cmd.Parameters.Add(new SqlParameter("description", game.Description));
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Had trouble connecting to server");
            }
            return true;
        }

        public List<Game> SearchGames(string searchQuery)
        {
            List<Game> games = new List<Game>();
            try
            {
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Game WHERE Name LIKE '%'+@searchTerm+'%'", con);
                    cmd.Parameters.Add(new SqlParameter("searchTerm", searchQuery));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        Game game = new Game(Convert.ToInt32(dataRow["GameId"]), Convert.ToString(dataRow["Name"]), Convert.ToString(dataRow["Description"]));
                        games.Add(game);
                    }
                } 
            }
            catch
            {
                throw new Exception("Had trouble connecting to server");
            }
            return games;
        }

        public bool GameAlreadyExists(string gameName)
        {
            try
            {
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Game WHERE Name = @name", con);
                    {
                        cmd.Parameters.Add(new SqlParameter("name", gameName));
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            con.Close();
                            return true;
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("Had trouble connecting to server");
            }
            return false;
        }

        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();
            try
            {
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Game ORDER BY Name Asc", con);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        Game game = new Game(Convert.ToInt32(dataRow["GameId"]), Convert.ToString(dataRow["Name"]), Convert.ToString(dataRow["Description"]));
                        games.Add(game);
                    }
                }
            }
            catch
            {
                throw new Exception("Had trouble connecting to server");
            }
            return games;
        }

        public List<Game> GetNewGames(int amount)
        {
            List<Game> games = new List<Game>();
            try
            {
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP (@amount) * FROM Game ORDER BY DateAdded Desc", con);
                    cmd.Parameters.Add(new SqlParameter("amount", amount));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        Game game = new Game(Convert.ToInt32(dataRow["GameId"]), Convert.ToString(dataRow["Name"]), Convert.ToString(dataRow["Description"]));
                        games.Add(game);
                    }
                }
            }
            catch
            {
                throw new Exception("Had trouble connecting to server");
            }
            return games;
        }

        public void DeleteGame(Game game)
        {
            try
            {
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Game WHERE Name = @name", con);
                    cmd.Parameters.Add(new SqlParameter("name", game.Name));
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Had trouble connecting to server");
            }
        }
    }
}
