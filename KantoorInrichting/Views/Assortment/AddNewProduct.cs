using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views.Assortment
{
    public partial class AddNewProduct : Form
    {
        public AddNewProduct()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            foreach(var p in getData_FromTextBoxes())
            {
                

                
            }
        }

        private Dictionary<string,string> getData_FromTextBoxes()
        {
            Dictionary <string, string> product = new Dictionary<string, string>();

            product.Add("Name",nameTextBox.Text);
            product.Add("Type", typeTextBox.Text);
            product.Add("Brand", brandTextBox.Text);
            product.Add("Height", heightTextBox.Text);
            product.Add("Width", widthTextBox.Text);
            product.Add("Length", lengthTextBox.Text);
            product.Add("Amount", amountTextBox.Text);
            product.Add("Image", imageTextBox.Text);
            product.Add("Category", categoryTextBox.Text);
            product.Add("Description", descriptionTextBox.Text);

            return product;
        }
    }
}
