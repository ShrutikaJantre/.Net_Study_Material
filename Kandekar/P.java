using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMvc.Models
{
    public class P
    {
        [Required(ErrorMessage ="Enter id")]
        public int PId { get; set; }


        [Required(ErrorMessage = "Enter name")]
        [Display(Name = "P Name")]
        public string PName { get; set; }

        [Required(ErrorMessage = "Enter rate")]
        public decimal R { get; set; }

        [Required(ErrorMessage = "Enter desc")]
        public string Des { get; set; }

        [Required(ErrorMessage = "Enter category")]
        public string CName { get; set; }

        internal static List<P> GetAllP()
        {
            List<P> plist = new List<P>();
            
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {

                cn.Open();
                SqlCommand cmdGetAll = new SqlCommand();
                cmdGetAll.Connection = cn;
                cmdGetAll.CommandType = System.Data.CommandType.StoredProcedure;
                cmdGetAll.CommandText = "GetAllP";
               
                SqlDataReader dr = cmdGetAll.ExecuteReader();
                while (dr.Read())
                {
                    P p = new P();
                    p.PId = (int)dr["PId"];
                    p.PName = (string)dr["PName"];
                    p.R = (decimal)dr["R"];
                    p.Des = (string)dr["Des"];
                    p.CName = (string)dr["CName"];
                    plist.Add(p);

                }
                dr.Close();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                cn.Close();
            }
            return plist;
        }

        internal static void UpdateP(P p)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUpdate.CommandText = "UpdateP";
                cmdUpdate.Parameters.AddWithValue("@PId", p.PId);
                cmdUpdate.Parameters.AddWithValue("@PName", p.PName);
                cmdUpdate.Parameters.AddWithValue("@R", p.R);
                cmdUpdate.Parameters.AddWithValue("@CName", p.CName);
                cmdUpdate.Parameters.AddWithValue("@Des", p.Des);
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

        internal static P GetSingleP(int id)
        {
            P p = new P();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try 
            {
                cn.Open();
                SqlCommand cmdGetSingleP = new SqlCommand();
                cmdGetSingleP.Connection = cn;
                cmdGetSingleP.CommandType = System.Data.CommandType.StoredProcedure;
                cmdGetSingleP.CommandText = "GetSingleP";
                cmdGetSingleP.Parameters.AddWithValue("@PId",id);

                SqlDataReader dr = cmdGetSingleP.ExecuteReader();
                while (dr.Read())
                {
                    p.PId = (int)dr["PId"];
                    p.PName = (string)dr["PName"];
                    p.R = (decimal)dr["R"];
                    p.Des = (string)dr["Des"];
                    p.CName = (string)dr["CName"];
                }
                dr.Close();
            }
            catch(Exception ex) 
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


//        Ps
//PId int - Primary Key
//PName varchar(50)
//R Decimal(18,2)
//Des varchar(200)
//CName varchar(50)