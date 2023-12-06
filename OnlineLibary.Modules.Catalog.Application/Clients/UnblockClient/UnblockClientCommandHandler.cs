using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Clients.UnblockClient
{
    public class UnblockClientCommandHandler : ICommandHandler<UnblockClientCommand, Result>
    {
        private readonly IClientRepository _clientRepository;

        public UnblockClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Result> Handle(UnblockClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Client client = await _clientRepository.GetByUsername(request.UserName);
                if (client == null)
                {
                    return Result.Failure("User does not exist.");
                }
                if (!client.IsBlocked)
                {
                    return Result.Failure("User is already unblocked.");
                }

                client.Unblock();
                _clientRepository.Update(client);
                return Result.Success("User is unblocked.");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx)
                {
                    return Result.Failure("Database error: " + sqlEx.Message);
                }
                return Result.Failure("Database error: " + ex.Message);

            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }
        }
    }
}
