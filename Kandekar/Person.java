using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmpAppWebMvc.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Please enter unique Login name")]
        
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string LoginName { get; set; }


        [Required(ErrorMessage = "Please enter  password")]
        public string Password { get; set; }

       
        //[ScaffoldColumn(false)]
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirm password should be the same")]
        public string ConfirmPassword { get; set; }

        //[ScaffoldColumn(false)]
        [Required(ErrorMessage = "Please enter Full Name")]
        
        public string FullName { get; set; }

        //[ScaffoldColumn(false)]
        [Required(ErrorMessage = "Please enter Full email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter valid email")]
        public string EmailId { get; set; }

        

        //[ScaffoldColumn(false)]
        [Required(ErrorMessage = "Select City Name")]
        public int CityId { get; set; }


        //[ScaffoldColumn(false)]
        [Required(ErrorMessage = "Please enter phone number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Enter valid phone number")]
        public long Phone { get; set; }

        public bool isActive { get; set; }

        internal static void InsertPerson(Person p)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertPerson";
                cmdInsert.Parameters.AddWithValue("@LoginName", p.LoginName);
                cmdInsert.Parameters.AddWithValue("@Password", p.Password);
                cmdInsert.Parameters.AddWithValue("@FullName", p.FullName);
                cmdInsert.Parameters.AddWithValue("@EmailId", p.EmailId);
                cmdInsert.Parameters.AddWithValue("@CityId", p.CityId);
                cmdInsert.Parameters.AddWithValue("@Phone", p.Phone);
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                cn.Close();
            }
        }

        internal static bool isValid(Person p)
        {
            bool retval = false;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdvalid = new SqlCommand();
                cmdvalid.Connection = cn;
                cmdvalid.CommandType = System.Data.CommandType.Text;
                cmdvalid.CommandText = "Select count(*) from Persons where LoginName = @LoginName AND Password= @Password";
                cmdvalid.Parameters.AddWithValue("@LoginName", p.LoginName);
                cmdvalid.Parameters.AddWithValue("@Password", p.Password);
                int count  = (int)cmdvalid.ExecuteScalar();

                if (count == 1)
                    retval = true;


            }
            catch (Exception ex)
            {

            }
            finally
            {
                cn.Close();
            }
            return retval;
        }

        internal static void UpdatePerson(Person p)
        {
           
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {

                cn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = System.Data.CommandType.Text;
                cmdUpdate.CommandText = "Update Persons set FullName = @FullName,EmailId =@EmailId,Password =@Password, Phone =@Phone, CityId=@CityId where  LoginName = @LoginName ";
                cmdUpdate.Parameters.AddWithValue("@LoginName", p.LoginName);
                cmdUpdate.Parameters.AddWithValue("@FullName", p.FullName);
                cmdUpdate.Parameters.AddWithValue("@EmailId", p.EmailId);
                cmdUpdate.Parameters.AddWithValue("@Password", p.Password);
                cmdUpdate.Parameters.AddWithValue("@Phone", p.Phone);
                cmdUpdate.Parameters.AddWithValue("@CityId", p.CityId);
                cmdUpdate.ExecuteNonQuery();


               
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cn.Close();
            }
           

        }

        internal static HttpCookie CreateCookie(Person p)
        {
            HttpCookie objCookie = new HttpCookie("ChocoChip");

            objCookie.Expires = DateTime.Now.AddDays(1);
            objCookie.Values["key1"] = p.LoginName;

            return objCookie;
        }


        internal static Person GetSinglePerson(string loginName)
        {
            Person p = new Person();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {

                cn.Open();
                SqlCommand cmdSingle = new SqlCommand();
                cmdSingle.Connection = cn;
                cmdSingle.CommandType = System.Data.CommandType.Text;
                cmdSingle.CommandText = "Select * from Persons where LoginName = @LoginName ";
                cmdSingle.Parameters.AddWithValue("@LoginName", loginName);

                SqlDataReader dr = cmdSingle.ExecuteReader();
                while (dr.Read())
                {
                    p.LoginName = (string)dr["LoginName"];
                    p.FullName = (string)dr["FullName"];
                    p.EmailId = (string)dr["EmailId"];
                    p.Password = (string)dr["Password"];
                    p.Phone = (long)dr["Phone"];
                    p.CityId = (int)dr["CityId"];
                    
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
            return p;

        }





    }
}