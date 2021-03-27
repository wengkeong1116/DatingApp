using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        //Get all user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = _context.Users.ToListAsync();
            return await users;
        }

        //api/users/3
         [HttpGet("{id}")]
        public async Task< ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
            
        }
    }
}