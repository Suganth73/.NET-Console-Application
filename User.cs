using System;
using System.Collections.Generic;
using InvestmentPlatform.Investments;

namespace InvestmentPlatform.User
{
    static class UserPanel
    {
        private static double balance;
        private static List<string> portfolio = new List<string>();

        public static void Login()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = InvestmentPlatform.Admin.AdminPanel.ReadPassword();

            // Validate user from the database
           // bool isValidUser = InvestmentPlatform.Database.Dbconnection.ValidateUser(username, password);
            bool isValidUser = true;

            if (isValidUser)
            {
                Console.WriteLine("User login successful. Please Deposit amount to buy stocks:");
                double depositAmount = 0;
                while (true)
                {
                    string input = Console.ReadLine();

                    if (!string.IsNullOrEmpty(input) && double.TryParse(input, out depositAmount) && depositAmount > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a valid number greater than 0:");
                    }
                }
                balance = depositAmount;
                UserFunctions();
            }
            else
            {
                Console.WriteLine("Invalid credentials. Press Enter to try again.");
                Console.ReadLine();
            }
        }


        private static void UserFunctions()
        {
            while (true)
            {
                Console.WriteLine("\n=== User Panel ===");
                Console.WriteLine("1. View Portfolio");
                Console.WriteLine("2. Buy Investment");
                Console.WriteLine("3. Sell Investment");
                Console.WriteLine("4. Deposit Money");
                Console.WriteLine("5. Withdraw Money");
                Console.WriteLine("6. Check Balance");
                Console.WriteLine("7. Return to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewPortfolio();
                        break;
                    case "2":
                        BuyInvestment();
                        break;
                    case "3":
                        SellInvestment();
                        break;
                    case "4":
                        DepositMoney();
                        break;
                    case "5":
                        WithdrawMoney();
                        break;
                    case "6":
                        CheckBalance();
                        break;
                    case "7":
                        InvestmentPlatform.Home.HomePage.Display(false);
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void ViewPortfolio()
        {
            Console.WriteLine("\n=== Your Portfolio ===");
            if (portfolio.Count == 0)
            {
                Console.WriteLine("Your portfolio is empty.");
            }
            else
            {
                foreach (var item in portfolio)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("\nPress Enter to return to User Panel...");
            Console.ReadLine();
        }

        private static void BuyInvestment()
        {
            var investments = new List<Investment>
            {
                new Stock { Name = "Tata Steel", Price = 200.75, TickerSymbol = "TATASTEEL" },
                new Stock { Name = "IRFC", Price = 100.50, TickerSymbol = "IRFC" },
                new MutualFund { Name = "Index Fund", Price = 50.25, FundManager = "ABC Fund Managers" },
                new MutualFund { Name = "Large Cap Fund", Price = 75.00, FundManager = "XYZ Fund Managers" }
            };

            
            Console.WriteLine("\n=== Available Investments ===");
            int IndexNumber = 1;
            foreach (var investment in investments)
            {
                Console.WriteLine($"{IndexNumber}. {investment.Name} - ${investment.Price}");
                investment.DisplayInfo(); 
                IndexNumber++;
            }

            Console.Write("\nEnter the number of the investment you want to buy: ");
            int investmentChoice = Convert.ToInt32(Console.ReadLine());

        
            if (investmentChoice < 1 || investmentChoice > investments.Count)
            {
                Console.WriteLine("Invalid investment choice. Press Enter to return to User Panel...");
                Console.ReadLine();
                return;
            }

           
            Investment selectedInvestment = investments[investmentChoice - 1];
            Console.WriteLine($"\nYou selected {selectedInvestment.Name} at ${selectedInvestment.Price} per unit.");

            Console.Write("Enter quantity to buy: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            double cost = selectedInvestment.Price * quantity;

            if (cost <= balance)
            {
                portfolio.Add($"{quantity} of {selectedInvestment.Name} at ${selectedInvestment.Price} each");
                balance -= cost;
                Console.WriteLine($"You have successfully bought {quantity} of {selectedInvestment.Name}.");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }

            Console.WriteLine("\nPress Enter to return to User Panel...");
            Console.ReadLine();
        }

        private static void SellInvestment()
        {
            
            Console.WriteLine("\n=== Your Portfolio ===");
            if (portfolio.Count == 0)
            {
                Console.WriteLine("Your portfolio is empty.");
                Console.WriteLine("\nPress Enter to return to User Panel...");
                Console.ReadLine();
                return;
            }

            
            int index = 1;
            List<string> portfolioCopy = new List<string>(portfolio); 
            foreach (var item in portfolioCopy)
            {
                Console.WriteLine($"{index}. {item}");
                index++;
            }

            
            Console.Write("\nEnter the number of the investment you want to sell: ");
            int selectedIndex = Convert.ToInt32(Console.ReadLine());

           
            if (selectedIndex < 1 || selectedIndex > portfolio.Count)
            {
                Console.WriteLine("Invalid selection. You must choose a valid investment number.");
                Console.WriteLine("\nPress Enter to return to User Panel...");
                Console.ReadLine();
                return;
            }

            
            string investmentToSell = portfolio[selectedIndex - 1];
          
            string[] investmentParts = investmentToSell.Split(' ');
            int quantityOwned = int.Parse(investmentParts[0]);
            double pricePerUnit = Convert.ToDouble(investmentParts[investmentParts.Length - 2].TrimStart('$')); 

            
            Console.Write("\nEnter quantity to sell: ");
            int quantityToSell = Convert.ToInt32(Console.ReadLine());

           
            if (quantityToSell > quantityOwned)
            {
                Console.WriteLine("You don't have enough quantity to sell.");
                Console.WriteLine("\nPress Enter to return to User Panel...");
                Console.ReadLine();
                return;
            }

           
            if (quantityToSell == quantityOwned)
            {
                
                portfolio.RemoveAt(selectedIndex - 1);
                Console.WriteLine($"Successfully sold");
            }
            else
            {
               
                portfolio[selectedIndex - 1] = $"{quantityOwned - quantityToSell} of {investmentParts[1]} at ${pricePerUnit}";
                Console.WriteLine($"Successfully sold");
            }

            
            balance += quantityToSell * pricePerUnit;

            
            Console.WriteLine("\n=== Updated Portfolio ===");
            foreach (var item in portfolio)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nPress Enter to return to User Panel...");
            Console.ReadLine();
        }





        private static void DepositMoney()
        {
            Console.Write("\nEnter deposit amount: ");
            double amount =  Convert.ToDouble(Console.ReadLine());;
            balance += amount;
            Console.WriteLine($"Successfully deposited ${amount}. New balance: ${balance}");
            Console.WriteLine("\nPress Enter to return to User Panel...");
            Console.ReadLine();
        }

        private static void WithdrawMoney()
        {
            Console.Write("\nEnter withdrawal amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Successfully withdrew ${amount}. New balance: ${balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
            Console.WriteLine("\nPress Enter to return to User Panel...");
            Console.ReadLine();
        }

        private static void CheckBalance()
        {
            Console.WriteLine($"\nCurrent Balance: ${balance}");
            Console.WriteLine("\nPress Enter to return to User Panel...");
            Console.ReadLine();
        }
    }
}