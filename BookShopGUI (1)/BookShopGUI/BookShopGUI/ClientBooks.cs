using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopGUI
{
    public class ClientBooks
    {
        public List<KeyValuePair<int, double>> readBooks = new List<KeyValuePair<int, double>>();

        public void AddBook(int id, double rating)
        {
            readBooks.Add(new KeyValuePair<int, double> (id, rating));
        }

        public void AddBook(int id)
        {
            readBooks.Add(new KeyValuePair<int, double>(id, 1));
        }

        public void AddRating(int id, double rating)
        {
            var target_idx = readBooks.FindIndex(n => n.Key.Equals(id));
            KeyValuePair<int, double> newRating = new KeyValuePair<int, double>(id, rating);
            readBooks[target_idx] = newRating;
        }

    }


}
