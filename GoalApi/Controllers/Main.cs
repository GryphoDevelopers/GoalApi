using Goal.Compile;
using Goal.Response;
using GoalApi.Models.Customers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoalApi.Controllers
{
    public class Main : Controller
    {
        [HttpGet]
        public IActionResult Status()
        {
            return Content("O retorno teste");
        }

        [HttpPost]
        [Route("/api/create/customer")]
        public IActionResult CreateCustomer(Customers customers)
        {
            var result = new List<ValidationResult>();
            if (Validator.TryValidateObject(
                customers,
                new ValidationContext(customers,
                serviceProvider: null,
                items: null),
                result,
                true))
            {
                Compile.Add("tbCustomers", customers).Save();
                return Json(GoalResponse.Success("Create Customer"));
            }
            return Json(GoalResponse.ModelError(result, GetResponse.Action.Insert, "Create Customer").GetError());
        }
    }
}
