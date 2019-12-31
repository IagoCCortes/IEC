using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUserId;
using AutoMapper;
using Infrastructure.Identity;
using Infrastructure.Identity.ViewModels;
using MediatR;
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
                var user = await Mediator.Send(new CreateUserCommand{ UserId = userToCreate.Id, UserName = userToCreate.UserName, Email = userToCreate.Email});
                return CreatedAtRoute("GetUser", new {controller = "Users", id = user.Id}, user);
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
                var userId = await Mediator.Send(new GetUserIdQuery { Id = user.Id});

                return Ok(new
                {
                    token = GenerateJwtToken(user, userId.Id),
                    user
                });
            }

            return Unauthorized();
        }

        private string GenerateJwtToken(ApplicationUser user, int userId)
        {
            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

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