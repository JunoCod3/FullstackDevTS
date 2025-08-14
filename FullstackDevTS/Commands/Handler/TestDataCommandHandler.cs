using FullstackDevTS.Commands.Dto;
using FullstackDevTS.Commands.Response;
using FullstackDevTS.Services;
using MediatR;

namespace FullstackDevTS.Commands.Handler;

public class TestDataCommandHandler : IRequestHandler<TestDataDto, TestDataResponse>
{
    private readonly ITestService  _service;

    public TestDataCommandHandler(ITestService testService)
    {
        this._service = testService;
    }
    
    public async Task<TestDataResponse> Handle(TestDataDto request, CancellationToken cancellationToken)
    {
        var execute = await _service.AddNewTestName(request.Name);

        return new TestDataResponse { Message = execute };
    }
}