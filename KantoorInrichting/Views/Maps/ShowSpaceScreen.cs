﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KantoorInrichting.Views.Maps
{
    public partial class ShowSpaceScreen : Form
    {
        public ShowSpaceScreen()
        {
            DoubleBuffered = true;
            this.MinimumSize = new Size(600, 600);
            InitializeComponent();
        }
    }
}
