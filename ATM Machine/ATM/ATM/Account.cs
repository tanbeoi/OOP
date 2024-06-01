using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Account
    {
        int _accountNumber;
        int _password;
        int _balance = 0;

        public Account(int accountNumber, int password)
        {
            _accountNumber = accountNumber;
            _password = password;
        }

        public int AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        public int Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public void Deposit(int amount)
        {
            _balance += amount;
        }

        public void Withdraw(int amount)
        {
            _balance -= amount;
        }

        public void Transfer(int amount, Account destinationAccount)
        {
            _balance -= amount;
            destinationAccount.Deposit(amount);
        }

        public Account? AreYou(int InputAccountNum, int InputPassword)
        {
            if (InputAccountNum == _accountNumber && InputPassword == _password)
            {
                return this;
            }
            else
            {
                return null;
            }
        }


    }
}
