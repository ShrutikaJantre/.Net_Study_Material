using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductTable.Models
{
    public class ProductsCLass
    {
        public int ProductId { set; get; }

        public String ProductName { set; get; }

        public String Description { set; get; }

        public decimal Rate { set; get; }
        public int CategoryId { set; get; }
        public String CategoryName { set; get; }

        public IEnumerable<SelectListItem> Category { set; get; }

        public static List<ProductsCLass> GetAllProducts()
        {
            ProductsCLass obj = new ProductsCLass();

            List<ProductsCLass> list = new List<ProductsCLass>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString= @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Products,Categories Where Products.CategoryId=Categories.CategoryId";                                                     //"Select * from Products, Categories where Products.CategoryId = Categories.CategoryId";
                SqlDataReader dr = cmdSelect.ExecuteReader();
                while (dr.Read())
                {

                    list.Add(new ProductsCLass { ProductId = (int)dr["ProductId"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], 
                                            Description = (string)dr["Description"],CategoryId=(int)dr["CategoryId"] ,CategoryName = (String)dr["CategoryName"] });
                
                }
                dr.Close();
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }    
            return list;
        }
        public  static ProductsCLass GetSingleProduct(int ProductId)
        {
            ProductsCLass obj = new ProductsCLass();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdSingle = new SqlCommand();
                cmdSingle.Connection = cn;
                cmdSingle.CommandType = CommandType.StoredProcedure;
                cmdSingle.CommandText = "DisplaySingle";
                cmdSingle.Parameters.AddWithValue("@ProductId", ProductId);
                // cmdSingle.CommandText = "Select * from Employee";

                SqlDataReader dr = cmdSingle.ExecuteReader();
                if (dr.Read())
                {
                    obj.ProductId = (int)dr["ProductId"];
                    obj.ProductName = (string)dr["ProductName"];
                    obj.Rate = (decimal)dr["Rate"];
                    obj.Description = (string)dr["Description"];
                    obj.CategoryId = (int)dr["CategoryId"];
                    obj.CategoryName = (string)dr["CategoryName"];
                }
                dr.Close();
            }
            catch(Exception ex) {
            }
            finally { cn.Close(); }
               
                return obj; 

            }

        public static void InsertProduct(ProductsCLass obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertProduct";

                cmdInsert.Parameters.AddWithValue("@ProductId", obj.ProductId);
                cmdInsert.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmdInsert.Parameters.AddWithValue("@Rate", obj.Rate);
                cmdInsert.Parameters.AddWithValue("@Description", obj.Description);
                cmdInsert.Parameters.AddWithValue("@CategoryId", obj.CategoryId);
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("okay inserted");

            }
            catch (Exception ex)
            {
            }
            finally { cn.Close(); }
        }
        public static void UpdateProduct(ProductsCLass obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "UpdateProduct";

                cmdInsert.Parameters.AddWithValue("@ProductId", obj.ProductId);
                cmdInsert.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmdInsert.Parameters.AddWithValue("@Rate", obj.Rate);
                cmdInsert.Parameters.AddWithValue("@Description", obj.Description);
                cmdInsert.Parameters.AddWithValue("@CategoryId", obj.CategoryId);
                cmdInsert.ExecuteNonQuery();
               

            }
            catch (Exception ex)
            {
            }
            finally { cn.Close(); }
        }
        public static void DeleteProduct(ProductsCLass obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "DeleteProduct";

                cmdInsert.Parameters.AddWithValue("@ProductId", obj.ProductId);
                
                cmdInsert.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
            }
            finally { cn.Close(); }
        }
    }
}