using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
 using Table_Track.Models;
using Table_Track.Utilty;
using Table_Track.viewModels;

namespace Table_Track.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

 
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

         public async Task<IActionResult> Register()
        {
            if (roleManager.Roles.IsNullOrEmpty())
            {
                await roleManager.CreateAsync(new(Sw.adminRole));
                await roleManager.CreateAsync(new(Sw.CustomerRole));
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUserVm applicationUserVm)
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                UserName = applicationUserVm.name , 
                Email = applicationUserVm.email ,
            };
            var result = await userManager.CreateAsync(applicationUser , applicationUserVm.Password);
            if (result.Succeeded) {
                await userManager.AddToRoleAsync(applicationUser, Sw.CustomerRole);
                await signInManager.SignInAsync(applicationUser, false);
        return RedirectToAction("Index", "Home");
            }        

            return View();
        }
        public async Task<IActionResult> Login()
        {
             return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            
                var applicationUser = await userManager.FindByNameAsync(loginVm.UserName);
                if (applicationUser != null)
                {
                    var c = await userManager.CheckPasswordAsync(applicationUser, loginVm.Password);
                    if (c)
                    {
                        await signInManager.SignInAsync(applicationUser, loginVm.RemeberMe);
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Invalid Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("UserName", "Invalid user");
                }
 
            return View();
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
