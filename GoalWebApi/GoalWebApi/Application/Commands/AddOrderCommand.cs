using GoalWebApi.Models.Validations;
using MediatR;

namespace GoalWebApi.Application.Commands
{
    public class AddOrderCommand : IRequest<MainValidation>
    {

    }
}
