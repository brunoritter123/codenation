using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext _context;
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return (from submission in _context.Submissions
                    join user in _context.Users on submission.UserId equals user.Id
                    join candidate in _context.Candidates on user.Id equals candidate.UserId
                    where submission.ChallengeId == challengeId && candidate.AccelerationId == accelerationId
                    orderby submission.UserId, submission.ChallengeId
                    select submission)
                    .Distinct()
                    .ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            throw new System.NotImplementedException();
        }

        public Submission Save(Submission submission)
        {
            throw new System.NotImplementedException();
        }
    }
}
