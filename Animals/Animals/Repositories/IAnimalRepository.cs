using Animal.DTOs;

namespace Animal.Repositories;

public interface IAnimalRepository
{
    Task<bool> DoesAnimalExist(int Id);
    Task<AnimalWithProcedures?> GetAnimalsWithProcedures(int Id);

}