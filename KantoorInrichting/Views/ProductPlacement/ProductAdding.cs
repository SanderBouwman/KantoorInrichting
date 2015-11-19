using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting;

namespace KantoorInrichting
{
    public partial class ProductAdding : UserControl
    {
        public ProductAdding()
        {
            InitializeComponent();

            productList1.SelectionChanged += new ProductSelectionChanged(this.changeSelected);

        }



        public void changeSelected(ProductInfo sender)
        {
            productInfo1.setProduct(sender.product);
        }
    }
}
