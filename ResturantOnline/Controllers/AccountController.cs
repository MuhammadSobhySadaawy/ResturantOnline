using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResturantOnline.Models;
using ResturantOnline.ViewModel;
using System.Threading.Tasks;

namespace ResturantOnline.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly Context contexttDB;

        public AccountController(UserManager<ApplicationUser> _userManager,
                                  SignInManager<ApplicationUser> _signInManager,
                                  RoleManager<IdentityRole> _roleManager,
                                  Context _contexttDB)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            RoleManager = _roleManager;
            contexttDB = _contexttDB;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Regiester()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegiesterUser(RegisterUserModelView UserVm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser UserApp = new ApplicationUser();
                UserApp.Address = UserVm.Address;
                UserApp.Email = UserVm.Email;
                UserApp.PasswordHash = UserVm.Password;
                UserApp.UserName = UserVm.UserName;
                IdentityResult result = await userManager.CreateAsync(UserApp, UserVm.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(UserApp, "User");
                    //create cookie
                    await signInManager.SignInAsync(UserApp, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }


                }

            }
            return View("Regiester");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUSER(LoginModelView userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userww = await userManager.FindByEmailAsync(userVM.Email);
                if (userww != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userww, userVM.Password);
                    if (found)
                    {
                        //create cookie
                        await signInManager.SignInAsync(userww, userVM.RemeberME);
                        return RedirectToAction("Index", "Home");

                    }
                }

                ModelState.AddModelError("", "Email or Password Not Valid");
            }

            return View("Login");
        }


        public async Task<IActionResult> singout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        //   public async Task<IActionResult> EditRole(string id)
        //{
        //    ApplicationUser allACCOUNT = await userManager.FindByIdAsync(id);
        //    if (allACCOUNT != null)
        //    {
        //        IdentityRole userRole = RoleManager.CreateAsync()
        //    }
        //    return View(allACCOUNT);
        //}

    }
}
