﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memory
{
    public partial class Form1 : Form
    {
        PictureBox pictureBox1 = new PictureBox();

        public Form1()
        {
            InitializeComponent();
            game_play1.Show();
        }
        private void card_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            if (clickedCard != null)
            {
                clickedCard.Visible = false;
            }

        }

    }
}