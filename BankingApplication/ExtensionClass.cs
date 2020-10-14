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
            double theMoney = n*100;
            if (tf == true)
            {
                if (theMoney < 0)
                {
                    theMoney *= -1; 
                    string str = string.Format("({0:C})", (Decimal.Ceiling((decimal) theMoney))/100); //Rounds the number accordingly
                    return str;
                }
                else
                {
                    string str = string.Format("{0:C}", (Decimal.Ceiling((decimal)theMoney)) / 100); //Rounds the number accordingly
                    return str;
                }
            }
            else
            {
                if (theMoney < 0)
                {
                    theMoney *= -1; 
                    string str = string.Format("({0:C})", (Decimal.Floor((decimal)theMoney)) / 100); //Rounds the number downwards
                    return str;
                }
                else
                { 
                    string str = string.Format("{0:C}", (Decimal.Floor((decimal)theMoney)) / 100); //Rounds the number downwards
                    return str;
                }
            }
        }
        public static double ToNAMoneyFormatD (this double n, Boolean tf) //Added this extension method in order to be able to round nicely all the numbers going in the system so there isn't any discrepancies
        {
            double theMoney = n * 100;
            if (tf == true)
            {
                if (theMoney < 0)
                {
                    theMoney *= -1;
                    decimal d = (Decimal.Ceiling((decimal)theMoney)) / 100; //Rounds the number accordingly
                    return ((double) d);
                }
                else
                {
                    decimal d =  (Decimal.Ceiling((decimal)theMoney)) / 100; //Rounds the number accordingly
                    return ((double) d);
                }
            }
            else
            {
                if (theMoney < 0)
                {
                    theMoney *= -1;
                    decimal d = (Decimal.Floor((decimal)theMoney)) / 100; //Rounds the number downwards
                    return ((double) d);
                }
                else
                {
                    decimal d = (Decimal.Floor((decimal)theMoney)) / 100; //Rounds the number downwards
                    return ((double) d);
                }
            }
        }
    }
}
