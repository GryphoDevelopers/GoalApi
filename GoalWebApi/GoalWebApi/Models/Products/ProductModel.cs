using System;
using System.Collections.Generic;

namespace GoalWebApi.Models.Products
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SellerId { get; set; }
        public List<ProductsDetailsListModel> DetailsList { get; set; }
    }
}
