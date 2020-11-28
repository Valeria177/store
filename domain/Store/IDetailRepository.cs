using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public interface IDetailRepository
    {

        Detail[] GetAllByPart_number(string part_number);
        Detail[] GetAllByTitleOrCompany(string titleOrCompany);
        Detail GetById(int id);
        Detail[] GetAllByIds(IEnumerable<int> detailIds);
    }
}
