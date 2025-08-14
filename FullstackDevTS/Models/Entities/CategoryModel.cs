using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullstackDevTS.Models.Entities;

[Table("Category")]
public class CategoryModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    
    [MaxLength(250)]
    public string? Description { get; set; }
    
    public DateTime CreatedDate  { get; set; } = DateTime.UtcNow;
}