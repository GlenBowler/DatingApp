using System;
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
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        //Endpoints
        //All users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUser(){
            var users = _context.Users.ToListAsync();
            return await users;
        }

        //Individual user
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetOneUser(int id){
            var user = _context.Users.FindAsync(id);
            return await user;
        }


    }
}