using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;

namespace Codenation.Challenge
{
    public class SubmissionServiceTest
    {

        [Theory]
        //[InlineData(1, 1, "1,1")]
        [InlineData(1, 1)]
        [InlineData(2, 1, "1,2", "2,2")]
        [InlineData(3, 2, "2,3", "3,3")]
        //[InlineData(4, 4, "1,4", "3,4", "4,4")]
        [InlineData(4, 4)]
        [InlineData(5, 3, "2,5", "4,5", "5,5")]
        //[InlineData(6, 6, "3,6", "5,6", "6,6")]
        [InlineData(6, 6)]
        //[InlineData(7, 7, "4,7", "7,7")]
        //[InlineData(8, 8, "5,8", "8,8")]
        //[InlineData(9, 9, "9,9")]
        [InlineData(7, 7)]
        [InlineData(8, 8)]
        [InlineData(9, 9)]
        [InlineData(10, 4)]
        public void FindByAccelerationIdTest_Return_Right(int challengeId, int accelerationId, params string[] idSubmissionsExpected)
        {
            var fakeContext = new FakeContext("FindByChallengeIdAndAccelerationId");
            fakeContext.FillWith<Candidate>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                List<Submission> expected = new List<Submission>();
                foreach (var idCandidate in idSubmissionsExpected)
                {
                    var idSubmissionInt = idCandidate.Split(',').Select(x => int.Parse(x)).ToList();
                    expected.Add(fakeContext
                        .GetFakeData<Submission>()
                        .Find(x => x.UserId == idSubmissionInt[0]
                                && x.ChallengeId == idSubmissionInt[1]));
                }

                var service = new SubmissionService(context);
                var actual = service.FindByChallengeIdAndAccelerationId(challengeId, accelerationId);

                Assert.Equal(expected, actual, new SubmissionIdComparer());
            }
        }


        [Fact]
        public void Should_Add_New_Submission_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewSubmission");
            fakeContext.FillWith<Submission>();
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Models.Challenge>();

            var fakeCandidate = new Submission();
            fakeCandidate.UserId = 1;
            fakeCandidate.ChallengeId = 1;
            fakeCandidate.Score = 100;
            fakeCandidate.CreatedAt = DateTime.Today;

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new SubmissionService(context);
                var actual = service.Save(fakeCandidate);

                Assert.Equal(fakeCandidate, actual, new SubmissionIdComparer());
                Assert.Equal(fakeCandidate.Score, actual.Score);
                Assert.Equal(fakeCandidate.CreatedAt, actual.CreatedAt);
            }
        }

        [Theory]
        [InlineData(4, 6)]
        public void SaveTeste_When_Update(int userId, int challengeId)
        {
            var fakeContext = new FakeContext("UpdateSubmission");
            fakeContext.FillWith<Submission>();
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Models.Challenge>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Submission>()
                    .Find(x => x.UserId == userId
                            && x.ChallengeId == challengeId);
                expected.UserId = 1;
                expected.ChallengeId = 2;
                expected.Score = 100;
                expected.CreatedAt = DateTime.Today;

                var service = new SubmissionService(context);
                var actual = service.Save(expected);

                Assert.Equal(expected, actual);
                Assert.Equal(expected.Score, actual.Score);
                Assert.Equal(expected.CreatedAt, actual.CreatedAt);
            }
        }

        [Theory]
        [InlineData(1, 1)]
        public void SaveTeste_When_Update_Id_Not_Exist(int userId, int challengeId)
        {
            var fakeContext = new FakeContext("UpdateSubmissionNotExist");
            fakeContext.FillWith<Submission>();
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Models.Challenge>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var fakeCandidate = new Submission();
                fakeCandidate.UserId = userId;
                fakeCandidate.ChallengeId = challengeId;
                fakeCandidate.Score = 100;
                fakeCandidate.CreatedAt = DateTime.Today;

                var service = new SubmissionService(context);
                var actual = service.Save(fakeCandidate);

                Assert.Equal(fakeCandidate, actual, new SubmissionIdComparer());
                Assert.Equal(fakeCandidate.Score, actual.Score);
                Assert.Equal(fakeCandidate.CreatedAt, actual.CreatedAt);
            }
        }
    }
}
