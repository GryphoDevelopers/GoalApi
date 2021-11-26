using GoalWebApi.Models.Products;
using GoalWebApi.Models.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Commands
{
    public class AddProductsCommand : IRequest<MainValidation>
    {
        public AddProductsCommand(string title, string desc, decimal price, int amount, Guid id, Guid sellerId, Guid categoryId, List<DetailsModel> details)
        {
            Title = title;
            Desc = desc;
            Price = price;
            Amount = amount;
            Id = id;
            SellerId = sellerId;
            CategoryId = categoryId;
            Details = details;
        }

        public string Title { get; private set; }
        public string Desc { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; private set; }
        public Guid Id { get; private set; }
        public Guid SellerId { get; private set; }
        public Guid CategoryId { get; private set; }
        public List<DetailsModel> Details { get; set; }
    }
}
