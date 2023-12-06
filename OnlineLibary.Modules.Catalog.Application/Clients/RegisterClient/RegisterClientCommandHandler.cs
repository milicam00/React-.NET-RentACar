using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Clients.RegisterClient
{
    public class RegisterClientCommandHandler : ICommandHandler<RegisterClientCommand, Result>
    {
        private readonly IClientRepository _clientRepository;

        public RegisterClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Result> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = Client.CreateUser(
                request.UserName,
                request.Email,
                request.FirstName,
                request.LastName
                );
                await _clientRepository.AddAsync(client);

                return Result.Success("Successfully registration!");
            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }
        }
    }
}
