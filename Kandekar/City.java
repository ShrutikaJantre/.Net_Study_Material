using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmpAppWebMvc.Models
{
    public class City
    {

        public int CityId { get; set; }
        public String CityName { get; set; }

        internal static List<City> GetAllCity()
        {
            List<City> cities = new List<City>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdAllcity = new SqlCommand();
                cmdAllcity.Connection = cn;
                cmdAllcity.CommandType = System.Data.CommandType.Text;
                cmdAllcity.CommandText = "Select * from Cities";

                SqlDataReader dr = cmdAllcity.ExecuteReader();

                while (dr.Read())
                {
                    cities.Add(new City { CityId = (int)dr["CityId"], CityName = (string)dr["CityName"] });
                }
                dr.Close();
            
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cn.Close();
            }
            return cities;
        }
    }
}