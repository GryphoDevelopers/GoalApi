using GoalWebApi.Application.Queries;
using GoalWebApi.Models.Filter;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System;
using GoalWebApi.Application.Commands;
using System.Linq;
using GoalWebApi.Models.Products;
using GoalWebApi.Application.Queries.Interfaces;
using GoalWebApi.Extensions;

namespace GoalWebApi.Controllers
{
    [ApiController]
    [Route("goal/api/products")]
    public class ProductsController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IProductsQueries _productsQueries;
        public ProductsController(IMediator mediator, IProductsQueries productsQueries)
        {
            _mediator = mediator;
            _productsQueries = productsQueries;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(PagedResult<ProductModel>), 200)]
        public async Task<IActionResult> GetAllProducts(int page = 1, int pageSize = 10, [FromQuery] ProductsFilter query = null)
        {
            return ApiResponse(await _productsQueries.GetAllProducts(page, pageSize, query));
        }

        [HttpPost]
        [Route("add-product")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ProductModel), 200)]
        public async Task<IActionResult> AddProducts([FromBody] ProductModel model)
        {
            if (model.Id == Guid.Empty) model.Id = Guid.NewGuid();
            var command = new AddUpdateProductCommand(model.Id, model.Title, model.Desc,
                model.Price, model.Amount, model.CategoryId, model.SellerId, model.DetailsList);
            var valid = await _mediator.Send(command);
            if (!valid.isValid())
            {
                AddErrors(valid.Errors);
                return ApiResponse();
            }
            return ApiResponse(model);
        }
        
        [HttpPut]
        [Route("update-product")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(ProductModel), 200)]
        public async Task<IActionResult> UpdateProducts([FromBody] ProductModel model)
        {
            if (model.Id == Guid.Empty) model.Id = Guid.NewGuid();
            var command = new AddUpdateProductCommand(model.Id, model.Title, model.Desc,
                model.Price, model.Amount, model.CategoryId, model.SellerId, model.DetailsList);
            var valid = await _mediator.Send(command);
            if (!valid.isValid())
            {
                AddErrors(valid.Errors);
                return ApiResponse();
            }
            return ApiResponse(model);
        }

        [HttpDelete]
        [Route("{userId}/{productId}/remove-product")]
        public async Task<IActionResult> RemoveProduct()
        {
            return ApiResponse();
        }

        [HttpGet]
        [Route("{userId}/my-products")]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(PagedResult<ProductModel>), 200)]
        public async Task<IActionResult> MyProducts(Guid userId, int page = 1, int pageSize = 10, [FromQuery] ProductsFilter query = null)
        {
            return ApiResponse(await _productsQueries.GetMyProducts(userId, page, pageSize, query));
        }
    }
}
