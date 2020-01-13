using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.UserProfiles.Commands.CreateUserProfile;
using Application.UserProfiles.Queries.GetUserProfileId;
using Infrastructure.Identity;
using Infrastructure.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        // public event EventHandler UserRegistered;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody]RegisterViewModel registerViewModel)
        {
            var userToCreate = new ApplicationUser
            {
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(userToCreate, registerViewModel.Password);

            if (result.Succeeded)
            {
                var user = await Mediator.Send(new CreateUserProfileCommand{ UserId = userToCreate.Id, UserName = userToCreate.UserName, Email = userToCreate.Email});
                return CreatedAtRoute("GetUser", new {controller = "UserProfiles", userName = user.UserName}, user);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user == null)
                return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, false);

            if (result.Succeeded)
            {
                //var userToReturn = _mapper.Map<UserForDetailedDto>(user);
                var userProfile = await Mediator.Send(new GetUserProfileIdQuery { Id = user.Id });

                return Ok(new
                {
                    token = GenerateJwtToken(user, userProfile.Id).Result,
                    user
                });
            }

            return Unauthorized();
        }

        private async Task<string> GenerateJwtToken(ApplicationUser user, int userProfileId)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("UserProfileId", userProfileId.ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(10),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}