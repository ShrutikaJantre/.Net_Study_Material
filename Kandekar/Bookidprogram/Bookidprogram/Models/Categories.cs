using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Bookidprogram.Models
{
    public class Categories
    {
        
         public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public static List<Categories> GetAll()
        {
            List<Categories> list = new List<Categories>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practise;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true";
            
            con.Open();
            SqlCommand s = new SqlCommand();
            s.Connection = con;
            s.CommandType = System.Data.CommandType.Text;
            s.CommandText = "select * from Categories";

            var e = s.ExecuteReader();
            while (e.Read())
            {
                Categories c = new Categories();
                c.CategoryId =(int) e[0];
                c.CategoryName = (string)e[1];
                list.Add(c);

            }
            e.Close();
            con.Close();
            return list;
        }

    }
}