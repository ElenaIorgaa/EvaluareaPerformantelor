using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookShopGUI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Properties.Resources.DALLE2022CozyLibrary;
            BackgroundImageLayout = ImageLayout.Stretch;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Create a list of images and labels
            List<Tuple<Image, string>> imageList = new List<Tuple<Image, string>>()
            {
                Tuple.Create(Image.FromFile("../../Resources/5saptamaniinbalon.png"), "Cinci săptamâni în balon " + Environment.NewLine + "- Jules Verne"),
                Tuple.Create(Image.FromFile("../../Resources/amintiridincopilarie.png"), "Amintiri din copilărie " + Environment.NewLine + "- Ion Creangă"),
                Tuple.Create(Image.FromFile("../../Resources/calatoriesprecentrulpamantului.png"), "O calatorie spre centrul pamantului " + Environment.NewLine + "- Jules Verne"),
                Tuple.Create(Image.FromFile("../../Resources/capitanla15ani.png"), "Căpitan la cincisprezece ani " + Environment.NewLine +  "- Jules Verne "),
                Tuple.Create(Image.FromFile("../../Resources/coltalb.png"), "Colț alb" + Environment.NewLine + "- Jack London"),
                Tuple.Create(Image.FromFile("../../Resources/doualozuri.png"), "Două lozuri" + Environment.NewLine + "- I. L. Caragiale" ),
                Tuple.Create(Image.FromFile("../../Resources/fratiikip.png"), "Frații Kip" + Environment.NewLine + "- Jules Verne"),
                Tuple.Create(Image.FromFile("../../Resources/invitatialavals.png"), "Invitația la vals" + Environment.NewLine + "- Mihail Drumeș"),
                Tuple.Create(Image.FromFile("../../Resources/ion.png"), "Ion" + Environment.NewLine + "- Liviu Rebreanu" ),
                Tuple.Create(Image.FromFile("../../Resources/loveoflife.png"), "Love of life" + Environment.NewLine + "- Jack London" ),
                Tuple.Create(Image.FromFile("../../Resources/luceafarul.png"), "Luceafărul" + Environment.NewLine + "- Mihai Eminescu"),
                Tuple.Create(Image.FromFile("../../Resources/mara.png"), "Mara" + Environment.NewLine + "- Ioan Slavici"),
                Tuple.Create(Image.FromFile("../../Resources/mihailstrogoff.png"), "Mihail Strogoff" + Environment.NewLine + "- Jules Verne"),
                Tuple.Create(Image.FromFile("../../Resources/ocolulpamantului.png"), "Ocolul pamantului in optzeci de zile" + Environment.NewLine + "- Jules Verne" ),
                Tuple.Create(Image.FromFile("../../Resources/plumb.png"), "Plumb" + Environment.NewLine + "- George Bacovia"),
                Tuple.Create(Image.FromFile("../../Resources/callofthewild.png"), "The call of the wild" + Environment.NewLine + "- Jack London"),
                Tuple.Create(Image.FromFile("../../Resources/theseawolf.png"), "The sea wolf" + Environment.NewLine + "- Jack London"),
                Tuple.Create(Image.FromFile("../../Resources/tobuildafire.png"), "To build a fire" + Environment.NewLine + "- Jack London")

            };
            button1.Enabled = true;

            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.RowCount = (imageList.Count / tableLayoutPanel1.ColumnCount) * 2;


            tableLayoutPanel1.AutoScroll = true;
            int idx = 0;
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.RowCount; j += 2)
                {

                    // Create a PictureBox and set its Image property
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = imageList[idx].Item1;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Dock = DockStyle.Fill;

                    // Create a Label and set its Text property
                    Label label = new Label();
                    label.Text = imageList[idx].Item2;
                    label.Dock = DockStyle.Fill;
                    idx++;


                    tableLayoutPanel1.Controls.Add(pictureBox, i, j);
                    tableLayoutPanel1.Controls.Add(label, i, j + 1);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int noOfItems = Form1.listOfProducts.Count;
            int noOfUsers = 10;
            int populationCount = 50;
            int maxNrOfGenerations = 6000;
            int CR = 30;
            double F = 0.9;
            Random rand = new Random();
            double[][] userRatings = new double[noOfUsers][];
            double[] itemWeights = new double[noOfItems];

            String carteRecomandata = Rezolvare.Recommend(noOfItems, noOfUsers, maxNrOfGenerations, CR, F, userRatings, Form2.clientBooksRatings.readBooks, populationCount, Form1.listOfProducts);
            textBox1.Text = "Recomandam cartea " + carteRecomandata;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
