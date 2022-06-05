using Microsoft.AspNetCore.Identity;

namespace AuthorizationWithIdentity.CustomValidation
{
    public class CustomIdentityErrorDescriber :IdentityErrorDescriber  
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DuplicateUserName",
                Description = $"Bu {userName} kullanıcı adı kullanılmaktadır."

            };
        }
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "InvalidUserName",
                Description = $"Bu {userName} geçersizdir"
            };

        }     
        public override IdentityError  DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"Bu {email} adresi kullanılmaktadır."
            };

        }     
        public override IdentityError  PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordShort",
                Description = $"Şifreniz en az {length} karakterli olmalıdır."
            };

        }
    }
}
