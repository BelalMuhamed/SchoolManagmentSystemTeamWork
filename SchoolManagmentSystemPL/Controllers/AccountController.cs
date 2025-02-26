using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemDAL.ViewModels;


namespace SchoolManagmentSystemPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> user;
        private readonly SignInManager<ApplicationUser> sign;

        public AccountController(UserManager<ApplicationUser> user, SignInManager<ApplicationUser> sign)
        {
            this.user = user;
            this.sign = sign;
        }
        public IActionResult register()
        {
            return View("register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser app = new ApplicationUser()
                {
                    UserName = model.Name,
                    Address = model.Address,
                    PasswordHash = model.Password
                };
                IdentityResult result = await user.CreateAsync(app, model.Password);
                if (result.Succeeded)
                {
                    await user.AddToRoleAsync(app, "Teacher");
                    await sign.SignInAsync(app, false);
                    return RedirectToAction("login", "Account");
                }
                else
                {
                    foreach (var i in result.Errors)
                    {
                        ModelState.AddModelError("", i.Description);
                    }
                }
            }
            return View("register");
        }
        public IActionResult login()
        {
            return View("login");
        }
        [HttpPost]
     
        public async Task<IActionResult> login(LoginViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUser result = await user.FindByNameAsync(model.Name);
                if (result != null)
                {
                    bool found = await user.CheckPasswordAsync(result, model.Password);
                    if (found)
                    {
                        await sign.SignInAsync(result, model.RememberMe);
                        if (User.IsInRole("Admin"))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (User.IsInRole("Student"))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (User.IsInRole("Teacher"))
                        {

                        }
                    }
                }
                ModelState.AddModelError("", "enter invalid name or password y basha");
            }
            return View("login", model);
        }

        [HttpPost]

        public async Task<IActionResult> logout()
        {
            await sign.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}