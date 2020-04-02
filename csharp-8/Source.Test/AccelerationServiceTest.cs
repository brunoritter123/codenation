using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Codenation.Challenge
{
    public class AccelerationServiceTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_Right_Acceleration_When_Find_By_Id(int id)
        {
            var fakeContext = new FakeContext("AccelerationById");
            fakeContext.FillWith<Acceleration>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Acceleration>().Find(x => x.Id == id);

                var service = new AccelerationService(context);
                var actual = service.FindById(id);

                Assert.Equal(expected, actual, new AccelerationIdComparer());
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1, 1, 2, 3, 4)]
        [InlineData(2, 2, 3, 4)]
        [InlineData(3, 3, 4, 5, 6)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(7, 7)]
        [InlineData(8, 8)]
        [InlineData(9, 9)]
        [InlineData(10)]
        public void FindByCompanyIdTest_Return_Right(int companyId, params int[] idAccelerationExpected)
        {
            var fakeContext = new FakeContext("AccelerationFindByCompanyId");
            fakeContext.FillWith<Candidate>();
            fakeContext.FillWith<Acceleration>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                List<Acceleration> expected = new List<Acceleration>();
                foreach (var id in idAccelerationExpected)
                {
                    var expectedData = fakeContext.GetFakeData<Acceleration>().Find(x => x.Id == id);
                    if (!(expectedData is null))
                    {
                        expected.Add(fakeContext.GetFakeData<Acceleration>().Find(x => x.Id == id));
                    }
                }

                var service = new AccelerationService(context);
                var actual = service.FindByCompanyId(companyId);

                Assert.Equal(expected, actual, new AccelerationIdComparer());
            }
        }

        [Fact]
        public void Should_Add_New_Acceleration_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewAcceleration");
            fakeContext.FillWith<Models.Challenge>();

            var fakeAcceleration = new Acceleration();
            fakeAcceleration.Name = "name";
            fakeAcceleration.Slug = "slug";
            fakeAcceleration.ChallengeId = 1;
            fakeAcceleration.CreatedAt = DateTime.Today;

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new AccelerationService(context);
                var actual = service.Save(fakeAcceleration);

                Assert.NotEqual(0, actual.Id);
                Assert.Equal(fakeAcceleration.Name, actual.Name);
                Assert.Equal(fakeAcceleration.Slug, actual.Slug);
                Assert.Equal(fakeAcceleration.ChallengeId, actual.ChallengeId);
                Assert.Equal(fakeAcceleration.CreatedAt, actual.CreatedAt);
            }
        }

        [Fact]
        public void SaveTeste_When_Update()
        {
            var fakeContext = new FakeContext("UpdateAcceleration");
            int idAccelerationUpdate = 1;
            fakeContext.FillWith<Acceleration>();
            fakeContext.FillWith<Models.Challenge>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Acceleration>().Find(x => x.Id == idAccelerationUpdate);
                expected.Name = "name";
                expected.Slug = "slug";
                expected.ChallengeId = 1;
                expected.CreatedAt = DateTime.Today;

                var service = new AccelerationService(context);
                var actual = service.Save(expected);

                Assert.Equal(expected.Id, actual.Id);
                Assert.Equal(expected.Name, actual.Name);
                Assert.Equal(expected.Slug, actual.Slug);
                Assert.Equal(expected.ChallengeId, actual.ChallengeId);
                Assert.Equal(expected.CreatedAt, actual.CreatedAt);
            }
        }

        [Fact]
        public void SaveTeste_When_Update_Id_Not_Exist()
        {
            var fakeContext = new FakeContext("UpdateAccelerationNotExists");
            fakeContext.FillWith<Acceleration>();
            fakeContext.FillWith<Models.Challenge>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = new Acceleration();
                expected.Id = -1;
                expected.Name = "name";
                expected.Slug = "slug";
                expected.ChallengeId = 1;
                expected.CreatedAt = DateTime.Today;

                var service = new AccelerationService(context);
                var actual = service.Save(expected);

                Assert.NotEqual(0, actual.Id);
                Assert.Equal(expected.Name, actual.Name);
                Assert.Equal(expected.Slug, actual.Slug);
                Assert.Equal(expected.ChallengeId, actual.ChallengeId);
                Assert.Equal(expected.CreatedAt, actual.CreatedAt);
            }
        }
    }
}
