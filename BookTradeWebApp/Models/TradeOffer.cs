using System;
namespace BookTradeWebApp.Models
{
	public class TradeOffer
	{
        public int TradeOfferId { get; set; }
        public int OfferingUserId { get; set; }
        public int OfferedBookId { get; set; }
        public int TargetBookId { get; set; }
        public TradeOfferStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public User OfferingUser { get; set; }
        public Book OfferedBook { get; set; }
        public Book TargetBook { get; set; }
    }
}

