using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NileSchool.API.Data;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Dtos;
using NileSchool.API.Models;

namespace NileSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;

        public UsersController(IUserRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto user){
            
            var userToLogin = await _repo.LoginAsync(user.Username.ToLower(), user.Password);

            if(userToLogin == null){
                return Unauthorized();
            }

            var Claims = new[] {
                new Claim(ClaimTypes.PrimarySid, userToLogin.Id.ToString()),
                new Claim(ClaimTypes.Name, userToLogin.Name),
                new Claim(ClaimTypes.Role, userToLogin.UserTypeId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var Credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        
            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = Credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }


    }
}