﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineRentCar.API.Configuration.Authorization
{
    public class AuthorizeRoleAttribute : TypeFilterAttribute
    {
        public AuthorizeRoleAttribute(string role) : base(typeof(AuthorizeRoleFilter))
        {
            Arguments = new object[] { role };
        }
    }
}
