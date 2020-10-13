using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    public static class ExtensionClass
    {
        public static string ToNAMoneyFormat(this double n, Boolean tf)
        {
            double theMoney = n;
            if (tf == true)
            {
                if (theMoney < 0)
                {
                    theMoney *= -1; 
                    string str = string.Format("({0:C})", Decimal.Ceiling((decimal) theMoney)); //Rounds the number accordingly
                    return str;
                }
                else
                {
                    string str = string.Format("{0:C}", Decimal.Ceiling((decimal)theMoney)); //Rounds the number accordingly
                    return str;
                }
            }
            else
            {
                if (theMoney < 0)
                {
                    theMoney *= -1; //Rounds the number downwards
                    string str = string.Format("({0:C})", Decimal.Floor((decimal)theMoney));
                    return str;
                }
                else
                { 
                    string str = string.Format("{0:C}", Decimal.Floor((decimal)theMoney)); //Rounds the number downwards
                    return str;
                }
            }
        }
    }
}
