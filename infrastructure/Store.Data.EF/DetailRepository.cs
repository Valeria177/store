using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Data.EF
{
    class DetailRepository : IDetailRepository
    {

        private readonly DbContextFactory dbContextFactory;

        public DetailRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public Detail[] GetAllByIds(IEnumerable<int> detailIds)
        {
            var dbContext = dbContextFactory.Create(typeof(DetailRepository));

            return dbContext.Details
                            .Where(detail => detailIds.Contains(detail.Id))
                            .AsEnumerable()
                            .Select(Detail.Mapper.Map)
                            .ToArray();
        }

        public Detail[] GetAllByPart_number(string part_number)
        {
            var dbContext = dbContextFactory.Create(typeof(DetailRepository));

            if (Detail.TryFormatPart_number(part_number, out string formattedPart_number))
            {
                return dbContext.Details
                                .Where(detail => detail.Part_number == formattedPart_number)
                                .AsEnumerable()
                                .Select(Detail.Mapper.Map)
                                .ToArray();
            }

            return new Detail[0];
        }

        public Detail[] GetAllByTitleOrCompany(string titleOrCompany)
        {
            var dbContext = dbContextFactory.Create(typeof(DetailRepository));

            var parameter = new SqlParameter("@titleOrCompany", titleOrCompany);
            return dbContext.Details
                            .FromSqlRaw("SELECT * FROM Details WHERE CONTAINS((Company, Title), @titleOrCompany)",
                                        parameter)
                            .AsEnumerable()
                            .Select(Detail.Mapper.Map)
                            .ToArray();
        }

        public Detail GetById(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(DetailRepository));

            var dto = dbContext.Details
                               .Single(detail => detail.Id == id);

            return Detail.Mapper.Map(dto);
        }
    }
}
