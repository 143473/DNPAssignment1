using System.Collections.Generic;
using Assignment1.Models;

namespace Assignment1.Data
{
    public interface IUserService
    {
        IList<User> GetUsers();
        void AddUser(User newUser);
        void RemoveUser(int userId);
        void UpdateUser(User user);
        User GetUser(int id);
        User ValidateUser(string userName, string password);
    }
}