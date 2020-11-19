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

        public Detail(int id, string part_number, string company, string title)
        {
            Id = id;
            Part_number = part_number;
            Company = company;
            Title = title;
        }

        internal static bool IsPart_number(string s)
        {
            if (s == null)
                return false;

            s = s.Replace("-", "").Replace(" ", "").ToUpper();

            return Regex.IsMatch(s, "\\d{9}");
        }
    }
}
