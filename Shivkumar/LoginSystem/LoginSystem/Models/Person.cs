using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LoginSystem.Models
{
    public class Person
    {
        [Required(ErrorMessage ="please enter a unique Login Name")]
    
        public string LoginName { set; get; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirm password should be the same")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { set; get; }

        

        [Required(ErrorMessage ="Please enter Full name")]
        [DataType(DataType.Text)]
        public string FullName { set; get; }

        [Required(ErrorMessage ="Please enter valid email id")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Enter valid email id")]
        public string EmailId { set; get; }

        public int CityId { set; get; }

        [Required(ErrorMessage ="Please enter mobile number")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Please enter valid phone number")]
        public long Phone { set; get; }

        internal static void InsertPersons(Person obj)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ShivkumarDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            try
            {
                con.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection= con;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertPerson";

                cmdInsert.Parameters.AddWithValue("@LoginName", obj.LoginName);
                cmdInsert.Parameters.AddWithValue("@Password", obj.Password);
                cmdInsert.Parameters.AddWithValue("@FullName", obj.FullName);
                cmdInsert.Parameters.AddWithValue("@EmailId", obj.EmailId);
                cmdInsert.Parameters.AddWithValue("@CityId", obj.CityId);
                cmdInsert.Parameters.AddWithValue("@Phone", obj.Phone);

                cmdInsert.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }

        internal static void UpdatePerson(Person obj)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ShivkumarDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            try
            {
                con.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = con;
                //cmdUpdate.CommandType = System.Data.CommandType.Text;
                //cmdUpdate.CommandText = "update Persons set FullName=@FullName ,EmailId=@EmailId , CityId=@CityId ,Phone=@Phone where LoginName=@LoginName";

                cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUpdate.CommandText = "UpdatePerson";

                cmdUpdate.Parameters.AddWithValue("@LoginName", obj.LoginName);
                cmdUpdate.Parameters.AddWithValue("@FullName", obj.FullName);
                cmdUpdate.Parameters.AddWithValue("@EmailId", obj.EmailId);
                cmdUpdate.Parameters.AddWithValue("@CityId", obj.CityId);
                cmdUpdate.Parameters.AddWithValue("@Phone", obj.Phone);

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

        public bool isActive { set; get; }

        internal static bool IsValidPerson(Person obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ShivkumarDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            try
            {
                con.Open();

                SqlCommand cmdValid = new SqlCommand();
                cmdValid.Connection = con;
                cmdValid.CommandType = System.Data.CommandType.Text;
                cmdValid.CommandText = "select count(*) from Persons where LoginName=@LoginName and Password=@Password";

                cmdValid.Parameters.AddWithValue("@LoginName", obj.LoginName);
                cmdValid.Parameters.AddWithValue("@Password", obj.Password);

                int val = (int)cmdValid.ExecuteScalar();

                if (val == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }

            return false;
        }

        internal static Person GetSinglePerson(string name)
        {
            Person person = new Person();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ShivkumarDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            try
            {
                con.Open();

                SqlCommand cmdSingle = new SqlCommand();
                cmdSingle.Connection = con;
                cmdSingle.CommandType = System.Data.CommandType.Text;
                cmdSingle.CommandText = "select * from Persons where LoginName=@LoginName";

                cmdSingle.Parameters.AddWithValue("@LoginName", name);

                SqlDataReader dr = cmdSingle.ExecuteReader();

                while (dr.Read())
                {
                    person.LoginName = (string)dr["LoginName"];
                    person.FullName = (string)dr["FullName"];
                    person.EmailId = (string)dr["EmailId"];
                    person.CityId = (int)dr["CityId"];
                    person.Phone = (long)dr["Phone"];

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

            return person;
        }
    }
}