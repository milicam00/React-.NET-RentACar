﻿using OnlineRentCar.BuildingBlocks.Domain;

namespace OnlineRentCar.Modules.UserAccess.Domain.Users
{

    public class User : Entity, IAggregateRoot
    {

        public Guid UserId { get; private set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public List<UserRole> Roles { get; set; }
        public int? ResetPasswordCode { get; set; }
        public DateTime? ResetPasswordCodeExpiration { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        public User()
        {

            UserId = Guid.NewGuid();
            Roles = new List<UserRole>();
            RefreshTokens = new List<RefreshToken>();
        }


        public User(string userName, string password, string email, string firstName, string lastName)
        {

            UserId = Guid.NewGuid();
            UserName = userName;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            RegisterDate = DateTime.Now;
            IsActive = true;
            RefreshTokens = new List<RefreshToken>();

        }

        public User(
            Guid id,
            string username,
            string password,
            string email,
            string firstName,
            string lastName,
            UserRole role
            )
        {
            UserId = id;
            UserName = username;
            Password = password;
            Email = email;
            IsActive = true;
            FirstName = firstName;
            LastName = lastName;
            RegisterDate = DateTime.Now;
            Roles = new List<UserRole>();
            Roles.Add(role);
            

        }



        public static User CreateAdmin(
            string username,
            string password,
            string email,
            string firstName,
            string lastName
            )
        {

            return new User(
                Guid.NewGuid(),
                username,
                password,
                email,
                firstName,
                lastName,
                UserRole.Administrator);
        }



        public static User CreateOwner(
            string username,
            string password,
            string email,
            string firstName,
            string lastName
            )
        {
            return new User(
                Guid.NewGuid(),
                username,
                password,
                email,
                firstName,
                lastName,
                UserRole.Owner);
        }


        public static User CreateClient(
            string username,
            string password,
            string email,
            string firstName,
            string lastName
            )
        {
            return new User(
                Guid.NewGuid(),
                username,
                password,
                email,
                firstName,
                lastName,
                UserRole.Client);
        }

        public void BlockUser()
        {
            this.IsActive = false;
        }


        public void UnblockUser()
        {
            this.IsActive = true;
        }

        public void SetResetPasswordCode(int code)
        {
            this.ResetPasswordCode = code;
        }


        public void ChangeUsername(string username)
        {
            this.UserName = username;
        }
    }



}
