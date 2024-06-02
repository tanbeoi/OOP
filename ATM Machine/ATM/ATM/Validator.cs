﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Validator
    {
        
        public Validator()
        {
        }

        public Account? SignInOptions(Bank bank)
        {
           
            Console.WriteLine("Please select an option: \n1. Sign in \n2. Create a normal account\n3. Create a saving account\n4. Create a checking account\n5. Back");
            int InputOption = Convert.ToInt32(Console.ReadLine().Trim());

            if (InputOption == 5)
            {
                return null;
            }

            switch (InputOption)
            {
                case 1:
                    
                    Console.WriteLine("Please enter your account number (6 digits): ");
                    int InputAccountNum = Convert.ToInt32(Console.ReadLine().Trim());
                    int InputPassword = Convert.ToInt32(Utility.GetSecretInput("Please enter your password (4 digits): "));

                    if (InputAccountNum.ToString().Length != 6 || InputPassword.ToString().Length != 4)
                    {
                    
                        Utility.PrintColoredMessage("Invalid account number or password. Please try again.", ConsoleColor.Red);
                        return SignInOptions(bank);
                    }
                    else if (bank.GetAccount(InputAccountNum, InputPassword) == null)
                    {
                   
                        Utility.PrintColoredMessage("Account not found. Please try again.", ConsoleColor.Red);
                        return SignInOptions(bank);
                    }
                    else
                    {
                        Console.Clear();
                        Utility.PrintColoredMessage("You have logged in successfully. Welcome back " + (bank.GetAccount(InputAccountNum, InputPassword).AccountNumber), ConsoleColor.Green);
                        return bank.GetAccount(InputAccountNum, InputPassword);
                    }

                    break;

                case 2:
                    int NewAccountNum;
                    Console.WriteLine("\nPlease enter your new account number (6 digits): ");
                    string accountNumInput = Console.ReadLine();
                    if (!int.TryParse(accountNumInput, out NewAccountNum) || accountNumInput.Length != 6)
                    {
                        Utility.PrintColoredMessage("Invalid account number format. Please enter a 6-digit number.", ConsoleColor.Red);
                        return SignInOptions(bank);
                    }

                    int NewPassword;
                    string passwordInput = Utility.GetSecretInput("Please enter your preferred password (4 digits): ");
                    if (!int.TryParse(passwordInput, out NewPassword) || passwordInput.Length != 4)
                    {
                        Utility.PrintColoredMessage("Invalid password format. Please enter a 4-digit number.", ConsoleColor.Red);
                        return SignInOptions(bank);
                    }

                    Account newAccount = new Account(NewAccountNum, NewPassword);
                    bank.AddAccount(newAccount);
                        
                    Console.Clear();
                    Utility.PrintColoredMessage("Account created successfully!", ConsoleColor.Green);
                    return SignInOptions(bank);

                    
                    break;


                case 3:
                    int NewAccountNum2;
                    Console.WriteLine("\nPlease enter your new account number (6 digits): ");
                    string accountNumInput2 = Console.ReadLine();
                    if (!int.TryParse(accountNumInput2, out NewAccountNum2) || accountNumInput2.Length != 6)
                    {
                        Utility.PrintColoredMessage("Invalid account number format. Please enter a 6-digit number.", ConsoleColor.Red);
                        return SignInOptions(bank);
                    }

                    int NewPassword2;
                    string passwordInput2 = Utility.GetSecretInput("Please enter your preferred password (4 digits): ");
                    if (!int.TryParse(passwordInput2, out NewPassword2) || passwordInput2.Length != 4)
                    {
                        Utility.PrintColoredMessage("Invalid password format. Please enter a 4-digit number.", ConsoleColor.Red);
                        return SignInOptions(bank);
                    }

                    int InputInterestRate;
                    Console.WriteLine("Please select your desired interest rate: \n1. 3%\n2. 5%");
                    string interestRateInput = Console.ReadLine().Trim();
                    if (!int.TryParse(interestRateInput, out InputInterestRate) || (InputInterestRate != 1 && InputInterestRate != 2))
                    {
                        Utility.PrintColoredMessage("Invalid interest rate choice. Please enter either 1 or 2.", ConsoleColor.Red);
                        return SignInOptions(bank);
                    }

                    if (InputInterestRate == 1)
                    {
                        SavingsAccount Account = new SavingsAccount(NewAccountNum2, NewPassword2, 3);
                        bank.AddAccount(Account);
                    }
                    else
                    {
                        SavingsAccount Account = new SavingsAccount(NewAccountNum2, NewPassword2, 5);
                        bank.AddAccount(Account);
                    }
                        
                    Utility.PrintColoredMessage("Account created successfully!", ConsoleColor.Green);
                    return SignInOptions(bank);

                    
                    break;

                case 4:
                    int NewAccountNum3;
                    Console.WriteLine("\nPlease enter your new account number (6 digits): ");
                    string accountNumInput3 = Console.ReadLine();
                    if (!int.TryParse(accountNumInput3, out NewAccountNum3) || accountNumInput3.Length != 6)
                    {
                        Utility.PrintColoredMessage("Invalid account number format. Please enter a 6-digit number.", ConsoleColor.Red);
                        return SignInOptions(bank);
                    }

                    int NewPassword3;
                    string passwordInput3 = Utility.GetSecretInput("Please enter your preferred password (4 digits): ");
                    if (!int.TryParse(passwordInput3, out NewPassword3) || passwordInput3.Length != 4)
                    {
                        Utility.PrintColoredMessage("Invalid password format. Please enter a 4-digit number.", ConsoleColor.Red);
                        return SignInOptions(bank);
                    }

                    int InputOverdraftLimit;
                    Console.WriteLine("Please select your desired overdraft limit: \n1. $100\n2. $200");
                    string overdraftLimitInput = Console.ReadLine().Trim();
                    if (!int.TryParse(overdraftLimitInput, out InputOverdraftLimit) || (InputOverdraftLimit != 1 && InputOverdraftLimit != 2))
                    {
                        Utility.PrintColoredMessage("Invalid overdraft limit choice. Please enter either 1 or 2.", ConsoleColor.Red);
                        return SignInOptions(bank);
                    }

                    CheckingAccount accountToCreate;
                    if (InputOverdraftLimit == 1)
                    {
                        accountToCreate = new CheckingAccount(NewAccountNum3, NewPassword3, 100);
                    }
                    else
                    {
                        accountToCreate = new CheckingAccount(NewAccountNum3, NewPassword3, 200);
                    }
                    bank.AddAccount(accountToCreate);
                    Utility.PrintColoredMessage("Account created successfully!", ConsoleColor.Green);
                    return SignInOptions(bank);
                    break;
                default:
                 
                    Utility.PrintColoredMessage("Invalid option. Please try again.", ConsoleColor.Red);
                    return SignInOptions(bank);
            }
        }
    }
}
