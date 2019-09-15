using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Exceptions;
using Pecunia.Entities;
using Pecunia.DataAccessLayer;
using System.Text.RegularExpressions;

namespace Pecunia.BusinessLayer
{
    public class EmployeeBL
    {
        private static bool ValidateEmployee(Employee employee)
        {
            StringBuilder sb = new StringBuilder();
            bool validEmployee = true;
            if (employee.EmployeeID <= 0)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Invalid Employee ID");

            }
            if (employee.EmployeeName == string.Empty)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Employee Name Required");

            }

            Regex regexName = new Regex("^[a-zA-Z ]{2,30}*$");
            if (regexName.IsMatch(employee.EmployeeName) != true)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Employee Name should be between 2 to 30 characters");

            }

            Regex regexCode = new Regex("^[a-zA-Z0-9]+$"); //no spaces allowed
            if (regexCode.IsMatch(employee.EmployeeCode) != true)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Employee Code should be alpha numeric");

            }

            Regex regexEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (regexEmail.IsMatch(employee.EmployeeEmail) != true)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Employee Email should be valid");

            }

            Regex regexPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$");
            if (regexPassword.IsMatch(employee.EmployeePassword) != true)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Employee Password should be valid");

            }

            Regex regexMobile = new Regex("^([9]{1})([234789]{1})([0-9]{8})$");
            if (regexMobile.IsMatch(employee.EmployeeMobile) != true)
            {
                validEmployee = false;
                sb.Append(Environment.NewLine + "Employee Mobile should be valid");

            }

            if (validEmployee == false)
                throw new PecuniaException(sb.ToString());
            return validEmployee;
        }


        public static bool AddEmployeeBL(Employee newEmployee)
        {
            bool employeeAdded = false;
            try
            {
                if (ValidateEmployee(newEmployee))
                {
                    EmployeeDAL employeeDAL = new EmployeeDAL();
                    employeeAdded = employeeDAL.AddEmployeeDAL(newEmployee);
                }
            }
            catch (PecuniaException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return employeeAdded;
        }

        public static List<Employee> GetAllEmployeesBL()
        {
            List<Employee> employeeList = null;
            try
            {
                EmployeeDAL employeeDAL = new EmployeeDAL();
                employeeList = employeeDAL.GetAllEmployeesDAL();
            }
            catch (PecuniaException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employeeList;
        }

        public static Employee SearchEmployeeBL(int searchEmployeeID)
        {
            Employee searchEmployee = null;
            try
            {
                EmployeeDAL employeeDAL = new EmployeeDAL();
                searchEmployee = employeeDAL.SearchEmployeeDAL(searchEmployeeID);
            }
            catch (PecuniaException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchEmployee;

        }

        public static bool UpdateEmployeeBL(Employee updateEmployee)
        {
            bool employeeUpdated = false;
            try
            {
                if (ValidateEmployee(updateEmployee))
                {
                    EmployeeDAL employeeDAL = new EmployeeDAL();
                    employeeUpdated = employeeDAL.UpdateEmployeeDAL(updateEmployee);
                }
            }
            catch (PecuniaException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return employeeUpdated;
        }

        public static bool DeleteEmployeeBL(int deleteEmployeeID)
        {
            bool employeeDeleted = false;
            try
            {
                if (deleteEmployeeID > 0)
                {
                    EmployeeDAL employeeDAL = new EmployeeDAL();
                    employeeDeleted = employeeDAL.DeleteEmployeeDAL(deleteEmployeeID);
                }
                else
                {
                    throw new PecuniaException("Invalid Employee ID");
                }
            }
            catch (PecuniaException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return employeeDeleted;
        }


    }
}
