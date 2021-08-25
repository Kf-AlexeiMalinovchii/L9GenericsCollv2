
using Microsoft.EntityFrameworkCore;
using System;
using L9GenericsColl.Entities;
namespace SomeGamesDbContext
{
    public class MyGameDbContext:DbContext
    {
        private const string _connectionString = "";
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Gamer> Gamers { get; set; }

    }
}
