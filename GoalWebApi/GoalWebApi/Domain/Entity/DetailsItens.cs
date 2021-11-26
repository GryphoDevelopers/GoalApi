using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Domain.Entity
{
    public class DetailsItens : Entity
    {
        public DetailsItens(string name, string value, Guid productId)
        {
            Name = name;
            Value = value;
            ProductId = productId;
        }
        public void Add(string name, string value, Guid productId)
        {
            Id = Guid.NewGuid();
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
