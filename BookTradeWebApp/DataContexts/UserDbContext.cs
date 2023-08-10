using System;
using BookTradeWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTradeWebApp.DataContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
       : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}

