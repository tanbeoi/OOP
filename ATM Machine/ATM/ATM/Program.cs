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
            Bank cba = new Bank(new List<string> {"Commonwealth", "CBA", "1" }, "Commonwealth");
            Account account1 = new Account(123456, 1234);
            cba.AddAccount(account1);
            Bank westpac = new Bank(new List<string> { "Westpac", "2" }, "Westpac");
            Bank nab = new Bank(new List<string> { "National Australia Bank", "NAB", "3" }, "National Australia Bank");
            Bank anz = new Bank(new List<string> { "Australia and New Zealand Banking Group", "ANZ", "4" }, "Australia and New Zealand Banking Group");
            List<Bank> banks = new List<Bank> { cba, westpac, nab, anz };

            // Set the console title and text color
            Console.Title = "My ATM Application";
            Console.ForegroundColor = ConsoleColor.White;

            // Display the welcome message
            Console.WriteLine("\n\n-----------------------Welcome to my ATM App-----------------------\n");

            //Sign in or create an account to sign in
            Bank selectedBank = SelectBank(banks);
            Account signedInAccount = SignInOptions(selectedBank);

            while (signedInAccount == null)
            {
                selectedBank = SelectBank(banks);
                signedInAccount = SignInOptions(selectedBank);
            } 


            static Bank? SelectBank(List<Bank> banks)
            {
                Console.WriteLine("\nPlease select a bank: \n1. Commonwealth (CBA)\n2. Westpac\n3. National Australia Bank (NAB)\n4. Australia and New Zealand Banking Group (ANZ)\n");
                string InputBank = Console.ReadLine().Trim();

                while (true) {
                    foreach (Bank bank in banks)
                    {
                        if (bank.AreYou(InputBank))
                        {
                            Console.WriteLine("Welcome to " + bank.Name + ".");
                            return bank;
                        }
                    }
                    Console.WriteLine("Invalid bank selection. Please try again.");
                    return SelectBank(banks);
                }
            }

            static Account? SignInOptions(Bank bank)
            {
                Console.WriteLine("Please select an option: \n1. Sign in \n2. Create an account\n3. Back\n");
                int InputOption = Convert.ToInt32(Console.ReadLine().Trim());

                if (InputOption == 3)
                {
                    return null;
                }

                switch (InputOption)
                {
                    case 1: 
                        Console.WriteLine("\nPlease enter your account number (6 digits): ");
                        int InputAccountNum = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.WriteLine("\nPlease enter your password (4 digits): ");
                        int InputPassword = Convert.ToInt32(Console.ReadLine().Trim());

                        if (InputAccountNum.ToString().Length != 6 || InputPassword.ToString().Length != 4)
                        {
                            Console.WriteLine("Invalid account number or password. Please try again.");
                            return SignInOptions(bank);
                        } 
                        else if (bank.GetAccount(InputAccountNum, InputPassword) == null)
                        {
                            Console.WriteLine("Account not found. Please try again.");
                            return SignInOptions(bank);
                        } 
                        else
                        {
                            Console.WriteLine("You have logged in successfully.");
                            return bank.GetAccount(InputAccountNum, InputPassword);
                        }
                        
                        break;
                    case 2:
                        Console.WriteLine("\nPlease enter your new account number (6 digits): ");
                        int NewAccountNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nPlease enter your prefered password (4 digits): ");
                        int NewPassword = Convert.ToInt32(Console.ReadLine());

                        if (NewAccountNum.ToString().Length != 6 || NewPassword.ToString().Length != 4)
                        {
                            Console.WriteLine("Invalid account number or password. Please try again.");
                            return SignInOptions(bank);
                        } else
                        {
                            Account newAccount = new Account(NewAccountNum, NewPassword);
                            bank.AddAccount(newAccount);
                            Console.WriteLine("Account created successfully!");
                            return SignInOptions(bank);
                            
                        }
                        break;
                    default:
                            Console.WriteLine("Invalid option. Please try again.");
                            return SignInOptions(bank);
                }
            }

            /*//Prompt the user to select the bank
            Console.WriteLine("\nPlease select a bank: \n1. Commonwealth (CBA)\n2. Westpac\n3. National Australia Bank (NAB)\n4. Australia and New Zealand Banking Group (ANZ)\n");
            string InputBank = Console.ReadLine();

            bool validBank = false;
            Bank selectedBank = null;
            
            while (!validBank)
            {
                foreach (Bank bank in banks)
                {
                    if (bank.AreYou(InputBank))
                    {
                        selectedBank = bank;
                        validBank = true;

                        Console.WriteLine("Welcome to " + selectedBank.Name + ". Please select an option: \n1. Sign in \n2. Create an account\n3.Back\n");
                        int InputOption = Convert.ToInt32(Console.ReadLine().Trim());

                        //If the user selects to go back
                        if (InputOption == 3)
                        {
                            validBank = false;
                            break;
                        }    

                        //For sign in and sign up options
                        bool validAccount = false;
                        while (!validAccount)
                        {
                            if (InputOption == 1)
                            {
                                Console.WriteLine("\nPlease enter your account number (6 digits): ");
                                int InputAccountNum = Convert.ToInt32(Console.ReadLine().Trim());
                                Console.WriteLine("\nPlease enter your password (4 digits): ");
                                int InputPassword = Convert.ToInt32(Console.ReadLine().Trim());

                                Account? account = selectedBank.GetAccount(InputAccountNum, InputPassword);

                                while (InputAccountNum.ToString().Length != 6 || InputPassword.ToString().Length != 4 || account == null)
                                {
                                    Console.WriteLine("Invalid account number or password: \n1. Retry\n2. Sign up first");
                                    int RetryOption = Convert.ToInt32(Console.ReadLine().Trim());

                                    while (InputOption != 1 && InputOption != 2)
                                    {
                                        Console.WriteLine("Invalid option. Please select a valid option: \n1. Retry\n2. Sign up first");
                                        RetryOption = Convert.ToInt32(Console.ReadLine().Trim());
                                    }

                                }



                                Console.WriteLine("You have logged in successfully.");
                                validAccount = true;
                                break;
                            }
                            else if (InputOption == 2)
                            {
                                Console.WriteLine("\nPlease enter your new account number (6 digits): ");
                                int InputAccountNum = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\nPlease enter your prefered password (4 digits): ");
                                int InputPassword = Convert.ToInt32(Console.ReadLine());

                                Account newAccount = new Account(InputAccountNum, InputPassword);
                                selectedBank.AddAccount(newAccount);
                                Console.WriteLine("Account created successfully!");

                                //Make user sign in after creating an account
                                validAccount = false;
                                InputOption = 1;
                                break;
                            }
                        }
                         
                    }
                }

                Console.WriteLine("\nPlease select a bank again: \n1. Commonwealth (CBA)\n2. Westpac\n3. National Australia Bank (NAB)\n4. Australia and New Zealand Banking Group (ANZ)\n");
                InputBank = Console.ReadLine().Trim();
                
            }*/
   

            
        }
    }
}
