using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LoginSystem.Models
{
    public class City
    {

        public int CityId { set; get; }

        public string CityName { set; get; }

        internal static List<City> GetAllCities()
        {
            List<City> cities = new List<City>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShivkumarDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                con.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = con;
                cmdSelect.CommandType = System.Data.CommandType.Text;
                cmdSelect.CommandText = "select * from Cities";

                SqlDataReader dr = cmdSelect.ExecuteReader();

                while (dr.Read())
                {
                    cities.Add(new City {CityId= (int)dr[0], CityName= (string)dr[1]});
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

            return cities;
        }
    }
}