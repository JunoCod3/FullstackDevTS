using FullstackDevTS.Commands.Response;
using MediatR;

namespace FullstackDevTS.Commands.Dto;

public class TestDataDto : IRequest<TestDataResponse>
{
    public required string Name { get; set; }
}