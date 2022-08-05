using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductTable.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }

        public static List<Categories> GetAllCategories()
        {
            List<Categories> cat = new List<Categories>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.CommandText = "DisplayCategories";

                SqlDataReader dr = cmdSelect.ExecuteReader();

                while (dr.Read())
                {
                    cat.Add(new Categories
                    {
                        CategoryId = (int)dr["CategoryId"],
                        CategoryName = (string)dr["CategoryName"]

                    });

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return cat;
        }
    }
}