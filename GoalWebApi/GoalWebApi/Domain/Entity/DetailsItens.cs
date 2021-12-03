using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Domain.Entity
{
    public class DetailsItens : Entity
    {
        public DetailsItens(Guid id, string name, string value, Guid productId)
        {
            Id = id;
            Name = name;
            Value = value;
            ProductId = productId;
        }
        public string Name { get; private set; }
        public string Value { get; private set; }
        public Guid ProductId { get; private set; }
        //ef
        private List<Products> Products { get; set; }
    }
}
