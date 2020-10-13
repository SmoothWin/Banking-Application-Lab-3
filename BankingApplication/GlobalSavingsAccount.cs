using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    class GlobalSavingsAccount : SavingsAccount, IExchangeable, IAccount
    {
        public GlobalSavingsAccount(double balance, double interest_rate) : base(balance, interest_rate)
        {
        }
        public double USValue(double rate)
        {
            return Month_current_balance * rate;
        }
    }
}
