using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Controllers
{
    [ApiController]
    [Route("goal/api/payments")]
    public class PaymentsController : MainController
    {
        [HttpPost]
        [Route("register-payment")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
