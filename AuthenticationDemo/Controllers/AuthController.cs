using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationDemo.Auth;
using AuthenticationDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationDemo.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtFactory _jwtFactory;

        public AuthController(UserManager<AppUser> userManager, IJwtFactory jwtFactory)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginInputDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new LoginOutputDto(new[]
                {
                    new Error("login_failure", "Invalid username or password.")
                }));
            }

            if(!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return BadRequest(new LoginOutputDto(new[]
                {
                    new Error("login_failure", "Invalid username or password.")
                }));
            }

            var response = new LoginOutputDto(
                await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName),
                Guid.NewGuid().ToString().Replace("-", string.Empty),
                true);

            return Ok(response);
        }
    }
}