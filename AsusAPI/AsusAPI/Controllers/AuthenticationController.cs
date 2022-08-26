using AsusAPI.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.DataTransferObject;
using Model.Domain;
using System.Threading.Tasks;

namespace AsusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtAuthentication authentication;
        private readonly UserManager<OdgovornoLice> manager;

        public AuthenticationController(JwtAuthentication authentication,UserManager<OdgovornoLice> manager )
        {
            this.authentication = authentication;
            this.manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticationDTO auth)
        {
            var token = await authentication.AuthenticateAsync(auth.Username, auth.Password);
            if(token == null)
            {
                return Unauthorized();
            }   
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterDTO auth)
        {
            try
            {
                var newUser = new OdgovornoLice
                {
                    UserName = auth.Username,
                    ImePrezime = auth.Name,
                    Email = auth.Email
                };
                var result = await manager.CreateAsync(newUser, auth.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                var res = await manager.AddToRoleAsync(newUser, auth.Role);

                if (res.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
