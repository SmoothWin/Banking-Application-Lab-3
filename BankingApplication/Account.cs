﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    abstract class Account : IAccount
    {
        private double month_start_balance;
        private double month_current_balance;

        protected double month_total_deposits;
        protected int month_deposit_count;

        protected double month_total_withdraws;
        protected int month_withdraws_count;

        protected double annual_interest_rate;
        protected double month_service_charge;
        public double Month_start_balance
        { 
            get
            {
                return month_start_balance;
            }    
        }
        public double Month_current_balance { 
            get 
            {
                return month_current_balance;
            }
        }
        public enum Status
        {
            active = 1,
            inactive = 0
        }
        public Account(double balance,double interest_rate)
        {
            month_start_balance = balance;
            month_current_balance = balance;
            annual_interest_rate = interest_rate;

        }

        public void CalculateInterest()
        {
            double month_interest_rate = (annual_interest_rate / 12);
            double month_interest = month_current_balance * month_interest_rate;
            month_current_balance += month_interest;

        }

        public double PercentChange ()
        {
            double percentDifference = Math.Round(((Month_current_balance - Month_start_balance) / month_start_balance), 2);
            return percentDifference;
        }

        public virtual string CloseAndReport()
        {
            month_current_balance -= month_service_charge;
            CalculateInterest();

            double month_interest_rate = (annual_interest_rate / 12);
            string formattedMIR = string.Format("{0:0.00}%", month_interest_rate*100);
            double month_interest = Month_current_balance * month_interest_rate;
            string formattedMI = month_interest.ToNAMoneyFormat(true);

            string balance = "Previous balance: " + Month_start_balance.ToNAMoneyFormat(true) +
                "\nNew balance: " + Month_current_balance.ToNAMoneyFormat(true);

            string percent = "% difference between Previous and Present balance: " + PercentChange();

            string interestPay = "Month's interest rate (" + formattedMIR + ") paid: " + formattedMI;

            string monthservicecharge = "The monthly service charge paid: " + month_service_charge.ToNAMoneyFormat(true);

            string str = string.Format("{0}\n{1}\n{2}\n{3}\n",balance,percent,interestPay,monthservicecharge);

            month_withdraws_count = 0;
            month_deposit_count = 0;

            month_total_withdraws = 0;
            month_total_deposits = 0;

            month_service_charge = 0;

            return str;


        }

        public virtual void MakeDeposit(double amount)
        {
            month_current_balance += amount;
            month_total_deposits += amount;
            month_deposit_count++;
        }

        public virtual void MakeWithdraw(double amount)
        {
            month_current_balance -= amount;
            month_total_withdraws += amount;
            month_withdraws_count++;
        }
    }
}
