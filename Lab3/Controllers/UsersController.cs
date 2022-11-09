using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Controllers
{
    public class UsersController : ControllerBase
    {
        private Memory _memory = Memory.GetMemory();
        [HttpGet]
        [Route("/GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _memory.Users.ToList();
        }
        [HttpPost]
        [Route("/AddUser")]
        public IActionResult AddUser(User user)
        {
            if (_memory.Users.Any(x => x.Id == user.Id))
            {
                return Forbid();
            }
            _memory.Users.Add(user);
            return Ok();
        }
        [HttpDelete]
        [Route("/DeleteUserById")]
        public IActionResult DeleteUserById(int id)
        {
            var user = _memory.Users.Find(x => x.Id == id);
            if (user is null) return NotFound();
            _memory.Users.Remove(user);
            return Ok();
        }
        [HttpPut]
        [Route("/UpdateUser")]
        public IActionResult UpdateUser(int oldId,User newUser)
        {
            var userIndex = _memory.Users.FindIndex(x => x.Id == oldId);
            if (userIndex < 0) return NotFound();
            _memory.Users[userIndex] = newUser;
            return Ok();
        }
    }
}
