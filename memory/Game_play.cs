using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace memory
{
    public partial class Game_play : UserControl
    {
        public Game_play()
        {
            InitializeComponent();
        }
        private void card_Click(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            if (clickedCard != null)
            {
                clickedCard.Visible = false; 
                //Thread.Sleep(unfolded_time);
                clickedCard.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
