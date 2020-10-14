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
            // Creation of instances classes
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
            bool exit = false; // loop break for Bank menu
            bool innerExit = false; //loop break for Account menus

            bool goodDeposit = false; //loop break for deposits
            bool goodWithdraw = false; //loop break for withdraws

            //Start of program loop
            while(exit == false) {
                innerExit = false;
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
                    //Start of main switch statement
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


                                    goodDeposit = false; // Resets the deposit loop to keep looping the next time we enter a bad value
                                    goodWithdraw = false; // Resets the deposit loop to keep looping the next time we enter a bad value

                                    //Start of switch statement for Savings menu
                                    switch (letterChoice.Trim().ToLower())
                                    {
                                        case "a":
                                        case "deposit":
                                            //loop for deposit validation
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
                                                        goodDeposit = true; // Exit of loop allowed
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
                                            //loop for withdraw validation
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
                                                        goodWithdraw = true; // Exit of loop allowed
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
                                    //End of switch statement for Savings menu
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
                                    string balance = ca.Month_current_balance.ToNAMoneyFormat(true);
                                    Console.WriteLine("Current Balance: " + balance);
                                    letterChoice = Console.ReadLine();
                                    
                                    //Start of switch statement for Checking Menu
                                    switch (letterChoice.Trim().ToLower())
                                    {
                                        case "a":
                                        case "deposit":
                                            //loop for deposit validation
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
                                                        goodDeposit = true; // Exit of loop allowed
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
                                            //loop for withdraw validation
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
                                                        goodWithdraw = true; // Exit of inner-loop allowed
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
                                            innerExit = true; // Exit of loop allowed
                                            break;
                                        default:
                                            WrongMenuChoice();
                                            break;
                                    }
                                    //End of switch statement for Checking Menu
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
                                    string balance = gsa.Month_current_balance.ToNAMoneyFormat(true);
                                    Console.WriteLine("Current Balance: " + balance);
                                    letterChoice = Console.ReadLine();

                                    //Start of switch statement for Global Savings menu
                                    switch (letterChoice.Trim().ToLower())
                                    {
                                        case "a":
                                        case "deposit":
                                            //loop for deposit validation
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
                                            //loop for withdraw validation
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
                                            Console.WriteLine("Total balance: " + gsa.USValue(0.76).ToNAMoneyFormat(true) + " USD");
                                            break;
                                        case "r":
                                            innerExit = true;
                                            break;
                                        default:
                                            WrongMenuChoice();
                                            break;
                                    }
                                    //End of switch statement for Global Savings menu
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
                    //End of main switch statement
                }
                catch (WrongMenuChoiceException e)
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
