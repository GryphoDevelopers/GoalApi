using Microsoft.AspNetCore.Mvc;

namespace GoalWebApi.Controllers
{
    [ApiController]
    [Route("goal/api/users")]
    public class UsersController : MainController
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAllUsers()
        {
            return ApiResponse("Autorizado");
        }
    }
}
