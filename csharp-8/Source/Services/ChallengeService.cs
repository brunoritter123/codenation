using Codenation.Challenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext _context;
        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna uma lista de Desafios a partir do id da aceleração e usuário
        /// </summary>
        /// <param name="accelerationId">ID da acceleração</param>
        /// <param name="userId">ID do usuário</param>
        /// <returns>Lista de desafios</returns>
        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return (from challenge in _context.Challenges
                    join acceleration in _context.Accelerations on challenge.Id equals acceleration.ChallengeId
                    join candidate in _context.Candidates on acceleration.Id equals candidate.AccelerationId
                    where acceleration.Id == accelerationId && candidate.UserId == userId
                    select challenge)
                    .Distinct()
                    .ToList();
        }

        /// <summary>
        /// Cria ou atualiza um desafio
        /// Caso o Id seja zero, fará a inserção do desafio.
        /// Caso contrário fará a atualização dos dados do desafio com o Id informado
        /// </summary>
        /// <param name="challenge">Desafio para salvar</param>
        /// <returns>Desafil salvo</returns>
        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id > 0 && _context.Challenges.Any(c => c.Id == challenge.Id))
                _context.Challenges.Update(challenge);
            else
                _context.Challenges.Add(challenge);

            _context.SaveChanges();

            return challenge;
        }
    }
}