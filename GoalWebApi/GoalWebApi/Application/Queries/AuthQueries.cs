using GoalWebApi.Data;
using GoalWebApi.Domain.Entity;
using GoalWebApi.Models.Auth;
using GoalWebApi.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Queries
{
    public class AuthQueries
    {
        private readonly GoalRepository<Users> _usersQueries;
        public AuthQueries(GoalRepository<Users> usersQueries)
        {
            _usersQueries = usersQueries;
        }
        public UserModel Authenticate(AuthenticateModel model)
        {
            var user = _usersQueries.GetAll().Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
            if (user == null)
                return null;
            return new UserModel
            {
                Email = user.Email,
                Id = user.Id,
                Surname = user.Surname,
                Name = user.Name
            };

        }
    }
}
