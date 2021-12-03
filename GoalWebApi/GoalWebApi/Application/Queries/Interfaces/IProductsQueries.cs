using GoalWebApi.Extensions;
using GoalWebApi.Models.Filter;
using GoalWebApi.Models.Products;
using System.Threading.Tasks;
using System;

namespace GoalWebApi.Application.Queries.Interfaces
{
    public interface IProductsQueries 
    {
        Task<PagedResult<ProductModel>> GetAllProducts(int page, int pageSize, ProductsFilter query = null);
        Task<ProductModel> GetProductById(Guid id);
        Task<PagedResult<ProductModel>> GetMyProducts(Guid sellerId, int page, int pageSize, ProductsFilter query = null);
    }
}
