using GoalWebApi.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using GoalWebApi.Application.Queries;
using GoalWebApi.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using GoalWebApi.Models.Auth;
using System.Threading.Tasks;
using GoalWebApi.Data;
using MediatR;
using System;

namespace GoalWebApi.Controllers
{
    [ApiController]
    [Route("goal/api/auth")]
    public class AuthController : MainController
    {
        private readonly AuthQueries _authQueries;
        
        public AuthController(AuthQueries authQueries)
        {
            _authQueries = authQueries;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IActionResult Authenticate(AuthenticateModel model)
        {
            if (!TryValidateModel(model))
            {
                AddErrors(ModelState);
                return ApiResponse();
            }
            var user = _authQueries.Authenticate(model);
            if (user == null)
            {
                AddError("Email e/ou senha incorretos!");
                return ApiResponse();
            }
            var token = TokenService.GenerateToken(user);
            return ApiResponse(new { token = token });
        }
        [HttpPost]
        [Route("add-access")]
        [AllowAnonymous]
        public async Task<IActionResult> NewAccess(NewAccess model)
        {
            try
            {
                if (!TryValidateModel(model))
                {
                    AddErrors(ModelState);
                    return ApiResponse();
                }
                var context = new GoalContext();
                context.Add(new Users
                {
                    Id = Guid.NewGuid(),
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password,
                    Surname = model.Surname
                });
                context.SaveChanges();
                return ApiResponse(model);
            }
            catch (Exception e)
            {
                AddError(e.Message);
                return ApiResponse();
            }
        }
    }
}
