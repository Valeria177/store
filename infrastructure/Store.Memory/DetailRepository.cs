using System;
using System.Linq;

namespace Store.Memory
{
    public class DetailRepository : IDetailRepository
    {
        private readonly Detail[] details = new[]
        {
            new Detail(1,"058133843","Россия", "Фильтр воздушный"),
            new Detail(2, "028127435B", "Россия","Фильтр топливный"),
            new Detail(3, "8E0698451L","Россия" ,"Колодки тормозные"),
            new Detail(4,"N10140105","Китай", "Свеча накаливания"),
            new Detail(5, "71769481", "Россия","Тормозной диск, задний"),
            new Detail(6, "46423415","Россия" ,"Тормозной диск, передний"),
        };

        public Detail[] GetAllByPart_number(string part_number)
        {
            return details.Where(detail => detail.Part_number == part_number).ToArray();
        }

        public Detail[] GetAllByTitleOrCompany(string query)
        {
            return details.Where(detail => detail.Title.Contains(query)||detail.Company.Contains(query)).ToArray();

        }

    }
}
