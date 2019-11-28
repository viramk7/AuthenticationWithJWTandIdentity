using System.Linq;
using System.Threading.Tasks;
using AuthenticationDemo.Auth;
using AuthenticationDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationDemo.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Post(RegisterInputDto model)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);

            var user = new AppUser { Email = model.Email, UserName = model.Email };

            var identityResult = await _userManager.CreateAsync(user, model.Password);
            if (!identityResult.Succeeded)
            {
                var createUserResponse =
                    new RegisterOutputDto(
                        user.Id,
                        user.Email,
                        false,
                        identityResult.Errors.Select(e => new Error(e.Code, e.Description)));

                return BadRequest(createUserResponse);
            }

            return Ok(new RegisterOutputDto(
                        user.Id,
                        user.Email,
                        true,
                        identityResult.Errors.Select(e => new Error(e.Code, e.Description))));
        }

    }
}