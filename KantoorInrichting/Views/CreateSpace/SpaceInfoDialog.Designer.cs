namespace KantoorInrichting.Views.CreateSpace
{
    partial class SpaceInfoDialog
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_Length = new System.Windows.Forms.Label();
            this.nud_Length = new System.Windows.Forms.NumericUpDown();
            this.nud_Width = new System.Windows.Forms.NumericUpDown();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.lbl_Text1 = new System.Windows.Forms.Label();
            this.lbl_Text2 = new System.Windows.Forms.Label();
            this.lbl_Numer = new System.Windows.Forms.Label();
            this.cbx_Building = new System.Windows.Forms.ComboBox();
            this.nud_Floor = new System.Windows.Forms.NumericUpDown();
            this.nud_Room = new System.Windows.Forms.NumericUpDown();
            this.lbl_CalculatedNumber = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Floor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Room)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(12, 138);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 38);
            this.btn_Cancel.TabIndex = 0;
            this.btn_Cancel.Text = "Annuleer";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(101, 138);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 38);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "Opslaan";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // lbl_Length
            // 
            this.lbl_Length.AutoSize = true;
            this.lbl_Length.Location = new System.Drawing.Point(16, 14);
            this.lbl_Length.Name = "lbl_Length";
            this.lbl_Length.Size = new System.Drawing.Size(40, 13);
            this.lbl_Length.TabIndex = 2;
            this.lbl_Length.Text = "Lengte";
            // 
            // nud_Length
            // 
            this.nud_Length.DecimalPlaces = 2;
            this.nud_Length.Location = new System.Drawing.Point(60, 12);
            this.nud_Length.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nud_Length.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Length.Name = "nud_Length";
            this.nud_Length.Size = new System.Drawing.Size(78, 20);
            this.nud_Length.TabIndex = 3;
            this.nud_Length.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_Width
            // 
            this.nud_Width.DecimalPlaces = 2;
            this.nud_Width.Location = new System.Drawing.Point(60, 38);
            this.nud_Width.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nud_Width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Width.Name = "nud_Width";
            this.nud_Width.Size = new System.Drawing.Size(78, 20);
            this.nud_Width.TabIndex = 4;
            this.nud_Width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_Width
            // 
            this.lbl_Width.AutoSize = true;
            this.lbl_Width.Location = new System.Drawing.Point(12, 40);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(44, 13);
            this.lbl_Width.TabIndex = 5;
            this.lbl_Width.Text = "Breedte";
            // 
            // lbl_Text1
            // 
            this.lbl_Text1.AutoSize = true;
            this.lbl_Text1.Location = new System.Drawing.Point(144, 14);
            this.lbl_Text1.Name = "lbl_Text1";
            this.lbl_Text1.Size = new System.Drawing.Size(33, 13);
            this.lbl_Text1.TabIndex = 6;
            this.lbl_Text1.Text = "meter";
            // 
            // lbl_Text2
            // 
            this.lbl_Text2.AutoSize = true;
            this.lbl_Text2.Location = new System.Drawing.Point(144, 40);
            this.lbl_Text2.Name = "lbl_Text2";
            this.lbl_Text2.Size = new System.Drawing.Size(33, 13);
            this.lbl_Text2.TabIndex = 7;
            this.lbl_Text2.Text = "meter";
            // 
            // lbl_Numer
            // 
            this.lbl_Numer.AutoSize = true;
            this.lbl_Numer.Location = new System.Drawing.Point(12, 106);
            this.lbl_Numer.Name = "lbl_Numer";
            this.lbl_Numer.Size = new System.Drawing.Size(79, 13);
            this.lbl_Numer.TabIndex = 8;
            this.lbl_Numer.Text = "Lokaal nummer";
            // 
            // cbx_Building
            // 
            this.cbx_Building.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Building.FormattingEnabled = true;
            this.cbx_Building.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "S",
            "T",
            "X",
            "Z"});
            this.cbx_Building.Location = new System.Drawing.Point(97, 103);
            this.cbx_Building.Name = "cbx_Building";
            this.cbx_Building.Size = new System.Drawing.Size(41, 21);
            this.cbx_Building.TabIndex = 9;
            this.cbx_Building.SelectedIndexChanged += new System.EventHandler(this.NumberChanged);
            // 
            // nud_Floor
            // 
            this.nud_Floor.Location = new System.Drawing.Point(144, 103);
            this.nud_Floor.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nud_Floor.Name = "nud_Floor";
            this.nud_Floor.Size = new System.Drawing.Size(32, 20);
            this.nud_Floor.TabIndex = 10;
            this.nud_Floor.ValueChanged += new System.EventHandler(this.NumberChanged);
            // 
            // nud_Room
            // 
            this.nud_Room.Location = new System.Drawing.Point(182, 103);
            this.nud_Room.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nud_Room.Name = "nud_Room";
            this.nud_Room.Size = new System.Drawing.Size(44, 20);
            this.nud_Room.TabIndex = 11;
            this.nud_Room.ValueChanged += new System.EventHandler(this.NumberChanged);
            // 
            // lbl_CalculatedNumber
            // 
            this.lbl_CalculatedNumber.AutoSize = true;
            this.lbl_CalculatedNumber.Location = new System.Drawing.Point(232, 106);
            this.lbl_CalculatedNumber.Name = "lbl_CalculatedNumber";
            this.lbl_CalculatedNumber.Size = new System.Drawing.Size(29, 13);
            this.lbl_CalculatedNumber.TabIndex = 12;
            this.lbl_CalculatedNumber.Text = "A0.0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 13;
            this.button1.Text = "Opslaan en bewerken";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SpaceInfoDialog
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(270, 188);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_CalculatedNumber);
            this.Controls.Add(this.nud_Room);
            this.Controls.Add(this.nud_Floor);
            this.Controls.Add(this.cbx_Building);
            this.Controls.Add(this.lbl_Numer);
            this.Controls.Add(this.lbl_Text2);
            this.Controls.Add(this.lbl_Text1);
            this.Controls.Add(this.lbl_Width);
            this.Controls.Add(this.nud_Width);
            this.Controls.Add(this.nud_Length);
            this.Controls.Add(this.lbl_Length);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Name = "SpaceInfoDialog";
            this.Text = "SpaceInfoDialog";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Floor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Room)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_Length;
        private System.Windows.Forms.NumericUpDown nud_Length;
        private System.Windows.Forms.NumericUpDown nud_Width;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.Label lbl_Text1;
        private System.Windows.Forms.Label lbl_Text2;
        private System.Windows.Forms.Label lbl_Numer;
        private System.Windows.Forms.NumericUpDown nud_Floor;
        private System.Windows.Forms.NumericUpDown nud_Room;
        private System.Windows.Forms.ComboBox cbx_Building;
        private System.Windows.Forms.Label lbl_CalculatedNumber;
        private System.Windows.Forms.Button button1;
    }
}