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
    public partial class MainForm : Form
    {
        private List<MenuItem> menuItems;
        public MainForm()
        {
            InitializeComponent();
            LoadMenuItems();
            DisplayMenuItems("Drinks");
        }
        private void LoadMenuItems()
        {
            // Load menu items (example images should be replaced with actual image paths)
            menuItems = new List<MenuItem>
            {
                new MenuItem("Coffee", "Drinks", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/coffee.jpg")), 2.99m),
                new MenuItem("Tea", "Drinks", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/tea.png")), 2.49m),
                new MenuItem("Latte", "Drinks", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/latte.png")), 3.99m),
                new MenuItem("Cappuccino", "Drinks", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/cappuccino.png")), 3.99m),
                new MenuItem("Espresso", "Drinks", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/espresso.png")), 2.99m),
                new MenuItem("Sandwich", "Snacks", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/sandwich.png")), 4.99m),
                new MenuItem("Chips", "Snacks", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/chips.png")), 1.99m),
                new MenuItem("Nachos", "Snacks", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/nachos.jpeg")), 3.49m),
                new MenuItem("Fries", "Snacks", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/fries.png")), 2.99m),
                new MenuItem("Nuggets", "Snacks", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/nuggets.png")), 4.49m),
                new MenuItem("Croissant", "Bakery", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/croissant.jpeg")), 2.49m),
                new MenuItem("Muffin", "Bakery", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/muffin.jpeg")), 2.99m),
                new MenuItem("Bagel", "Bakery", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/bagel.png")), 1.99m),
                new MenuItem("Donut", "Bakery", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/donut.jpeg")), 1.99m),
                new MenuItem("Scone", "Bakery", Image.FromFile(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Resources/scone.png")), 2.99m)
            };
        }
        private void DisplayMenuItems(string category)
        {
            flowLayoutPanelItems.Controls.Clear();
            foreach (var item in menuItems)
            {
                if (item.Category == category)
                {
                    flowLayoutPanelItems.Controls.Add(CreateMenuItemPanel(item));
                }
            }
        }

        private Panel CreateMenuItemPanel(MenuItem item)
        {
            var panel = new Panel
            {
                Size = new Size(200, 250),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            var pictureBox = new PictureBox
            {
                Image = item.Image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(200, 250)
            };

            var nameLabel = new Label
            {
                Text = item.Name,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var priceLabel = new Label
            {
                Text = $"${item.Price:F2}",
                Font = new Font("Arial", 10, FontStyle.Regular),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var quantityLabel = new Label
            {
                Text = "Quantity:",
                Font = new Font("Arial", 10, FontStyle.Regular),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var numericUpDown = new NumericUpDown
            {
                Minimum = 0,
                Maximum = 10,
                Value = 0,
                Dock = DockStyle.Top
            };
            numericUpDown.ValueChanged += (sender, e) =>
            {
                item.Quantity = (int)numericUpDown.Value;
            };

            var addButton = new Button
            {
                Text = "Add to Cart",
                Font= new Font("Arial", 8, FontStyle.Regular),
                Dock = DockStyle.Top,
                BackColor = Color.Green
               
                
            };
            addButton.Click += (sender, e) =>
            {
                Cart.AddItem(item);
                MessageBox.Show($"{item.Name} added to cart!");
                foreach (var cartItem in Cart.Items)
                {
                    Console.WriteLine($"{cartItem.Name} - {cartItem.Quantity} x ${cartItem.Price}");
                }
            };

            panel.Controls.Add(addButton);
            panel.Controls.Add(numericUpDown);
            panel.Controls.Add(quantityLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(pictureBox);

            return panel;
        }


        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayMenuItems(comboBoxCategories.SelectedItem.ToString());
        }

        private void buttonViewCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm();
            cartForm.Show();
        }
    }
}
