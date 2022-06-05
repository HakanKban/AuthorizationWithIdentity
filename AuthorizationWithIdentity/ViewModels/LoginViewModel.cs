using System.ComponentModel.DataAnnotations;

namespace AuthorizationWithIdentity.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email Adresi gereklidir.")]
        [Display(Name = "E-mail Adresi")]
        [EmailAddress(ErrorMessage = "E mail adresi doğru formatta değil.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage ="Şifre en az karakterli olmalıdır")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
