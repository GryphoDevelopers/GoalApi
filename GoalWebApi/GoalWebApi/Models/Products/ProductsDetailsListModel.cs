using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Models.Products
{
    public class ProductsDetailsListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Guid ProductId { get; set; }
    }
}
