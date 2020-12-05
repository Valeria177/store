using System;
using System.Text.RegularExpressions;

namespace Store
{
    public class Detail
    {
        public int Id { get; }

        public string Part_number { get; }

        public string Company { get; }

        public string Title { get; }

        public string Description { get; }

        public decimal Price { get; }

        public Detail(int id, string part_number, string company, string title, string description, decimal price)
        {
            Id = id;
            Part_number = part_number;
            Company = company;
            Title = title;
            Description = description;
            Price = price;
        }

        internal static bool IsPart_number(string s)
        {
            if (s == null)
                return false;
            //s = s.Replace(" ", "").Replace("-", "");

            return Regex.IsMatch(s, "\\d{9}");
        }
    }
}
