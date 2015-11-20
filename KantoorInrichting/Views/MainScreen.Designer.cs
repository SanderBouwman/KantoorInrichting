namespace KantoorInrichting.Views
{
    partial class MainScreen
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
            this.VooraadButton = new System.Windows.Forms.Button();
            this.mapButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VooraadButton
            // 
            this.VooraadButton.Location = new System.Drawing.Point(25, 32);
            this.VooraadButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VooraadButton.Name = "VooraadButton";
            this.VooraadButton.Size = new System.Drawing.Size(151, 57);
            this.VooraadButton.TabIndex = 0;
            this.VooraadButton.Text = "Voorraad";
            this.VooraadButton.UseVisualStyleBackColor = true;
            this.VooraadButton.Click += new System.EventHandler(this.VooraadButton_Click);
            // 
            // mapButton
            // 
            this.mapButton.Location = new System.Drawing.Point(25, 129);
            this.mapButton.Name = "mapButton";
            this.mapButton.Size = new System.Drawing.Size(151, 57);
            this.mapButton.TabIndex = 1;
            this.mapButton.Text = "Plattegrond";
            this.mapButton.UseVisualStyleBackColor = true;
            this.mapButton.Click += new System.EventHandler(MapButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapButton);
            this.Controls.Add(this.VooraadButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainScreen";
            this.Size = new System.Drawing.Size(356, 239);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button VooraadButton;
        private System.Windows.Forms.Button mapButton;
    }
}
