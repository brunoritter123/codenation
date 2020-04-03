using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;

namespace Codenation.Challenge
{
    public class CompanyServiceTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_Right_Company_When_Find_By_Id(int id)
        {
            var fakeContext = new FakeContext("CompanyById");
            fakeContext.FillWith<Company>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Company>().Find(x => x.Id == id);

                var service = new CompanyService(context);
                var actual = service.FindById(id);

                Assert.Equal(expected, actual, new CompanyIdComparer());
            }
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(3, 1, 2, 3)]
        [InlineData(4, 1, 2, 3, 4)]
        [InlineData(0)]
        [InlineData(999)]
        public void FindByAccelerationNameTest_Return_Right(int accelerationId, params int[] idCompaniesExpected)
        {
            var fakeContext = new FakeContext("FindByAccelerationName");
            fakeContext.FillWith<Company>();
            fakeContext.FillWith<Candidate>();
            fakeContext.FillWith<Acceleration>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                List<Company> expected = new List<Company>();
                foreach (var id in idCompaniesExpected)
                {
                    expected.Add(fakeContext.GetFakeData<Company>().Find(x => x.Id == id));
                }

                var service = new CompanyService(context);
                var actual = service.FindByAccelerationId(accelerationId)
                                    .OrderBy(c => c.Id);

                Assert.Equal(expected, actual, new CompanyIdComparer());
            }
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(3, 2, 3)]
        [InlineData(4, 3, 4)]
        [InlineData(5, 5)]
        [InlineData(10)]
        [InlineData(0)] 
        [InlineData(999)]
        public void FindByUserIdTest_Return_Right(int userId, params int[] idCompanysExpected)
        {
            var fakeContext = new FakeContext("FindByAccelerationName");
            fakeContext.FillWith<Company>();
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Candidate>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                List<Company> expected = new List<Company>();
                foreach (var id in idCompanysExpected)
                {
                    expected.Add(fakeContext.GetFakeData<Company>().Find(x => x.Id == id));
                }

                var service = new CompanyService(context);
                var actual = service.FindByUserId(userId).OrderBy(c => c.Id);

                Assert.Equal(expected, actual, new CompanyIdComparer());
            }
        }

        [Fact]
        public void Should_Add_New_Company_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewCompany");
            var fakeCompany = new Company();
            fakeCompany.Name = "name";
            fakeCompany.Slug = "slug";
            fakeCompany.CreatedAt = DateTime.Today;

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new CompanyService(context);
                var actual = service.Save(fakeCompany);

                Assert.NotEqual(0, actual.Id);
                Assert.Equal(fakeCompany.Name, actual.Name);
                Assert.Equal(fakeCompany.Slug, actual.Slug);
                Assert.Equal(fakeCompany.CreatedAt, actual.CreatedAt);
            }
        }

        [Fact]
        public void SaveTeste_When_Update()
        {
            var fakeContext = new FakeContext("UpdateCompany");
            int idCompanyUpdate = 1;
            fakeContext.FillWith<Company>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Company>().Find(x => x.Id == idCompanyUpdate);
                expected.Name = "name";
                expected.Slug = "slug";
                expected.CreatedAt = DateTime.Today;

                var service = new CompanyService(context);
                var actual = service.Save(expected);

                Assert.Equal(expected.Id, actual.Id);
                Assert.Equal(expected.Name, actual.Name);
                Assert.Equal(expected.Slug, actual.Slug);
                Assert.Equal(expected.CreatedAt, actual.CreatedAt);
            }
        }

        [Fact]
        public void SaveTeste_When_Update_Id_Not_Exist()
        {
            var fakeContext = new FakeContext("UpdateCompany");
            fakeContext.FillWith<Company>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var fakeCompany = new Company();
                fakeCompany.Id = 999;
                fakeCompany.Name = "name";
                fakeCompany.Slug = "slug";
                fakeCompany.CreatedAt = DateTime.Today;

                var service = new CompanyService(context);
                var actual = service.Save(fakeCompany);

                Assert.NotEqual(0, actual.Id);
                Assert.Equal(fakeCompany.Name, actual.Name);
                Assert.Equal(fakeCompany.Slug, actual.Slug);
                Assert.Equal(fakeCompany.CreatedAt, actual.CreatedAt);
            }
        }
    }
}
