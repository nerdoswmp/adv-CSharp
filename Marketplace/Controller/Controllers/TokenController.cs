namespace Controller.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using DTO;
using Model;

[ApiController]
[Route("client")]
public class TokenController : ControllerBase
{
    public IConfiguration _configuration;

    public TokenController(IConfiguration config)
    {
        _configuration = config;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult tokenGenerate([FromBody] ClientDTO login)
    {
        if (login != null && login.login != null && login.passwd != null)
        {
            var user = Model.Client.loginClient(login);
            if (user != null)
            {
                Console.WriteLine(user.getId().ToString());
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.getId().ToString()),
                    
                    new Claim("UserName", user.getName()),
                    new Claim("Email", user.getEmail())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
{
                return BadRequest("Invalid credentials");
            }
        }
        else
    {
            return BadRequest("Empty credentials");
        }
    }
}
