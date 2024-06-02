using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CheckingAccount : Account
    {
        public int OverdraftLimit { get; private set; }

        public CheckingAccount(int accountNumber, int password, int overdraftLimit)
            : base(accountNumber, password)
        {
            OverdraftLimit = overdraftLimit;
        }


        public override string Withdraw(int amount)
        {
            if (amount <= Balance + OverdraftLimit)
            {
                base.Withdraw(amount);
                return $"You have withdrawn ${amount}. Your new balance is ${Balance}";
            }
            else
            {
                return null;
            }
        }

        public override string Deposit(int amount)
        {
            base.Deposit(amount);
            return $"You have deposited ${amount}. Your new balance is ${Balance}";
        }
    }
}
