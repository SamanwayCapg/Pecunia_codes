using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Exceptions;
using Pecunia.Entities;
using Pecunia.BusinessLayer;

namespace Pecunia.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                PrintSelectionList();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AdminLogIn();
                        break;
                    case 2:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }
            }
            while (choice != -1);
        }

        private static void AdminLogIn()
        {
            Console.WriteLine("Enter Admin ID and Password to log in");
            try
            {
                Admin admin = new Admin();
                Console.WriteLine("Enter Admin Id");
                admin.AdminID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee Password");
                admin.AdminPassword = Console.ReadLine();

                bool adminLoggedin = AdminBL.AdminLogInBL(admin);
                if (adminLoggedin)
                    Console.WriteLine("Admin Logged In");
                else
                    Console.WriteLine("Admin not Logged In");
            }
            catch (PecuniaException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintSelectionList()
        {
            Console.WriteLine("************Admin**************");
            Console.WriteLine("1.Log In");
            Console.WriteLine("2.Exit");
            Console.WriteLine("********************************\n");
        }
    }
}
