using FullstackDevTS.Commands.Response;
using FullstackDevTS.Models.Entities;
using FullstackDevTS.Services;
using MediatR;

namespace FullstackDevTS.Commands.Handler.QueryHandler;

public class GetAllCategoriesQuery : IRequest<ResponseDto<List<CategoryModel?>>>
{
    
}