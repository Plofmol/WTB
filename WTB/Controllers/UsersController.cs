using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WTB;
using WTB.Models;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    // GET api/users
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = _context.User.ToList();
        return Ok(users);
    }

    // GET api/users/{id}
    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _context.User.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    // POST api/users
    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    // PUT api/users/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, User user)
    {
        if (id != user.Id)
            return BadRequest();

        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE api/users/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var user = _context.User.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();

        _context.User.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }
}
