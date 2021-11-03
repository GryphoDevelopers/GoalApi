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
    public class UserCommandHandler : CommandActions,
                            IRequestHandler<NewAccessAuthenticateCommand, MainValidation>
    {
        private readonly IMediator _mediator;
        private readonly GoalRepository<Users> _usersRepository;
        public UserCommandHandler(IMediator mediator, GoalRepository<Users> usersRepository)
        {
            _mediator = mediator;
            _usersRepository = usersRepository;
        }

        public Task<MainValidation> Handle(NewAccessAuthenticateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
