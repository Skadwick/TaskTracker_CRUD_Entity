using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker_CRUD.Server.Data;
using TaskTracker_CRUD.Server.Models;

namespace TaskTracker_CRUD.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrackedTaskController : ControllerBase
{
    private readonly TrackedTaskContext _context;

    public TrackedTaskController(TrackedTaskContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrackedTask>>> Get()
    {
        return await _context.TrackedTasks.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrackedTask>> Get(int id)
    {
        var example = await _context.TrackedTasks.FindAsync(id);
        if (example == null) return NotFound();
        return example;
    }

    [HttpPost]
    public async Task<ActionResult<TrackedTask>> Post(TrackedTask example)
    {
        _context.TrackedTasks.Add(example);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = example.Id }, example);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, TrackedTask example)
    {
        if (id != example.Id) return BadRequest();
        _context.Entry(example).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var example = await _context.TrackedTasks.FindAsync(id);
        if (example == null) return NotFound();
        _context.TrackedTasks.Remove(example);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}


