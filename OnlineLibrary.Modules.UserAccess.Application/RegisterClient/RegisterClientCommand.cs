﻿using OnlineRentCar.BuildingBlocks.Domain;
using OnlineRentCar.Modules.UserAccess.Application.Contracts;

namespace OnlineRentCar.Modules.UserAccess.Application.AddReader
{
    public class RegisterClientCommand : CommandBase<Result>
    {
        public RegisterClientCommand(
            string username,
            string password,
             string email,
            string firstName,
            string lastName
            )
        {

            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;

        }

        public string Username { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Password { get; }
    }
}
