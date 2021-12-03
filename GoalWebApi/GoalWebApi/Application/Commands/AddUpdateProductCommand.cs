using GoalWebApi.Models.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using GoalWebApi.Models.Products;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Commands
{
    public class AddUpdateProductCommand : IRequest<MainValidation>
    {
        public AddUpdateProductCommand(Guid id, string title, string desc, decimal price, int amount, Guid categoryId, Guid sellerId, List<ProductsDetailsListModel> details)
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

        public Guid Id { get; set; }
        public string Title { get; private set; }
        public string Desc { get; private set; }
        public decimal Price { get; private  set; }
        public int Amount { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid SellerId { get; private set; }
        public List<ProductsDetailsListModel> Details { get; set; }

    }
}
