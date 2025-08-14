namespace FullstackDevTS.Commands.Response;

public class CategoryResponse
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime CreatedDate  { get; set; }
}