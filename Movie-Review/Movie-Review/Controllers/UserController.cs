using Microsoft.AspNetCore.Mvc;
using Movie_Review.Data.Dtos;
using Movie_Review.Services;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private UserService _UserService;

        public UserController(UserService registerService)
        {
            _UserService = registerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser
            (CreateUserDto dto)
        {
            await _UserService.SignUser(dto);
            return Ok("Usuário cadastrado!");

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserDto dto)
        {
            var token = await _UserService.Login(dto);
            return Ok(token);
        }
    }
}
