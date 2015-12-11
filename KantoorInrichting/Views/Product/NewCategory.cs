using KantoorInrichting.Controllers;
using KantoorInrichting.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views.Product
{
    public partial class NewCategory : Form
    {
        private CategoryManager catman;
        public string tempcat;
        private DatabaseController controller;

        public NewCategory(CategoryManager catman)
        {
            this.catman = catman;
            InitializeComponent();
            catman.controller.fillcombobox(CategoryModel.CategoryList, comboBox1);
            controller = DatabaseController.Instance;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            string Text = UpperFirst(textBox1.Text);          
            bool exists = false;
            // check if there is some name filled in
            if (Text == null || Text == "")
            {
                MessageBox.Show("U heeft geen categorienaam ingevuld, kies een andere naam");
            }

            // check if text already exists
            foreach(var category in controller.DataSet.category)
            {
                if(category.name == Text)
                {
                    exists = true;
                }
            }
            
            if (exists)
            {
                // if exitst error rename
                MessageBox.Show("Deze categorienaam bestaat al kies een andere naam");
            } else
            {
                // check if checkbox is checked
                if (checkBox1.Checked)
                {
                    // insert category into database


                    this.Close();
                }
                else
                {
                    // insert subcategory into database

                    this.Close();
                }
            }


           


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox1.Enabled = true;
                comboBox1.BackColor = System.Drawing.SystemColors.Window;
            } else
            {
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = false;
                this.comboBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            }
        }


        private string UpperFirst(string text)
        {
            return char.ToUpper(text[0]) +
                ((text.Length > 1) ? text.Substring(1).ToLower() : string.Empty);
        }
    }
}
