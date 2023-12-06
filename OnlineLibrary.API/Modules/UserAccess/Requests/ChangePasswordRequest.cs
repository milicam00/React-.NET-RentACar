namespace OnlineRentCar.API.Modules.UserAccess.Requests
{
    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
