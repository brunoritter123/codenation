using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Codenation.Challenge
{
    public class ChallengeServiceTest
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 1, 3)]
        [InlineData(2, 2, 3)]
        [InlineData(2, 3, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 1, 5)]
        [InlineData(3, 2, 5)]
        [InlineData(3, 3, 5)]
        [InlineData(3, 4)]
        [InlineData(4, 1, 10)]
        [InlineData(4, 2, 10)]
        [InlineData(4, 3, 10)]
        [InlineData(4, 4, 10)]
        [InlineData(900, 1)]
        [InlineData(1, 900)]
        public void FindByAccelerationIdAndUserIdTest_Return_Right(int accelerationId, int userId
            , params int[] idChallengesExpected)
        {
            var fakeContext = new FakeContext("indByAccelerationIdAndUserIdTest");
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Acceleration>();
            fakeContext.FillWith<Candidate>();
            fakeContext.FillWith<Models.Challenge>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                List<Models.Challenge> expected = new List<Models.Challenge>();
                foreach (var id in idChallengesExpected)
                {
                    expected.Add(fakeContext.GetFakeData<Models.Challenge>().Find(x => x.Id == id));
                }

                var service = new ChallengeService(context);
                var actual = service.FindByAccelerationIdAndUserId(accelerationId, userId);

                Assert.Equal(expected, actual, new ChallengeIdComparer());
            }
        }


        [Fact]
        public void Should_Add_New_Challenge_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewChallenge");
            var fakeChallenge = new Models.Challenge();
            fakeChallenge.Name = "name";
            fakeChallenge.Slug = "slug";
            fakeChallenge.CreatedAt = DateTime.Today;

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new ChallengeService(context);
                var actual = service.Save(fakeChallenge);

                Assert.NotEqual(0, actual.Id);
                Assert.Equal(fakeChallenge.Name, actual.Name);
                Assert.Equal(fakeChallenge.Slug, actual.Slug);
                Assert.Equal(fakeChallenge.CreatedAt, actual.CreatedAt);
            }
        }

        [Fact]
        public void SaveTeste_When_Update()
        {
            var fakeContext = new FakeContext("UpdateChallenge");
            int idChallengeUpdate = 1;
            fakeContext.FillWith<Models.Challenge>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Models.Challenge>().Find(x => x.Id == idChallengeUpdate);
                expected.Name = "name";
                expected.Slug = "slug";
                expected.CreatedAt = DateTime.Today;

                var service = new ChallengeService(context);
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
            var fakeContext = new FakeContext("UpdateChallengeNotExist");
            fakeContext.FillWith<Models.Challenge>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = new Models.Challenge();
                expected.Id = 999;
                expected.Name = "name";
                expected.Slug = "slug";
                expected.CreatedAt = DateTime.Today;

                var service = new ChallengeService(context);
                var actual = service.Save(expected);

                Assert.NotEqual(0, actual.Id);
                Assert.Equal(expected.Name, actual.Name);
                Assert.Equal(expected.Slug, actual.Slug);
                Assert.Equal(expected.CreatedAt, actual.CreatedAt);
            }
        }
    }
}
