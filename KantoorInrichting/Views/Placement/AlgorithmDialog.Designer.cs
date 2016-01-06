namespace KantoorInrichting.Views.Placement {
    partial class AlgorithmDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.amountLabel = new System.Windows.Forms.Label();
            this.marginLabel = new System.Windows.Forms.Label();
            this.marginBox = new System.Windows.Forms.TextBox();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(44, 73);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(84, 13);
            this.amountLabel.TabIndex = 0;
            this.amountLabel.Text = "Aantal personen";
            // 
            // marginLabel
            // 
            this.marginLabel.AutoSize = true;
            this.marginLabel.Location = new System.Drawing.Point(44, 129);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(228, 13);
            this.marginLabel.TabIndex = 1;
            this.marginLabel.Text = "Ruimte tussen stoel/tafel paren (in centimeters)";
            // 
            // marginBox
            // 
            this.marginBox.Location = new System.Drawing.Point(47, 146);
            this.marginBox.Name = "marginBox";
            this.marginBox.Size = new System.Drawing.Size(100, 20);
            this.marginBox.TabIndex = 3;
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(47, 89);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(100, 20);
            this.amountBox.TabIndex = 4;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(174, 225);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "OK";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(47, 225);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(3, 1);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(290, 72);
            this.errorLabel.TabIndex = 7;
            this.errorLabel.Text = "Één van de onderstaande velden\r\nis niet goed ingevuld\r\n(Alleen cijfers)";
            // 
            // AlgorithmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 272);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.marginBox);
            this.Controls.Add(this.marginLabel);
            this.Controls.Add(this.amountLabel);
            this.Name = "AlgorithmDialog";
            this.Text = "AlgorithmDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label marginLabel;
        private System.Windows.Forms.TextBox marginBox;
        private System.Windows.Forms.TextBox amountBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label errorLabel;
    }
}