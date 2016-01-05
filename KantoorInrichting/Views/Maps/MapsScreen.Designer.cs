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
            this.Titel = new System.Windows.Forms.Label();
            this.MapsGridView1 = new System.Windows.Forms.DataGridView();
            this.Show = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Building = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Roomnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MapsGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Titel
            // 
            this.Titel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Titel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titel.Location = new System.Drawing.Point(27, 25);
            this.Titel.Name = "Titel";
            this.Titel.Size = new System.Drawing.Size(908, 69);
            this.Titel.TabIndex = 5;
            this.Titel.Text = "Plattegronden";
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
            this.MapsGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Show,
            this.Building,
            this.Floor,
            this.Roomnumber,
            this.Room});
            this.MapsGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapsGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.MapsGridView1.Location = new System.Drawing.Point(0, 172);
            this.MapsGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MapsGridView1.Name = "MapsGridView1";
            this.MapsGridView1.RowTemplate.Height = 50;
            this.MapsGridView1.Size = new System.Drawing.Size(935, 357);
            this.MapsGridView1.TabIndex = 3;
            this.MapsGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MapsGridView1_CellContentClick);
            // 
            // Show
            // 
            this.Show.DataPropertyName = "Show";
            this.Show.HeaderText = "Toon";
            this.Show.Name = "Show";
            this.Show.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Show.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Show.Text = "Toon";
            this.Show.ToolTipText = "Toon";
            this.Show.UseColumnTextForButtonValue = true;
            // 
            // Building
            // 
            this.Building.DataPropertyName = "Building";
            this.Building.HeaderText = "Gebouw";
            this.Building.Name = "Building";
            // 
            // Floor
            // 
            this.Floor.DataPropertyName = "Floor";
            this.Floor.HeaderText = "Verdieping";
            this.Floor.Name = "Floor";
            // 
            // Roomnumber
            // 
            this.Roomnumber.DataPropertyName = "Roomnumber";
            this.Roomnumber.HeaderText = "Kamernummer";
            this.Roomnumber.Name = "Roomnumber";
            // 
            // Room
            // 
            this.Room.DataPropertyName = "Room";
            this.Room.HeaderText = "Lokaal";
            this.Room.Name = "Room";
            // 
            // MapsScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.MapsGridView1);
            this.Controls.Add(this.Titel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MapsScreen";
            this.Size = new System.Drawing.Size(937, 527);
            ((System.ComponentModel.ISupportInitialize)(this.MapsGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Titel;
        private System.Windows.Forms.DataGridViewButtonColumn Show;
        private System.Windows.Forms.DataGridViewTextBoxColumn Building;
        private System.Windows.Forms.DataGridViewTextBoxColumn Floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Roomnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        public System.Windows.Forms.DataGridView MapsGridView1;
    }
}
