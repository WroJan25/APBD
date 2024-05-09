
using Kolokwium.DTOs;
using Animal.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;

[Route("api")]
[ApiController]
public class AnimalController(IAnimalRepository animalRepository) : ControllerBase
{
    private IAnimalRepository _animalRepository = animalRepository;

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetAnimalById(int Id)
    {
        if (await _animalRepository.DoesAnimalExist(Id))
        {
            return NotFound($"Animal with Id {Id} can not be found");
        }
        var response = _animalRepository.GetAnimalsWithProcedures(Id);
        return Ok(response);
    }
    
    
    [HttpPost("SecondTable")]
    public async Task<IActionResult> PostNewObjectWithFields([FromBody] PostDTORequest request)
    {
       
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpDelete("{objectId:int}")]
    public async Task<IActionResult> DeleteObjectById(int objectID)
    {
       
        
        if (true) return NoContent();
        
        return NotFound($"Object with id :{objectID} does not exist"); ////////zmienić w zależności od polecenia

    }
    
}