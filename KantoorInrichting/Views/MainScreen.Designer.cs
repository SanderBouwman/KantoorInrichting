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
            this.SuspendLayout();
            // 
            // VooraadButton
            // 
            this.VooraadButton.Location = new System.Drawing.Point(33, 40);
            this.VooraadButton.Name = "VooraadButton";
            this.VooraadButton.Size = new System.Drawing.Size(201, 70);
            this.VooraadButton.TabIndex = 0;
            this.VooraadButton.Text = "Voorraad";
            this.VooraadButton.UseVisualStyleBackColor = true;
            this.VooraadButton.Click += new System.EventHandler(this.VooraadButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VooraadButton);
            this.Name = "MainScreen";
            this.Size = new System.Drawing.Size(474, 294);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button VooraadButton;
    }
}
