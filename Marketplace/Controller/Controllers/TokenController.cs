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
[Route("login")]
public class TokenController : ControllerBase
{
    public IConfiguration _configuration;

    public TokenController(IConfiguration config)
    {
        _configuration = config;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult tokenGenerate([FromBody] LoginDTO login)
    {
        bool isClient = Client.getAllClients().Any(l => l.login == login.login && l.passwd == login.passwd);
        bool isOwner = Owner.getAllOwners().Any(l => l.login == login.login && l.passwd == login.passwd);

        dynamic user = null;

        switch((isClient, isOwner))
        {
            case (true, false):
                user = Model.Client.loginClient(login);
                break;
            case (false, true):
                user = Model.Owner.loginOwner(login);
                break;

        }

        if (login != null && login.login != null && login.passwd != null)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
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

    [HttpPost]
    [Route("type")]
    public bool getPersonType([FromBody] LoginDTO login)
    {
        bool isClient = Client.getAllClients().Any(l => l.login == login.login && l.passwd == login.passwd);
        bool isOwner = Owner.getAllOwners().Any(l => l.login == login.login && l.passwd == login.passwd);

        dynamic user = null;

        switch ((isClient, isOwner))
        {
            case (true, false):
                return false;
            case (false, true):
                return true;
            default:
                return false;
        }
    }
}
