using System.Data;
using System.Data.SqlClient;
using ExampleTest.DTOs;

namespace ExampleTest.Repositories;

public interface IDbRepository
{
    Task<GetGroupDTO?> GetGroupDetailsByIdAsync(int id);
}
public class DbRepository(IConfiguration configuration): IDbRepository
{
    private async Task<SqlConnection> GetConnection()
    {
        var connection = new SqlConnection(configuration.GetConnectionString("Default"));
        if (connection.State!=ConnectionState.Open)
        {
            await connection.OpenAsync();
        }
        return connection;
    }
    
    public async Task<GetGroupDTO?> GetGroupDetailsByIdAsync(int id)
    {
        await using var connection = await GetConnection();
        var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = """
                               SELECT g.ID,g.Nam,s.id
                               from Groups g
                               left join  GrupAssigments ga
                               on g.ID = ga.Group_ID
                               left join Students s
                               on s.ID=ga.Students_ID
                               where g.ID = @id
                               """;
        command.Parameters.AddWithValue("@id", id);
        var reader = await command.ExecuteReaderAsync();
        await reader.ReadAsync();
        int TempId = reader.GetInt32(0);
        string TempName = reader.GetString(1);
        List<int> TempStudentsID = !await reader.IsDBNullAsync(2) ? [reader.GetInt32(2)] : [];
        var result = new GetGroupDTO();
        result.Id = TempId;
        result.Name = TempName;
        result.StudentID = TempStudentsID;
        while (await reader.ReadAsync())
        {
            result.StudentID.Add(reader.GetInt32(2));
        }
        
        return result;
    }
    public async <>
    
}