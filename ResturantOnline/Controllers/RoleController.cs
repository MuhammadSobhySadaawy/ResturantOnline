using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantOnline.Models;
using ResturantOnline.ViewModel;

namespace ResturantOnline.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel newRole)
        {
            if (ModelState.IsValid == true)
            {
                IdentityRole role = new IdentityRole();
                role.Name = newRole.RoleName;
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View("AllRoles");
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(newRole);
        }


        public IActionResult AllRoles()
        {

            var roles = roleManager.Roles.ToList();

            return View(roles);
        }

        public async Task<IActionResult> EditUserRole(string Email)
        {
            var user = await userManager.FindByEmailAsync(Email);
            // Get the roles for the user

            EditUserRoleViewModel viewModel = new EditUserRoleViewModel
            {
                Email = user.Email,
                Address = user.Address,
                UserName = user.UserName,
                RoleNames = roleManager.Roles.ToList(),
            };
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditUserRole(EditUserRoleViewModel edit)
        {
            var user = await userManager.FindByEmailAsync(edit.Email);
            var currentRoleId = await roleManager.FindByIdAsync(edit.RoleId);
            var cRoleId = await userManager.GetRolesAsync(user);

            var newRoleName = await roleManager.Roles.Where(x => x.Id == edit.RoleId).Select(x => x.Name).FirstOrDefaultAsync();
            if (cRoleId != null)
            {
                var x = await userManager.RemoveFromRoleAsync(user, cRoleId.FirstOrDefault());
            }

            var s = await userManager.AddToRoleAsync(user, newRoleName);

            return RedirectToAction("AllAccount");

        }



        public async Task<IActionResult> AllAccount()
        {
            List<ApplicationUser> allACCOUNT = userManager.Users.ToList();
            List<AllAcountViewModel> all = new List<AllAcountViewModel>();

            foreach (var item in allACCOUNT)
            {
                var user = await userManager.FindByEmailAsync(item.Email);
                // Get the roles for the user
                var roles = await userManager.GetRolesAsync(user);


                AllAcountViewModel viewModel = new AllAcountViewModel
                {
                    Email = item.Email,
                    Address = item.Address,
                    UserName = item.UserName,
                    RoleName = roles.FirstOrDefault(),
                };
                all.Add(viewModel);
            }
            return View(all);
        }
    }
}
