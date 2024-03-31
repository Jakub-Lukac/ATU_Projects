using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Challenge
{
    public class Basket
    {
        private List<Product> _items;
        public Basket()
        {
            _items = new List<Product>();
        }
        public List<Product> Items { get => _items; set => _items = value; }


        // Add item to basket
        public void AddItem(Product product)
        {
            // checking if it contains the product
            bool contains = false;
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Id == product.Id)
                {
                    contains = true;
                }
            }

            // if contains we need to find the match
            if (contains)
            {
                // find the match
                for (int i = 0; i < _items.Count; i++)
                {
                    if (_items[i].Id == product.Id)
                    {
                        _items[i].Quantity += product.Quantity;
                    }
                }
            }
            // if it does not contain append new product to the list
            else
            {
                _items.Add(product);
            }
        }

        // Display report
        public void DisplayReport(List<string> basketHeader)
        {
            const int margin = -30;
            for (int i = 0; i < basketHeader.Count; i++)
            {
                Console.Write($"{basketHeader[i],margin}");
            }
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"{_items[i].Id + 1,margin}{_items[i].Name,margin}{_items[i].Quantity,margin}{_items[i].GetTotalPrice(),margin}");
            }
        }

        // Calculate Total value of the Basket

        public double CalculateTotal()
        {
            double total = 0;
            for (int i = 0; i < _items.Count; i++)
            {
                total += _items[i].GetTotalPrice();
            }
            return total;
        }
    }
}
