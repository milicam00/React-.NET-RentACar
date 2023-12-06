using Dapper;
using Newtonsoft.Json;
using OnlineRentCar.BuildingBlocks.Application.Data;
using OnlineRentCar.BuildingBlocks.Infrastructure.IInternalCommandsMapper;
using OnlineRentCar.BuildingBlocks.Infrastructure.Serialization;
using OnlineRentCar.Modules.UserAccess.Application.Configuration.Commands;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.Modules.UserAccess.Infrastructure.Configuration.Processing
{
    public class CommandsScheduler : ICommandsScheduler
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        private readonly IInternalCommandsMapper _internalCommandsMapper;

        public CommandsScheduler(
            ISqlConnectionFactory sqlConnectionFactory,
            IInternalCommandsMapper internalCommandsMapper)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _internalCommandsMapper = internalCommandsMapper;
        }

        public async Task EnqueueAsync(ICommand command)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sqlInsert = "INSERT INTO [administration].[InternalCommands] ([Id], [EnqueueDate] , [Type], [Data]) VALUES " +
                                     "(@Id, @EnqueueDate, @Type, @Data)";

            await connection.ExecuteAsync(sqlInsert, new
            {
                command.Id,
                EnqueueDate = DateTime.UtcNow,
                Type = _internalCommandsMapper.GetName(command.GetType()),
                Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
                {
                    ContractResolver = new AllPropertiesContactResolver()
                })
            });
        }

        public async Task EnqueueAsync<T>(ICommand<T> command)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sqlInsert = "INSERT INTO [administration].[InternalCommands] ([Id], [EnqueueDate] , [Type], [Data]) VALUES " +
                                     "(@Id, @EnqueueDate, @Type, @Data)";

            await connection.ExecuteAsync(sqlInsert, new
            {
                command.Id,
                EnqueueDate = DateTime.UtcNow,
                Type = _internalCommandsMapper.GetName(command.GetType()),
                Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
                {
                    ContractResolver = new AllPropertiesContactResolver()
                })
            });
        }
    }
}
