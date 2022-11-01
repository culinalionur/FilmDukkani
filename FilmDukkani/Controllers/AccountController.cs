using FilmDukkani.Models.DTOs;
using FilmDukkani.Models.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmDukkani.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IPasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost , ValidateAntiForgeryToken , AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.UserName, Email = model.MailAddress };
                IdentityResult identityResult = await _userManager.CreateAsync(user,model.Password);
                if (identityResult.Succeeded)
                    return RedirectToAction("Login");
                else
                    foreach (IdentityError error in identityResult.Errors)
                        ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        public IActionResult LogIn(string returnUrl)
        {
            return View(new LoginDTO { ReturnUrl = returnUrl });
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> LogIn(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
               User appUser = await _userManager.FindByNameAsync(model.UserName);

                if (appUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult singInResult = await _signInManager.PasswordSignInAsync(appUser.UserName, model.Password, false, false);

                    if (singInResult.Succeeded) return Redirect(model.ReturnUrl ?? "/");

                    ModelState.AddModelError("", "Wrong credation information..!");
                }
            }
            return View(model);
        }
    }
}
