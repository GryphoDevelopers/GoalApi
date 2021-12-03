using GoalWebApi.Models.Validations;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using System;
using GoalWebApi.Domain.Entity;
using GoalWebApi.Data;
using System.Linq;

namespace GoalWebApi.Application.Commands.Handlers
{
    public class UserCommandHandler : CommandActions, IRequestHandler<ChangeUserTypeCommand, MainValidation>
    {
        private readonly GoalRepository<Users> _userRepository;

        public UserCommandHandler(GoalRepository<Users> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<MainValidation> Handle(ChangeUserTypeCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Where(x => x.Id == request.userId).FirstOrDefault();
            if (user == null)
            {
                Validation.AddError("Usuário não existe");
                return Validation;
            }
            if (user.SellerId != Guid.Empty)
            {
                Validation.AddError("Usuário já possui acesso total ao sistema, não foi possivel trocar o tipo de conta");
                return Validation;
            }
            user.Update(user.Name, user.Surname, user.Email, user.Password, Guid.NewGuid());
            _userRepository.Update(user);
            await SaveDatabase(_userRepository.UnitOfWork);
            return Validation;
        }
    }
}
