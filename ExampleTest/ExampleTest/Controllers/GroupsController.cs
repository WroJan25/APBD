using ExampleTest.DTOs;
using ExampleTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GroupsController (IDbRepository db): ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await db.GetGroupDetailsByIdAsync(id);
        if (result is null) return NotFound($"Group with id:{id} does not exist");
        return Ok(result);
    }
    
}