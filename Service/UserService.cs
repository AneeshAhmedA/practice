using System;
using System.Collections.Generic;
using PracticeTest.Entities;
using PracticeTest.Database;
using Microsoft.EntityFrameworkCore;

namespace PracticeTest.Service
{
    public class UserService : IUserService
    {
        private readonly Mycontext _context;

        public UserService(Mycontext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void EditUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User ValidateUser(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
