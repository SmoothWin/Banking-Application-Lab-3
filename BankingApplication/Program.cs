using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount sa = new SavingsAccount(5,0.5);
            CheckingAccount ca = new CheckingAccount(5,0.5);
            GlobalSavingsAccount gsa = new GlobalSavingsAccount(5,0.05);
            
            
            Console.WriteLine("Hello welcome to Champlain international bank...");
            Console.WriteLine("Login to continue...");
            Console.Write("Username: ");
            string name = Console.ReadLine();
            Console.Write("Password (enter random things this is just for fun): ");
            Console.ReadLine();
            Console.WriteLine("Hello " + name + "\nSelect which Bank Menu you would like to interact with: ");
            bool exit = false;
            bool innerExit = false;

            while(exit == false) { 
            Console.WriteLine(" ___________________________");
            Console.WriteLine("|         Bank Menu         |");
            Console.WriteLine("|---------------------------|");
            Console.WriteLine("| A: Savings                |");
            Console.WriteLine("| B: Checking               |");
            Console.WriteLine("| C: GlobalSavings          |");
            Console.WriteLine("| Q: Exit                   |");
            Console.WriteLine("|                           |");
            Console.WriteLine("|___________________________|");

            string letterAccount = Console.ReadLine();
            string letterChoice;
                switch (letterAccount.Trim().ToLower())
                {
                    case "a":
                        Console.WriteLine(" ___________________________");
                        Console.WriteLine("|       Savings Menu        |");
                        Console.WriteLine("|---------------------------|");
                        Console.WriteLine("| A: Deposit                |");
                        Console.WriteLine("| B: Withdrawal             |");
                        Console.WriteLine("| C: Close + Report         |");
                        Console.WriteLine("| R: Return to Bank Menu    |");
                        Console.WriteLine("|                           |");
                        Console.WriteLine("|___________________________|");
                        letterChoice = Console.ReadLine();
                        break;
                    case "b":
                        Console.WriteLine(" ___________________________");
                        Console.WriteLine("|       Checking Menu       |");
                        Console.WriteLine("|---------------------------|");
                        Console.WriteLine("| A: Deposit                |");
                        Console.WriteLine("| B: Withdrawal             |");
                        Console.WriteLine("| C: Close + Report         |");
                        Console.WriteLine("| R: Return to Bank Menu    |");
                        Console.WriteLine("|                           |");
                        Console.WriteLine("|___________________________|");
                        letterChoice = Console.ReadLine();
                        break;
                    case "c":
                        while (innerExit == false) {
                            Console.WriteLine(" ___________________________ ");
                            Console.WriteLine("|    Global Savings Menu    |");
                            Console.WriteLine("|---------------------------|");
                            Console.WriteLine("| A: Deposit                |");
                            Console.WriteLine("| B: Withdrawal             |");
                            Console.WriteLine("| C: Close + Report         |");
                            Console.WriteLine("| D: Report Balance in USD  |");
                            Console.WriteLine("| R: Return to Bank Menu    |");
                            Console.WriteLine("|___________________________|");
                            letterChoice = Console.ReadLine();
                            switch (letterChoice.Trim().ToLower())
                            {
                                case "a":
                                    try
                                    {
                                        string balance = string.Format("{0:C}", gsa.Month_current_balance);
                                        Console.WriteLine("Current Balance: " + balance);
                                        Console.WriteLine("Enter the amount you want to deposit: ");
                                        string depositStr = Console.ReadLine();
                                        double deposit = Convert.ToDouble(depositStr);
                                        if(deposit < 0)
                                        {
                                            throw new Exception();
                                        }
                                        gsa.MakeDeposit(deposit);
                                        Console.WriteLine("Successfully deposited $" + deposit);
                                    } 
                                    catch(Exception e)
                                    {
                                        Console.WriteLine("Invalid number type, no negative numbers allowed");
                                        Console.WriteLine(e.Message);
                                    }

                                    break;
                                case "b":
                                    try
                                    {
                                        string balance = string.Format("{0:C}", gsa.Month_current_balance);
                                        Console.WriteLine("Current Balance: " + balance);
                                        Console.WriteLine("Enter the amount you want to withdraw");
                                        string withdrawStr = Console.ReadLine();
                                        double withdraw = Convert.ToDouble(withdrawStr);
                                        if (withdraw < 0)
                                        {
                                            throw new Exception();
                                        }
                                        gsa.MakeWithdraw(withdraw);
                                        Console.WriteLine("Successfully deposited $" + withdraw);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Invalid number type, no negative numbers allowed");
                                        Console.WriteLine(e.Message);
                                        break;
                                    }
                                    break;
                                case "c":
                                    Console.WriteLine("Closing and Giving Report...");
                                    gsa.CloseAndReport();
                                    break;
                                case "d":
                                    Console.WriteLine("Total balance in USD: "+ gsa.USValue(0.76));
                                    break;
                                case "r":
                                    innerExit = true;
                                    break;
                                default:
                                    Console.WriteLine("Wrong Letter was entered choose between A, B, C, D");
                                    break;
                            }
                        }
                        break;
                    case "q":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("The wrong key was pressed please choose between A,B,C,Q");
                        break;
                }

            }
        }
    }
}
