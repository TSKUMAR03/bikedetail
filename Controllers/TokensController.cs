using Bike.Domain.Context;
using Bike.Domain.Halder;
using Bike.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BikeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {

        private readonly DataContext _context;

        private readonly JWTSetting _jwtSetting;

        public TokensController(DataContext context, IOptions<JWTSetting> options)
        {
            _context = context;
            _jwtSetting = options.Value;
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]

        public IActionResult Authenticate([FromBody] SignInModel user)
        {

            var _user = _context.SalesManTable.FirstOrDefault(Us => Us.EmailId == user.EmailId && Us.PassWord == user.PassWord);
            if (_user == null)
                return Unauthorized();

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(_jwtSetting.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {

                           new Claim(ClaimTypes.Email,_user.EmailId.ToString()),
                    }
                 ),
                Expires = DateTime.Now.AddSeconds(70),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)

            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            String finaltoken = tokenhandler.WriteToken(token);

            return Ok(finaltoken);
        }

    }
}
