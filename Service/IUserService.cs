using System.Collections.Generic;
using PracticeTest.Entities;

namespace PracticeTest.Service
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int userId);
        void EditUser(User user);
        void DeleteUser(int userId);
        User ValidateUser(string email, string password);
    }
}
