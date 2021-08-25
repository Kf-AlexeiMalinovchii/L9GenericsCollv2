
using Microsoft.EntityFrameworkCore;
using L9GenericsColl.Entities;
namespace L9GenericsColl.DbContexts
{
    public class MyGameDbContext : DbContext
    {
        private const string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;DataBase=GameHistory; Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Gamer> Gamers { get; set; }

    }
}
