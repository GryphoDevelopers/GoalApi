using GoalWebApi.Data;
using GoalWebApi.Domain.Entity;
using GoalWebApi.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Queries
{
    public class UsersQueries
    {
        private readonly GoalRepository<Users> _usersQueries;
        public UsersQueries(GoalRepository<Users> usersQueries)
        {
            _usersQueries = usersQueries;
        }
        
    }
}
