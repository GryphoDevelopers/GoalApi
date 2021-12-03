using GoalWebApi.Application.Commands;
using GoalWebApi.Application.Queries.Interfaces;
using GoalWebApi.Extensions;
using GoalWebApi.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GoalWebApi.Controllers
{
    [ApiController]
    [Route("goal/api/users")]
    public class UsersController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IUsersQueries _usersQueries;
        public UsersController(IMediator mediator, IUsersQueries usersQueries)
        {
            _mediator = mediator;
            _usersQueries = usersQueries;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(PagedResult<UserModel>), 200)]
        public async Task<IActionResult> GetAllUsers(int page = 1, int pageSize = 10)
        {
            return ApiResponse(await _usersQueries.GetAllUsers(page, pageSize));
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            return ApiResponse(await _usersQueries.GetUserById(userId));
        }

        [HttpPatch]
        [Route("{userId}/change-level")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(UserModel), 200)]
        public async Task<IActionResult> ChangeUserLevel(Guid userId)
        {
            var command = new ChangeUserTypeCommand(userId);
            var valid = await _mediator.Send(command);
            if (!valid.isValid())
            {
                AddErrors(valid.Errors);
                return ApiResponse();
            }
            return ApiResponse(await _usersQueries.GetUserById(userId));
        }

        [HttpDelete]
        [Route("{userId}/delete-account")]
        public IActionResult DeleteUser()
        {
            return ApiResponse("Autorizado");
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(UserModel), 200)]
        public IActionResult UpdateUser()
        {
            return ApiResponse("Autorizado");
        }
    }
}
