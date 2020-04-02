using Codenation.Challenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly CodenationContext _context;

        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna uma lista de acelerações a relacionado com a empresa pelo id da empresa
        /// </summary>
        /// <param name="companyId"> ID da empresa</param>
        /// <returns>Lista de acelerações da empresa</returns>
        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return (from acceleration in _context.Accelerations
                    join candidate in _context.Candidates on acceleration.Id equals candidate.AccelerationId
                    where candidate.CompanyId == companyId
                    orderby acceleration.Id
                    select acceleration)
                    .Distinct()
                    .ToList();
        }

        /// <summary>
        /// Retorna uma aceleração a partir do id da aceleração
        /// </summary>
        /// <param name="nameof(id)">ID da aceleração</param>
        /// <returns>Aceleração com o ID do parâmetro</returns>
        public Acceleration FindById(int id)
        {
            return _context.Accelerations.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Cria ou atualiza um Acelerações
        /// Caso o Id seja zero, fará a inserção do aceleração.
        /// Caso contrário fará a atualização dos dados da aceleração com o Id informado
        /// </summary>
        /// <param name="acceleration">Aceleração para salvar</param>
        /// <returns>Aceleração salva</returns>
        public Acceleration Save(Acceleration acceleration)
        {
            if (acceleration.Id > 0 && _context.Accelerations.Any(a => a.Id == acceleration.Id))
                _context.Accelerations.Update(acceleration);
            else
                _context.Accelerations.Add(acceleration);

            _context.SaveChanges();

            return acceleration;
        }
    }
}
