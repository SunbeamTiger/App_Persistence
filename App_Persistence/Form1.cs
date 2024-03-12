﻿using App_Persistence.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Persistence
{
    public partial class Form1 : Form
    {
        private Color _chosenColor;
        public Form1()
        {
            InitializeComponent();
        }

        private void getSettings()
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int FW = Settings.Default.FormWidth;
            int FH = Settings.Default.FormHeight;
            _chosenColor = Settings.Default.FormColor;

             
            this.Height = FH;   
            bool ColorizeIt = Settings.Default.ShowColor;
            if (ColorizeIt==true)
            {
                this.BackColor = _chosenColor; 
                chkColor.Checked = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.FormColor = _chosenColor;
            Settings.Default.FormWidth = this.Width;
            Settings.Default.FormHeight = this.Height;
            Settings.Default.ShowColor = chkColor.Checked;  
            Settings.Default.Save();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();    
            dlg.ShowDialog();  
            _chosenColor = dlg.Color;   
        }
    }
}
