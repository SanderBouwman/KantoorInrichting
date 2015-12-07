namespace KantoorInrichting.Views.Maps
{
    partial class MapsScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MapsGridView1 = new System.Windows.Forms.DataGridView();
            this.Merk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lengte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Toon = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Titel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MapsGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // MapsGridView1
            // 
            this.MapsGridView1.AllowUserToAddRows = false;
            this.MapsGridView1.AllowUserToDeleteRows = false;
            this.MapsGridView1.AllowUserToOrderColumns = true;
            this.MapsGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapsGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MapsGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.MapsGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MapsGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MapsGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Merk,
            this.Lengte,
            this.Amount,
            this.Toon});
            this.MapsGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapsGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.MapsGridView1.Location = new System.Drawing.Point(2, 89);
            this.MapsGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.MapsGridView1.MultiSelect = false;
            this.MapsGridView1.Name = "MapsGridView1";
            this.MapsGridView1.RowTemplate.Height = 50;
            this.MapsGridView1.Size = new System.Drawing.Size(688, 337);
            this.MapsGridView1.TabIndex = 4;
            // 
            // Merk
            // 
            this.Merk.DataPropertyName = "Building";
            this.Merk.HeaderText = "Gebouw";
            this.Merk.Name = "Merk";
            this.Merk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Lengte
            // 
            this.Lengte.DataPropertyName = "Floor";
            this.Lengte.HeaderText = "Verdieping";
            this.Lengte.Name = "Lengte";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Room";
            this.Amount.HeaderText = "Lokaal";
            this.Amount.Name = "Amount";
            // 
            // Toon
            // 
            this.Toon.HeaderText = "Toon";
            this.Toon.Name = "Toon";
            this.Toon.Text = "Toon";
            this.Toon.UseColumnTextForButtonValue = true;
            // 
            // Titel
            // 
            this.Titel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Titel.Font = new System.Drawing.Font("Maiandra GD", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titel.Location = new System.Drawing.Point(20, 20);
            this.Titel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titel.Name = "Titel";
            this.Titel.Size = new System.Drawing.Size(293, 56);
            this.Titel.TabIndex = 5;
            this.Titel.Text = "Plattegronden";
            // 
            // MapsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Titel);
            this.Controls.Add(this.MapsGridView1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MapsScreen";
            this.Size = new System.Drawing.Size(703, 428);
            ((System.ComponentModel.ISupportInitialize)(this.MapsGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView MapsGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lengte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewButtonColumn Toon;
        private System.Windows.Forms.Label Titel;
    }
}
