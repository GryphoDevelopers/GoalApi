using GoalWebApi.Models.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Commands
{
    public class NewAccessAuthenticateCommand : IRequest<MainValidation>
    {
        public NewAccessAuthenticateCommand(Guid id, string name, string surname, string email, string password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
