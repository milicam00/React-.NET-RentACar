using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;
using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.ChangeUsername
{
    public class ChangeUsernameCommand : CommandBase<List<UserRole>>
    {
        public ChangeUsernameCommand(Guid userId,string oldUsername,string newUsername)
        {
            UserId = userId;
            OldUsername = oldUsername;
            NewUsername = newUsername;
        }
        public Guid UserId { get; set; }
        public string OldUsername { get; set; }
        public string NewUsername { get; set; }  
    }
}
