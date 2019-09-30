using DAL.Context.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Context
{
    class UserContext : IUserContext
    {
        public UserContext()
        {

        }
        string constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public bool AddReview(Review review)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd =
                        new SqlCommand(
                            "INSERT INTO Review (UserId, GameId, Description, Score) VALUES(@userId, @gameId, @description, @score)", con)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("userId", review.User.Id));
                    cmd.Parameters.Add(new SqlParameter("gameId", review.Game.Id));
                    cmd.Parameters.Add(new SqlParameter("description", review.Description));
                    cmd.Parameters.Add(new SqlParameter("score", review.Score));
                }
                con.Close();
                return true;
            }
        }

        public bool ChangePassword(User updatedUser)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReview(Review review)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd =
                        new SqlCommand(
                            "DELETE FROM Review WHERE ReviewId = @reviewId", con)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("reviewId", review.Id));
                }
                con.Close();
                return true;
            }
        }

        public DataSet GetReviews(User user)
        {
            throw new NotImplementedException();
        }

        public DataSet Login(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
