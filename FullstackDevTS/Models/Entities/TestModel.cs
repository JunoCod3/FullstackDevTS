using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FullstackDevTS.Models.Entities;

[Table("fs_test")]
public class TestModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } //GUID modern approach than Int for PK 
    public string? Name { get; set; }
}
