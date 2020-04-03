using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CodenationContext _context;
        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna uma lista de candidatos a partir do id da aceleração
        /// </summary>
        /// <param name="accelerationId">Id da aceleração</param>
        /// <returns>Lista de candidatos</returns>
        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _context.Candidates
                .Where(c => c.AccelerationId == accelerationId)
                .ToList();
        }

        /// <summary>
        /// Retorna uma lista candidatos a partir do id da empresa
        /// </summary>
        /// <param name="companyId">Id da Empresa</param>
        /// <returns>Lista de candidatos</returns>
        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _context.Candidates
                .Where(c => c.CompanyId == companyId)
                .ToList();
        }

        /// <summary>
        /// Retorna um candidato a partir do id do usuário, do id da aceleração e do id da empresa
        /// </summary>
        /// <param name="userId">Id do Usuário</param>
        /// <param name="accelerationId">Id da Aceleração</param>
        /// <param name="companyId">Id da empresa</param>
        /// <returns></returns>
        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _context.Candidates
                .Where(c => c.UserId == userId && c.AccelerationId == accelerationId && c.CompanyId == companyId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Cria ou atualiza um Candidato
        /// Caso o Id seja zero, fará a inserção do candidato.
        /// Caso contrário fará a atualização dos dados do candidato com o Id informado
        /// </summary>
        /// <param name="candidate">Candidato para salvar</param>
        /// <returns>Candidato salvo</returns>
        public Candidate Save(Candidate candidate)
        {
            bool idPreenchido = candidate.UserId > 0 && candidate.AccelerationId > 0 && candidate.CompanyId > 0;
            if (idPreenchido && _context.Candidates.Any(c => c.UserId == candidate.UserId
                                                          && c.AccelerationId == candidate.AccelerationId
                                                          && c.CompanyId == candidate.CompanyId))
                _context.Candidates.Update(candidate);
            else
                _context.Candidates.Add(candidate);

            _context.SaveChanges();

            return candidate;
        }
    }
}
