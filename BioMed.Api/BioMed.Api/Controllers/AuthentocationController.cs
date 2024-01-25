using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BioMed.Api.Controllers
{
    [Route("auth")]
    [ApiController]

    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public class AuthentocationController : Controller
    {
        [HttpPost("Login")]
        public ActionResult<string> Login(LoginRequest loginRequest)
        {
            var user = Authenticate(loginRequest.Login, loginRequest.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("login_AzamatG_17SecretKeyInBioMedApi"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Phone));
            claimsForToken.Add(new Claim("name", user.Name));

            var jwtSecurityToken = new JwtSecurityToken(
                "BioMed-api",
                "BioMed",
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(2),
                signingCredentials);

            var token = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(token);
        }

        static User Authenticate(string login, string password)
        {
            return new User()
            {
                Login = login,
                Password = password,
                Name = "Azamat",
                Phone = "+998 (88) 000 00 00"
            };
        }
    }
    class User
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
