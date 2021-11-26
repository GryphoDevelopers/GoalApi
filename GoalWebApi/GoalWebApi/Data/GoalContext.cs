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
        public DbSet<Products> Products { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<DetailsItens> DetailsItens { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var connection= "Server=localhost;Port=3306;Database=dbGoalDev;Uid=root;Pwd=root;";
                var connection = "Server=remotemysql.com;Port=3306;Database=butAyb3R9k;Uid=butAyb3R9k;Pwd=3Um4H4NRez;";
                optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
            }
        }
        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}

// butAyb3R9k
// 3Um4H4NRez
