using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PreviousYearQPaper.Models
{
    public class Product
    {
        [Required(ErrorMessage ="Plaese enter the product id !")]
        public int ProductId { set; get; }

        [Required(ErrorMessage ="Please enter valid Product name")]
        [Display(Name ="Product Name")]
        public string ProductName { set; get; }

       

        [Required(ErrorMessage ="Please enter the valid rate value!")]
        public decimal Rate { set; get; }

        [Required(ErrorMessage ="Please enter Description")]
        public string Description { set; get; }

        [Required(ErrorMessage = "Please enter valid Category Id")]
        public int CategoryId { set; get; }

        public string CategoryName { set; get; }
        public static List<Product> GetAllProducts()
        {
            List<Product> product = new List<Product>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShivkumarDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                con.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = con;
                cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
                cmdSelect.CommandText = "SelectProducts";

                SqlDataReader dr = cmdSelect.ExecuteReader();

                while (dr.Read())
                {
                    product.Add(new Product { ProductId = (int)dr["ProductId"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryId = (int)dr["CategoryId"], CategoryName = (string)dr["CategoryName"] });
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


            return product;
        }

        internal static void UpdateProduct(Product product)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShivkumarDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                con.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = con;
                //cmdUpdate.CommandType = System.Data.CommandType.Text;
                //cmdUpdate.CommandText = "update Products set ProductName=@ProductName,Rate=@ProductName,Description=@Description,CategoryId=CategoryId where ProductId=@ProductId";

                cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUpdate.CommandText = "UpdateProducts2";

                cmdUpdate.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmdUpdate.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmdUpdate.Parameters.AddWithValue("@Rate", product.Rate);
                cmdUpdate.Parameters.AddWithValue("@Description", product.Description);
                cmdUpdate.Parameters.AddWithValue("@CategoryId", product.CategoryId);

                cmdUpdate.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }

        internal static Product GetSingleProduct(int id)
        {
            Product product = new Product();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShivkumarDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                con.Open();
                SqlCommand cmdSingle = new SqlCommand();
                cmdSingle.Connection = con;
                cmdSingle.CommandType = System.Data.CommandType.Text;
                cmdSingle.CommandText = "select * from Products where ProductId=@ProductId";

                cmdSingle.Parameters.AddWithValue("@ProductId", id);

                SqlDataReader dr = cmdSingle.ExecuteReader();

                while (dr.Read())
                {
                    product.ProductId = (int)dr["ProductId"];
                    product.ProductName = (string)dr["ProductName"];
                    product.Rate = (decimal)dr["Rate"];
                    product.Description = (string)dr["Description"];
                    product.CategoryId = (int)dr["CategoryId"];
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
           return product;

        }
    }
}