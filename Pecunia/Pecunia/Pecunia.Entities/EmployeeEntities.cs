using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.Entities
{
    public class Employee
    {
        private int employeeID;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        private string employeeName;

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        private string employeeCode;
        public string EmployeeCode
        {
            get { return employeeCode; }
            set { employeeCode = value; }
        }


        private string employeeEmail;

        public string EmployeeEmail
        {
            get { return employeeEmail; }
            set
            {
                employeeEmail = value;
            }
        }

        private string employeePassword;
        public string EmployeePassword
        {
            get { return employeePassword; }
            set { employeePassword = value; }
        }

        private string employeeMobile;
        public string EmployeeMobile
        {
            get { return employeeMobile; }
            set
            {
                employeeMobile = value;
            }
        }


        public Employee()
        {
            employeeID = 0;
            employeeName = string.Empty;
            employeeCode = string.Empty;
            employeeEmail = string.Empty;
            employeePassword = string.Empty;
            employeeMobile = string.Empty;

        }
    }
}
