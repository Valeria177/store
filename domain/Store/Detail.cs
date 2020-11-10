using System;

namespace Store
{
    public class Detail
    {
        public int Id { get; }
        public string Title { get; }

        public Detail(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
