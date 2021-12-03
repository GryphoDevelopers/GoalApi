using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Domain.Entity
{
    public class Users : Entity
    {
        public Users(Guid id, string surname, string email, string password, Guid sellerId, string name)
        {
            Id = id;
            Surname = surname;
            Email = email;
            Password = password;
            SellerId = sellerId;
            Name = name;
        }

        public void Update(string name, string surname, string email, string password, Guid sellerId)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            SellerId = sellerId;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Guid SellerId { get; private set; }
    }
}
