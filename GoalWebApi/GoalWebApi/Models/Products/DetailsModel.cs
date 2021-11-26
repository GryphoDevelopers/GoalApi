using System;

namespace GoalWebApi.Models.Products
{
    public class DetailsModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get;  set; }
        public string Value { get;set; }
    }
}
