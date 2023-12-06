using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.API.Modules.UserAccess.Requests;
using OnlineRentCar.Modules.Catalog.Application.Clients.ChangeClientUsername;
using OnlineRentCar.Modules.Catalog.Application.Owners.ChangeOwnerUsernameCommand;
using OnlineRentCar.Modules.UserAccess.Application.ChangePassword;
using OnlineRentCar.Modules.UserAccess.Application.ChangeUsername;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;
using OnlineRentCar.Modules.UserAccess.Application.Logout;
using OnlineRentCar.Modules.UserAccess.Application.ResetPassword;
using OnlineRentCar.Modules.UserAccess.Application.ResetPasswordRequest;
using OnlineRentCar.Modules.UserAccess.Application.TokenRefresh;

namespace OnlineRentCar.API.Modules.UserAccess.Controllers
{
    [Route("api/userAccess")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccessModule _userAccessModule;
        private readonly ICatalogModule _catalogModule;


        public AccountController(IUserAccessModule userAccessModule, ICatalogModule catalogModule)
        {
            _userAccessModule = userAccessModule;
            _catalogModule = catalogModule;

        }

        [Authorize]
        [HttpPut("change-password/{userId}")]
        public async Task<IActionResult> ChangePassword([FromRoute] Guid userId, [FromBody] ChangePasswordRequest request)
        {

            var result = await _userAccessModule.ExecuteCommandAsync(new ChangePasswordCommand(userId, request.OldPassword, request.NewPassword));
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }


        [HttpPost("reset-password-request/{userName}")]
        public async Task<IActionResult> ForgotPassword([FromRoute] string userName)
        {
            var result = await _userAccessModule.ExecuteCommandAsync(new ResetPasswordRequestCommand(userName));

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result?.ErrorMessage);
            }
        }


        [HttpPut("reset-password/{userName}")]
        public async Task<IActionResult> ResetPassword([FromRoute] string userName, [FromBody] NewPasswordRequest request)
        {
            var result = await _userAccessModule.ExecuteCommandAsync(new ResetPasswordCommand(request.Code, userName, request.Password));
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result?.ErrorMessage);
            }
        }


        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefrehToken([FromBody] RefreshTokenRequest request)
        {
            var token = await _userAccessModule.ExecuteCommandAsync(new RefreshTokenCommand(request.RefreshToken));
            if (token.IsSuccess)
            {
                return Ok(token);
            }
            else
            {
                return BadRequest(token.ErrorMessage);
            }
        }

        [Authorize]
        [HttpPut("change-username/{userId}")]
        public async Task<IActionResult> ChangeUsername([FromRoute] Guid userId, [FromBody] ChangeUsernameRequest request)
        {
            var result = await _userAccessModule.ExecuteCommandAsync(new ChangeUsernameCommand(userId, request.OldUsername, request.NewUsername));
            List<string> roles = new List<string>();
            foreach (var item in result)
            {
                roles.Add(item.Value.ToString());
            }

            if (roles.Contains("Client"))
            {
                await _catalogModule.ExecuteCommandAsync(new ChangeClientUsernameCommand(request.OldUsername, request.NewUsername));
            }

            if (roles.Contains("Owner"))
            {
                await _catalogModule.ExecuteCommandAsync(new ChangeOwnerUsernameCommand(request.OldUsername, request.NewUsername));
            }

            return Ok();
        }

       // [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest logoutRequest)
        {
            var result = await _userAccessModule.ExecuteCommandAsync(new LogoutCommand(logoutRequest.RefreshToken));
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
    }
}
