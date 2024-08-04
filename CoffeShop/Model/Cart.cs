using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Model
{
    internal class Cart
    {
        public static List<MenuItem> Items { get; private set; } = new List<MenuItem>();

        public static void AddItem(MenuItem item)
        {
            Items.Add(item);
        }

        public static void Clear()
        {
            Items.Clear();
        }
    }
}
