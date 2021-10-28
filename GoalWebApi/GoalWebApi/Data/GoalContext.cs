using GoalWebApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Data
{
    public class GoalContext : DbContext, IUnitOfWork
    {
        public GoalContext() { }
        public GoalContext(DbContextOptions<GoalContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connection = "Server=localhost;Port=3306;Database=dbGoal;Uid=root;Pwd=localroot";
        //    optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        //}
        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
