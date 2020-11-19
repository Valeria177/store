using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public class DetailService
    {

        private readonly IDetailRepository detailRepository;

        public DetailService(IDetailRepository detailRepository)
        {
            this.detailRepository = detailRepository;
        }
        public Detail[] GetAllByQuery(string query)
        {
            if (Detail.IsPart_number(query))
                return detailRepository.GetAllByPart_number(query);

            return detailRepository.GetAllByTitleOrCompany(query);
        }
    }
}
