using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SavingsAccount : Account
    {
        public int InterestRate { get; private set; }

        public SavingsAccount(int accountNumber, int password, int interestRate)
            : base(accountNumber, password)
        {
            InterestRate = interestRate;
        }

        public override string Deposit(int amount)
        {
            base.Deposit(amount);
            
            Balance += Balance * (InterestRate / 100);
            return ($"Interest applied at {InterestRate}% for deposit of ${amount}. Now your balance is ${Balance}");
        }

        public override string Withdraw(int amount)
        {
            if (amount <= Balance)
            {
                base.Withdraw(amount);
                return $"You have withdrawn ${amount}. Your new balance is ${Balance}";
            }
            else
            {
                return null;
            }
        }
    }
}
