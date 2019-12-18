using System.Threading.Tasks;
using AutoMapper;
using IEC.API.Core;
using Microsoft.AspNetCore.Mvc;

namespace IEC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetAsync(id);

            return Ok(user);
        }
    }
}