using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace GoalWebApi.Controllers
{
    [ApiController]
    [Route("goal/api/v1/auth")]
    public class AuthController : MainController
    {
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IActionResult Authenticate()
        {
            return Ok();
        }
    }
}
