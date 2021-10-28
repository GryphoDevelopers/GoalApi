using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace GoalWebApi.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class MainController : Controller
    {
        protected List<string> Errors = new List<string>();
        protected string Title { get; set; }
        protected int Status { get; set; }
        protected IActionResult ApiResponse(object model = null)
        {
            if (!isValid())
            {
                return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }
                )
            );
            }

            return Ok(model);
        }
        protected bool isValid()
        {
            return !Errors.Any();
        }
        protected void AddError(string erro)
        {
            Errors.Add(erro);
        }
        protected void AddErrors(List<string> erro)
        {
            Errors = erro;
        }
        protected void AddErrors(ModelStateDictionary modelState)
        {
            foreach (var erro in modelState.Values.SelectMany(e => e.Errors))
            {
                AddError(erro.ErrorMessage);
            }
        }
    }
}
