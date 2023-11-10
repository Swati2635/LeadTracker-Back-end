using LeadTracker.API.Extensions;
using LeadTracker.Application.IService;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class LoginController : BaseController
    {

        public IConfiguration _configuration;
        private readonly ILoginService _loginService;
        private readonly IEmployeeRepository _employeerepository;



        public LoginController(IConfiguration config, ILoginService loginService, IEmployeeRepository employeeService)
        {
            _configuration = config;

            _loginService = loginService;
            _employeerepository = employeeService;



        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post(LoginDTO loginDetails)
        {

            if (loginDetails != null && loginDetails.Mobile != null && loginDetails.DeviceId != null && loginDetails.Password != null)
            {
                // Authenticate the user with the provided credentials
                var user = await _loginService.GetUser(loginDetails.Mobile, loginDetails.Password).ConfigureAwait(false);

                if (user != null && user.DeviceId == null)
                {
                    await _employeerepository.UpdateEmployeeDeviceIdAsync(user.Id, loginDetails.DeviceId);
                    user.DeviceId = loginDetails.DeviceId;
                }
                if (user != null)
                {
                    if (user.DeviceId != loginDetails.DeviceId)
                    {
                        return BadRequest("Login successful, but device details are incorrect, please use correct device");
                    }

                    // User authenticated successfully; create claims for the JWT
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        //Subject = new ClaimsIdentity(new[] { new Claim("UserId", user.UserId.ToString()) }),
                        Subject = new ClaimsIdentity(new[]
                       {
                       new Claim("EmployeeId", user.Id.ToString()),
                       new Claim("Name", user.Name),
                       new Claim("EmailId", user.EmailId),
                       new Claim("UserName", user.UserName),
                       new Claim("OrgId", user.OrgId.ToString()),
                       new Claim("DeviceId", loginDetails.DeviceId),
                       new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"]),
                       new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"])


                    }),
                        Expires = DateTime.Now.AddYears(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
   , SecurityAlgorithms.HmacSha256Signature),
                        Audience = _configuration["Jwt:Audience"],
                        Issuer = _configuration["Jwt:Issuer"]
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    // return Ok(tokenHandler.WriteToken(token));//.ToString();
                    return Ok(new TokenDTO() { Token = tokenHandler.WriteToken(token), User = user });
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }

        }

    }
}

