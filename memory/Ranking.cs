using System;
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
    public partial class Ranking : Form
    {
        Form1 form1;
        public Ranking(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            showRanking();

        }
        private void showRanking()
        {
            StringBuilder sb = new StringBuilder();
            List<(string, int)> r = new List<(string, int)>();
            r = form1.Ranking;
            for (int i = 1; i <= r.Count; ++i)
            {
                sb.Append(i + ". " + r[i-1].Item1 + "  " + r[i-1].Item2 + "\n");
            }
            label1.Text = sb.ToString();
        }
        private void toMenu_button_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
    }
}
