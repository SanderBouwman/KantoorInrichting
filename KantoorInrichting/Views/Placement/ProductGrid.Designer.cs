namespace KantoorInrichting.Views.Placement {
    partial class ProductGrid {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.controlPanel = new System.Windows.Forms.Panel();
            this.algorithmButton = new System.Windows.Forms.Button();
            this.algorithmLabel = new System.Windows.Forms.Label();
            this.algorithmComboBox = new System.Windows.Forms.ComboBox();
            this.zoomCheckbox = new System.Windows.Forms.CheckBox();
            this.zoomTrackbar = new System.Windows.Forms.TrackBar();
            this.spaceSizeTextbox = new System.Windows.Forms.TextBox();
            this.spaceNumberTextbox = new System.Windows.Forms.TextBox();
            this.spaceSizeLabel = new System.Windows.Forms.Label();
            this.spaceNumberLabel = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCW = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonCCW = new System.Windows.Forms.Button();
            this.legendLabel = new System.Windows.Forms.Label();
            this.controlDock = new System.Windows.Forms.Panel();
            this.productList = new KantoorInrichting.Views.Placement.ProductList();
            this.gridFieldPanel = new KantoorInrichting.Models.Grid.GridFieldPanel();
            this.legend = new KantoorInrichting.Views.Placement.Legend();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackbar)).BeginInit();
            this.controlDock.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.Controls.Add(this.algorithmButton);
            this.controlPanel.Controls.Add(this.algorithmLabel);
            this.controlPanel.Controls.Add(this.algorithmComboBox);
            this.controlPanel.Controls.Add(this.zoomCheckbox);
            this.controlPanel.Controls.Add(this.zoomTrackbar);
            this.controlPanel.Controls.Add(this.spaceSizeTextbox);
            this.controlPanel.Controls.Add(this.spaceNumberTextbox);
            this.controlPanel.Controls.Add(this.spaceSizeLabel);
            this.controlPanel.Controls.Add(this.spaceNumberLabel);
            this.controlPanel.Controls.Add(this.buttonSave);
            this.controlPanel.Controls.Add(this.buttonDelete);
            this.controlPanel.Controls.Add(this.buttonCW);
            this.controlPanel.Controls.Add(this.buttonRight);
            this.controlPanel.Controls.Add(this.buttonDown);
            this.controlPanel.Controls.Add(this.buttonUp);
            this.controlPanel.Controls.Add(this.buttonLeft);
            this.controlPanel.Controls.Add(this.buttonCCW);
            this.controlPanel.Location = new System.Drawing.Point(62, 473);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(372, 194);
            this.controlPanel.TabIndex = 1;
            // 
            // algorithmButton
            // 
            this.algorithmButton.Location = new System.Drawing.Point(242, 114);
            this.algorithmButton.Name = "algorithmButton";
            this.algorithmButton.Size = new System.Drawing.Size(75, 23);
            this.algorithmButton.TabIndex = 16;
            this.algorithmButton.Text = "Start";
            this.algorithmButton.UseVisualStyleBackColor = true;
            // 
            // algorithmLabel
            // 
            this.algorithmLabel.AutoSize = true;
            this.algorithmLabel.Location = new System.Drawing.Point(127, 95);
            this.algorithmLabel.Name = "algorithmLabel";
            this.algorithmLabel.Size = new System.Drawing.Size(72, 13);
            this.algorithmLabel.TabIndex = 15;
            this.algorithmLabel.Text = "Kies algoritme";
            // 
            // algorithmComboBox
            // 
            this.algorithmComboBox.FormattingEnabled = true;
            this.algorithmComboBox.Location = new System.Drawing.Point(114, 114);
            this.algorithmComboBox.Name = "algorithmComboBox";
            this.algorithmComboBox.Size = new System.Drawing.Size(121, 21);
            this.algorithmComboBox.TabIndex = 14;
            // 
            // zoomCheckbox
            // 
            this.zoomCheckbox.AutoSize = true;
            this.zoomCheckbox.Location = new System.Drawing.Point(3, 95);
            this.zoomCheckbox.Name = "zoomCheckbox";
            this.zoomCheckbox.Size = new System.Drawing.Size(53, 17);
            this.zoomCheckbox.TabIndex = 13;
            this.zoomCheckbox.Text = "Zoom";
            this.zoomCheckbox.UseVisualStyleBackColor = true;
            // 
            // zoomTrackbar
            // 
            this.zoomTrackbar.Enabled = false;
            this.zoomTrackbar.LargeChange = 25;
            this.zoomTrackbar.Location = new System.Drawing.Point(0, 114);
            this.zoomTrackbar.Maximum = 300;
            this.zoomTrackbar.Minimum = 50;
            this.zoomTrackbar.Name = "zoomTrackbar";
            this.zoomTrackbar.Size = new System.Drawing.Size(104, 45);
            this.zoomTrackbar.SmallChange = 10;
            this.zoomTrackbar.TabIndex = 12;
            this.zoomTrackbar.Value = 50;
            // 
            // spaceSizeTextbox
            // 
            this.spaceSizeTextbox.Location = new System.Drawing.Point(259, 56);
            this.spaceSizeTextbox.Name = "spaceSizeTextbox";
            this.spaceSizeTextbox.Size = new System.Drawing.Size(100, 20);
            this.spaceSizeTextbox.TabIndex = 11;
            // 
            // spaceNumberTextbox
            // 
            this.spaceNumberTextbox.Location = new System.Drawing.Point(259, 17);
            this.spaceNumberTextbox.Name = "spaceNumberTextbox";
            this.spaceNumberTextbox.Size = new System.Drawing.Size(100, 20);
            this.spaceNumberTextbox.TabIndex = 10;
            // 
            // spaceSizeLabel
            // 
            this.spaceSizeLabel.AutoSize = true;
            this.spaceSizeLabel.Location = new System.Drawing.Point(256, 41);
            this.spaceSizeLabel.Name = "spaceSizeLabel";
            this.spaceSizeLabel.Size = new System.Drawing.Size(79, 13);
            this.spaceSizeLabel.TabIndex = 9;
            this.spaceSizeLabel.Text = "Afmeting ruimte";
            // 
            // spaceNumberLabel
            // 
            this.spaceNumberLabel.AutoSize = true;
            this.spaceNumberLabel.Location = new System.Drawing.Point(256, 3);
            this.spaceNumberLabel.Name = "spaceNumberLabel";
            this.spaceNumberLabel.Size = new System.Drawing.Size(40, 13);
            this.spaceNumberLabel.TabIndex = 8;
            this.spaceNumberLabel.Text = "Ruimte";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.buttonSave.Location = new System.Drawing.Point(185, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(50, 70);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "💾";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.buttonDelete.Location = new System.Drawing.Point(130, 5);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(50, 70);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "🗑";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonCW
            // 
            this.buttonCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.buttonCW.Location = new System.Drawing.Point(85, 3);
            this.buttonCW.Name = "buttonCW";
            this.buttonCW.Size = new System.Drawing.Size(35, 35);
            this.buttonCW.TabIndex = 5;
            this.buttonCW.Text = "↷";
            this.buttonCW.UseVisualStyleBackColor = true;
            // 
            // buttonRight
            // 
            this.buttonRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonRight.Location = new System.Drawing.Point(85, 43);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(35, 35);
            this.buttonRight.TabIndex = 4;
            this.buttonRight.Text = "→";
            this.buttonRight.UseVisualStyleBackColor = true;
            // 
            // buttonDown
            // 
            this.buttonDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonDown.Location = new System.Drawing.Point(44, 43);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(35, 35);
            this.buttonDown.TabIndex = 4;
            this.buttonDown.Text = "↓";
            this.buttonDown.UseVisualStyleBackColor = true;
            // 
            // buttonUp
            // 
            this.buttonUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonUp.Location = new System.Drawing.Point(44, 3);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(35, 35);
            this.buttonUp.TabIndex = 2;
            this.buttonUp.Text = "↑";
            this.buttonUp.UseVisualStyleBackColor = true;
            // 
            // buttonLeft
            // 
            this.buttonLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonLeft.Location = new System.Drawing.Point(3, 43);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(35, 35);
            this.buttonLeft.TabIndex = 1;
            this.buttonLeft.Text = "←";
            this.buttonLeft.UseVisualStyleBackColor = true;
            // 
            // buttonCCW
            // 
            this.buttonCCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.buttonCCW.Location = new System.Drawing.Point(3, 3);
            this.buttonCCW.Name = "buttonCCW";
            this.buttonCCW.Size = new System.Drawing.Size(35, 35);
            this.buttonCCW.TabIndex = 0;
            this.buttonCCW.Text = "↶";
            this.buttonCCW.UseVisualStyleBackColor = true;
            // 
            // legendLabel
            // 
            this.legendLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.legendLabel.AutoSize = true;
            this.legendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.legendLabel.Location = new System.Drawing.Point(26, 587);
            this.legendLabel.Name = "legendLabel";
            this.legendLabel.Size = new System.Drawing.Size(119, 31);
            this.legendLabel.TabIndex = 3;
            this.legendLabel.Text = "Legenda";
            // 
            // controlDock
            // 
            this.controlDock.Controls.Add(this.productList);
            this.controlDock.Controls.Add(this.controlPanel);
            this.controlDock.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlDock.Location = new System.Drawing.Point(683, 0);
            this.controlDock.Name = "controlDock";
            this.controlDock.Size = new System.Drawing.Size(437, 670);
            this.controlDock.TabIndex = 5;
            // 
            // productList
            // 
            this.productList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.productList.AutoScroll = true;
            this.productList.Location = new System.Drawing.Point(14, 0);
            this.productList.Name = "productList";
            this.productList.Size = new System.Drawing.Size(420, 420);
            this.productList.TabIndex = 0;
            // 
            // gridFieldPanel
            // 
            this.gridFieldPanel.AllowDrop = true;
            this.gridFieldPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFieldPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridFieldPanel.Location = new System.Drawing.Point(3, 3);
            this.gridFieldPanel.Name = "gridFieldPanel";
            this.gridFieldPanel.Size = new System.Drawing.Size(600, 550);
            this.gridFieldPanel.TabIndex = 4;
            // 
            // legend
            // 
            this.legend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.legend.AutoScroll = true;
            this.legend.Location = new System.Drawing.Point(163, 568);
            this.legend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.legend.Name = "legend";
            this.legend.Size = new System.Drawing.Size(403, 86);
            this.legend.TabIndex = 2;
            // 
            // ProductGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlDock);
            this.Controls.Add(this.gridFieldPanel);
            this.Controls.Add(this.legendLabel);
            this.Controls.Add(this.legend);
            this.Name = "ProductGrid";
            this.Size = new System.Drawing.Size(1120, 670);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackbar)).EndInit();
            this.controlDock.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProductList productList;
        private System.Windows.Forms.Panel controlPanel;
        private Legend legend;
        private System.Windows.Forms.Label legendLabel;
        private System.Windows.Forms.Button buttonCCW;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonCW;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label spaceSizeLabel;
        private System.Windows.Forms.Label spaceNumberLabel;
        public System.Windows.Forms.TextBox spaceSizeTextbox;
        public System.Windows.Forms.TextBox spaceNumberTextbox;
        private System.Windows.Forms.Panel controlDock;
        private System.Windows.Forms.CheckBox zoomCheckbox;
        private System.Windows.Forms.TrackBar zoomTrackbar;
        private System.Windows.Forms.Button algorithmButton;
        private System.Windows.Forms.Label algorithmLabel;
        private System.Windows.Forms.ComboBox algorithmComboBox;
        public Models.Grid.GridFieldPanel gridFieldPanel;
    }
}
