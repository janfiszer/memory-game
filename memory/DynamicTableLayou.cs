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
    public partial class DynamicTableLayou : Form
    {
        System.Windows.Forms.TableLayoutPanel all_cards;
        private Label label4;
        private Label label5;
        Label label6;
        Label label7;
        Label label8;
        Label label9;
        Label label10;
        Label label11;
        Label label12;
        Label label13;
        Label label14;
        Label label15;
        Label label16;
        Label label17;
        Label label18;
        Label label19;
        Label label20;
        Label label21;
        Label label22;
        Label label23;

        List<Label> labels = new List<Label>();


        Random random = new Random();
        List<String> symbols;


        readonly int cardSize = 100;

        public List<Label> Labels { get => Labels1; set => Labels1 = value; }
        public List<Label> Labels1 { get => labels; set => labels = value; }

        public DynamicTableLayou()
        {
            int size = 4;
            InitializeComponent();
            symbols = new List<String>
            {
            "a", "a", "d", "d", "e", "e", "h", "h", "i", "i",
            "b", "b", "c", "c", "f", "f", "g", "g", "j", "j"
            };
            symbols = symbols.GetRange(0, size * 4);

            createTable(size);

            ShuffleSquarse();

        }
        private void button1_Click(object sender, EventArgs e)
        {

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
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Wingdings", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //this.label4.Click += new System.EventHandler(this.card_Click);
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

            this.all_cards = new System.Windows.Forms.TableLayoutPanel();
            this.all_cards.AccessibleDescription = "public";
            this.all_cards.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.all_cards.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.all_cards.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.all_cards.CausesValidation = false;
            this.all_cards.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;

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
            /*//this.all_cards.Controls.Add(this.label19, 3, 3);
            this.all_cards.Controls.Add(this.label18, 2, 3);
            this.all_cards.Controls.Add(this.label17, 1, 3);
            this.all_cards.Controls.Add(this.label16, 0, 3);
            //this.all_cards.Controls.Add(this.label15, 3, 2);
            this.all_cards.Controls.Add(this.label14, 2, 2);
            this.all_cards.Controls.Add(this.label13, 1, 2);
            this.all_cards.Controls.Add(this.label12, 0, 2);
            //this.all_cards.Controls.Add(this.label11, 3, 1);
            this.all_cards.Controls.Add(this.label10, 2, 1);
            this.all_cards.Controls.Add(this.label9, 1, 1);
            this.all_cards.Controls.Add(this.label8, 0, 1);
            //this.all_cards.Controls.Add(this.label7, 3, 0);
            this.all_cards.Controls.Add(this.label6, 2, 0);
            this.all_cards.Controls.Add(this.label5, 1, 0);
            this.all_cards.Controls.Add(this.label4, 0, 0);*/
            this.all_cards.Location = new System.Drawing.Point(267, 27);
            this.all_cards.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.all_cards.Name = "all_cards";
            this.all_cards.RowCount = 4;
            this.all_cards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute,cardSize));
            this.all_cards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, cardSize));
            this.all_cards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, cardSize));
            this.all_cards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, cardSize));

            this.all_cards.Size = new System.Drawing.Size((size*cardSize)+((size - 1)*4) , 4 * cardSize + 3 * 4);
            this.all_cards.TabIndex = 44;

            this.Controls.Add(this.all_cards);


        }

        private void ShuffleSquarse()
        {
            foreach (Control card in all_cards.Controls)
            {
                Label symbolLabel = card as Label;
                // TODO: make it smoother
                if (symbolLabel != null)
                {
                    int randomIndex = random.Next(symbols.Count);
                    symbolLabel.Text = symbols[randomIndex];
                    symbols.RemoveAt(randomIndex);
                }
            }
        }
    }
}
