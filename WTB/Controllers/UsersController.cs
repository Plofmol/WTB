using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WTB;
using WTB.Models;

namespace WTB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly AppDbContext _context;

        //public UsersController(AppDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: Users
        //public async Task<IActionResult> Index()
        //{
        //      return _context.UserCredentials != null ? 
        //                  View(await _context.UserCredentials.ToListAsync()) :
        //                  Problem("Entity set 'AppDbContext.UserCredentials'  is null.");
        //}

        //// GET: Users/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.UserCredentials == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.UserCredentials
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// GET: Users/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Users/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Username,Password,Email,CountryOfOrigin")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(user);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.UserCredentials == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.UserCredentials.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Username,Password,Email,CountryOfOrigin")] User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(user);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(user.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.UserCredentials == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.UserCredentials
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.UserCredentials == null)
        //    {
        //        return Problem("Entity set 'AppDbContext.UserCredentials'  is null.");
        //    }
        //    var user = await _context.UserCredentials.FindAsync(id);
        //    if (user != null)
        //    {
        //        _context.UserCredentials.Remove(user);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UserExists(int id)
        //{
        //  return (_context.UserCredentials?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

        // GPT

        
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/usercredentials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserCredentials()
        {
            return await _context.UserCredentials.ToListAsync();
        }

        // GET: api/usercredentials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserCredentials(int id)
        {
            var userCredentials = await _context.UserCredentials.FindAsync(id);

            if (userCredentials == null)
            {
                return NotFound();
            }

            return userCredentials;
        }

        // POST: api/usercredentials
        [HttpPost]
        public async Task<ActionResult<User>> PostUserCredentials(User userCredentials)
        {
            _context.UserCredentials.Add(userCredentials);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserCredentials", new { id = userCredentials.Id }, userCredentials);
        }

        // PUT: api/usercredentials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCredentials(int id, User userCredentials)
        {
            if (id != userCredentials.Id)
            {
                return BadRequest();
            }

            _context.Entry(userCredentials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCredentialsExists(id))
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

        // DELETE: api/usercredentials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCredentials(int id)
        {
            var userCredentials = await _context.UserCredentials.FindAsync(id);
            if (userCredentials == null)
            {
                return NotFound();
            }

            _context.UserCredentials.Remove(userCredentials);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCredentialsExists(int id)
        {
            return _context.UserCredentials.Any(e => e.Id == id);
        }
    }

}

