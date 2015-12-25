using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KantoorInrichting.Controllers;

namespace KantoorInrichting.Views.Placement {
    public partial class AlgorithmDialog : Form
    {

        public Dictionary<string, float> Result { get; }

        public AlgorithmDialog() {
            InitializeComponent();
            SetEvents();
            this.errorLabel.Hide();
            this.Result = new Dictionary<string, float>(2);
        }

        private void SetEvents()
        {
            this.submitButton.Click += SubmitButton_Click;
            this.cancelButton.Click += CancelButton_Click;
        }

        private void CancelButton_Click( object sender, EventArgs e ) {
            this.Close();
        }

        private void SubmitButton_Click( object sender, EventArgs e )
        {
            float margin, people;
            if (float.TryParse(this.marginBox.Text, out margin) && float.TryParse(this.amountBox.Text, out people))
            {
                this.Result["Margin"] = margin;
                this.Result["People"] = people;
                this.Hide();
            }
            else
            {
                this.errorLabel.Show();
            }
        }
    }
}
