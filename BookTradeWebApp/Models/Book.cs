using System;


namespace BookTradeWebApp.Models
{
	public class Book
	{
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public BookStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public int OwnerUserId { get; set; }
        public User OwnerUser { get; set; }
        public List<TradeOffer> TradeOffers { get; set; }
        public List<Review> Reviews { get; set; }

    }
}

