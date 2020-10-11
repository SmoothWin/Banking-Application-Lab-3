using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    class CheckingAccount : Account
    {
        public CheckingAccount(double balance, double interest_rate) : base(balance, interest_rate)
        {
        }
        public override void MakeWithdraw(double amount)
        {
            if(Month_current_balance - amount < 0)
            {
                month_service_charge += 15;
            }
            else
            {
                base.MakeWithdraw(amount);
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
