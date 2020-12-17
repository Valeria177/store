using Store.Web.App;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public DetailModel GetById(int id)
        {
            var detail = detailRepository.GetById(id);

            return Map(detail);
        }

        public IReadOnlyCollection<DetailModel> GetAllByQuery(string query)
        {

            var details = Detail.IsPart_number(query)
                    ? detailRepository.GetAllByPart_number(query)
                    : detailRepository.GetAllByTitleOrCompany(query);
            return details.Select(Map).ToArray();
            
        }

        private DetailModel Map(Detail detail)
        {
            return new DetailModel
            {
                Id = detail.Id,
                Part_number = detail.Part_number,
                Title = detail.Title,
                Company = detail.Company,
                Description = detail.Description,
                Price = detail.Price,
            };
        }
    }
}
