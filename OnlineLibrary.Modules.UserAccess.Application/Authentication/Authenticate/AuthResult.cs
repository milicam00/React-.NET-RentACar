using OnlineRentCar.Modules.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRentCar.Modules.UserAccess.Application.Authentication.Authenticate
{
    public class AuthResult
    {
        public AuthResult(string accessToken, string refreshToken, UserDto user)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            User = user;
        }

        public UserDto User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
