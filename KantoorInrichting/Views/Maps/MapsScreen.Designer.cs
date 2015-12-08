﻿namespace KantoorInrichting.Views.Maps
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
            this.Building = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Roomnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Show = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MapsGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Titel
            // 
            this.Titel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Titel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titel.Location = new System.Drawing.Point(20, 20);
            this.Titel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titel.Name = "Titel";
            this.Titel.Size = new System.Drawing.Size(681, 56);
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
            this.Building,
            this.Floor,
            this.Room,
            this.Roomnumber,
            this.Show});
            this.MapsGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapsGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.MapsGridView1.Location = new System.Drawing.Point(0, 140);
            this.MapsGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.MapsGridView1.Name = "MapsGridView1";
            this.MapsGridView1.RowTemplate.Height = 50;
            this.MapsGridView1.Size = new System.Drawing.Size(701, 290);
            this.MapsGridView1.TabIndex = 3;
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
            // Room
            // 
            this.Room.DataPropertyName = "Room";
            this.Room.HeaderText = "Lokaal";
            this.Room.Name = "Room";
            // 
            // Roomnumber
            // 
            this.Roomnumber.DataPropertyName = "Roomnumber";
            this.Roomnumber.HeaderText = "Kamernummer";
            this.Roomnumber.Name = "Roomnumber";
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
            // MapsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MapsGridView1);
            this.Controls.Add(this.Titel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MapsScreen";
            this.Size = new System.Drawing.Size(703, 428);
            ((System.ComponentModel.ISupportInitialize)(this.MapsGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Titel;
        private System.Windows.Forms.DataGridView MapsGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Building;
        private System.Windows.Forms.DataGridViewTextBoxColumn Floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn Roomnumber;
        private System.Windows.Forms.DataGridViewButtonColumn Show;
    }
}