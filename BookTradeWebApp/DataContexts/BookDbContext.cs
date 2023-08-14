
using System;
using BookTradeWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTradeWebApp.DataContexts
{
	public class BookDbContext: DbContext
	{
        public BookDbContext(DbContextOptions<BookDbContext> options)
      : base(options) { }

        public DbSet<Book> Books => Set<Book>();
    }
}

