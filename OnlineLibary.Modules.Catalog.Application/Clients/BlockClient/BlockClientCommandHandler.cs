using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineLibary.Modules.Catalog.Application.Configuration.Commands;
using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscription;
using OnlineRentCar.Modules.Catalog.Domain.Clients.ClientSubscriptions;

namespace OnlineRentCar.Modules.Catalog.Application.Clients.BlockClient
{
    public class BlockClientCommandHandler : ICommandHandler<BlockClientCommand, Result>
    {
        private readonly IClientRepository _clientRepository;

        public BlockClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Result> Handle(BlockClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Client client = await _clientRepository.GetByUsername(request.UserName);
                if (client == null)
                {
                    return Result.Failure("Client does not exist.");
                }

                if (client.IsBlocked)
                {
                    return Result.Failure("Client is already blocked.");
                }
                client.Block();
                _clientRepository.Update(client);

                return Result.Success("Client is blocked");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx)
                {
                    return Result.Failure("Database error: " + sqlEx.Message);
                }
                return Result.Failure("Database error.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Error message: " + ex.Message);
            }


        }
    }
}
