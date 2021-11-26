using System;
using System.Collections.Generic;

namespace GoalWebApi.Domain.Entity
{
    public class Products : Entity
    {
        public Products(Guid id, string title, string desc, decimal price, int amount, Guid categoryId, Guid userId)
        {
            Id = id;
            Title = title;
            Desc = desc;
            Price = price;
            Amount = amount;
            CategoryId = categoryId;
            UserId = userId;
        }
        public string Title { get; private set; }
        public string Desc { get; private set; }
        public decimal Price { get; private  set; }
        public int Amount { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid UserId { get; private set; }
        //Ef core 
        public virtual Categories Category { get; set; }
        public virtual List<DetailsItens> Details { get; private set; }
        public virtual Users Seller { get; set; }
    }
}
