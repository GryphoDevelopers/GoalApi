using GoalWebApi.Extensions;
using GoalWebApi.Models.Filter;
using GoalWebApi.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Queries.Interfaces
{
    public interface IProductsQueries 
    {
        Task<PagedResult<ProductDetailsModel>> GetProducts(int page, int pageSize, ProductsFilter query = null);
    }
}
