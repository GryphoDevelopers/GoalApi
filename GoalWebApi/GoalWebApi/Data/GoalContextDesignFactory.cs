using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GoalWebApi.Data
{
    public class GoalContextDesignFactory : GoalContextFactoryBase<GoalContext>
    {
        public GoalContextDesignFactory() : base("DefaultConnection", typeof(Startup).GetTypeInfo().Assembly.GetName().Name)
        { }
        protected override GoalContext CreateNewInstance(DbContextOptions<GoalContext> options)
        {
            return new GoalContext(options);
        }
    }
}
