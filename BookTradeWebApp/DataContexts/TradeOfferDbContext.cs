using System;
using BookTradeWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTradeWebApp.DataContexts
{
	public class TradeOfferDbContext : DbContext
	{
        public TradeOfferDbContext(DbContextOptions<TradeOfferDbContext> options)
    : base(options) { }

        public DbSet<TradeOffer> TradeOffers => Set<TradeOffer>();
    }
}

