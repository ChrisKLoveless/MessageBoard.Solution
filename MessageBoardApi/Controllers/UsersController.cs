using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

namespace MessageBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MessageBoardContext _db;

        public UsersController(MessageBoardContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get(string name)
        {
            IQueryable<Users> query = _db.Users.AsQueryable();
            if (name != null)
            {
                query = query.Where(us => us.Name == name);
            }
            return await query.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            Users user = await _db.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<Users>> Post(Users user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new { id = user.UsersId }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Users user)
        {
            if (user.UsersId != id)
            {
                return BadRequest();
            }

            _db.Users.Update(user);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(user.UsersId))
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, Users user)
        {
            if (!UsersExists(user.UsersId))
            {
                return NotFound();
            }
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return _db.Users.Any(e => e.UsersId == id);
        }
    }
}