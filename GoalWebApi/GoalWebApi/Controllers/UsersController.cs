using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Controllers
{
    [ApiController]
    [Route("goal/api/v1/users")]
    public class UsersController : MainController
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAllUsers()
        {
            return ApiResponse();
        }

        [HttpPost]
        [Route("add-user")]
        [AllowAnonymous]
        public IActionResult AddUser()
        {
            return ApiResponse();
        }
    }
}
