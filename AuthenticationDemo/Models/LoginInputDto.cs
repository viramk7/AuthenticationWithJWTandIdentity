using System.ComponentModel.DataAnnotations;

namespace AuthenticationDemo.Models
{
    public class LoginInputDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(32)]
        public string Password { get; set; }
    }
}
