using Microsoft.AspNetCore.Mvc;
namespace GoalWebApi.Controllers
{
    [ApiController]
    [Route("goal/api/orders")]
    public class OrdersController : MainController
    {
        [HttpPost]
        [Route("create-order")]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPatch]
        [Route("confirm-order")]
        public IActionResult ConfirmOrder()
        {
            return View();
        }

        [HttpGet]
        [Route("my-orders")]
        public IActionResult GetMyOrders()
        {
            return View();
        }

        [HttpPut]
        [Route("change-order-info")]
        public IActionResult ChangeOrderInfo()
        {
            return View();
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllOrders()
        {
            return View();
        }
    }
}
