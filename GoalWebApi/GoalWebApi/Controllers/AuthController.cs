using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GoalWebApi.Services.Authentication;
using System.Threading.Tasks;
using GoalWebApi.Application.Queries;
using GoalWebApi.Models.Auth;

namespace GoalWebApi.Controllers
{
    [ApiController]
    [Route("goal/api/v1/auth")]
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
            if(user == null)
            {
                AddError("Email e/ou senha incorretos!");
                return ApiResponse();
            }
            var token = TokenService.GenerateToken(user);
            return ApiResponse("token");
        }
        [HttpPost]
        [Route("add-access")]
        [AllowAnonymous]
        public IActionResult NewAccess(NewAccess model)
        {
            if (!TryValidateModel(model))
            {
                AddErrors(ModelState);
                return ApiResponse();
            }return Ok();
        }
    }
}
