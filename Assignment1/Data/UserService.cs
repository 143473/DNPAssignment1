using System;
using System.Collections.Generic;
using System.Linq;
using Assignment1.Models;
using FileData;

namespace Assignment1.Data
{
    public class UserService : IUserService
    {
        private FileContext FileContext;

        public UserService()
        {
            FileContext = new FileContext();
        }

        public IList<User> GetUsers()
        {
            return FileContext.Users;
        }

        public void AddUser(User newUser)
        {
            var nextId = FileContext.Users.Max(user => user.Id);
            newUser.Id = ++nextId;
            newUser.SecurityLevel = 1;
            newUser.Role = "user";
            FileContext.Users.Add(newUser);
            FileContext.SaveChanges();
        }

        public void RemoveUser(int userId)
        {
            User user = FileContext.Users.First(t => t.Id == userId);
            FileContext.Users.Remove(user);
            FileContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User toUpdate = FileContext.Users.First(t => t.Id == user.Id);
            FileContext.Users.Remove(toUpdate);
            FileContext.Users.Add(user);
            FileContext.SaveChanges();
        }

        public User GetUser(int id)
        {
            return FileContext.Users.FirstOrDefault(t => t.Id == id);
        }

        public User ValidateUser(string userName, string password)
        {
            User first = FileContext.Users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}