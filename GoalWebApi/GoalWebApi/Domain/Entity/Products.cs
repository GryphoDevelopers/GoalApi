using System;
using System.Collections.Generic;

namespace GoalWebApi.Domain.Entity
{
    public class Products : Entity
    {

        public Products() { }


        public Products(Guid id, string title, string desc, decimal price, int amount, Guid categoryId, Guid sellerId, List<DetailsItens> details)
        {
            Id = id;
            Title = title;
            Desc = desc;
            Price = price;
            Amount = amount;
            CategoryId = categoryId;
            SellerId = sellerId;
            Details = details;
        }

        public void Update(Guid id, string title, string desc, decimal price, int amount, Guid categoryId, Guid sellerId, List<DetailsItens> details)
        {
            Id = id;
            Title = title;
            Desc = desc;
            Price = price;
            Amount = amount;
            CategoryId = categoryId;
            SellerId = sellerId;
            Details = details;
        }

        public string Title { get; private set; }
        public string Desc { get; private set; }
        public decimal Price { get; private  set; }
        public int Amount { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid SellerId { get; private set; }
        //Ef core S
        public virtual Categories Category { get; private set; }
        public virtual List<DetailsItens> Details { get; set; }
        public virtual Users Seller { get; private set; }
    }
}
