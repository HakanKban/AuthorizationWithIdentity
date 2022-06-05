using AuthorizationWithIdentity.Models;
using AuthorizationWithIdentity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationWithIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIn(string ReturnUrl) // giriş sayfası
        {
            TempData["ReturnUrl"]=ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel login) // giriş sayfası
        {
            if (ModelState.IsValid)
            {

                AppUser user = await _userManager.FindByEmailAsync(login.Email);
                if (user != null)
                {
       
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, login.Password,login.RememberMe, false);// checkboxı ekledik.

                    if (result.Succeeded)
                    {
                        if (TempData["ReturnUrl"] !=null)
                        {
                            return Redirect(TempData["ReturnUrl"].ToString());

                        }
                        return RedirectToAction("Index", "Member");
                    }
          
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz email adresi veya şifresi");
                }


            }
            return View(login);
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel userViewModel) // kayıt sayfası
        {
            //Modelden gelen değerleri veritabanındaki tablomuza atadık.
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;
                IdentityResult result = await _userManager.CreateAsync(user, userViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(userViewModel);
        }

    }
}
