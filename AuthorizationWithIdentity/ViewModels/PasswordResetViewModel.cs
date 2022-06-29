using System.ComponentModel.DataAnnotations;

namespace AuthorizationWithIdentity.ViewModels
{
    public class PasswordResetViewModel
    {
        [Required(ErrorMessage = "Email Adresi gereklidir.")]
        [Display(Name = "E-mail Adresi")]
        [EmailAddress(ErrorMessage = "E mail adresi doğru formatta değil.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifre gereklidir.")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifre en az karakterli olmalıdır")]
        public string PasswordNew { get; set; }
    }
}
