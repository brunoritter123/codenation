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
        /// Retorna uma lista de acelera��es a relacionado com a empresa pelo id da empresa
        /// </summary>
        /// <param name="companyId"> ID da empresa</param>
        /// <returns>Lista de acelera��es da empresa</returns>
        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return _context.Accelerations
                .Where(a => a.Candidates.Any(c => c.CompanyId == companyId))
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Retorna uma acelera��o a partir do id da acelera��o
        /// </summary>
        /// <param name="nameof(id)">ID da acelera��o</param>
        /// <returns>Acelera��o com o ID do par�metro</returns>
        public Acceleration FindById(int id)
        {
            return _context.Accelerations.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Cria ou atualiza um Acelera��es
        /// Caso o Id seja zero, far� a inser��o do acelera��o.
        /// Caso contr�rio far� a atualiza��o dos dados da acelera��o com o Id informado
        /// </summary>
        /// <param name="acceleration">Acelera��o para salvar</param>
        /// <returns>Acelera��o salva</returns>
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
