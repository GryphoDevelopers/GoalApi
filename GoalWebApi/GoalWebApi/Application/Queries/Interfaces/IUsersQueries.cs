using GoalWebApi.Extensions;
using GoalWebApi.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Queries.Interfaces
{
    public interface IUsersQueries
    {
        Task<PagedResult<UserModel>> GetAllUsers(int page, int pageSize);
        Task<UserModel> GetUserById(Guid id);
    }
}
