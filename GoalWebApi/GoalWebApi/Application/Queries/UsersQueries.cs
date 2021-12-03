using GoalWebApi.Application.Queries.Interfaces;
using GoalWebApi.Domain.Entity;
using GoalWebApi.Data;
using GoalWebApi.Extensions;
using System.Threading.Tasks;
using GoalWebApi.Models.Users;
using System.Linq;
using System;

namespace GoalWebApi.Application.Queries
{
    public class UsersQueries : IUsersQueries
    {
        private readonly GoalRepository<Products> _productsRepository;
        private readonly GoalRepository<Users> _usersRepository;
        public UsersQueries(GoalRepository<Products> productsRepository, GoalRepository<Users> usersRepository)
        {
            _productsRepository = productsRepository;
            _usersRepository = usersRepository;
        }

        public async Task<PagedResult<UserModel>> GetAllUsers(int page, int pageSize)
        {
            var users = _usersRepository.GetAll();
            return await users.Select(x => new UserModel
            {
                Email = x.Email,
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            }).GetPagination(page, pageSize);
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            var user = _usersRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
            return new UserModel
            {
                Id = user.Id,
                Surname = user.Surname,
                Name = user.Name,
                Email = user.Email,
                SellerId = user.SellerId
            };
        }
    }
}
