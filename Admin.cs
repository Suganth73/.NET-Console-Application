using System;
using System.Text;
using InvestmentPlatform.Investments;


namespace InvestmentPlatform.Admin
{
    static class AdminPanel
    {
        public static void Login()
        {
            Console.Write("Enter Admin Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Admin Password: ");
            string password = ReadPassword();

            if (username == "admin" && password == "admin123")
            {
                AdminFunctions();
            }
            else
            {
                Console.WriteLine("Invalid credentials. Press Enter to return.");
                Console.ReadLine();
                InvestmentPlatform.Home.HomePage.Display(false);
            }
        }

        private static void AdminFunctions()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Admin Panel ===");
                Console.WriteLine("1. Add Investment");
                Console.WriteLine("2. Delete Investment");
                Console.WriteLine("3. Update Investment Price");
                Console.WriteLine("4. Return to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddInvestment();
                        break;
                    case "4":
                        // Returning to Main Menu, hide stocks
                        InvestmentPlatform.Home.HomePage.Display(false);
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue...");
                        break;
                }
                Console.ReadLine();
            }
        }

        private static void AddInvestment()
        {
            Console.WriteLine("Choose Investment Type:");
            Console.WriteLine("1. Stock");
            Console.WriteLine("2. Mutual Fund");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Add Stock
                Console.Write("Enter stock name: ");
                string name = Console.ReadLine();
                Console.Write("Enter stock price: ");
                double price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter stock ticker symbol: ");
                string ticker = Console.ReadLine();
                
                // Add investment to the database
               // bool isAdded = InvestmentPlatform.Database.Dbconnection.AddInvestment(name, price, ticker, true);
                bool isAdded = true;
                if (isAdded)
                {
                    Console.WriteLine($"Successfully added {name} at price ${price}.");
                }
                else
                {
                    Console.WriteLine("Failed to add investment.");
                }
            }
            else if (choice == "2")
            {
                // Add Mutual Fund
                Console.Write("Enter mutual fund name: ");
                string name = Console.ReadLine();
                Console.Write("Enter mutual fund price: ");
                double price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter fund manager name: ");
                string manager = Console.ReadLine();
                
                // Add investment to the database
                bool isAdded = true;
                //InvestmentPlatform.Database.Dbconnection.AddInvestment(name, price, manager, false);
                if (isAdded)
                {
                    Console.WriteLine($"Successfully added {name} at price ${price}.");
                }
                else
                {
                    Console.WriteLine("Failed to add investment.");
                }
            }
        }



        public static string ReadPassword()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true); 
                if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Length--; // Removes the last character from StringBuilder
                    Console.Write("\b \b"); // Backspace visual feedback
                }
                else if (keyInfo.Key != ConsoleKey.Enter)
                {
                    password.Append(keyInfo.KeyChar); // Append the actual character typed
                    Console.Write("*"); // Display * for each character typed
                }
            } while (keyInfo.Key != ConsoleKey.Enter); // Stop when Enter is pressed
            Console.WriteLine(); // Move to the next line after password input is complete
            return password.ToString(); // Return the password as a string
        }

    }
}
