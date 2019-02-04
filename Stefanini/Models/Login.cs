using System.ComponentModel.DataAnnotations;

namespace Stefanini.Models
{
    public class Login
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}