using System.ComponentModel.DataAnnotations;

namespace Cwiczenia6;

public record GetAllAnimalsResponse(int Id, string Name, string Description, string Category, string Area);
public record GetSingleAnimalResponse(int Id, string Name, string Description, string Category, string Area);

public record CreateAnimalRequest(
	[Required][MaxLength(200)] string Name,
	[MaxLength(200)] string Description,
	[Required][MaxLength(200)] string Category,
	[Required][MaxLength(200)] string Area
	);

public record EditAnimalRequest(
	[Required][MaxLength(200)] string Name,
	[MaxLength(200)] string Description,
	[Required][MaxLength(200)] string Category,
	[Required][MaxLength(200)] string Area
	);
