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
        /// Retornar uma lista de usuários a partir do nome da aceleração
        /// </summary>
        /// <param name="name"> Nome da aceleração</param>
        /// <returns>Lista de usuário da acelereção</returns>
        public IList<User> FindByAccelerationName(string name)
        {
            return _context.Candidates
                           .Where(c => c.Acceleration.Name == name)
                           .GroupBy(u => u.User)
                           .Select(g => g.Key)
                           .ToList();
        }

        /// <summary>
        /// Retorna uma lista de usuários a relacionado com a empresa pelo id da empresa
        /// </summary>
        /// <param name="companyId"> ID da empresa</param>
        /// <returns>Lista de usuário da acelereção</returns>
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
        /// Retorna um usuário a partir do id do usuário
        /// </summary>
        /// <exception cref="EntityNotFoundException">Retorna quando não foi encontrado um registro para o argumento recebido</exception>
        /// <param name="nameof(id)">ID do usuário</param>
        /// <returns>Usuário com o ID do parâmetro</returns>
        public User FindById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Cria ou atualiza um Usuário
        /// Caso o Id seja zero, fará a inserção do usuário.
        /// Caso contrário fará a atualização dos dados do usuário com o Id informado
        /// </summary>
        /// <param name="user">Usuário para salvar</param>
        /// <returns>Usuário salvo</returns>
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
