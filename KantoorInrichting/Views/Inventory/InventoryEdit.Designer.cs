namespace KantoorInrichting.Views.Inventory
{
    partial class InventoryEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WijzigenButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Productnaam = new System.Windows.Forms.Label();
            this.ProductAantal = new System.Windows.Forms.NumericUpDown();
            this.AnnulerenButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProductAantal)).BeginInit();
            this.SuspendLayout();
            // 
            // WijzigenButton
            // 
            this.WijzigenButton.Location = new System.Drawing.Point(27, 182);
            this.WijzigenButton.Name = "WijzigenButton";
            this.WijzigenButton.Size = new System.Drawing.Size(102, 36);
            this.WijzigenButton.TabIndex = 0;
            this.WijzigenButton.Text = "Wijzigen";
            this.WijzigenButton.UseVisualStyleBackColor = true;
            this.WijzigenButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(93, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wijzigen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aantal :";
            // 
            // Productnaam
            // 
            this.Productnaam.AutoSize = true;
            this.Productnaam.Location = new System.Drawing.Point(94, 73);
            this.Productnaam.Name = "Productnaam";
            this.Productnaam.Size = new System.Drawing.Size(92, 17);
            this.Productnaam.TabIndex = 3;
            this.Productnaam.Text = "Productnaam";
            // 
            // ProductAantal
            // 
            this.ProductAantal.Location = new System.Drawing.Point(135, 124);
            this.ProductAantal.Name = "ProductAantal";
            this.ProductAantal.Size = new System.Drawing.Size(70, 22);
            this.ProductAantal.TabIndex = 4;
            // 
            // AnnulerenButton
            // 
            this.AnnulerenButton.Location = new System.Drawing.Point(153, 182);
            this.AnnulerenButton.Name = "AnnulerenButton";
            this.AnnulerenButton.Size = new System.Drawing.Size(102, 36);
            this.AnnulerenButton.TabIndex = 5;
            this.AnnulerenButton.Text = "Annuleren";
            this.AnnulerenButton.UseVisualStyleBackColor = true;
            this.AnnulerenButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // InventoryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.AnnulerenButton);
            this.Controls.Add(this.ProductAantal);
            this.Controls.Add(this.Productnaam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WijzigenButton);
            this.Name = "InventoryEdit";
            this.Text = "InventoryEdit";
            ((System.ComponentModel.ISupportInitialize)(this.ProductAantal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WijzigenButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Productnaam;
        private System.Windows.Forms.NumericUpDown ProductAantal;
        private System.Windows.Forms.Button AnnulerenButton;
    }
}