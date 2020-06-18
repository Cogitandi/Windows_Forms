﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicutreViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(stretchCheckBox.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            } else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Close app
            this.Close();
        }


        private void backgroundColor_Click(object sender, EventArgs e)
        {
            // Open dialog for choose color, if correctly choosed
            // set background color
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // clear visible image
            pictureBox1.Image = null;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // Open dialog for choose file
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // If file choosed load picture to box
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }
    }
}
