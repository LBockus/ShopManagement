using System;
using ShopManagement.ConsoleApp.Services;

namespace ShopManagement.ConsoleApp
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var applicationService = new ApplicationService();
            bool exit = true;
            while(exit)
            {
                Console.WriteLine("Enter your command:");
                string command = Console.ReadLine(); // user command input
                applicationService.Process(command); // processing the input
                exit = ApplicationService.ApplicationExit(command, exit); // checking if the user wants to exit
            }
        }
    }
}
