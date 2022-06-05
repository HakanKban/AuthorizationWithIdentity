using System.ComponentModel.DataAnnotations;

namespace AuthorizationWithIdentity.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı gereklidir.")]
        [Display(Name="Kullanıcı Adı")]
        public string UserName { get; set; }

        [Display(Name = "Tel No.")]

        public string PhoneNumber{ get; set; }

        [Required(ErrorMessage = "Email Adresi gereklidir.")]
        [Display(Name = "E-mail Adresi")]
        [EmailAddress(ErrorMessage ="E mail adresi doğru formatta değil.")]
        public string  Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
