using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DAL.Context.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Logic;
using Logic.Exceptions;

namespace DAL.Context
{
    public class ReviewContext : IReviewContext
    {
        private readonly Connection connection;

        public ReviewContext(Connection connection)
        {
            this.connection = connection;
        }

        public bool UpdateReview(Review changedReview)
        {
            try
            {
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Review SET Description = @description, Score = @score WHERE ReviewId = @reviewId", con);
                    cmd.Parameters.Add(new SqlParameter("description", changedReview.Description));
                    cmd.Parameters.Add(new SqlParameter("score", changedReview.Score));
                    cmd.Parameters.Add(new SqlParameter("reviewId", changedReview.Id));
                }
            }
            catch
            {
                throw new ServerException("Had trouble connecting to server");
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
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Review WHERE Review.GameId = @gameId", con);
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
            }
            catch
            {
                throw new ServerException("Had trouble connecting to server");
            }
            return reviews;
        }

        public bool AddReview(Review review)
        {
            try
            {
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Review (UserId, GameId, Description, Score) VALUES(@userId, @gameId, @description, @score)", con);
                    cmd.Parameters.Add(new SqlParameter("userId", review.UserId));
                    cmd.Parameters.Add(new SqlParameter("gameId", review.Game.Id));
                    cmd.Parameters.Add(new SqlParameter("description", review.Description));
                    cmd.Parameters.Add(new SqlParameter("score", review.Score));
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new ServerException("Had trouble connecting to server");
            }
            return true;
        }

        public bool DeleteReview(Review review)
        {
            try
            {
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Review WHERE ReviewId = @reviewId", con);
                    cmd.Parameters.Add(new SqlParameter("reviewId", review.Id));
                }
            }
            catch
            {
                throw new ServerException("Had trouble connecting to server");
            }
            return true;
        }

        public bool ReviewExists(Review review)
        {
            try
            {
                using (SqlConnection con = connection.SqlConnection)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Review WHERE UserId = @userId AND GameId = @gameId", con);
                    cmd.Parameters.Add(new SqlParameter("userId", review.UserId));
                    cmd.Parameters.Add(new SqlParameter("gameId", review.Game.Id));
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
            catch
            {
                throw new ServerException("Had trouble connecting to server");
            }
            return false;
        }
    }
}
