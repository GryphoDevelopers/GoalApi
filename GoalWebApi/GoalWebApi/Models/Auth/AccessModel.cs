using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Models.Auth
{
    public class AccessModel
    {
        public string Token { get; set; }
        public Guid SellerId { get; set; }
        public bool IsSeller { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
