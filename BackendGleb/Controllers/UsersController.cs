using BackendGleb.DAL.Entities;
using BackendGleb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendGleb.Controllers
{
    [Produces("application/json")]
    [Route("api/user-portal")]
    //[ApiController]
    public class UsersController : ControllerBase
    {
        private readonly EFContext _context;
        public UsersController(EFContext context)//ctor
        {
            _context = context;
        }
        // GET api/user-portal/users
        [HttpGet("users")]
        public List<UserViewModel> Get()
        {
            var model = _context.Users
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.UserProfile.FirstName,
                    LastName = u.UserProfile.LastName,
                    Age = u.UserProfile.Age,
                    Salary = u.UserProfile.Salary
                }).ToList();
            return model;
        }

        // POST api/user-portal/users
        [HttpPost("users")]
        public async Task<IActionResult> Post([FromBody]UserAddViewModel model)
        {
            string id = null;
            if (!ModelState.IsValid)
            {
                var errors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest(errors);
            }
            return Ok();
        }
    }
}
