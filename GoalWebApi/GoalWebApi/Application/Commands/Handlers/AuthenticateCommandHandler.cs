using GoalWebApi.Application.Queries;
using GoalWebApi.Data;
using GoalWebApi.Domain.Entity;
using GoalWebApi.Models.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Commands.Handlers
{
    public class AuthenticateCommandHandler : CommandActions,
                         IRequestHandler<NewAccessAuthenticateCommand, MainValidation>
    {
        private readonly IMediator _mediator;
        private readonly AuthQueries _authQueries;
        private readonly GoalRepository<Users> _usersRepository;
        public AuthenticateCommandHandler(IMediator mediator, AuthQueries authQueries, GoalRepository<Users> usersRepository)
        {
            _mediator = mediator;
            _authQueries = authQueries;
            _usersRepository = usersRepository;
        }
        public async Task<MainValidation> Handle(NewAccessAuthenticateCommand message, CancellationToken cancellationToken)
        {
            var user = _authQueries.Authenticate(new Models.Auth.AuthenticateModel
            {
                Email = message.Email,
                Password = message.Password
            });
            if (user != null)
            {
                Validation.AddError("Email already exists");
                return Validation;
            }
            var newUser = new Users
            {
                Id = Guid.NewGuid(),
                Email = message.Email,
                Password = message.Password,
                Name = message.Name,
                Surname = message.Surname
            };
            _usersRepository.Add(newUser);
            await SaveDatabase(_usersRepository.UnitOfWork);
            return Validation;
        }
    }
}
