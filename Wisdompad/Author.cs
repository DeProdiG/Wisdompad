﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.DataFormats;

namespace Wisdompad
{
    public partial class Author : Form
    {
        private Form1 _mainForm;
        public Author()
        {
            InitializeComponent();
            _mainForm = new Form1(); 
            _mainForm.Hide(); 
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            _mainForm.Show();
        }
    }
}
