using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;

namespace Codenation.Challenge
{
    public class CandidateServiceTest
    {
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 1)]
        [InlineData(4, 5, 3)]
        public void Should_Return_Right_Candidate_When_Find_By_Id(int userId, int accelerationId, int companyId)
        {
            var fakeContext = new FakeContext("CandidateById");
            fakeContext.FillWith<Candidate>();
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Company>();
            fakeContext.FillWith<Acceleration>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Candidate>()
                    .Find(x => x.UserId == userId
                            && x.AccelerationId == accelerationId
                            && x.CompanyId == companyId);

                var service = new CandidateService(context);
                var actual = service.FindById(userId, accelerationId, companyId);

                Assert.Equal(expected, actual, new CandidateIdComparer());
            }
        }

        [Theory]
        [InlineData(1, "1,1,1")]
        [InlineData(2, "1,2,1", "2,2,2", "3,2,2")]
        [InlineData(3, "1,3,1", "2,3,1", "3,3,2", "3,3,3")]
        [InlineData(4, "1,4,1", "2,4,1", "3,4,2", "4,4,3", "4,4,4")]
        [InlineData(5, "4,5,3", "5,5,5")]
        [InlineData(6, "4,6,3", "6,6,6")]
        [InlineData(7, "7,7,7")]
        [InlineData(8, "8,8,8")]
        [InlineData(9, "9,9,9")]
        public void FindByAccelerationIdTest_Return_Right(int accelerationId, params string[] idCandidatesExpected)
        {
            var fakeContext = new FakeContext("FindByAccelerationIdName");
            fakeContext.FillWith<Candidate>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                List<Candidate> expected = new List<Candidate>();
                foreach (var idCandidate in idCandidatesExpected)
                {
                    var idCandidateInt = idCandidate.Split(',').Select(x => int.Parse(x)).ToList();
                    expected.Add(fakeContext
                        .GetFakeData<Candidate>()
                        .Find(x => x.UserId == idCandidateInt[0]
                                && x.AccelerationId == idCandidateInt[1]
                                && x.CompanyId == idCandidateInt[2]));
                }

                var service = new CandidateService(context);
                var actual = service.FindByAccelerationId(accelerationId);

                Assert.Equal(expected, actual, new CandidateIdComparer());
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1, "1,1,1", "1,2,1", "1,3,1", "1,4,1", "2,3,1", "2,4,1")]
        [InlineData(2, "2,2,2", "3,2,2", "3,3,2", "3,4,2")]
        [InlineData(3, "3,3,3", "4,4,3", "4,5,3", "4,6,3")]
        [InlineData(4, "4,4,4")]
        [InlineData(10)]
        public void FindByCompanyIdTest_Return_Right(int companyId, params string[] idCandidatesExpected)
        {
            var fakeContext = new FakeContext("Candidate_FindByCompanyId");
            fakeContext.FillWith<Candidate>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                List<Candidate> expected = new List<Candidate>();
                foreach (var idCandidate in idCandidatesExpected)
                {
                    var idCandidateInt = idCandidate.Split(',').Select(x => int.Parse(x)).ToList();
                    expected.Add(fakeContext
                        .GetFakeData<Candidate>()
                        .Find(x => x.UserId == idCandidateInt[0]
                                && x.AccelerationId == idCandidateInt[1]
                                && x.CompanyId == idCandidateInt[2]));
                }

                var service = new CandidateService(context);
                var actual = service.FindByCompanyId(companyId);

                Assert.Equal(expected, actual, new CandidateIdComparer());
            }
        }

        [Fact]
        public void Should_Add_New_Candidate_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewCandidate");
            fakeContext.FillWith<Candidate>();
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Company>();
            fakeContext.FillWith<Acceleration>();

            var fakeCandidate = new Candidate();
            fakeCandidate.UserId = 1;
            fakeCandidate.AccelerationId = 1;
            fakeCandidate.CompanyId = 2;
            fakeCandidate.Status = 1;
            fakeCandidate.CreatedAt = DateTime.Today;

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new CandidateService(context);
                var actual = service.Save(fakeCandidate);

                Assert.Equal(fakeCandidate, actual, new CandidateIdComparer());
                Assert.Equal(fakeCandidate.Status, actual.Status);
                Assert.Equal(fakeCandidate.CreatedAt, actual.CreatedAt);
            }
        }

        [Theory]
        [InlineData(4, 6, 3)]
        public void SaveTeste_When_Update(int userId, int accelerationId, int companyId)
        {
            var fakeContext = new FakeContext("UpdateCandidate");
            fakeContext.FillWith<Candidate>();
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Company>();
            fakeContext.FillWith<Acceleration>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Candidate>()
                    .Find(x => x.UserId == userId
                            && x.AccelerationId == accelerationId
                            && x.CompanyId == companyId);
                expected.UserId = 1;
                expected.AccelerationId = 1;
                expected.CompanyId = 3;
                expected.Status = 1;
                expected.CreatedAt = DateTime.Today;

                var service = new CandidateService(context);
                var actual = service.Save(expected);

                Assert.Equal(expected, actual);
                Assert.Equal(expected.Status, actual.Status);
                Assert.Equal(expected.CreatedAt, actual.CreatedAt);
            }
        }

        [Theory]
        [InlineData(1, 1, 2)]
        public void SaveTeste_When_Update_Id_Not_Exist(int userId, int accelerationId, int companyId)
        {
            var fakeContext = new FakeContext("UpdateCandidateNotExist");
            fakeContext.FillWith<Candidate>();
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Company>();
            fakeContext.FillWith<Acceleration>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var fakeCandidate = new Candidate();
                fakeCandidate.UserId = userId;
                fakeCandidate.AccelerationId = accelerationId;
                fakeCandidate.CompanyId = companyId;
                fakeCandidate.Status = 1;
                fakeCandidate.CreatedAt = DateTime.Today;

                var service = new CandidateService(context);
                var actual = service.Save(fakeCandidate);

                Assert.Equal(fakeCandidate, actual, new CandidateIdComparer());
                Assert.Equal(fakeCandidate.Status, actual.Status);
                Assert.Equal(fakeCandidate.CreatedAt, actual.CreatedAt);
            }
        }
    }
}
