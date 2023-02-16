using BookShopGUI.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopGUI
{
    public partial class Form1 : Form
    {
        public static List<Carte> listOfProducts = new List<Carte>();
        public static List<Carte> listOfReadBooks = new List<Carte>();
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Properties.Resources.DALLE2022CozyLibrary;
            BackgroundImageLayout = ImageLayout.Stretch;
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Create a list of objects to display in the list
            listOfProducts.Add(new Carte(0, "Colt alb", "Jack London"));
            listOfProducts.Add(new Carte(1, "Ion", "Liviu Rebreanu"));
            listOfProducts.Add(new Carte(2, "Mara", "Ioan Slavici"));
            listOfProducts.Add(new Carte(3, "Luceafarul", "Mihai Eminescu"));
            listOfProducts.Add(new Carte(4, "Amintiri din copilarie", "Ion Creanga"));
            listOfProducts.Add(new Carte(5, "Doua lozuri", "I. L. Caragiale"));
            listOfProducts.Add(new Carte(6, "Plumb", "George Bacovia"));
            listOfProducts.Add(new Carte(7, "The Call of the Wild", "Jack London"));
            listOfProducts.Add(new Carte(8, "To Build a Fire", "Jack London"));
            listOfProducts.Add(new Carte(9, "The Sea Wolf", "Jack London"));
            listOfProducts.Add(new Carte(10, "Love of Life", "Jack London"));
            listOfProducts.Add(new Carte(11, "Capitan la cincisprezece ani", "Jules Verne"));
            listOfProducts.Add(new Carte(12, "Ocolul pamantului in optzeci de zile", "Jules Verne"));
            listOfProducts.Add(new Carte(13, "O calatorie spre centrul pamantului", "Jules Verne"));
            listOfProducts.Add(new Carte(14, "Fratii Ki", "Jules Verne"));
            listOfProducts.Add(new Carte(15, "Mihail Strogoff", "Jules Verne"));
            listOfProducts.Add(new Carte(16, "Cinci saptamani in balon", "Jules Verne"));
            listOfProducts.Add(new Carte(17, "Invitatie la vals", "Mihail Drumes"));

            // Set the list as the data source for the checked list box
            checkedListBox1.DataSource = listOfProducts;
            checkedListBox1.DisplayMember = "titleAndAuthor";
            checkedListBox1.ValueMember = "Id";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
            //this.Close();

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 5)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

            Carte book = (Carte)checkedListBox1.SelectedItem;
            bool isChecked = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);

            if (isChecked)
            {
                listOfReadBooks.Add(book);
            }
            else
            {
                listOfReadBooks.Remove(book);
            }

            System.IO.StreamWriter writer = new System.IO.StreamWriter("./chosenBooks.txt"); //open the file for writing in /bin/Debug

            foreach( Carte item in listOfReadBooks)
            {
                writer.Write($"{item.titleAndAuthor}\r\n");
            }
            writer.Close(); //remember to close the file again.
            writer.Dispose(); //remember to dispose it from the memory.

        }
    }
}

