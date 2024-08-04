using CoffeShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeShop.View
{
    public partial class CartForm : Form
    {
        public CartForm()
        {
            InitializeComponent();
            DisplayCartItems();
        }
        private void buttonCheckout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Checkout successful!");
            Cart.Clear();
            DisplayCartItems();
        }
        private void DisplayCartItems()
        {
            listBoxCart.Items.Clear();
            foreach (var item in Cart.Items)
            {
                listBoxCart.Items.Add($"{item.Name} - {item.Quantity} x ${item.Price} = ${item.Quantity * item.Price}");
            }
            labelTotal.Text = $"Total: ${Cart.Items.Sum(i => i.Quantity * i.Price):F2}";
        }


    }
}
