using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Animal.DTOs;

public record AnimalWithProcedures(
    [Required] int Id,
    [Required] [MaxLength(100)] string Name,
    [Required] [MaxLength(100)] string Type,
    [Required] DateTime AdmissionDate,
    [Required] Owner Owner,
    [Required] ICollection<GetProcedure> Procedures);

public record GetProcedure(
    [Required] [MaxLength(100)] string Name,
    [Required] [MaxLength(100)] string Description,
    [Required] DateTime Date
);

public record Owner(
    [Required] int OwnerId,
    [Required] [MaxLength(100)] string FirstName,
    [Required] [MaxLength(100)] string LastName
);
