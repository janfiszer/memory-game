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
    public partial class GamePlay : Form
    {
        Random random = new Random();

        private Form1 form1;
        private int points;
        private int guessedCards = 0;
        List<String> symbols = new List<String>()
         {
        "a", "a", "d", "d", "e", "e", "h", "h",
        "b", "b", "c", "c", "f", "f", "g", "g"
         };
        Label firstClickedCard = null;
        Label secondClickedCard = null;


        public GamePlay(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            label1.Text = form1.Nick + " is playing!";
            reset();
            debugging_shit.Text = form1.UnfoldedTime.ToString();
            timer1.Interval = form1.UnfoldedTime;
        }

        private void reset()
        {
            symbols = new List<String>
            {
            "a", "a", "d", "d", "e", "e", "h", "h",
            "b", "b", "c", "c", "f", "f", "g", "g"
            };
            points_label.Text = "0";
            guessedCards = 0;
            points = 0;
            firstClickedCard = null;
            secondClickedCard = null;
            ShuffleSquarse();
            unfoldAllCards();
            timer2.Start();
        }

        private void ShuffleSquarse()
        {
            foreach (Control card in all_cards.Controls)
            {
                Label symbolLabel = card as Label;
                if (symbolLabel != null)
                {
                    int randomIndex = random.Next(symbols.Count);
                    symbolLabel.Text = symbols[randomIndex];
                    symbols.RemoveAt(randomIndex);
                }
            }
        }
        
        private void card_Click(object sender, EventArgs e)
        {
            Label clickedCard = sender as Label;
            if (clickedCard != null)
            {
                if (already_choosen(clickedCard) || already_guessed(clickedCard) )
                    return;
                //MessageBox.Show("clicked", "lelele");
                if (firstClickedCard == null)
                {
                    firstClickedCard = clickedCard;
                    clickedCard.ForeColor = Color.White;

                    return;
                }
                if (secondClickedCard == null)
                {
                    secondClickedCard = clickedCard;
                    clickedCard.ForeColor = Color.White;

                    timer1.Enabled = true;
                }
            }
        }
        private void unfoldAllCards()
        {
            foreach(Control card in all_cards.Controls)
            {
                Label symbolLabel = card as Label;
                symbolLabel.ForeColor = Color.White;
            }
        }

        private bool already_guessed(Label clickedcard)
        {
            return clickedcard.ForeColor == this.BackColor;
        }

        private bool already_choosen(Label clickedcard)
        {
            return clickedcard.ForeColor == Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();
            // Checking if are cards the same
            if (firstClickedCard.Text.Equals(secondClickedCard.Text))
            {
                firstClickedCard.ForeColor = Color.White;
                secondClickedCard.ForeColor = Color.White;
                points += (10000 / form1.UnfoldedTime);
                guessedCards++;
            }
            else
            {
                firstClickedCard.ForeColor = firstClickedCard.BackColor;
                secondClickedCard.ForeColor = secondClickedCard.BackColor;
                points -= form1.UnfoldedTime / 1000;
            }
            points_label.Text = points.ToString();

            // GAME ENDED scenario 
            if (guessedCards == 8)
            {
                gameEndedAction();
            }

            firstClickedCard = null;
            secondClickedCard = null;
        }
        private void gameEndedAction()
        {
            form1.addToRanking((form1.Nick, points));
            form1.rankingToFile();
            string message = form1.Nick + ", Your score is: " + points;
            MessageBox.Show(message, "GAME ENDED");
            StringBuilder sb = new StringBuilder();
            List<(string, int)> r = new List<(string, int)>();
            r = form1.Ranking;
            for (int i = 0; i < r.Count; ++i)
            {
                sb.Append(r[i].Item1 + " " + r[i].Item2 + "\n");
            }
            debugging_shit.Text = sb.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            foreach (Control card in all_cards.Controls)
            {
                Label symbolLabel = card as Label;
                symbolLabel.ForeColor = symbolLabel.BackColor;
            }
        }

        private void play_again_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reshuffling cards...", "Game started again");
            reset();
        }

        private void toMenu_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                unfoldAllCards();
            else
            {
                foreach (Control card in all_cards.Controls)
                {
                    Label symbolLabel = card as Label;
                    symbolLabel.ForeColor = symbolLabel.BackColor;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guessedCards = 7;
        }
    }
}
