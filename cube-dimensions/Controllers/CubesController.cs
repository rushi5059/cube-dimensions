
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cube_dimensions.Data;
using cube_dimensions.Models;

[Route("api/[controller]")]
[ApiController]
public class CubesController : ControllerBase
{
    private readonly CubeContext _context;

    public CubesController(CubeContext context)
    {
        _context = context;
    }

    // GET: api/Cubes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cube>>> GetCubes()
    {
        return await _context.Cubes.ToListAsync();
    }

    // GET: api/Cubes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Cube>> GetCube(int id)
    {
        var cube = await _context.Cubes.FindAsync(id);

        if (cube == null)
        {
            return NotFound();
        }

        return cube;
    }

    // PUT: api/Cubes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCube(int id, Cube cube)
    {
        if (id != cube.Id)
        {
            return BadRequest();
        }

        _context.Entry(cube).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CubeExists(id))
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

    // POST: api/Cubes
    [HttpPost]
    public async Task<ActionResult<Cube>> PostCube(Cube cube)
    {
        _context.Cubes.Add(cube);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCube), new { id = cube.Id }, cube);
    }

    // DELETE: api/Cubes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCube(int id)
    {
        var cube = await _context.Cubes.FindAsync(id);
        if (cube == null)
        {
            return NotFound();
        }

        _context.Cubes.Remove(cube);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CubeExists(int id)
    {
        return _context.Cubes.Any(e => e.Id == id);
    }
}
