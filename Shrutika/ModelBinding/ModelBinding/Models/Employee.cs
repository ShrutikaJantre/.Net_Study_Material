using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ModelBinding.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> emps = new List<Employee>();
            //emps.Add(new Employee { EmpNo = 1, Name = "V", Basic = 10000, DeptNo = 20 });
            //emps.Add(new Employee { EmpNo = 2, Name = "A", Basic = 10000, DeptNo = 20 });
            //emps.Add(new Employee { EmpNo = 3, Name = "H", Basic = 10000, DeptNo = 20 });
            //emps.Add(new Employee { EmpNo = 4, Name = "S", Basic = 10000, DeptNo = 20 });

            //while(dr.Read())
            //emps.Add(new Employee { EmpNo = ---, Name = ----, Basic = ---, DeptNo = --- });
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Employee";

                SqlDataReader dr = cmdSelect.ExecuteReader();
                while (dr.Read())
                {
                    emps.Add(new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (int)dr["DeptNo"] });
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
                return emps;
        }

        public static Employee GetSingleEmployee(int EmpNo)
        {

            Employee obj = new Employee();
            //obj.EmpNo = EmpNo;
            //obj.Name = "himensh";
            //obj.Basic = 10000;
            //obj.DeptNo = 10;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                cn.Open();
                SqlCommand cmdSingle = new SqlCommand();
                cmdSingle.Connection = cn;
                cmdSingle.CommandType = CommandType.Text;

                cmdSingle.CommandText = "Select * from Employee where EmpNo= @EmpNo";
                cmdSingle.Parameters.AddWithValue("@EmpNo", EmpNo);
                // cmdSingle.CommandText = "Select * from Employee";

                SqlDataReader dr = cmdSingle.ExecuteReader();
                if (dr.Read())
                {
                    obj.EmpNo = (int)dr["EmpNo"];
                    obj.Name = (string)dr["Name"];
                    obj.Basic = (decimal)dr["Basic"];
                    obj.DeptNo = (int)dr["DeptNo"];
                }

                /* while (dr.Read())
                 {
                     if (EmpNo == (int)dr["EmpNo"])
                     {
                         obj.EmpNo = (int)dr["EmpNo"];
                         obj.Name = (string)dr["Name"];
                         obj.Basic = (decimal)dr["Basic"];
                         obj.DeptNo = (int)dr["DeptNo"];
                     }

                 }*/

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
        public static void InsertEmployee(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = $"insert into Employee values(@EmpNo,@Name,@Basic,@DeptNo)";
                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
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
        public static void UpdateEmployee(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = "Update Employee set EmpNo=@EmpNo ,Name=@Name,Basic=@Basic, DeptNo=@DeptNo where EmpNo=@EmpNo";
                cmdUpdate.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdUpdate.Parameters.AddWithValue("@Name", obj.Name);
                cmdUpdate.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdUpdate.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmdUpdate.ExecuteNonQuery();
                Console.WriteLine("okay");

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
        public static void DeleteEmployee(int EmpNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cn;
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.CommandText = "delete from Employee where EmpNo=@EmpNo";

                // cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });
                cmdDelete.Parameters.AddWithValue("@EmpNo", EmpNo);
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

