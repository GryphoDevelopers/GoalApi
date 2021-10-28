using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Domain.Entity
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool SysIsDeleted { get; private set; }
        public void Deletar() => SysIsDeleted = true;
    }
}
