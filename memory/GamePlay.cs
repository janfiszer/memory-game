﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace memory
{
    public partial class GamePlay : Form
    {
        Random random = new Random();

        public static readonly int cardSize = 100;

        // TABLE REPRESENTING CARDS
        System.Windows.Forms.TableLayoutPanel all_cards;

        // TABLE CONECTED LABELS
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        List<Label> labels = new List<Label>();

        Settings settings;

        private Form1 form1;
        private int points;
        private int guessedCards = 0;
        private int centyseconds = 0;
        List<String> symbols;
        Label firstClickedCard = null;
        Label secondClickedCard = null;

        public GamePlay(Form1 form1, Settings settings)
        {
            InitializeComponent();

            this.settings = settings;

            this.Location = form1.Location;
            this.Size = form1.Size;
            this.form1 = form1;

            label1.Text = settings.Nick + " is playing!";
            timer1.Interval = settings.Unfolded_time;
            timer2.Interval = settings.Start_time;

            startGameAction();

        }

        private void startGameAction()
        {
            // In Wingdings font those letter looks fancy... Good enough for memory game
            symbols = new List<String>
            {
            "a", "a", "d", "d", "e", "e", "h", "h", "i", "i",
            "b", "b", "c", "c", "f", "f", "g", "g", "j", "j"
            };
            symbols = symbols.GetRange(0, (int)this.settings.level * 4);

            // PLAY AGAIN SYNERIO 
            // We don't want to create table if we did it before
            if (labels.Count == 0)
            {
                createTable((int)this.settings.level);
            }

            points_label.Text = "0";
            time_label.Text = "0";
            guessedCards = 0;
            points = 0;
            centyseconds = 0;
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
                if (timer3.Enabled == false)
                {
                    MessageBox.Show("Game paused, resume to continue playing");
                    return;
                }

                if (already_choosen(clickedCard) || already_guessed(clickedCard) )
                    return;

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

                    // Checking if are cards the same
                    if (firstClickedCard.Text.Equals(secondClickedCard.Text))
                    {
                        cardsGuessedRight();
                    }
                    else
                    {
                        // cards weren't guessed right
                        timer1.Enabled = true;
                    }
                    points_label.Text = points.ToString();
                }
            }
        }

        private void cardsGuessedRight()
        {
            firstClickedCard.ForeColor = Color.White;
            secondClickedCard.ForeColor = Color.White;
            points += (10000 / settings.Unfolded_time);
            guessedCards++;

            // GAME ENDED scenario 
            if (guessedCards == (int)this.settings.level * 2)
            {
                gameEndedAction();
            }
            // TODO: make those null just once
            firstClickedCard = null;
            secondClickedCard = null;
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
            timer1.Stop();

            firstClickedCard.ForeColor = firstClickedCard.BackColor;
            secondClickedCard.ForeColor = secondClickedCard.BackColor;
            points -= settings.Unfolded_time / 500;

            // TODO: make those null just once
            firstClickedCard = null;
            secondClickedCard = null;
        }
        private void calculatingPionts()
        {
            points *= 1000;
            points /= centyseconds;
            points -= settings.Start_time / 1000;
            points *= ((int)this.settings.level - 2);
        }
        private void gameEndedAction()
        {
            calculatingPionts();

            form1.addToRanking((settings.Nick, points));
            timer3.Stop();
            string message = settings.Nick + ", Your score is (after taking time to consideration): " + points;
            MessageBox.Show(message, "GAME ENDED");
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            foreach (Control card in all_cards.Controls)
            {
                Label symbolLabel = card as Label;
                symbolLabel.ForeColor = symbolLabel.BackColor;
            }
            timer3.Start();
        }
        private void play_again_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reshuffling cards...", "Game started again");
            // BIG TODO: MAKE IT SOMEHOW BETTER
            //Thread.Sleep(3000);

            startGameAction();
        }

        private void toMenu_button_Click(object sender, EventArgs e)
        {
            form1.rankingToFile();
            form1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer3.Enabled == false)
            {
                timer3.Start();
                button1.Text = "PAUSE";
            }
            else
            {
                timer3.Stop();
                button1.Text = "RESUME";
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            centyseconds++;
            seconds_label.Text = centyseconds.ToString();
        }
        private void Closed(object sender, FormClosedEventArgs e)
        {
            form1.rankingToFile();
            form1.Show();
        }
        private void setLabelProprties(Label label)
        {
            label.AutoSize = true;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.Font = new System.Drawing.Font("Wingdings", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.Click += new System.EventHandler(this.card_Click);
        }
        private void createTable(int size)
        {
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();

            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            labels.Add(label10);
            labels.Add(label11);
            labels.Add(label12);
            labels.Add(label13);
            labels.Add(label14);
            labels.Add(label15);
            if (size > 3)
            {
                labels.Add(label16);
                labels.Add(label17);
                labels.Add(label18);
                labels.Add(label19);
            }
            if (size > 4)
            {
                labels.Add(label20);
                labels.Add(label21);
                labels.Add(label22);
                labels.Add(label23);
            }
            foreach (Label label in labels)
            {
                setLabelProprties(label);
            }

            this.all_cards = new TableLayoutPanel();
            this.all_cards.AccessibleDescription = "public";
            this.all_cards.AccessibleRole = AccessibleRole.None;
            this.all_cards.Anchor = AnchorStyles.Top;
            this.all_cards.BackColor = SystemColors.ActiveCaption;
            this.all_cards.CausesValidation = false;
            this.all_cards.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;

            this.all_cards.ColumnCount = size;
            for (int i = 0; i < size; i++)
            {
                this.all_cards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, cardSize));

            }

            int column = 0, row = 0;
            foreach (Label label in labels)
            {
                if (column >= size - 1)
                {
                    column = 0;
                    row++;
                }
                this.all_cards.Controls.Add(label, column, row);
            }

            this.all_cards.Location = new System.Drawing.Point(300, 27);
            this.all_cards.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.all_cards.Name = "all_cards";
            this.all_cards.RowCount = 4;
            this.all_cards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, cardSize));
            this.all_cards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, cardSize));
            this.all_cards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, cardSize));
            this.all_cards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, cardSize));

            this.all_cards.Size = new System.Drawing.Size((size * cardSize) + ((size - 1) * 4), 4 * cardSize + 4 * 4);
            this.all_cards.TabIndex = 44;
            this.all_cards.Location = new Point(159, 25);


            this.Controls.Add(this.all_cards);
        }
    }
}
