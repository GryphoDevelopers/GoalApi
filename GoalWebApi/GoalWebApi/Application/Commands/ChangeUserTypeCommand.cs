using GoalWebApi.Models.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Commands
{
    public class ChangeUserTypeCommand : IRequest<MainValidation>
    {
        public ChangeUserTypeCommand(Guid userId)
        {
            this.userId = userId;
        }
        public Guid userId { get; private set; }

    }
}
