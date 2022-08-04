using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DotNetQ.Models
{
    public class Products
    {
        [Key]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "enter the name of product")]
        [StringLength(10, ErrorMessage = "the word{0} is excedded by {1} letter")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "enter the rate")]
        [DataType(DataType.Currency)]
        [Display(Name = "Rate")]
        public decimal Rate { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "enter the Description")]
        [StringLength(20, ErrorMessage = "the word{0} is excedded by {1} letter")]
        [Display(Name = "Desciption")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "enter the name of pcategory")]
        [StringLength(10, ErrorMessage = "the word{0} is excedded by {1} letter")]
        [Display(Name = "Category Name")]
        public string CategoryName  { get; set; }

        public static List<Products> GetAllProducts()
        {
            List<Products> prod= new List<Products>();
          
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Products";

                SqlDataReader dr = cmdSelect.ExecuteReader();
                while (dr.Read())
                {
                    prod.Add(new Products { ProductId = (int)dr["ProductId"], ProductName = (string)dr["ProductName"], Rate= (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName= (string)dr["CategoryName"] });

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
            return prod;
        }

        public static Products GetSingleProduct(int ProductId)
        {

            Products obj = new Products();
      
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                cn.Open();
                SqlCommand cmdSingle = new SqlCommand();
                cmdSingle.Connection = cn;
                cmdSingle.CommandType = CommandType.Text;

                cmdSingle.CommandText = "Select * from Products where ProductId= @ProductId";
                cmdSingle.Parameters.AddWithValue("@ProductId", ProductId);
                // cmdSingle.CommandText = "Select * from Employee";

                SqlDataReader dr = cmdSingle.ExecuteReader();
                if (dr.Read())
                {
                    obj.ProductId = (int)dr["ProductId"];
                    obj.ProductName = (string)dr["ProductName"];
                    obj.Rate = (decimal)dr["Rate"];
                    obj.Description = (string)dr["Description"];
                    obj.CategoryName = (string)dr["CategoryName"];
                }

             
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();

            }
            return obj;

        }

        public static void InsertProduct(Products obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = $"insert into Products values(@ProductId, @ProductName, @Rate, @Description, @CategoryName)";
                cmdInsert.Parameters.AddWithValue("@ProductId", obj.ProductId);
                cmdInsert.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmdInsert.Parameters.AddWithValue("@Rate", obj.Rate);
                cmdInsert.Parameters.AddWithValue("@Description", obj.Description);
                cmdInsert.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("okay inserted");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public static void UpdateProduct(Products obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "Update Products set ProductName = @ProductName, Rate=@Rate, Description=@Description,CategoryName=@CategoryName";
                //cmdInsert.Parameters.AddWithValue("@ProductId", obj.ProductId);
                cmdInsert.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmdInsert.Parameters.AddWithValue("@Rate", obj.Rate);
                cmdInsert.Parameters.AddWithValue("@Description", obj.Description);
                cmdInsert.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("okay Updated");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public static void DeleteProduct(int ProductId)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cn;
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.CommandText = "delete from Products where ProductId=@ProductId";

                // cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });
                cmdDelete.Parameters.AddWithValue("@ProductId", ProductId);
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

       
    }
}