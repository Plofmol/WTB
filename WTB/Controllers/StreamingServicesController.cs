using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WTB;
using WTB.Models;

[Route("api/streamingservices")]
[ApiController]
public class StreamingServicesController : ControllerBase
{
    private readonly AppDbContext _context;

    public StreamingServicesController(AppDbContext context)
    {
        _context = context;
    }

    // GET api/streamingservices
    [HttpGet]
    public ActionResult<IEnumerable<StreamingServices>> GetStreamingServices()
    {
        var streamingServices = _context.StreamingServices.ToList();
        return Ok(streamingServices);
    }

    // GET api/streamingservices/{id}
    [HttpGet("{id}")]
    public ActionResult<StreamingServices> GetStreamingServiceById(int id)
    {
        var streamingService = _context.StreamingServices.FirstOrDefault(s => s.Id == id);
        if (streamingService == null)
            return NotFound();

        return Ok(streamingService);
    }

    // POST api/streamingservices
    [HttpPost]
    public ActionResult<StreamingServices> CreateStreamingService(StreamingServices streamingService)
    {
        _context.StreamingServices.Add(streamingService);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetStreamingServiceById), new { id = streamingService.Id }, streamingService);
    }

    // PUT api/streamingservices/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateStreamingService(int id, StreamingServices streamingService)
    {
        if (id != streamingService.Id)
            return BadRequest();

        _context.Entry(streamingService).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE api/streamingservices/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteStreamingService(int id)
    {
        var streamingService = _context.StreamingServices.FirstOrDefault(s => s.Id == id);
        if (streamingService == null)
            return NotFound();

        _context.StreamingServices.Remove(streamingService);
        _context.SaveChanges();
        return NoContent();
    }
}
