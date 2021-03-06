﻿using KantoorInrichting.Controllers;
using KantoorInrichting.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views.Product
{
    public partial class NewCategory : Form
    {
        private readonly DatabaseController _controller;
        private readonly CategoryManager _catMan;
        public string TempCat;
        bool NotDone = false;

        public NewCategory(CategoryManager catMan)
        {
            this._catMan = catMan;
            InitializeComponent();
            catMan.Controller.Fillcombobox(CategoryModel.CategoryList, comboBox1);
            _controller = DatabaseController.Instance;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            string Text = UpperFirst(textBox1.Text);          
            bool exists = false;
            // check if there is some name filled in
            if (Text.Length < 3)
            {
                MessageBox.Show("U heeft geen categorienaam ingevuld van minstens 3 karakters, kies een andere naam");
            } 
            // check for special chars
            if (!Regex.IsMatch(Text, @"^[a-zA-Z0-9_\s]+$"))
                {
                MessageBox.Show("Uw categorie bevat speciale tekens, kies een andere naam");
            }

            // check if text already exists
            foreach (var category in _controller.DataSet.category)
            {
                if(category.name == Text)
                {
                    exists = true;
                }
            }
            
            if (exists == true)
            {
                // if exitst error rename
                MessageBox.Show("Deze categorienaam bestaat al kies een andere naam");
          
            }

            if (exists == false && Text.Length >= 3 && Regex.IsMatch(Text, @"^[a-zA-Z0-9_\s]+$"))
            {
                // check if checkbox is checked
                if (checkBox1.Checked == false)
                {
                            

                    // insert category into database
                    _catMan.Controller.AddCategory(Text, textBox2.Text);
                    _catMan.categoryComboBox.SelectedIndex = 0;
                    this.Close();
                }
                else
                {
                    // get the mainCategory ID

                    // linq select category with the current name
                    var selectedcategory = CategoryModel.List
                            .Where(c => c.Name == comboBox1.SelectedItem.ToString())
                            .Select(c => c)
                            .ToList();

                    // test the current iD
                    //MessageBox.Show("geselecteerde categorie ID =" + selectedcategory[0].catID);
                    

                    // insert subcategory into database
                    _catMan.Controller.AddSubCategory(Text, textBox2.Text, selectedcategory[0].CatId);
                    _catMan.categoryComboBox.SelectedIndex = 0;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show("een subcategorie heeft geen kleur, deze gebruikt de kleur van de hoofdcategorie");
            }
            else
            {
                ColorDialog colordialog1 = new ColorDialog();
                //show the dialog.
                DialogResult result = colordialog1.ShowDialog();
                // See if OK was pressed.
                if (result == DialogResult.OK)
                {
                    // Get color
                    Color color = colordialog1.Color;
                    // Set TextBox properties.

                    string text = String.Format("#99{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);

                    this.textBox2.Text = string.Format("{0}", text);
                    this.textBox2.ForeColor = color;
                }
            }
        }

    }
}
