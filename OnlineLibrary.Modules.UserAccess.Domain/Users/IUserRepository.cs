﻿namespace OnlineRentCar.Modules.UserAccess.Domain.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<int> Commit();
        Task<User> GetByIdAsync(Guid userId);
        Task<User> GetByUsernameAsync(string username);
        void UpdateUser(User user);
        void DeleteUser(User user);
       
    }
}
