using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Model
{
    internal class MenuItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public Image Image { get; set ; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public MenuItem(string name, string category, Image image, decimal price)
        {
            
            Name = name;
            Category = category;
            Image = image;
            Price = price;
            Quantity = 0;
            
        }
        
    }
}
