using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PreviousYearQPaper.Models
{
    public class Category
    {
        public int CategoryId { set; get; }

        public string CategoryName { set; get; }

        internal static List<Category> GetAllCatogories()
        {
            List<Category> cata = new List<Category>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShivkumarDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                con.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = con;
                cmdSelect.CommandType = System.Data.CommandType.Text;
                cmdSelect.CommandText = "select * from Categories";

                SqlDataReader dr = cmdSelect.ExecuteReader();

                while (dr.Read())
                {
                    cata.Add(new Category { CategoryName = (string)dr["CategoryName"], CategoryId = (int)dr["CategoryId"] });
                }
                dr.Close();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }


            return cata;
        }
    }
}