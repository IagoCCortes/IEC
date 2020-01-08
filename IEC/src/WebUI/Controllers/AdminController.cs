using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Identity;
using Infrastructure.Identity.ViewModels;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    public class AdminController : BaseController
    {
        private readonly IECDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(IECDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersWithRoles()
        {
            var users = await _context.Users.OrderBy(u => u.UserName)
                                .Select(u => new UserRolesDto
                                {
                                    Id = u.Id,
                                    UserName = u.UserName,
                                    Roles = (from ur in _context.UserRoles
                                             join r in _context.Roles on ur.RoleId equals r.Id
                                             where ur.UserId == u.Id
                                             select r.Name).ToList()
                                }).ToListAsync();

            return Ok(users);
        }

        [HttpPost("editRoles/{userName}")]
        public async Task<IActionResult> EditRoles(string userName, RoleEditDto roleEditDto)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var userRoles = await _userManager.GetRolesAsync(user);

            var selectedRoles = roleEditDto.RoleNames;

            selectedRoles = selectedRoles ?? new string[] {};

            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if(!result.Succeeded)
                return BadRequest("Failed to add roles");

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if(!result.Succeeded)
                return BadRequest("Failed to remove roles");

            return Ok(await _userManager.GetRolesAsync(user));
        }
    }
}