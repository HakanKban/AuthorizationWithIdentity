using System.ComponentModel.DataAnnotations;

namespace AuthorizationWithIdentity.ViewModels
{
    public class PasswordChangeModel
    {
        [Display(Name ="Eski Şifreniz")]
        [Required(ErrorMessage="Eski şifreniz gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage ="Şifreniz en az 4 karakterli olmak zorundadır")]
        public string PasswordOld { get; set; }

        [Display(Name = "Yeni Şifreniz")]
        [Required(ErrorMessage = "Yeni şifreniz gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifreniz en az 4 karakterli olmak zorundadır")]
        public string PasswordNew { get; set; }

        [Display(Name = "Tekrar Yeni Şifreniz")]
        [Required(ErrorMessage = "Yeni şifreniz gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifreniz en az 4 karakterli olmak zorundadır")]
        [Compare("PasswordNew",ErrorMessage ="Yeni şifre ile onay şifreniz aynı olmalıdır")]
        public string PasswordConfirm { get; set; }
    }
}
