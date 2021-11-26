using GoalWebApi.Models.Validations;
using GoalWebApi.Domain.Entity;
using System.Threading.Tasks;
using System.Threading;
using GoalWebApi.Data;
using MediatR;
using System;
using System.Linq;

namespace GoalWebApi.Application.Commands.Handlers
{
    public class ProductsCommandHandler : CommandActions, IRequestHandler<AddProductsCommand, MainValidation>
    {
        private readonly IMediator _mediator;
        private readonly GoalRepository<Products> _productsRepository;
        public ProductsCommandHandler(IMediator mediator, GoalRepository<Products> productsRepository)
        {
            _mediator = mediator;
            _productsRepository = productsRepository;
        }
        public async Task<MainValidation> Handle(AddProductsCommand request, CancellationToken cancellationToken)
        {
            var product = new Products(Guid.NewGuid(), request.Title, request.Desc,
                request.Price, request.Amount, request.CategoryId, request.SellerId);
            await SaveDatabase(_productsRepository.UnitOfWork);
            return Validation;

        }
    }
}
