using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Controllers
{
    [ApiController]
    [Route("goal/api/contact")]
    public class ContactController : Controller
    {
        [HttpPost]
        [Route("open-ticket")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
