using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Set up banks and accounts
            Bank cba = new Bank(new List<string> {"CBA"}, "Commonwealth");
            Account account1 = new Account(123456, 1234);
            cba.AddAccount(account1);
            Bank westpac = new Bank(new List<string> {"WBC"}, "Westpac");
            Account account2 = new Account(654321, 4321);
            westpac.AddAccount(account2);
            Bank nab = new Bank(new List<string> { "NAB" }, "National Australia Bank");
            Bank anz = new Bank(new List<string> { "ANZ" }, "Australia and New Zealand Banking Group");
            List<Bank> banksDatabase = new List<Bank> { cba, westpac, nab, anz };

            // Set the console title and text color
            Console.Title = "My ATM Application";
            Console.ForegroundColor = ConsoleColor.White;

            // Display the welcome message
            Utility.PrintColoredMessage("\n\n-----------------------------------Welcome to the ATM-----------------------------------\n", ConsoleColor.Green);

            Utility.PressEnterToContinue();

            //Sign in or create an account to sign in
            BankSelector bankSelector = new BankSelector(banksDatabase);
            Bank? selectedBank = bankSelector.SelectBank();

            while (selectedBank == null)
            {
                Utility.PrintColoredMessage("Please select a valid bank by either abbreviated name or number", ConsoleColor.Red);
                selectedBank = bankSelector.SelectBank();
            }
            
            Validator validator = new Validator();
            Account signedInAccount = validator.SignInOptions(selectedBank);

            //Make sure the user is signed in first before proceeding
            while (signedInAccount == null)
            {   
                Console.Clear();
                selectedBank = bankSelector.SelectBank();
                signedInAccount = validator.SignInOptions(selectedBank);
            } 

            Utility.PressEnterToContinue();

            //Display account options
            AccountOptions accountOptions = new AccountOptions();
            bool isSignedOut = accountOptions.AccountOptionsMenu(signedInAccount, banksDatabase);
            
            //For the sign out option
            while (isSignedOut)
            {
                Console.Clear();
               signedInAccount = validator.SignInOptions(selectedBank);
               while (signedInAccount == null)
                {
                   selectedBank = bankSelector.SelectBank();
                   signedInAccount = validator.SignInOptions(selectedBank);
               }
               isSignedOut = accountOptions.AccountOptionsMenu(signedInAccount, banksDatabase);
            }

            
            
            
        }
    }
}
