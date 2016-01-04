using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Controllers.Product;

namespace KantoorInrichting.Views.Product
{
    public partial class ChangeCategoryName : Form
    {
        public ChangeCategoryNameController controller;
        public string name;

        public ChangeCategoryName(string name)
        {
            InitializeComponent();
            this.controller = new ChangeCategoryNameController(this);
            this.name = name;
            categoryNameTextBox.Text = name;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            controller.saveButton();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            controller.cancelButton();
        }
    }
}
