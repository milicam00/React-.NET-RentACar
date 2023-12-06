using Microsoft.AspNetCore.Mvc;
using OnlineRentCar.API.Modules.UserAccess.Requests;
using OnlineRentCar.Modules.UserAccess.Application.Authentication.Authenticate;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;


namespace OnlineRentCar.API.Modules.UserAccess.Controllers
{
    [Route("api/userAccess/authenticate")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserAccessModule _userAccessModule;

        public LoginController(IUserAccessModule userAccessModule)
        {
            _userAccessModule = userAccessModule;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _userAccessModule.ExecuteCommandAsync(new AuthenticateCommand(request.UserName, request.Password));
            if (token.IsSuccess)
            {
                return Ok(new { token });
            }
            else
            {
                return BadRequest(token.ErrorMessage);
            }
        }

    }
}
