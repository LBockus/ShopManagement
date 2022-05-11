using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.ConsoleApp.Services
{
    public class ShopService
    {
        private List<ShopItem> _items;

        public ShopService()
        {
            _items = new List<ShopItem>();
        }
           
        public void Add(string name, string quantity)
        {
            var item = new ShopItem
            {
                Name = name,
                Quantity = quantity
            };
            
            _items.Add(item); // adding items to class
        }

        public void Remove(string name)
        {
            _items = _items.Where(i => i.Name != name).ToList(); // removing items from class
        }

        public List<ShopItem> GetAll()
        {
            return _items; // providing full item list
        }

        public void Set(string name, string quantity)
        {
            foreach (ShopItem item in _items) // searching for specified item
            {
                if (item.Name == name)
                {
                    item.Quantity = quantity; // changing items quantity
                }
            }
        }
    }
}
