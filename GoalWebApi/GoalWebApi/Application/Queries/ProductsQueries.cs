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
        private readonly GoalRepository<Users> _usersRepository;

        public ProductsQueries(GoalRepository<Products> productsRepository, GoalRepository<Users> usersRepository)
        {
            _productsRepository = productsRepository;
            _usersRepository = usersRepository;
        }

        public async Task<PagedResult<ProductModel>> GetAllProducts(int page, int pageSize, ProductsFilter query = null)
        {
            var products = _productsRepository.GetAll();
            return await products.Select(x => new ProductModel
            {
                Id = x.Id,
                Amount = x.Amount,
                CategoryId = x.CategoryId,
                Desc = x.Desc,
                DetailsList = x.Details.Select(x => new ProductsDetailsListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductId = x.ProductId,
                    Value = x.Value

                }).ToList(),
                Price = x.Price,
                SellerId = x.SellerId,
                Title = x.Title


            }).GetPagination(page, pageSize);
        }

        public async Task<ProductModel> GetProductById(Guid id)
        {
            var product = _productsRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
            return new ProductModel
            {
                Id = product.Id,
                Amount = product.Amount,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Desc = product.Desc,
                DetailsList = product.Details.Select(x => new ProductsDetailsListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductId = x.ProductId,
                    Value = x.Value
                }).ToList(),
                SellerId = product.SellerId,
                Title = product.Title
            };
        }

        public async Task<PagedResult<ProductModel>> GetMyProducts(Guid sellerId, int page, int pageSize, ProductsFilter query = null)
        {

            var seller = _usersRepository.Where(x => x.SellerId == sellerId).FirstOrDefault();
            if (seller == null)
                return null;
            var products = _productsRepository.GetAll().Where(x => x.SellerId == sellerId);
            return await products.Select(x => new ProductModel
            {
                Id = x.Id,
                Amount = x.Amount,
                CategoryId = x.CategoryId,
                Desc = x.Desc,
                DetailsList = x.Details.Select(x => new ProductsDetailsListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductId = x.ProductId,
                    Value = x.Value

                }).ToList(),
                Price = x.Price,
                SellerId = x.SellerId,
                Title = x.Title
            }).GetPagination(page, pageSize);
        }

    }
}
