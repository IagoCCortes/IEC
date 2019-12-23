using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebUI.Controllers
{
    public class AuthController
    {
        // [Route("api/[controller]")]
        // [ApiController]
        // public class AuthController : ControllerBase
        // {
        //     private readonly IUnitOfWork _unitOfWork;
        //     private readonly IMapper _mapper;
        //     private readonly IConfiguration _config;
        //     public AuthController(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        //     {
        //         _config = config;
        //         _mapper = mapper;
        //         _unitOfWork = unitOfWork;
        //     }

        //     // public event EventHandler UserRegistered;

        //     [HttpPost("register")]
        //     public async Task<IActionResult> RegisterUserAsync(UserForRegisterDto userForRegisterDto)
        //     {
        //         userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

        //         if (await _unitOfWork.Auth.UserExistis(userForRegisterDto.Username))
        //             return BadRequest("Username already exists");

        //         var userToCreate = _mapper.Map<User>(userForRegisterDto);

        //         byte[] passwordHash, passwordSalt;

        //         CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

        //         userToCreate.PasswordHash = passwordHash;
        //         userToCreate.PasswordSalt = passwordSalt;

        //         _unitOfWork.Auth.Add(userToCreate);

        //         if (await _unitOfWork.CompleteAsync() > 0)
        //         {
        //             var userToReturn = _mapper.Map<UserForDetailedDto>(userToCreate);

        //             // UserRegistered();

        //             return Ok(userToReturn);
        //             //return CreatedAtRoute("GetUser", new {controller = "Users", id = userToCreate.Id}, userToReturn);
        //         }

        //         throw new Exception("Registering user failed on save");
        //     }

        //     private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //     {
        //         using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //         {
        //             passwordSalt = hmac.Key;
        //             passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //         }
        //     }

        //     [HttpPost("login")]
        //     public async Task<IActionResult> LoginAsync(UserForLoginDto userForLoginDto)
        //     {
        //         var user = await _unitOfWork.Users.GetUserByUsernameAsync(userForLoginDto.Username);

        //         if ((user == null) || (!VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt)))
        //             return Unauthorized();

        //         var claims = new[]{
        //         new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //         new Claim(ClaimTypes.Name, user.Username)
        //     };

        //         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

        //         var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //         var tokenDescriptor = new SecurityTokenDescriptor
        //         {
        //             Subject = new ClaimsIdentity(claims),
        //             Expires = DateTime.Now.AddDays(10),
        //             SigningCredentials = creds
        //         };

        //         var tokenHandler = new JwtSecurityTokenHandler();

        //         var token = tokenHandler.CreateToken(tokenDescriptor);

        //         var userToReturn = _mapper.Map<UserForDetailedDto>(user);

        //         return Ok(new
        //         {
        //             token = tokenHandler.WriteToken(token),
        //             user
        //         });
        //     }

        //     private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        //     {
        //         using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        //         {
        //             var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        //             for (int i = 0; i < computedHash.Length; i++)
        //             {
        //                 if (computedHash[i] != passwordHash[i]) return false;
        //             }
        //         }
        //         return true;
        //     }
        // }
    }
}