using HRM.Rest.Services.DAL.Context;
using HRM.Rest.Services.DAL.CRUD;
using HRM.Rest.Services.DAL.Models;
using HRM.Rest.Services.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Rest.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private UserDbContext _context;

        public AuthController(IConfiguration config, UserDbContext userDbContext)
        {
            _config = config;
            _context = userDbContext;
        }
        // GET api/values  
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] UserInfo user)
        {
            if (user == null)
            {
                return BadRequest("Invalid request");
            }
            var userInfoDataOperations = new UserInfoDBOperations(_context);
            if (userInfoDataOperations.checkIfUserExists(user))
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(60),
                  signingCredentials: credentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost, Route("signup")]
        public IActionResult SignUp([FromBody] UserInfo user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Invalid request");
                }
                if (!(user.UserEmailId?.Length > 0) || !(user.Password?.Length > 0))
                {
                    throw new Exception("Email address and password are mandatory");
                }
                if (!RegExUtil.IsMatch(user.UserEmailId, RegExUtil.EMAIL_ID_FORMAT))
                {
                    throw new Exception("Invalid Email address");
                }
                var userInfoDataOperations = new UserInfoDBOperations(_context);
                if (userInfoDataOperations.checkIfUserExists(user)){
                    throw new Exception("User already exists");
                }
                else
                {                   
                    return Ok(userInfoDataOperations.SaveUserInfo(user));
                }
            }
            catch (Exception ex)
            {
                var res = new CustomHttpErrorResponse()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    ErrorMessage = ex.Message
                };
                return Ok(res);
            }



        }
    }
}
