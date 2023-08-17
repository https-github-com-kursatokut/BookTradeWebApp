using System;
using BookTradeWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTradeWebApp.DataContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
       : base(options) { }

        // Ayrı bir conection string belirtmesiyle de yapamadım 
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port = 5432;Database=BookTradeWebAppDb;User Id=Postgres;Password=Mamy.5656");
        }*/


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.TradeOffers)
                .WithOne(to => to.OfferedBook)
                .HasForeignKey(to => to.OfferedBookId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<TradeOffer> TradeOffers { get; set; }

    }
}

