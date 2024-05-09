using System.ComponentModel.DataAnnotations;

namespace ExampleTest.DTOs;

public class GetGroupDTO
{
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public List<int> StudentID { get; set; } = null!;
}