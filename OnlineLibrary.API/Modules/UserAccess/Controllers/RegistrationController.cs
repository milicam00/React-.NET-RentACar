using Microsoft.AspNetCore.Mvc;
using OnlineLibary.Modules.Catalog.Application.Contracts;
using OnlineRentCar.API.Modules.UserAccess.Requests;
using OnlineRentCar.Modules.Catalog.Application.Owners.ReverseRegisterOwner;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.API.Modules.UserAccess.Controllers
{
    [Route("api/userAccess/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserAccessModule _userAccessModule;
        private readonly ICatalogModule _catalogModule;

        public RegistrationController(IUserAccessModule userAccessModule, ICatalogModule catalogModule)
        {
            _userAccessModule = userAccessModule;
            _catalogModule = catalogModule;
        }

        [HttpPost("owner-registration")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> OwnerRegistration([FromBody] RegisterRequest request)
        {
            var firstTransaction = await _userAccessModule.ExecuteCommandAsync(new OnlineRentCar.Modules.UserAccess.Application.AddOwner.RegisterOwnerCommand(
                request.Username,
                request.Password,
                request.Email,
                request.FirstName,
                request.LastName

                ));

            if (!firstTransaction.IsSuccess)
            {
                await _catalogModule.ExecuteCommandAsync(new ReverseRegisterOwnerCommand(request.Username));
            }


            var secondTransaction = await _catalogModule.ExecuteCommandAsync(new OnlineRentCar.Modules.Catalog.Application.Owners.RegisterOwner.RegisterOwnerCommand(
                 request.Username,
                 request.Email,
                 request.FirstName,
                 request.LastName
                 ));

            if (!secondTransaction.IsSuccess)
            {
                await _userAccessModule.ExecuteCommandAsync(new OnlineRentCar.Modules.UserAccess.Application.ReverseRegisterUser.ReverseRegisterUserCommand(request.Username));
            }

            if (firstTransaction.IsSuccess && secondTransaction.IsSuccess)
            {
                return Ok("Successfully registartion!");
            }
            else
            {
                return BadRequest("Registration failed.");
            }

        }


        [HttpPost("client-registration")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> ClientRegistartion([FromBody] RegisterRequest request)
        {
            var firstTransaction = await _userAccessModule.ExecuteCommandAsync(new OnlineRentCar.Modules.UserAccess.Application.AddReader.RegisterClientCommand(
                 request.Username,
                 request.Password,
                 request.Email,
                 request.FirstName,
                 request.LastName

                 ));

            if (!firstTransaction.IsSuccess)
            {
                await _catalogModule.ExecuteCommandAsync(new OnlineRentCar.Modules.Catalog.Application.Clients.ReverseRegisterClient.ReverseRegisterUserCommand(request.Username));
            }

            var secondTransaction = await _catalogModule.ExecuteCommandAsync(new OnlineRentCar.Modules.Catalog.Application.Clients.RegisterClient.RegisterClientCommand(
                 request.Username,
                 request.Email,
                 request.FirstName,
                 request.LastName
                 ));

            if (!secondTransaction.IsSuccess)
            {
                await _catalogModule.ExecuteCommandAsync(new OnlineRentCar.Modules.Catalog.Application.Clients.ReverseRegisterClient.ReverseRegisterUserCommand(request.Username));
            }

            if (firstTransaction.IsSuccess && secondTransaction.IsSuccess)
            {
                return Ok("Successfully registartion!");
            }
            else
            {
                return BadRequest("Registration failed.");
            }
        }
    }
}
