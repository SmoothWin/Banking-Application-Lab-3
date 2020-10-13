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
            SavingsAccount sa = new SavingsAccount(5,0.05);
            CheckingAccount ca = new CheckingAccount(5,0.05);
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
            bool goodDeposit = false;
            bool goodWithdraw = false;

            while(exit == false) {
                innerExit = false;
                try
                {
                    Console.WriteLine(" ___________________________");
                    Console.WriteLine("|         Bank Menu         |");
                    Console.WriteLine("|---------------------------|");
                    Console.WriteLine("| A: Savings                |");
                    Console.WriteLine("| B: Checking               |");
                    Console.WriteLine("| C: Global Savings         |");
                    Console.WriteLine("| Q: Exit                   |");
                    Console.WriteLine("|                           |");
                    Console.WriteLine("|___________________________|");

                    string letterAccount = Console.ReadLine();
                    string letterChoice;
                    switch (letterAccount.Trim().ToLower())
                    {
                        case "a":
                            while (innerExit == false)
                            {
                                try
                                {
                                    Console.WriteLine(" ___________________________");
                                    Console.WriteLine("|       Savings Menu        |");
                                    Console.WriteLine("|---------------------------|");
                                    Console.WriteLine("| A: Deposit                |");
                                    Console.WriteLine("| B: Withdrawal             |");
                                    Console.WriteLine("| C: Close + Report         |");
                                    Console.WriteLine("| R: Return to Bank Menu    |");
                                    Console.WriteLine("|                           |");
                                    Console.WriteLine("|___________________________|");
                                    string balance = string.Format("{0:C}", sa.Month_current_balance);
                                    Console.WriteLine("Current Balance: " + balance);
                                    letterChoice = Console.ReadLine();


                                    goodDeposit = false;
                                    goodWithdraw = false;
                                    switch (letterChoice.Trim().ToLower())
                                    {
                                        case "a":
                                        case "deposit":
                                            while (goodDeposit == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("____________Deposit_____________");
                                                    Console.WriteLine("Enter the amount you want to deposit: ");
                                                    string depositStr = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double deposit = Convert.ToDouble(depositStr);
                                                    if (deposit < 0)
                                                    {
                                                        NegativeNumberError();
                                                    }
                                                    else
                                                    {
                                                        sa.MakeDeposit(Math.Round(deposit, 2, MidpointRounding.ToEven));
                                                        Console.WriteLine("Successfully deposited " + string.Format("{0:C}", deposit));
                                                        goodDeposit = true;
                                                    }
                                                }
                                                catch (NegativeNumberException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                    Console.WriteLine("Try Again");
                                                }
                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch (NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                        Console.WriteLine("Try Again");
                                                    }
                                                }
                                            }

                                            break;
                                        case "b":
                                        case "withdraw":
                                            while (goodWithdraw == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("___________Withdrawal___________");
                                                    Console.WriteLine("Enter the amount you want to withdraw");
                                                    string withdrawStr = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double withdraw = Convert.ToDouble(withdrawStr);
                                                    if (withdraw < 0)
                                                    {
                                                        NegativeNumberError(); //No negative numbers
                                                    }
                                                    else
                                                    {
                                                        sa.MakeWithdraw(Math.Round(withdraw, 2, MidpointRounding.ToEven));
                                                        goodWithdraw = true;
                                                    }
                                                }
                                                catch (NegativeNumberException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                    Console.WriteLine("Try Again");
                                                }
                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch (NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                        Console.WriteLine("Try Again");
                                                    }
                                                }
                                            }
                                            break;
                                        case "c":
                                            Console.WriteLine("Closing and Giving Report...");
                                            Console.WriteLine(sa.CloseAndReport());
                                            break;
                                        case "r":
                                            innerExit = true;
                                            break;
                                        default:
                                            WrongMenuChoice();
                                            break;
                                    }
                                }
                                catch (WrongMenuChoiceException e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("Try Again (A,B,C,R)");
                                }
                            }
                            break;
                        case "b":
                            while (innerExit == false)
                            {
                                try
                                {
                                    goodDeposit = false;
                                    goodWithdraw = false;
                                    Console.WriteLine(" ___________________________");
                                    Console.WriteLine("|       Checking Menu       |");
                                    Console.WriteLine("|---------------------------|");
                                    Console.WriteLine("| A: Deposit                |");
                                    Console.WriteLine("| B: Withdrawal             |");
                                    Console.WriteLine("| C: Close + Report         |");
                                    Console.WriteLine("| R: Return to Bank Menu    |");
                                    Console.WriteLine("|                           |");
                                    Console.WriteLine("|___________________________|");
                                    string balance = string.Format("{0:C}", ca.Month_current_balance);
                                    Console.WriteLine("Current Balance: " + balance);
                                    letterChoice = Console.ReadLine();
                                    switch (letterChoice.Trim().ToLower())
                                    {
                                        case "a":
                                        case "deposit":
                                            while (goodDeposit == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("____________Deposit_____________");
                                                    Console.WriteLine("Enter the amount you want to deposit: ");
                                                    string depositStr = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double deposit = Convert.ToDouble(depositStr);

                                                    if (deposit < 0)
                                                    {
                                                        NegativeNumberError();
                                                    }
                                                    else
                                                    {
                                                        ca.MakeDeposit(Math.Round(deposit, 2, MidpointRounding.ToEven));
                                                        Console.WriteLine("Successfully deposited " + string.Format("{0:C}", deposit));
                                                        goodDeposit = true;
                                                    }
                                                }
                                                catch (NegativeNumberException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                    Console.WriteLine("Try Again");
                                                }
                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch (NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                        Console.WriteLine("Try Again");
                                                    }
                                                }
                                            }

                                            break;
                                        case "b":
                                        case "withdraw":
                                            while (goodWithdraw == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("___________Withdrawal___________");
                                                    Console.WriteLine("Enter the amount you want to withdraw");
                                                    string withdrawStr = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double withdraw = Convert.ToDouble(withdrawStr);
                                                    if (withdraw < 0)
                                                    {
                                                        NegativeNumberError(); //No negative numbers
                                                    }

                                                    else
                                                    {
                                                        ca.MakeWithdraw(Math.Round(withdraw, 2, MidpointRounding.ToEven));
                                                        goodWithdraw = true;
                                                    }
                                                }
                                                catch (NegativeNumberException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                    Console.WriteLine("Try Again");
                                                }
                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch (NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                        Console.WriteLine("Try Again");
                                                    }
                                                }
                                            }
                                            break;
                                        case "c":
                                            Console.WriteLine("Closing and Giving Report...");
                                            Console.WriteLine(ca.CloseAndReport());
                                            break;
                                        case "r":
                                            innerExit = true;
                                            break;
                                        default:
                                            WrongMenuChoice();
                                            break;
                                    }
                                }
                                catch (WrongMenuChoiceException e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("Try Again (A,B,C,R)");
                                }
                            }
                            break;
                        case "c":
                            while (innerExit == false)
                            {
                                try
                                {
                                    goodDeposit = false;
                                    goodWithdraw = false;
                                    Console.WriteLine(" ___________________________ ");
                                    Console.WriteLine("|    Global Savings Menu    |");
                                    Console.WriteLine("|---------------------------|");
                                    Console.WriteLine("| A: Deposit                |");
                                    Console.WriteLine("| B: Withdrawal             |");
                                    Console.WriteLine("| C: Close + Report         |");
                                    Console.WriteLine("| D: Report Balance in USD  |");
                                    Console.WriteLine("| R: Return to Bank Menu    |");
                                    Console.WriteLine("|___________________________|");
                                    string balance = string.Format("{0:C}", gsa.Month_current_balance);
                                    Console.WriteLine("Current Balance: " + balance);
                                    letterChoice = Console.ReadLine();
                                    switch (letterChoice.Trim().ToLower())
                                    {
                                        case "a":
                                        case "deposit":
                                            while (goodDeposit == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("____________Deposit_____________");
                                                    Console.WriteLine("Enter the amount you want to deposit: ");
                                                    string depositStr = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double deposit = Convert.ToDouble(depositStr);
                                                    if (deposit < 0)
                                                    {
                                                        NegativeNumberError();
                                                    }
                                                    else
                                                    {
                                                        gsa.MakeDeposit(Math.Round(deposit, 2, MidpointRounding.ToEven));
                                                        Console.WriteLine("Successfully deposited " + string.Format("{0:C}", deposit));
                                                        goodDeposit = true;
                                                    }
                                                }
                                                catch (NegativeNumberException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                    Console.WriteLine("Try Again");
                                                }
                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch (NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                        Console.WriteLine("Try Again");
                                                    }
                                                }
                                            }

                                            break;
                                        case "b":
                                        case "withdraw":
                                            while (goodWithdraw == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("___________Withdrawal___________");
                                                    Console.WriteLine("Enter the amount you want to withdraw");
                                                    string withdrawStr = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double withdraw = Convert.ToDouble(withdrawStr);
                                                    if (withdraw < 0)
                                                    {
                                                        NegativeNumberError(); //No negative numbers
                                                    }

                                                    else
                                                    {
                                                        gsa.MakeWithdraw(Math.Round(withdraw, 2, MidpointRounding.ToEven));
                                                        goodWithdraw = true;
                                                    }
                                                }
                                                catch (NegativeNumberException e)
                                                {

                                                    Console.WriteLine(e.Message);
                                                    Console.WriteLine("Try Again");
                                                }
                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch (NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                        Console.WriteLine("Try Again");
                                                    }
                                                }
                                            }
                                            break;
                                        case "c":
                                            Console.WriteLine("Closing and Giving Report...");
                                            Console.WriteLine(gsa.CloseAndReport());
                                            break;
                                        case "d":
                                            Console.WriteLine("Total balance in USD: " + string.Format("{0:C}", gsa.USValue(0.76)));
                                            break;
                                        case "r":
                                            innerExit = true;
                                            break;
                                        default:
                                            WrongMenuChoice();
                                            break;
                                    }
                                }
                                catch (WrongMenuChoiceException e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("Try Again (A,B,C,D,R)");
                                }
                            }
                            break;
                        case "q":
                            exit = true;
                            break;
                        default:
                            WrongMenuChoice();
                            break;
                    }
                }catch(WrongMenuChoiceException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try Again (A,B,C,Q)");
                }
                
                

            }
        }
        public static void WrongMenuChoice()
        {
            WrongMenuChoiceException ex = new WrongMenuChoiceException("Selected choice is invalid ","Wrong letter choice was chosen for selected menu.",DateTime.Now);
            throw ex;
        }
        public static void NegativeNumberError()
        {
            NegativeNumberException ex = new NegativeNumberException("Invalid currency amount ","Number goes against withdrawal system.",DateTime.Now);
            throw ex;
        }
        public static double NotNumberError()
        {
            NotNumberException ex = new NotNumberException("Invalid value for currency", "The input needs to be a currency type value.", DateTime.Now);
            throw ex;
        }
    }
}
