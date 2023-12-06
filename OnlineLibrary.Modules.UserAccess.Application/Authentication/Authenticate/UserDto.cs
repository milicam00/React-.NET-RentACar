using OnlineRentCar.Modules.UserAccess.Domain.Users;

namespace OnlineRentCar.Modules.UserAccess.Application.Authentication.Authenticate
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public List<UserRole> Roles { get; set; }
    }

    public class UserRoleDto
    {
       
        public string RoleName { get; set; }
    }





}
