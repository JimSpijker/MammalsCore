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
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        game = new Game(Convert.ToInt32(dataRow["GameId"]), Convert.ToString(dataRow["Name"]), Convert.ToString(dataRow["Description"]));
                    }
                }

            }
            catch
            {
                throw new Exception("DatabaseError");
            }
            finally
            {
                con.SqlConnection.Close();
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
                        "INSERT INTO Game (Name, Description) VALUES(@name, @description)", con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("name", game.Name));
                    cmd.Parameters.Add(new SqlParameter("description", game.Description));
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("DatabaseError");
            }
            finally
            {
                con.SqlConnection.Close();
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
                }
            }
            catch
            {
                throw new Exception("Database Error");
            }
            finally
            {
                con.SqlConnection.Close();
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
            }
            catch
            {
                throw new Exception("DatabaseError");
            }
            finally
            {
                con.SqlConnection.Close();
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
                }
            }
            catch
            {
                throw new Exception("Database Error");
            }
            finally
            {
                con.SqlConnection.Close();
            }
            return games;
        }

        public List<Game> GetNewGames(int amount)
        {
            List<Game> games = new List<Game>();
            try
            {
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                    new SqlCommand(
                        "SELECT TOP (@amount) * FROM Game ORDER BY DateAdded Desc",
                        con.SqlConnection)
                )
                {
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
                throw new Exception("Database Error");
            }
            finally
            {
                con.SqlConnection.Close();
            }
            return games;
        }

        public void DeleteGame(Game game)
        {
            try
            {
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                    new SqlCommand(
                        "DELETE FROM Game WHERE Name = @name", con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("name", game.Name));
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("DatabaseError");
            }
            finally
            {
                con.SqlConnection.Close();
            }
        }
    }
}
