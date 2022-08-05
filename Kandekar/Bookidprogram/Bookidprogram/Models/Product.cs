using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Bookidprogram.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string  ProductName { get; set; }
        public decimal Rate { get; set; }
        public string Describution { get; set; }

        public static explicit operator Product(List<Product> v)
        {
            throw new NotImplementedException();
        }

        public string CategoryName { get; set; }
        public static string GetNameofcat(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practise;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true";
            con.Open();

            SqlCommand s1 = new SqlCommand();
            s1.Connection = con;
            s1.CommandType = System.Data.CommandType.Text;
            s1.CommandText = $"select CategoryName from Categories where CategoryId={id} ";
            string s = (string)s1.ExecuteScalar();
            return s;

        }
        public IEnumerable<SelectListItem> Categories { get; set; }

        internal static List<Product> GetAllproducts()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practise;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true" ;
            con.Open();

            SqlCommand s = new SqlCommand();
            s.Connection = con;
            s.CommandType = System.Data.CommandType.Text;
            s.CommandText = "select * from Products";

            SqlDataReader dr = s.ExecuteReader();
            List<Product> list = new List<Product>();
            int cid = 0;
            while (dr.Read())
            {
                Product p = new Product();
                p.ProductId = (int)dr[0];
                p.ProductName = (string)dr[1];
                p.Rate = (decimal)dr[2];
                p.Describution = (string)dr[3];
                cid =(int) dr[4];
                SqlCommand s1 = new SqlCommand();
                s1.Connection = con;
                s1.CommandType = System.Data.CommandType.Text;
                s1.CommandText = $"select CategoryName from Categories where CategoryId={cid} ";
                p.CategoryName = (string)s1.ExecuteScalar();
                list.Add(p);
            }
            
            dr.Close();
            con.Close();
            return list;
        }

        internal static void UpdateProduct(Product p)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practise;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true";
            con.Open();
            SqlCommand s1 = new SqlCommand($"select CategoryId from Categories where CategoryName= '{p.CategoryName}'",con);
            int cid = (int)s1.ExecuteScalar();
            con.Close();



            con.Open();

            SqlCommand s = new SqlCommand($"update Products set ProductName='{p.ProductName}',Rate={p.Rate},Description='{p.Describution}',CategoryId={cid} where ProductId={p.ProductId}",con);
            s.ExecuteNonQuery();
            con.Close();


        }

        internal static Product Getsingleproduct(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practise;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true";

            con.Open();
            SqlCommand s = new SqlCommand();
            s.Connection = con;
            s.CommandType = System.Data.CommandType.Text;
            s.CommandText = $"select * from Products where ProductId={id} ";
            //SqlDataReader
            SqlDataReader dr = s.ExecuteReader();
            Product p = new Product();
            if (dr.Read())
            {
                p.ProductId = (int)dr[0];
                p.ProductName = (string)dr[1];
                p.Rate =(decimal) dr[2];
                p.Describution = (string)dr[3];
                p.CategoryName = GetNameofcat((int)dr[4]);

            }
            
            con.Close();
            return p;




        }

        internal static void InsertProduct(Product p)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString= @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Practise; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; MultipleActiveResultSets = true" ;
            con.Open();
            SqlCommand s1 = new SqlCommand();
            int id = 100;
            SqlCommand s = new SqlCommand();
            s.Connection = con;
            s.CommandType = System.Data.CommandType.Text;
            s.CommandText = $"insert into Products values({p.ProductId},'{p.ProductName}',{p.Rate},'{p.Describution}',{id})";
            con.Close();

        }
    }
}