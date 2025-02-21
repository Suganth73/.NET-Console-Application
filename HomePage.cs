using System;


namespace InvestmentPlatform.Home
{
    static class HomePage
    {
        public static void Display(bool showStocks)
        {
            while (true)
            {
                if (showStocks)
                {
                    Console.WriteLine("=== Welcome to Investment Platform ===");
                    Console.WriteLine("Sample Stocks:");
                    Console.WriteLine("1. IRFC - 100.50");
                    Console.WriteLine("2. TATA STEEL - 200.75");
                    Console.WriteLine("3. SWIGGY - 50.25");
                    Console.WriteLine("\nTo Buy and Sell Stocks Please Enter......");
                    showStocks = false;
                    Console.ReadLine();
                }

                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Register (New User)");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        InvestmentPlatform.Admin.AdminPanel.Login();
                        break;
                    case "2":
                        InvestmentPlatform.User.UserPanel.Login();
                        break;
                    case "3":
                        InvestmentPlatform.Registration.UserRegistration.Register();
                        break;
                    case "4":
                        Console.WriteLine("Thanks For using the Platform!!!!!!!");
                        Console.WriteLine("-----------Visit Again-----------");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
