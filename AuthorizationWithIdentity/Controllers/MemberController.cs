using AuthorizationWithIdentity.Models;
using AuthorizationWithIdentity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace AuthorizationWithIdentity.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        public UserManager<AppUser> userManager { get; }
        public SignInManager<AppUser> signInManager { get; }

        public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

            UserViewModel userViewModel = user.Adapt<UserViewModel>(); //userviewmodele dönüştür.

            return View(userViewModel);
        }
        public IActionResult PasswordChange()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PasswordChange(PasswordChangeModel passwordChangeModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

                bool exist = userManager.CheckPasswordAsync(user, passwordChangeModel.PasswordOld).Result;
                if (exist)
                {
                    IdentityResult result = userManager.ChangePasswordAsync(user, passwordChangeModel.PasswordOld,
                        passwordChangeModel.PasswordNew).Result;
                    if (result.Succeeded)
                    {
                        userManager.UpdateSecurityStampAsync(user);

                        signInManager.SignOutAsync();
                        signInManager.PasswordSignInAsync(user, passwordChangeModel.PasswordNew, true, false);
                        //

                        ViewBag.success = "true";
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Eski şifreniz yanlış");
                }
            }



            return View(passwordChangeModel);
        }
    }
}
