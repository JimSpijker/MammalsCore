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
    class ReviewContext : IReviewContext
    {
        private readonly Connection con;

        public ReviewContext(Connection con)
        {
            this.con = con;
        }

        public bool UpdateReview(Review changedReview)
        {
            
                con.SqlConnection.Open();
                using (SqlCommand cmd =
                        new SqlCommand(
                            "UPDATE Review SET Description = @description, Score = @score WHERE ReviewId = @reviewId", con.SqlConnection)
                )
                {
                    cmd.Parameters.Add(new SqlParameter("description", changedReview.Description));
                    cmd.Parameters.Add(new SqlParameter("score", changedReview.Score));
                    cmd.Parameters.Add(new SqlParameter("reviewId", changedReview.Id));
                
                con.SqlConnection.Close();
                return true;
            }
        }
    }
}
