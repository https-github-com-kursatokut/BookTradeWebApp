using System;
namespace BookTradeWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Şifrelerin hash değerini saklamak için kullanılabilir.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfilePictureUrl { get; set; } // Profil resmi için URL
        public bool IsActive { get; set; } // Hesap aktif/pasif durumu
        public DateTime RegistrationDate { get; set; } // Kayıt tarihi
                                                       // Diğer kullanıcı özelliklerini burada ekleyebilirsiniz.
    }    
}

