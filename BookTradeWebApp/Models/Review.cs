﻿using System;
namespace BookTradeWebApp.Models
{
	public class Review
	{
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}

