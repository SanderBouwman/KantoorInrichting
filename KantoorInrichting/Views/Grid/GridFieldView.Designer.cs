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
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.zoomCheckbox = new System.Windows.Forms.CheckBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.drawPanel = new KantoorInrichting.Models.Grid.GridFieldPanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.SystemColors.HotTrack;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(619, 5);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(124, 340);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // zoomCheckbox
            // 
            this.zoomCheckbox.AutoSize = true;
            this.zoomCheckbox.Location = new System.Drawing.Point(619, 383);
            this.zoomCheckbox.Name = "zoomCheckbox";
            this.zoomCheckbox.Size = new System.Drawing.Size(100, 17);
            this.zoomCheckbox.TabIndex = 2;
            this.zoomCheckbox.Text = "Zoom rectangle";
            this.zoomCheckbox.UseVisualStyleBackColor = true;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(615, 406);
            this.trackBar.Maximum = 300;
            this.trackBar.Minimum = 50;
            this.trackBar.TickFrequency = 25;
            this.trackBar.LargeChange = 25;
            this.trackBar.SmallChange = 10;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(104, 45);
            this.trackBar.TabIndex = 3;
            // 
            // drawPanel
            // 
            this.drawPanel.Location = new System.Drawing.Point(5, 5);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(601, 601);
            this.drawPanel.TabIndex = 1;
            // 
            // GridFieldView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.zoomCheckbox);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.listView);
            this.Enabled = false;
            this.Name = "GridFieldView";
            this.Size = new System.Drawing.Size(800, 620);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.CheckBox zoomCheckbox;
        private GridFieldPanel drawPanel;
        private System.Windows.Forms.TrackBar trackBar;
    }
}
