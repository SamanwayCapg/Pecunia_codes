using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using Pecunia.Exceptions;
using System.Data.Common;

namespace Pecunia.DataAccessLayer
{
    public class EmployeeDAL
    {
        public static List<Employee> employeeList = new List<Employee>();

        public bool AddEmployeeDAL(Employee newEmployee)
        {
            DateTime time = DateTime.Now;
            string employeeID = "EMP" + time.ToString("yyyyMMddhhmmss"); 
            newEmployee.EmployeeID = employeeID;

            bool employeeAdded = false;
            try
            {
                employeeList.Add(newEmployee);
                employeeAdded = true;
            }
            catch (Exception ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return employeeAdded;

        }

        public List<Employee> GetAllEmployeesDAL()
        {
            return employeeList;
        }

        public Employee SearchEmployeeDAL(string searchEmployeeID)
        {
            Employee searchEmployee = null;
            try
            {
                foreach (Employee item in employeeList)
                {
                    if (item.EmployeeID == searchEmployeeID)
                    {
                        searchEmployee = item;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return searchEmployee;
        }

        public List<Employee> GetEmployeesByNameDAL(string employeeName)
        {
            List<Employee> searchEmployee = new List<Employee>();
            try
            {
                foreach (Employee item in employeeList)
                {
                    if (item.EmployeeName == employeeName)
                    {
                        searchEmployee.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return searchEmployee;
        }

        public bool UpdateEmployeeDAL(Employee updateEmployee)
        {
            bool employeeUpdated = false;
            try
            {
                for (int i = 0; i < employeeList.Count; i++)
                {
                    if (employeeList[i].EmployeeID == updateEmployee.EmployeeID)
                    {
                        updateEmployee.EmployeeName = employeeList[i].EmployeeName;
                        updateEmployee.EmployeeEmail = employeeList[i].EmployeeEmail;
                        updateEmployee.EmployeePassword = employeeList[i].EmployeePassword;
                        updateEmployee.EmployeeMobile = employeeList[i].EmployeeMobile;

                        employeeUpdated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return employeeUpdated;

        }

        public bool DeleteEmployeeDAL(string deleteEmployeeID)
        {
            bool employeeDeleted = false;
            try
            {
                Employee deleteEmployee = null;
                foreach (Employee item in employeeList)
                {
                    if (item.EmployeeID == deleteEmployeeID)
                    {
                        deleteEmployee = item;
                    }
                }

                if (deleteEmployee != null)
                {
                    employeeList.Remove(deleteEmployee);
                    employeeDeleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return employeeDeleted;

        }

    }
}
