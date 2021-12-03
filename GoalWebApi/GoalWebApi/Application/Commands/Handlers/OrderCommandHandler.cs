using GoalWebApi.Models.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Commands.Handlers
{
    public class OrderCommandHandler : IRequestHandler<AddOrderCommand, MainValidation>
    {
        public Task<MainValidation> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
