using GoalWebApi.Application.Queries;
using GoalWebApi.Models.Filter;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System;
using GoalWebApi.Models.Products;
using GoalWebApi.Application.Commands;
using System.Linq;
namespace GoalWebApi.Controllers
{
    [ApiController]
    [Route("goal/api/products")]
    public class ProductsController : MainController
    {
        private readonly IMediator _mediator;
        private readonly ProductsQueries _productsQueries;
        public ProductsController(IMediator mediator, ProductsQueries productsQueries)
        {
            _mediator = mediator;
            _productsQueries = productsQueries;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProducts(int page, int pageSize, [FromQuery] ProductsFilter query)
        {
            return ApiResponse(await _productsQueries.GetProducts(page, pageSize, query));
        }
        [HttpPost]
        [Route("{userId}/add-product")]
        public async Task<IActionResult> AddProducts(Guid userId, [FromBody] ProductDetailsModel model)
        {
            var command = new AddProductsCommand(model.Title, model.Desc, model.Price, model.Amount, model.Id, userId, model.CategoryId, model.Details);
            return ApiResponse();
        }
    }
}
