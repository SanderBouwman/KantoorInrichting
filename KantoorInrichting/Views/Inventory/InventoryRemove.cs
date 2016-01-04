using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views.Inventory
{
    public partial class InventoryRemove : Form
    {
        public event EventHandler InventoryEditorScreenClick;
        private readonly UserControl _userControl;
        private readonly string _productname;


        public InventoryRemove(Models.Product.ProductModel p, UserControl userControl)
        {
            InitializeComponent();
            this._productname = p.Name;
            this._userControl = userControl;
        }


        private void InventoryEditor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            _userControl.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("SQL query: \nDELETE FROM product \nWHERE productnaam = '" + _productname + "'");
            this.Close();
            _userControl.Refresh();
        }
    }
}
