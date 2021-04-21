using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_Payroll_Service;Integrated Security=True;";
        SqlConnection connection = new SqlConnection(connectionString);
        public void CheckConnection()
        {
            try
            {

                using (this.connection)
                {
                    connection.Open();
                    Console.WriteLine("Connection open");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed");
            }
        }
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select * from employee_payroll;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //employeeModel.EmployeeID = dr.GetInt32(0);

                            employeeModel.EmployeeName = reader["name"].ToString();
                            employeeModel.BasicPay = Convert.ToInt32(reader["basic_pay"]);
                            employeeModel.StartDate = Convert.ToDateTime(reader["start"]);
                            employeeModel.Gender = Convert.ToChar(reader["gender"]);
                            employeeModel.PhoneNumber = Convert.ToString(reader["Phone_number"]);
                            employeeModel.Address = Convert.ToString(reader["Address"]);
                            employeeModel.Department = Convert.ToString(reader["department"]);
                            employeeModel.Deductions = Convert.ToDouble(reader["Deduction"]);
                            employeeModel.TaxablePay = Convert.ToDouble(reader["Taxable_pay"]);
                            employeeModel.Tax = Convert.ToDouble(reader["Incometax"]);
                            employeeModel.NetPay = Convert.ToDouble(reader["NetPay"]);
                            System.Console.WriteLine(employeeModel.EmployeeName + " " + employeeModel.BasicPay + " " + employeeModel.StartDate + " " + employeeModel.Gender + " " + employeeModel.PhoneNumber + " " + employeeModel.Address + " " + employeeModel.Department + " " + employeeModel.Deductions + " " + employeeModel.TaxablePay + " " + employeeModel.Tax + " " + employeeModel.NetPay);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

    }
}
