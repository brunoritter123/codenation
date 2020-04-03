using Codenation.Challenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext _context;

        public UserService(CodenationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retornar uma lista de usu�rios a partir do nome da acelera��o
        /// </summary>
        /// <param name="name"> Nome da acelera��o</param>
        /// <returns>Lista de usu�rio da acelere��o</returns>
        public IList<User> FindByAccelerationName(string name)
        {
            return _context.Candidates
                           .Where(c => c.Acceleration.Name == name)
                           .GroupBy(u => u.User)
                           .Select(g => g.Key)
                           .ToList();
        }

        /// <summary>
        /// Retorna uma lista de usu�rios a relacionado com a empresa pelo id da empresa
        /// </summary>
        /// <param name="companyId"> ID da empresa</param>
        /// <returns>Lista de usu�rio da acelere��o</returns>
        public IList<User> FindByCompanyId(int companyId)
        {
            return (from user in _context.Users
                    join candidate in _context.Candidates on user.Id equals candidate.UserId
                    where candidate.CompanyId == companyId
                    select user)
                    .Distinct()
                    .ToList();
        }

        /// <summary>
        /// Retorna um usu�rio a partir do id do usu�rio
        /// </summary>
        /// <exception cref="EntityNotFoundException">Retorna quando n�o foi encontrado um registro para o argumento recebido</exception>
        /// <param name="nameof(id)">ID do usu�rio</param>
        /// <returns>Usu�rio com o ID do par�metro</returns>
        public User FindById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Cria ou atualiza um Usu�rio
        /// Caso o Id seja zero, far� a inser��o do usu�rio.
        /// Caso contr�rio far� a atualiza��o dos dados do usu�rio com o Id informado
        /// </summary>
        /// <param name="user">Usu�rio para salvar</param>
        /// <returns>Usu�rio salvo</returns>
        public User Save(User user)
        {
            if (user.Id > 0 && _context.Users.Any(u => u.Id == user.Id))
                _context.Users.Update(user);
            else
                _context.Users.Add(user);

            _context.SaveChanges();

            return user;
        }
    }
}
