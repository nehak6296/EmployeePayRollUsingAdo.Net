using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            EmployeeRepo employeeRepo = new EmployeeRepo();
            //employeeRepo.CheckConnection();
            employeeRepo.GetAllEmployee();
            Console.ReadKey();
        }
    }
}
