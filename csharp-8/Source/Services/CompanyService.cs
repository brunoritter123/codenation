using Codenation.Challenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext _context;

        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna uma lista de empresas a partir do id da aceleração
        /// </summary>
        /// <param name="accelerationId">ID da acceleração</param>
        /// <returns>Lista de empresas</returns>
        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return _context.Candidates.Where(c => c.AccelerationId == accelerationId)
                                      .GroupBy(c => c.Company)
                                      .Select(c => c.Key)
                                      .ToList();
        }

        /// <summary>
        /// Retorna uma empresa a partir do id da empresa
        /// </summary>
        /// <param name="id"> Id da empresa</param>
        /// <returns>Empresa com Id passado como argumento</returns>
        public Company FindById(int id)
        {
            return _context.Companies.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Retorna uma lista de empresas a partir do id do usuário
        /// </summary>
        /// <param name="userId">ID do usuário</param>
        /// <returns>Lista de empresas</returns>
        public IList<Company> FindByUserId(int userId)
        {
            return _context.Candidates.Where(c => c.UserId == userId)
                                      .GroupBy(c => c.Company)
                                      .Select(c => c.Key)
                                      .ToList();
        }

        /// <summary>
        /// Cria ou atualiza uma Empresa
        /// Caso o Id seja zero, fará a inserção da empresa.
        /// Caso contrário fará a atualização dos dados da empresa com o Id informado
        /// </summary>
        /// <param name="company">Empresa para salvar</param>
        /// <returns>Empresa salva</returns>
        public Company Save(Company company)
        {
            if (company.Id > 0 && _context.Companies.Any(c => c.Id == company.Id))
                _context.Companies.Update(company);
            else
                _context.Companies.Add(company);

            _context.SaveChanges();
            return company;
        }
    }
}