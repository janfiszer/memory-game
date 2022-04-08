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
using System.IO;

namespace memory
{
    public partial class Form1 : Form
    {
        int y = 0;
        List<(string, int)> ranking = new List<(string, int)> ();
        private String nick; 
        private int unfolded_time = 2000;
        private int start_time = 0;
        GamePlay gamePlay;
        Ranking ranking_window;

        public String Nick
        {
            get { return nick; }
            set { nick = value; }
        }
        public int UnfoldedTime
        {
            get { return unfolded_time; }
            set { unfolded_time = value; }
        }
        public List<(string, int)> Ranking
        {
            get { return ranking; }
            set { ranking = value; }
        }
        public Form1()
        {
            InitializeComponent();
            loadRanking();
        }
        private void loadRanking()
        {
            foreach(string line in System.IO.File.ReadLines("ranking.txt"))
            {
                string [] split = line.Split(' ');
                ranking.Add((split[0], Int32.Parse(split[1])));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                nick = textBox1.Text;
                gamePlay = new GamePlay(this);
                //gamePlay.Activate();
                gamePlay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No nickname entered", "Unable to start the game");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ranking_window = new Ranking(this);
            //ranking_window.Activate();
            ranking_window.Show();
            timer1.Enabled = true;
            this.Hide();
        }
        private void increase_button_Click(object sender, EventArgs e)
        {
            if (decrease_button.Enabled == false)
            {
                decrease_button.Enabled = true;
            }
            unfolded_time += 100;
            label1.Text = unfolded_time.ToString();
        }

        private void decrease_button_Click(object sender, EventArgs e)
        {
            if (unfolded_time > 100)
            {
                unfolded_time -= 100;
                label1.Text = unfolded_time.ToString();
                if (unfolded_time == 100)
                {
                    decrease_button.Enabled = false;
                }
            }
        }
        public void addToRanking((string, int) score)
        {
            // checking if it should be at the end of the ranking
            if (score.Item2 <= ranking[ranking.Count - 1].Item2)
            {
                ranking.Add(score);
                return;
            }
            for (int i = 0; i < ranking.Count; i++)
            {
                if (score.Item2 >= ranking[i].Item2)
                {
                    //adding to growen the list
                    //ranking.Add(("empty", 0));
                    //// making place for new record
                    //for (int j = ranking.Count - 1; j > i ; j--)
                    //{
                    //    ranking[j] = ranking[j - 1];
                    //}
                    ranking.Insert(i, score);
                    return;
                }
            }
            //ranking.Add(score);
        }
        public void rankingToFile()
        {
            StringBuilder to_file = new StringBuilder();
            foreach ((string, int) s in ranking)
            {
                //to_file.AppendLine(ranking.IndexOf(s) + ". " + s.Item1 + " " + score.ToString());
                to_file.AppendLine(s.Item1 + " " + s.Item2.ToString());
            }
            File.WriteAllText("ranking.txt", to_file.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ranking_window == null)
            {
                MessageBox.Show("zakmniete");
            }
            //if (ranking_window.IsAccessible && gamePlay.IsAccessible)
            //{
            //    this.Show();
            //    y++;
            //    label4.Text = y.ToString();
            //}
        }
    }
}
