using System;

namespace GoalWebApi.Models.Filter
{
    public class ProductsFilter
    {
        public Guid? CategoryId { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool HasFilter => CategoryId.HasValue || MaxPrice.HasValue;
    }
}
