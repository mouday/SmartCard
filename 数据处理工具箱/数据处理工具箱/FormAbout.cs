﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SocialDataMerge
{
    public partial class FormAbout : Form
    {
        public string text;
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            lblText.Text = text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
