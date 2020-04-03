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

        /// <summary>
        /// Retorna uma lista de submissões a partir do id do desafio e do id da aceleração
        /// </summary>
        /// <param name="challengeId">Id do desafio</param>
        /// <param name="accelerationId">Id da Aceleração</param>
        /// <returns>Lista de submissões</returns>
        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return (from submission in _context.Submissions
                    join user in _context.Users on submission.UserId equals user.Id
                    join candidate in _context.Candidates on user.Id equals candidate.UserId
                    where submission.ChallengeId == challengeId && candidate.AccelerationId == accelerationId
                    select submission)
                    .Distinct()
                    .ToList();
        }

        /// <summary>
        /// Retorna o valor do maior score a partir do id do desafio
        /// </summary>
        /// <param name="challengeId">Id do desafio</param>
        /// <returns></returns>
        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context.Submissions.Where(s => s.ChallengeId == challengeId)
                .Max(s => s.Score);
        }

        /// <summary>
        /// Cria ou atualiza uma submissão
        /// Caso o Id seja zero, fará a inserção do submissão.
        /// Caso contrário fará a atualização dos dados do candidato com o Id informado
        /// </summary>
        /// <param name="submission">Submissão para salvar</param>
        /// <returns>Submissão salvo</returns>
        public Submission Save(Submission submission)
        {
            bool idPreenchido = submission.UserId > 0 && submission.ChallengeId > 0;
            if (idPreenchido && _context.Submissions.Any(s => s.UserId == submission.UserId
                                                          && s.ChallengeId == submission.ChallengeId))
                _context.Submissions.Update(submission);
            else
                _context.Submissions.Add(submission);

            _context.SaveChanges();

            return submission;
        }
    }
}
