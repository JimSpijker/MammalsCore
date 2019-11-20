using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DAL.Context.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Context
{
    public class ReviewContext : IReviewContext
    {
        private readonly Connection con;

        public ReviewContext()
        {
            con = new Connection();
        }

        public bool UpdateReview(Review changedReview)
        {
            try
            {
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                    new SqlCommand(
                        "UPDATE Review SET Description = @description, Score = @score WHERE ReviewId = @reviewId",
                        con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("description", changedReview.Description));
                    cmd.Parameters.Add(new SqlParameter("score", changedReview.Score));
                    cmd.Parameters.Add(new SqlParameter("reviewId", changedReview.Id));
                }
                con.SqlConnection.Close();
            }
            catch
            {
                throw new Exception("DatabaseError");
            }
            return true;
                

        }

        public List<Review> GetReviews(User user)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetReviews(Game game)
        {
            List<Review> reviews = new List<Review>();
            try
            {
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                    new SqlCommand(
                        "SELECT * FROM Review WHERE Review.GameId = @gameId",
                        con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("gameId", game.Id));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        Review review = new Review(Convert.ToInt32(dataRow["ReviewId"]), Convert.ToInt32(dataRow["UserId"]), game, Convert.ToString(dataRow["Description"]), Convert.ToInt32(dataRow["Score"]));
                        reviews.Add(review);
                    } 
                }
                con.SqlConnection.Close();
            }
            catch
            {
                throw new Exception("DatabaseError");
            }
                return reviews;
        }

        public bool AddReview(Review review)
        {
            try
            {
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                    new SqlCommand(
                        "INSERT INTO Review (UserId, GameId, Description, Score) VALUES(@userId, @gameId, @description, @score)", con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("userId", review.UserId));
                    cmd.Parameters.Add(new SqlParameter("gameId", review.Game.Id));
                    cmd.Parameters.Add(new SqlParameter("description", review.Description));
                    cmd.Parameters.Add(new SqlParameter("score", review.Score));
                    cmd.ExecuteNonQuery();
                }
                con.SqlConnection.Close();
            }
            catch
            {
                throw new Exception("DatabaseError");
            }
            return true;

        }
        public bool DeleteReview(Review review)
        {
            try
            {
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                    new SqlCommand(
                        "DELETE FROM Review WHERE ReviewId = @reviewId", con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("reviewId", review.Id));
                }
                con.SqlConnection.Close();
            }
            catch
            {
                throw new Exception("DatabaseError");
            }
            return true;

        }

        public bool ReviewExists(Review review)
        {
            try
            {
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                    new SqlCommand(
                        "SELECT * FROM Review WHERE UserId = @userId AND GameId = @gameId", con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("userId", review.UserId));
                    cmd.Parameters.Add(new SqlParameter("gameId", review.Game.Id));
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
    }
}
