using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Models.DTOs;
using TaskManager.Api.Models.Entities;
using TaskManager.Api.Services;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        private readonly PasswordService _passwordService = new PasswordService();

        public UsersController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if(await _context.Users.AnyAsync(u => u.Email == userRegisterDto.Email))
                return BadRequest("Email already in use.");

            _passwordService.CreatePasswordHash(userRegisterDto.Password,out string hash, out string salt);

            var user = new User
            {
                FullName = userRegisterDto.FullName,
                Email = userRegisterDto.Email,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new {message = "User registered succesfully!"});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userLoginDto.Email);
            if (user == null) return Unauthorized("Invalid Credentials!");
            if (!_passwordService.VerifyPassword(userLoginDto.Password, user.PasswordHash, user.PasswordSalt)) return Unauthorized("Invalid Credentials!");

            var token = _jwtService.GenerateToken(user);
            return Ok(new { Token = token});
        }
    }
}
