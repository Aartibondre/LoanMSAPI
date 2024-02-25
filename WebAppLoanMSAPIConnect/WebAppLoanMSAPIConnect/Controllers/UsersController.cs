using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppLoanMSAPIConnect.Data;
using WebAppLoanMSAPIConnect.Models;
using WebAppLoanMSAPIConnect.Service;
using WebAppLoanMSAPIConnect.UserCredentials;

namespace WebAppLoanMSAPIConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly WebAppLoanMSAPIConnectContext _context;
        private readonly ILoginService _loginService;

        public UsersController(WebAppLoanMSAPIConnectContext context, ILoginService loginService)
        {
            _context = context;
            _loginService = loginService;
        }
          
         
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UserCreds user)
        {
            var result = _loginService.Login(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Invalid userName or Password");
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult RegisterUser(User user)
        {
            var result = _loginService.Register(user);
            if (result != null)
                return Ok(result);
            return BadRequest("Not able to register");

        }

        [Authorize]
        [HttpGet]
        [Route("authenticate")]
        public ActionResult Test()
        {
            return Ok("authenticate User");
        }
        

        // GET: api/Users
        [HttpGet]
        [Route("Register")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserDetails()
        {
            return await _context.UserDetails.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.UserDetails.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //// POST: api/Users
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    _context.UserDetails.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //}

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.UserDetails.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.UserDetails.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.UserDetails.Any(e => e.Id == id);
        }
    }
}
