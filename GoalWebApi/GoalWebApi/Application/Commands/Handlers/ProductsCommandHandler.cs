using GoalWebApi.Models.Validations;
using GoalWebApi.Domain.Entity;
using System.Threading.Tasks;
using System.Threading;
using GoalWebApi.Data;
using MediatR;
using System;
using System.Linq;
using GoalWebApi.Application.Queries;

namespace GoalWebApi.Application.Commands.Handlers
{
    public class ProductsCommandHandler :
                            CommandActions,
                            IRequestHandler<AddProductsCommand, MainValidation>
    {
        private readonly IMediator _mediator;
        private readonly GoalRepository<Products> _productsRepository;
        private readonly ProductsQueries _productsQueries;
        public ProductsCommandHandler(IMediator mediator, GoalRepository<Products> productsRepository, ProductsQueries productsQueries)
        {
            _mediator = mediator;
            _productsRepository = productsRepository;
            _productsQueries = productsQueries;
        }
        public async Task<MainValidation> Handle(AddProductsCommand request, CancellationToken cancellationToken)
        {
            var prod = _productsRepository.GetAll().Where(x => x.Id == request.Id).FirstOrDefault();
            if (prod != null)
            {
                prod.Atualizar(request.Title, request.Desc, request.Price, request.Amount, request.CategoryId, request.SellerId,
                    request.Details);
            }
            var product = new Products(Guid.NewGuid(), request.Title, request.Desc,
                request.Price, request.Amount, request.CategoryId, request.SellerId);
            await SaveDatabase(_productsRepository.UnitOfWork);
            return Validation;

        }
    }
}
