using System;
using BookTradeWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTradeWebApp.DataContexts
{
		public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
        : base(options) { }

        public DbSet<Review> Reviews => Set<Review>();
    }
	
}

