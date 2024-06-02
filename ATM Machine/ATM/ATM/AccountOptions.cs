using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class AccountOptions
    {
        public AccountOptions()
        {
        }

        public bool AccountOptionsMenu(Account account, List<Bank> banksDatabase)
        {   
            bool isSignedOut = false;
      
            Console.WriteLine("\nPlease select an option: \n1. Deposit \n2. Withdraw \n3. Transfer \n4. Check balance \n5. Sign out\n");
            int InputOption = Convert.ToInt32(Console.ReadLine().Trim());

            switch (InputOption)
            {
                case 1:

                    Console.WriteLine("Please enter the amount you would like to deposit: ");

                    int DepositAmount;
                    while (true)
                    {
                        string input = Console.ReadLine().Trim();
                        if (int.TryParse(input, out DepositAmount) && DepositAmount > 0)
                        {
                            break;
                        }
                        else
                        {
                        
                            Utility.PrintColoredMessage("Invalid input. Please enter a valid positive number.", ConsoleColor.Red);
                            input = Console.ReadLine().Trim();
                        }
                    }

                    
                    Console.Clear();
                    Console.WriteLine(account.Deposit(DepositAmount));
                    AccountOptionsMenu(account, banksDatabase);
                    return isSignedOut;

                case 2:
                  
                    Console.WriteLine("Please enter the amount you would like to withdraw: ");

                    int WithdrawAmount;
                    while (true)
                    {
                        string input = Console.ReadLine().Trim();
                        if (int.TryParse(input, out WithdrawAmount) && WithdrawAmount > 0)
                        {
                            break;
                        }
                        else
                        {
                            
                            Utility.PrintColoredMessage("Invalid input. Please enter a valid positive number.", ConsoleColor.Red);
                            input = Console.ReadLine().Trim();
                        }
                    }

                    if (account.Withdraw(WithdrawAmount) == null)
                    {
                        Utility.PrintColoredMessage("Insufficient funds. Please try again.", ConsoleColor.Red);
                        AccountOptionsMenu(account, banksDatabase);
                        return isSignedOut;
                    }
                    else
                    {
                        Console.Clear();    
                        Console.WriteLine(account.Withdraw(WithdrawAmount));
                        AccountOptionsMenu(account, banksDatabase);
                        return isSignedOut;
                    }
                    
                case 3:
           
                    Console.WriteLine("Please enter the amount you would like to transfer: ");

                    int TransferAmount;
                    while (true)
                    {
                        string input = Console.ReadLine().Trim();
                        if (int.TryParse(input, out TransferAmount) && TransferAmount > 0)
                        {
                            break;
                        }
                        else
                        {
                           
                            Utility.PrintColoredMessage("Invalid input. Please enter a valid positive number.", ConsoleColor.Red);
                            input = Console.ReadLine().Trim();
                        }
                    }

                    BankSelector bankSelector = new BankSelector(banksDatabase);
               
                    Console.WriteLine("Please enter the bank of the account you want to transfer to:\n" + bankSelector.BankList);
                    string DestinationBank = Console.ReadLine().Trim();
                    Console.WriteLine("\nPlease enter the account number you would like to transfer to (6 digits): ");

                    int DestinationAccountNum;
                    while (true)
                    {
                        string input = Console.ReadLine().Trim();
                        if (int.TryParse(input, out DestinationAccountNum) && input.Length == 6)
                        {
                            break;
                        }
                        else
                        {
                            Utility.PrintColoredMessage("Invalid input. Please enter a valid 6-digit account number.", ConsoleColor.Red);
                        }
                    }

                    foreach (Bank bank in banksDatabase)
                    {
                        if (bank.AreYou(DestinationBank))
                        {
                            Account? destinationAccount = bank.GetTransferAccount(DestinationAccountNum);
                            if (destinationAccount == null)
                            {
                                
                                Utility.PrintColoredMessage("Account not found. Please try again.", ConsoleColor.Red);
                                AccountOptionsMenu(account, banksDatabase);
                            }
                            else if (account.Withdraw(TransferAmount) == null)
                            {
                                
                                Utility.PrintColoredMessage("Insufficient funds. Please try again.", ConsoleColor.Red);
                                AccountOptionsMenu(account, banksDatabase);
                            } 
                            else 
                            {
                                Console.Clear();
                                Console.WriteLine(account.Transfer(TransferAmount, destinationAccount));
                                AccountOptionsMenu(account, banksDatabase);
                            }
                        }
                    }
            
                    Utility.PrintColoredMessage("Bank not found. Please try again.", ConsoleColor.Red);
                    AccountOptionsMenu(account, banksDatabase);
                    return isSignedOut;
               
                case 4:
                    Console.Clear();
                    Console.WriteLine("Your current balance is $" + account.Balance);
                    AccountOptionsMenu(account, banksDatabase);
                    return isSignedOut;
           
                case 5:
                    Console.Clear();
                    Console.WriteLine("You have signed out successfully.");
                    isSignedOut = true;
                    return isSignedOut;
                default:
                 
                    Console.WriteLine("Invalid option. Please try again.");
                    AccountOptionsMenu(account, banksDatabase);
                    return isSignedOut;
            }
        }
    }
}
