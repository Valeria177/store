using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
   public  class DetailServiceTest
    {
        [Fact]
        public void GetAllByQuery_WithPart_number_CallsGetAllByPart_number()
        {
            var detailRepositoryStub = new Mock<IDetailRepository>();
            detailRepositoryStub.Setup(x => x.GetAllByPart_number(It.IsAny<string>())).Returns
                (new[] { new Detail(1, "", "", "") });

            detailRepositoryStub.Setup(x => x.GetAllByTitleOrCompany(It.IsAny<string>())).Returns
                (new[] { new Detail(2, "", "", "") });

            var detailService = new DetailService(detailRepositoryStub.Object);
            var validPart_number = "789456123";

            var actual = detailService.GetAllByQuery(validPart_number);

            Assert.Collection(actual, detail => Assert.Equal(1, detail.Id));
        }

        [Fact]
        public void GetAllByQuery_WithCompany_CallsGetAllByTitleOrCompany()
        {
            var detailRepositoryStub = new Mock<IDetailRepository>();
            detailRepositoryStub.Setup(x => x.GetAllByPart_number(It.IsAny<string>())).Returns
                (new[] { new Detail(1, "", "", "") });

            detailRepositoryStub.Setup(x => x.GetAllByTitleOrCompany(It.IsAny<string>())).Returns
                (new[] { new Detail(2, "", "", "") });

            var detailService = new DetailService(detailRepositoryStub.Object);
            var invalidPart_number = "диск";

            var actual = detailService.GetAllByQuery(invalidPart_number);

            Assert.Collection(actual, detail => Assert.Equal(2, detail.Id));
        }

    }
       
  
}
