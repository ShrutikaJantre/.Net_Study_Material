using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HtmlHelpers.Models
{
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }

        public static List<Department> GetAllDepartments()
        {
            List<Department> objDepts = new List<Department>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Departments";

                SqlDataReader dr = cmdSelect.ExecuteReader();
                while (dr.Read())
                {
                    Department dept = new Department();
                    dept.DeptNo = (int)dr["DeptNo"];
                    dept.DeptName = (string)dr["DeptName"];
                    objDepts.Add(dept);
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
            return objDepts;
        }
    }

    
}
