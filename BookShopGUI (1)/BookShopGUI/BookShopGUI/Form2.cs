using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopGUI
{
    public partial class Form2 : Form
    {
        public static ClientBooks clientBooksRatings = new ClientBooks();
        public Form2()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Properties.Resources.DALLE2022CozyLibrary;
            BackgroundImageLayout = ImageLayout.Stretch;

            foreach (Carte b in Form1.listOfReadBooks)
            {
                clientBooksRatings.AddBook(b.id);
            }

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            string[] lines = File.ReadAllLines("./chosenBooks.txt");

            int x = 100;
            int y = 150;

            int n = lines.Length;
            foreach (string line in lines)
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Font = new Font("Microsoft Sans Serif", 14);
                label.Text = line;
                label.Location = new Point(x, y);

                /*
                NumericUpDown numUpDown = new NumericUpDown();
                //numUpDown.Name = "numUpDown" + n;
                numUpDown.Minimum = 1;
                numUpDown.Maximum = 5;
                numUpDown.Font = new Font("Microsoft Sans Serif", 14);
                numUpDown.Size = new Size(120, 40);
                numUpDown.AutoSize = false;
                numUpDown.Location = new Point(this.Width - numUpDown.Width - 2 * x, y);
                 */
                this.Controls.Add(label);
                //this.Controls.Add(numUpDown);
                //
                //n++;

                
                y += label.Height + 50;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
            //this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            clientBooksRatings.AddRating(Form1.listOfReadBooks[0].id, Convert.ToDouble(numericUpDown1.Value));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            clientBooksRatings.AddRating(Form1.listOfReadBooks[1].id, Convert.ToDouble(numericUpDown2.Value));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            clientBooksRatings.AddRating(Form1.listOfReadBooks[2].id, Convert.ToDouble(numericUpDown3.Value));
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            clientBooksRatings.AddRating(Form1.listOfReadBooks[3].id, Convert.ToDouble(numericUpDown4.Value));
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            clientBooksRatings.AddRating(Form1.listOfReadBooks[4].id, Convert.ToDouble(numericUpDown5.Value));
        }
    }
}
