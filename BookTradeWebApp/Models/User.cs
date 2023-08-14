using System;
namespace BookTradeWebApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfilePictureUrl { get; set; } 
        public bool IsActive { get; set; } 
        public DateTime RegistrationDate { get; set; }


        public List<Book> OwnedBooks { get; set; }
        public List<TradeOffer> TradeOffers { get; set; }
        public List<Review> Reviews { get; set; }

    }
}

