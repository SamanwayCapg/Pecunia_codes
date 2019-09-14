using Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.DataAccessLayer
{
    interface ILoanDAL
    {
        List<HomeLoan> HomeLoans { get; set; }
        List<HomeLoan> EduLoans { get; set; }
        List<HomeLoan> CarLoans { get; set; }
    }
    
   public class HomeLoanDAL : ILoanDAL
    {
        public List<HomeLoan> HomeLoans { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<HomeLoan> EduLoans { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<HomeLoan> CarLoans { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void listLoanByCustomerID(int customerID)
        {
            foreach(List<HomeLoan> loan in HomeLoans)
            {

            }
        }
    }

    public class EduLoanDAL
    {

    }

    public class CarLoanDAL
    {

    }
}
