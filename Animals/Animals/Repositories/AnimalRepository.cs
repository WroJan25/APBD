using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.Configuration;
using Animal.DTOs;

namespace Animal.Repositories;

public class AnimalRepository(IConfiguration configuration) : IAnimalRepository
{
    private IConfiguration _configuration = configuration;

    public async Task<bool> DoesAnimalExist(int Id)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();
        await using var command = new SqlCommand();
        command.CommandText = """
                              SELECT 1
                              FROM Animals
                              where @id=id
                              """;
        command.Parameters.AddWithValue("@id", Id);
        command.Connection = con;
        
        return await command.ExecuteScalarAsync()is not null;
    }
    public async Task<AnimalWithProcedures?> GetAnimalsWithProcedures(int Id)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();
        await using var command = new SqlCommand();
        command.CommandText = """
                              SELECT a.Name,a.Type,a.AdmissonDate,o.Owner_Id,o.FirstName,o.LasName
                              FROM Animal a left join Owner o
                              on a.Owner_Id = o.Id
                              where @id=a.Id
                              """;
        command.Parameters.AddWithValue("@id", Id);
        await con.OpenAsync();
        var animalReader = await command.ExecuteReaderAsync();
        animalReader.ReadAsync();
        var animalWithProcedures = new AnimalWithProcedures(
            Id,
            animalReader.GetString(0),
            animalReader.GetString(1),
            animalReader.GetDateTime(2),
            new Owner(
                animalReader.GetInt32(3),
                animalReader.GetString(4),
                animalReader.GetString(5)
            ),
             new List<GetProcedure>()
            
            );
        await animalReader.CloseAsync();
        command.CommandText = """
                              SELECT p.Name, p.Description, p.Date
                              FROM Procedure_Animal ap left join [Procedure] p
                              on ap.Procedure_ID =p.ID
                              where ap.Animal_ID = @id
                              """;
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@id", Id);
        var procedureReader = await command.ExecuteReaderAsync();
        while (await procedureReader.ReadAsync())
        {
            animalWithProcedures.Procedures.Add(
                new GetProcedure(
                    procedureReader.GetString(0),
                    procedureReader.GetString(1),
                    procedureReader.GetDateTime(2)
                    
                    )
                );
        }

        return animalWithProcedures; 
    }
    
    


}