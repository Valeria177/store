using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.EF
{
    class DetailRepository : IDetailRepository
    {
        public Detail[] GetAllByIds(IEnumerable<int> detailIds)
        {
            throw new NotImplementedException();
        }

        public Detail[] GetAllByPart_number(string part_number)
        {
            throw new NotImplementedException();
        }

        public Detail[] GetAllByTitleOrCompany(string titleOrCompany)
        {
            throw new NotImplementedException();
        }

        public Detail GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
