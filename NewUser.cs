using System;

namespace InvestmentPlatform.Registration
{
    static class UserRegistration
    {
        public static string RegisteredUsername { get; private set; }
        public static string RegisteredPassword { get; private set; }

        public static void Register()
        {
            Console.Write("Enter Username: ");
            RegisteredUsername = Console.ReadLine();

            Console.Write("Enter Password: ");
            RegisteredPassword = InvestmentPlatform.Admin.AdminPanel.ReadPassword();

            // Register the user to the database
           // bool isRegistered = InvestmentPlatform.Database.Dbconnection.RegisterUser(RegisteredUsername, RegisteredPassword);
            
      Database.Dbconnection.RegisterUser(RegisteredUsername, RegisteredPassword);
            
            // if (isRegistered)
            // {
            //     Console.WriteLine("Registration successful. Press Enter to return to main menu...");
            // }
            // else
            // {
            //     Console.WriteLine("Registration failed. Try again.");
            // }

            // Console.ReadLine();
        }

        
    }
}
