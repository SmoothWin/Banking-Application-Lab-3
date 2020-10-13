using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    class SavingsAccount : Account, IAccount
    {
        Status stat;
         public SavingsAccount(double balance,double interest_rate) : base(balance,interest_rate)
        {
            if(balance < 25)
            {
                stat = Status.inactive;
            }
            else
            {
                stat = Status.active;
            }
        }
        public override string CloseAndReport()
        {
            if (month_withdraws_count > 4)
            {
                month_service_charge += (month_withdraws_count - 4) * 1;
                return base.CloseAndReport();
            }
            else
            {
                return base.CloseAndReport();
            }
        }

        public override void MakeDeposit(double amount)
        {
            if(stat == Status.inactive && Month_current_balance + amount > 25)
            {
                base.MakeDeposit(amount);
                stat = Status.active;
            }
            else
            {
                base.MakeDeposit(amount);
            }
        }

        public override void MakeWithdraw(double amount)
        {
            if (stat == Status.inactive)
            {
                Console.WriteLine("The account is inactive");
                Console.WriteLine("In order to be able to withdraw, the account balance must be over $25");
            }
            else
            {
                 if (Month_current_balance - amount > 25)
                {
                    base.MakeWithdraw(amount);
                    Console.WriteLine("Successfully withdrawed " + string.Format("{0:C}", amount));

                }
                else
                {
                    base.MakeWithdraw(amount);
                    Console.WriteLine("Successfully withdrawed " + string.Format("{0:C}", amount));
                    stat = Status.inactive;
                }
            }
        }
    }
}
