using System;
using System.Linq;

namespace Store.Memory
{
    public class DetailRepository : IDetailRepository
    {
        private readonly Detail[] detail = new[]
        {
            new Detail(1, "Ремонтный к-т направляющей суппорта"),
            new Detail(2, "Диск тормозной задний"),
            new Detail(3, "Колодки дисковые"),
        };
        public Detail[] GetAllByTitle(string titlePart)
        {
            return detail.Where(detail => detail.Title.Contains(titlePart)).ToArray();
        }
    }
}
