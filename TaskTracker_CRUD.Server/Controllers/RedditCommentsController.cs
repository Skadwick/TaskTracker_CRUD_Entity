using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker_CRUD.Server.Data;
using TaskTracker_CRUD.Server.Models;

namespace TaskTracker_CRUD.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RedditCommentsController : ControllerBase
{
    private readonly RedditCommentsContext _context;

    public RedditCommentsController(RedditCommentsContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RedditComments>>> Get()
    {
        return await _context.RedditComments.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RedditComments>> Get(int id)
    {
        var redditComments = await _context.RedditComments.FindAsync(id);
        if (redditComments == null) return NotFound();
        return redditComments;
    }
    /*
    [HttpPost]
    public async Task<ActionResult<RedditComments>> Post(List<RedditComments> redditComments)
    {
        foreach (RedditComments redditComment in redditComments)
        {
            _context.RedditComments.Add(redditComment);
            await _context.SaveChangesAsync();
        }

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, RedditComments redditComments)
    {
        if (id != redditComments.Id) return BadRequest();
        _context.Entry(redditComments).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    */
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var redditComments = await _context.RedditComments.FindAsync(id);
        if (redditComments == null) return NotFound();
        _context.RedditComments.Remove(redditComments);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}


