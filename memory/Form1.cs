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

        Settings settings;
        private String nick; 
        private int unfolded_time = 1000;
        private int start_time = 3000;

        GamePlay gamePlay;

        Ranking ranking_window;

        public Settings Settings
        {
            get { return settings; }
            set { settings = value; }
        }
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
        public int StartTime
        {
            get { return start_time; }
            set { start_time = value; }
        }
        public List<(string, int)> Ranking
        {
            get { return ranking; }
            set { ranking = value; }
        }
        public Form1()
        {
            InitializeComponent();
            loadRankingFromFile();

            settings = new Settings();
        }
        private void loadRankingFromFile()
        {
            try
            {
                foreach (string line in System.IO.File.ReadLines("ranking.txt"))
                {
                    string[] split = line.Split(' ');
                    ranking.Add((split[0], Int32.Parse(split[1])));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Haven't load ranking propeply!\n" + ex);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                nick = textBox1.Text;
                settings.Nick = nick;

                if (radioButton1.Checked == true)
                {
                    settings.level = Level.EASY;
                }
                if (radioButton2.Checked == true)
                {
                    settings.level = Level.MEDIUM;
                }
                if (radioButton3.Checked == true)
                {
                    settings.level = Level.HARD;
                }
                if (settings.level == 0)
                {
                    MessageBox.Show("Choose a difficulty level", "Unable to start the game");
                    return;
                }

                settings.Unfolded_time = unfolded_time;
                settings.Start_time = start_time;

                gamePlay = new GamePlay(this, settings);
                gamePlay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No nickname entered", "Unable to start the game", MessageBoxButtons.OK);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ranking_window = new Ranking(this);

            ranking_window.Show();

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
        private void button2_increase_Click(object sender, EventArgs e)
        {
            if (button2_deacrease.Enabled == false)
            {
                button2_deacrease.Enabled = true;
            }
            start_time += 100;
            label5.Text = start_time.ToString();
        }
        private void button2_deacrease_Click(object sender, EventArgs e)
        {
            if (start_time > 100)
            {
                start_time -= 100;
                label5.Text = start_time.ToString();
                if (start_time == 100)
                {
                    button2_deacrease.Enabled = false;
                }
            }
        }
        // Adds to ranking sorted in correct place
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
                    ranking.Insert(i, score);
                    return;
                }
            }
        }
        public void rankingToFile()
        {
            StringBuilder to_file = new StringBuilder();
            foreach ((string, int) s in ranking)
            {
                to_file.AppendLine(s.Item1 + " " + s.Item2.ToString());
            }
            File.WriteAllText("ranking.txt", to_file.ToString());
        }
    }
}
