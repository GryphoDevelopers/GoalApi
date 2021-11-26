using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Models.Products
{
    public class ProductDetailsModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public List<DetailsModel> Details { get; set; }
    }
}
