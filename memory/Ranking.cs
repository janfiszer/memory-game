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
        }

        private void toMenu_button_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<(string, int)> r = new List<(string, int)>();
            r = form1.Ranking;
            for (int i = 0; i < r.Count; ++i)
            {
                sb.Append(r[i].Item1 + " " + r[i].Item2 + "\n");
            }
            label1.Text = sb.ToString();
        }
    }
}
