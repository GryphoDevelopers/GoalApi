using GoalWebApi.Models.Validations;
using GoalWebApi.Domain.Entity;
using System.Threading.Tasks;
using System.Threading;
using GoalWebApi.Data;
using System.Linq;
using MediatR;
using System;

namespace GoalWebApi.Application.Commands.Handlers
{
    public class ProductCommandHandler : CommandActions, IRequestHandler<AddUpdateProductCommand, MainValidation>
    {
        private readonly GoalRepository<Products> _productsRepository;
        private readonly GoalRepository<Users> _userRepository;
        private readonly GoalRepository<Categories> _categoryRepository;
        public ProductCommandHandler(GoalRepository<Products> productsRepository, GoalRepository<Users> userRepository, GoalRepository<Categories> categoryRepository)
        {
            _productsRepository = productsRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<MainValidation> Handle(AddUpdateProductCommand message, CancellationToken cancellationToken)
        {
            var seller = _userRepository.Where(x => x.SellerId == message.SellerId).FirstOrDefault();
            if(seller == null)
            {
                Validation.AddError("O usuário deve ser um vendedor");
                return Validation;
            }
            var category = _categoryRepository.Where(x => x.Id == message.CategoryId).FirstOrDefault();
            if(category == null)
            {
                Validation.AddError("A categoria informada não existe");
                return Validation;
            }
            var product = _productsRepository.GetAll().Where(x => x.Id == x.Id).FirstOrDefault();
            if (product != null)
            {
                product.Update(message.Id, message.Title, message.Desc, message.Price,
                message.Amount, message.CategoryId, message.SellerId,
                message.Details.Select(x => new DetailsItens((x.Id == Guid.Empty ? Guid.NewGuid() : x.Id), x.Name, x.Value, message.Id)).ToList());
                return Validation;
            }
            //add
            product = new Products(message.Id, message.Title, message.Desc, message.Price,
                message.Amount, message.CategoryId, message.SellerId,
                message.Details.Select(x => new DetailsItens(Guid.NewGuid(), x.Name, x.Value, message.Id)).ToList());
            _productsRepository.Add(product);
            await SaveDatabase(_productsRepository.UnitOfWork);
            return Validation;
        }
    }
}
