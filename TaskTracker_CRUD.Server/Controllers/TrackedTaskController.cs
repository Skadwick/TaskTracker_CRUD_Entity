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
        var trackedTask = await _context.TrackedTasks.FindAsync(id);
        if (trackedTask == null) return NotFound();
        return trackedTask;
    }

    [HttpPost]
    public async Task<ActionResult<TrackedTask>> Post(TrackedTask trackedTask)
    {
        _context.TrackedTasks.Add(trackedTask);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = trackedTask.Id }, trackedTask);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, TrackedTask trackedTask)
    {
        if (id != trackedTask.Id) return BadRequest();
        _context.Entry(trackedTask).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var trackedTask = await _context.TrackedTasks.FindAsync(id);
        if (trackedTask == null) return NotFound();
        _context.TrackedTasks.Remove(trackedTask);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}


