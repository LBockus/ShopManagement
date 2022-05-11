using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.ConsoleApp.Services
{
    public class ApplicationService
    {
        private ShopService _shopService;
        public ApplicationService()
        {
            _shopService = new ShopService();
        }
            
        public void Process(string command)
        {
            if (command.StartsWith("Add"))
            {
                string[] splitCommand = command.Split(" ");
                List<ShopItem> items = _shopService.GetAll();
                foreach (ShopItem item in items)
                {
                    if(item.Name == splitCommand[1]) // checking if the names duplicate
                    {
                        Console.WriteLine("Item already exists, to change its quantity use command Set");
                        return;
                    }
                }
                if (splitCommand.Length == 3) // checking if the format is correct
                {
                    _shopService.Add(splitCommand[1], splitCommand[2]);
                }
                else if (splitCommand.Length == 2)
                {
                    _shopService.Add(splitCommand[1], "Not specified");
                }
                else
                {
                    Console.WriteLine("Incorrect command format, to see all commands write Help");
                }
            }
            else if (command.StartsWith("Remove"))
            {
                string[] splitCommand = command.Split(" ");
                _shopService.Remove(splitCommand[1]); // removing specified item
            }
            else if (command.StartsWith("List"))
            {
                List<ShopItem> items = _shopService.GetAll();
                
                foreach (ShopItem item in items) // listing items
                    {
                        Console.WriteLine($"Item name: {item.Name} Item quantity: {item.Quantity}");
                    }
            }
            else if (command.StartsWith("Set"))
                {
                    string[] splitCommand = command.Split(" ");
                    List<ShopItem> items = _shopService.GetAll();

                foreach (ShopItem item in items) // searching for specified item
                    {
                        if(item.Name == splitCommand[1])
                        {
                            item.Quantity = splitCommand[2]; // changing items quantity
                        }
                    }
                }
            else if (command.StartsWith("Help"))
            {
                Console.WriteLine("Add - allows you to add an item with a format of: Add ItemName ItemQuantity");
                Console.WriteLine("Set - allows you to modify items quantity with a format of: Set ItemName ItemQuantity");
                Console.WriteLine("Remove - allows you to remove an item with a format of: Remove ItemName ");
                Console.WriteLine("List - allows you to see all items in the register.");
                Console.WriteLine("Exit - allows you to exit the program.");
            }
            else if (command.StartsWith("Exit"))
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Incorrect command, to see all commands write Help");
            }
        }
    }
}
