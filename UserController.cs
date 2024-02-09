using Microsoft.AspNetCore.Mvc;
using PracticeTest.Entities;
using PracticeTest.Service;
using System;
using System.Collections.Generic;

namespace PracticeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                _userService.CreateUser(user);
                return StatusCode(201, "User created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating user: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return StatusCode(200, users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting users: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);

                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                return StatusCode(200, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting user: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditUser(int id, [FromBody] User user)
        {
            try
            {
                var existingUser = _userService.GetUserById(id);

                if (existingUser == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;
                existingUser.isAdmin = user.isAdmin;

                _userService.EditUser(existingUser);
                return StatusCode(200, "User updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating user: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var existingUser = _userService.GetUserById(id);

                if (existingUser == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                _userService.DeleteUser(id);
                return StatusCode(200, "User deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting user: {ex.Message}");
            }
        }
    }
}
