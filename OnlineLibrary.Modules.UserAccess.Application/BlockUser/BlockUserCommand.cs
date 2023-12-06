using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.Modules.UserAccess.Application.BlockUser
{
    public class BlockUserCommand : CommandBase<Result>
    {
        public BlockUserCommand(string username)
        {
           Username = username;
        }
       
        public string Username { get; set; }
    }

    
}
