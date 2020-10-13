using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    class CheckingAccount : Account, IAccount
    {
        public CheckingAccount(double balance, double interest_rate) : base(balance, interest_rate)
        {
        }
        public override void MakeWithdraw(double amount)
        {
            if(Month_current_balance - amount < 0)
            {
                month_service_charge += 15;
                Console.WriteLine("The withdrawal exceeded the current available balance");
                Console.WriteLine("A $15 monthly charge fee was added to your account");
            }
            else
            {
                base.MakeWithdraw(amount);
                Console.WriteLine("Successfully withdrawed " + string.Format("{0:C}", amount));

            }
        }
        public override void MakeDeposit(double amount)
        {
            base.MakeDeposit(amount);
        }
        public override string CloseAndReport()
        {

            month_service_charge += 5 + (0.10 * month_withdraws_count);
            return base.CloseAndReport();
        }
    }
}
