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
    public class StreamingServicesController : ControllerBase
    {
        //private readonly AppDbContext _context;

        //public StreamingServicesController(AppDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: StreamingServices
        //public async Task<IActionResult> Index()
        //{
        //      return _context.StreamingServices != null ? 
        //                  View(await _context.StreamingServices.ToListAsync()) :
        //                  Problem("Entity set 'AppDbContext.StreamingServices'  is null.");
        //}

        //// GET: StreamingServices/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.StreamingServices == null)
        //    {
        //        return NotFound();
        //    }

        //    var streamingServices = await _context.StreamingServices
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (streamingServices == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(streamingServices);
        //}

        //// GET: StreamingServices/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: StreamingServices/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,UserId,Netflix,AmazonPrime,DisneyPlus,HBO")] StreamingServices streamingServices)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(streamingServices);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(streamingServices);
        //}

        //// GET: StreamingServices/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.StreamingServices == null)
        //    {
        //        return NotFound();
        //    }

        //    var streamingServices = await _context.StreamingServices.FindAsync(id);
        //    if (streamingServices == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(streamingServices);
        //}

        //// POST: StreamingServices/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Netflix,AmazonPrime,DisneyPlus,HBO")] StreamingServices streamingServices)
        //{
        //    if (id != streamingServices.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(streamingServices);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StreamingServicesExists(streamingServices.Id))
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
        //    return View(streamingServices);
        //}

        //// GET: StreamingServices/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.StreamingServices == null)
        //    {
        //        return NotFound();
        //    }

        //    var streamingServices = await _context.StreamingServices
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (streamingServices == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(streamingServices);
        //}

        //// POST: StreamingServices/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.StreamingServices == null)
        //    {
        //        return Problem("Entity set 'AppDbContext.StreamingServices'  is null.");
        //    }
        //    var streamingServices = await _context.StreamingServices.FindAsync(id);
        //    if (streamingServices != null)
        //    {
        //        _context.StreamingServices.Remove(streamingServices);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool StreamingServicesExists(int id)
        //{
        //  return (_context.StreamingServices?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

        // GPT

        private readonly AppDbContext _context;

        public StreamingServicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/streamingservices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StreamingServices>>> GetStreamingServices()
        {
            return await _context.StreamingServices.ToListAsync();
        }

        // GET: api/streamingservices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StreamingServices>> GetStreamingServices(int id)
        {
            var streamingServices = await _context.StreamingServices.FindAsync(id);

            if (streamingServices == null)
            {
                return NotFound();
            }

            return streamingServices;
        }

        // POST: api/streamingservices
        [HttpPost]
        public async Task<ActionResult<StreamingServices>> PostStreamingServices(StreamingServices streamingServices)
        {
            _context.StreamingServices.Add(streamingServices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStreamingServices", new { id = streamingServices.UserId }, streamingServices);
        }

        // PUT: api/streamingservices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStreamingServices(int id, StreamingServices streamingServices)
        {
            if (id != streamingServices.UserId)
            {
                return BadRequest();
            }

            _context.Entry(streamingServices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StreamingServicesExists(id))
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

        // DELETE: api/streamingservices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStreamingServices(int id)
        {
            var streamingServices = await _context.StreamingServices.FindAsync(id);
            if (streamingServices == null)
            {
                return NotFound();
            }

            _context.StreamingServices.Remove(streamingServices);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StreamingServicesExists(int id)
        {
            return _context.StreamingServices.Any(e => e.UserId == id);
        }
    }
}

