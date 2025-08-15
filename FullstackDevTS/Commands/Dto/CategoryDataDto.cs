using System.ComponentModel.DataAnnotations;
using FullstackDevTS.Commands.Response;
using FullstackDevTS.Models.Entities;
using MediatR;

namespace FullstackDevTS.Commands.Dto;

public class CategoryDataDto : IRequest<ResponseDto<CategoryModel?>>
{
    [MaxLength(100)]
    [Required]
    public required string Name { get; set; }
    
    [MaxLength(250)]
    public string? Description { get; set; }
}