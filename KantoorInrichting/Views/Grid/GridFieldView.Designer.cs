using System.Drawing;
using System.Windows.Forms;
using KantoorInrichting.Models.Grid;

namespace KantoorInrichting.Views.Grid {
    partial class GridFieldView {
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
            this.components = new System.ComponentModel.Container();
            this.zoomCheckbox = new System.Windows.Forms.CheckBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.algoSelector = new System.Windows.Forms.ComboBox();
            this.algoButton = new System.Windows.Forms.Button();
            this.drawPanel = new KantoorInrichting.Models.Grid.GridFieldPanel();
            this.clearFieldButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // zoomCheckbox
            // 
            this.zoomCheckbox.AutoSize = true;
            this.zoomCheckbox.Location = new System.Drawing.Point(825, 588);
            this.zoomCheckbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zoomCheckbox.Name = "zoomCheckbox";
            this.zoomCheckbox.Size = new System.Drawing.Size(93, 21);
            this.zoomCheckbox.TabIndex = 2;
            this.zoomCheckbox.Text = "Vergroten";
            this.zoomCheckbox.UseVisualStyleBackColor = true;
            // 
            // trackBar
            // 
            this.trackBar.LargeChange = 25;
            this.trackBar.Location = new System.Drawing.Point(825, 617);
            this.trackBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBar.Maximum = 300;
            this.trackBar.Minimum = 50;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(139, 56);
            this.trackBar.SmallChange = 10;
            this.trackBar.TabIndex = 3;
            this.trackBar.TickFrequency = 25;
            this.trackBar.Value = 50;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(825, 6);
            this.listView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(185, 461);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // algoSelector
            // 
            this.algoSelector.FormattingEnabled = true;
            this.algoSelector.Location = new System.Drawing.Point(825, 505);
            this.algoSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.algoSelector.Name = "algoSelector";
            this.algoSelector.Size = new System.Drawing.Size(137, 24);
            this.algoSelector.TabIndex = 5;
            this.algoSelector.Text = "Maak een keuze";
            // 
            // algoButton
            // 
            this.algoButton.Location = new System.Drawing.Point(972, 505);
            this.algoButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.algoButton.Name = "algoButton";
            this.algoButton.Size = new System.Drawing.Size(67, 26);
            this.algoButton.TabIndex = 6;
            this.algoButton.Text = "Start";
            this.algoButton.UseVisualStyleBackColor = true;
            // 
            // drawPanel
            // 
            this.drawPanel.AllowDrop = true;
            this.drawPanel.BackColor = System.Drawing.Color.White;
            this.drawPanel.Location = new System.Drawing.Point(7, 6);
            this.drawPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(801, 740);
            this.drawPanel.TabIndex = 1;
            // 
            // clearFieldButton
            // 
            this.clearFieldButton.Location = new System.Drawing.Point(825, 553);
            this.clearFieldButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearFieldButton.Name = "clearFieldButton";
            this.clearFieldButton.Size = new System.Drawing.Size(100, 28);
            this.clearFieldButton.TabIndex = 7;
            this.clearFieldButton.Text = "Leeg veld";
            this.clearFieldButton.UseVisualStyleBackColor = true;
            // 
            // GridFieldView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clearFieldButton);
            this.Controls.Add(this.algoButton);
            this.Controls.Add(this.algoSelector);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.zoomCheckbox);
            this.Controls.Add(this.drawPanel);
            this.Enabled = false;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GridFieldView";
            this.Size = new System.Drawing.Size(1067, 763);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox zoomCheckbox;
        private GridFieldPanel drawPanel;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.ImageList imageList;
        private ListView listView;
        private ComboBox algoSelector;
        private Button algoButton;
        private Button clearFieldButton;
    }
}
