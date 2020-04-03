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
        [InlineData(1, 91.13)]
        [InlineData(2, 50.0)]
        [InlineData(3, 79.22)]
        [InlineData(4, 90.08)]
        [InlineData(5, 58.67)]
        [InlineData(6, 67.08)]
        [InlineData(7, 58.9)]
        [InlineData(8, 43.2)]
        [InlineData(9, 51.18)]
        public void FindHigherScoreByChallengeIdTeste_Return_Right(int challengeId, decimal expectedMaxScore)
        {
            var fakeContext = new FakeContext("FindHigherScoreByChallengeId");
            fakeContext.FillWith<Submission>();
            fakeContext.FillWith<Models.Challenge>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new SubmissionService(context);
                var actual = service.FindHigherScoreByChallengeId(challengeId);

                Assert.Equal(expectedMaxScore, actual);
            }
        }

        [Theory]
        [InlineData(1, 1, "1,1")]
        [InlineData(2, 1, "1,2")]
        [InlineData(3, 2, "2,3", "3,3")]
        [InlineData(4, 4, "1,4", "3,4", "4,4")]
        [InlineData(5, 3, "2,5")]
        [InlineData(6, 6, "6,6")]
        [InlineData(7, 7, "7,7")]
        [InlineData(8, 8, "8,8")]
        [InlineData(9, 9, "9,9")]
        [InlineData(10, 4)]
        public void FindByAccelerationIdTest_Return_Right(int challengeId, int accelerationId, params string[] idSubmissionsExpected)
        {
            var fakeContext = new FakeContext("FindByChallengeIdAndAccelerationId");
            fakeContext.FillWith<Acceleration>();
            fakeContext.FillWith<Candidate>();
            fakeContext.FillWith<User>();
            fakeContext.FillWith<Submission>();
            fakeContext.FillWith <Models.Challenge>();

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
                var actual = service.FindByChallengeIdAndAccelerationId(challengeId, accelerationId)
                                    .OrderBy(s => s.UserId)
                                    .ThenBy(s => s.ChallengeId);

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
        [InlineData(9, 9)]
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
