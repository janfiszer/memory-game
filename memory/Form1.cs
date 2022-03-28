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
        List<(string, int)> ranking = new List<(string, int)> ();
        private String nick; 
        private int unfolded_time = 2000;
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
                //(string, int) to_add = (textBox1.Text, 0);
                //ranking.Add(to_add);
            }
            else
            {
                MessageBox.Show("No nickname entered", "Unable to start the game");
            }
        }
        private void increase_button_Click(object sender, EventArgs e)
        {
            unfolded_time += 100;
            label1.Text = unfolded_time.ToString();
        }

        private void decrease_button_Click(object sender, EventArgs e)
        {
            unfolded_time -= 100;
            label1.Text = unfolded_time.ToString();
        }

        public void addToRanking((string, int) score)
        {
            for (int i = 0; i < ranking.Count; i++)
            {
                if (score.Item2 > ranking[i].Item2)
                {
                    //adding to growen the list
                    ranking.Add(("empty", 0));
                    // making place for new record
                    for (int j = ranking.Count - 1; j > i ; j--)
                    {
                        ranking[j] = ranking[j - 1];
                    }
                    ranking.Insert(i, score);
                    return;
                }
            }
            //ranking.Add(score);
        }
        private void rankingToFile()
        {
            StringBuilder to_file = new StringBuilder();
            foreach ((string, int) s in ranking)
            {
                //to_file.AppendLine(ranking.IndexOf(s) + ". " + s.Item1 + " " + score.ToString());
                to_file.AppendLine(s.Item1 + " " + s.Item2.ToString());
            }
            File.WriteAllText("ranking.txt", to_file.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.rankingToFile();
            ranking_window = new Ranking(this);
            //ranking_window.Activate();
            ranking_window.Show();
        }
    }
}
