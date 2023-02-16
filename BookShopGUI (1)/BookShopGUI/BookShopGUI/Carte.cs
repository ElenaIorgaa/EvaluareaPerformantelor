using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopGUI
{
    public class Carte
    {
        public int id { get; set; }
        public string name { get; set; }
        public string author { get; set; }

        public string titleAndAuthor { get; set; }
        public Carte(int id, string name, string author)
        {
            this.id = id;
            this.name = name;
            this.author = author;

            titleAndAuthor = name + " - " + author;
        }
    }
}
