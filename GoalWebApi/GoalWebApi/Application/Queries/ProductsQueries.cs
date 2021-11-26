using GoalWebApi.Application.Queries.Interfaces;
using GoalWebApi.Data;
using GoalWebApi.Domain.Entity;
using GoalWebApi.Extensions;
using GoalWebApi.Models.Filter;
using GoalWebApi.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Queries
{
    public class ProductsQueries : IProductsQueries
    {
        private readonly GoalRepository<Products> _productsRepository;
        public ProductsQueries(GoalRepository<Products> productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<PagedResult<ProductDetailsModel>> GetProducts(int page, int pageSize, ProductsFilter query = null)
        {
            var productsQuery = _productsRepository.GetAll();
            if (query != null)
            {
                if (query.CategoryId != Guid.Empty)
                {
                    productsQuery = productsQuery.Where(x => x.CategoryId == query.CategoryId);
                }
            }
            var products = await productsQuery.GetPagination(page, pageSize);
            return new PagedResult<ProductDetailsModel>()
            {
                List = products.List.Select(x => new ProductDetailsModel {
                    Amount = x.Amount,
                    CategoryId = x.CategoryId,
                    Price = x.Price,
                    Desc = x.Desc,
                    Details = x.Details.Select(x => new DetailsModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ProductId = x.ProductId,
                        Value = x.Value
                        
                    }).ToList(),
                    Id = x.Id,
                    Title = x.Title,
                    UserId = x.UserId
                }).ToList()
            };
                
        }
    }
}
