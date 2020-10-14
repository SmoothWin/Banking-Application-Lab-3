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
            
            
            Console.WriteLine("Hello welcome to Champlain International Bank...");
            Console.WriteLine("Login to continue...");
            Console.Write("Username: ");
            string name = Console.ReadLine();
            Console.Write("Password (enter random things, this is just for fun): ");
            Console.ReadLine();
            Console.WriteLine("Hello " + name + "\nSelect an option within the menu you would like to interact with: ");
            bool exit = false;
            bool innerExit = false;
            bool goodDeposit = false;
            bool goodWithdraw = false;

            while(exit == false) {
                try
                {
                    Console.WriteLine(" ___________________________");
                    Console.WriteLine("|         Bank Menu         |");
                    Console.WriteLine("|---------------------------|");
                    Console.WriteLine("| A: Savings Account        |");
                    Console.WriteLine("| B: Checking Account       |");
                    Console.WriteLine("| C: Global Savings Account |");
                    Console.WriteLine("| Q: Exit                   |");
                    Console.WriteLine("|                           |");
                    Console.WriteLine("|___________________________|");

                    string letterAccount = Console.ReadLine();
                    string letterChoice;
                    switch (letterAccount.Trim().ToLower())
                    {
                        case "a":
                        case "savings":
                        case "savings account":
                            while (innerExit == false)
                            {
                                try
                                {
                                    Console.WriteLine(" ___________________________");
                                    Console.WriteLine("|       Savings Menu        |");
                                    Console.WriteLine("|---------------------------|");
                                    Console.WriteLine("| A: Deposit                |");
                                    Console.WriteLine("| B: Withdrawal             |");
                                    Console.WriteLine("| C: Close and Report       |");
                                    Console.WriteLine("| R: Return to Bank Menu    |");
                                    Console.WriteLine("|                           |");
                                    Console.WriteLine("|___________________________|");
                                    string balance = sa.Month_current_balance.ToNAMoneyFormat(true);
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
                                                        sa.MakeDeposit(deposit.ToNAMoneyFormatD(true));
                                                        Console.WriteLine("Successfully deposited " + deposit.ToNAMoneyFormat(true));
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
                                                        sa.MakeWithdraw(withdraw.ToNAMoneyFormatD(true));
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
                        case "checking":
                        case "checking account":
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
                                    Console.WriteLine("| C: Close and Report       |");
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
                                                        ca.MakeDeposit(deposit.ToNAMoneyFormatD(true));
                                                        Console.WriteLine("Successfully deposited " + deposit.ToNAMoneyFormat(true));
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
                                                        ca.MakeWithdraw(withdraw.ToNAMoneyFormatD(true));
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
                        case "global":
                        case "global savings":
                        case "global savings account":
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
                                    Console.WriteLine("| C: Close and Report       |");
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
                                                        gsa.MakeDeposit(deposit.ToNAMoneyFormatD(true));
                                                        Console.WriteLine("Successfully deposited " + deposit.ToNAMoneyFormat(true));
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
                                                        gsa.MakeWithdraw(withdraw.ToNAMoneyFormatD(true));
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
                                            Console.WriteLine("Total balance: " + gsa.USValue(0.76).ToNAMoneyFormatD(true) + " USD");
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
       
        public static void WrongMenuChoice() //Handles the error for a wrong menu choice
        {
            WrongMenuChoiceException ex = new WrongMenuChoiceException("Selected choice is invalid ","Wrong choice for selected menu. ",DateTime.Now);
            throw ex;
        }
        public static void NegativeNumberError() //Handles the error for negative number input
        {
            NegativeNumberException ex = new NegativeNumberException("Invalid amount ","Number goes against withdrawal numeral system.",DateTime.Now);
            throw ex;
        }
        public static double NotNumberError() //Handles the error for anything that is not a number
        {
            NotNumberException ex = new NotNumberException("Invalid value", "The input needs to be a numeral type value.", DateTime.Now);
            throw ex;
        }
    }
}
