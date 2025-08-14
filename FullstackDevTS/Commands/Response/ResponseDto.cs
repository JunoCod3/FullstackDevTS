using System.Net;
using MediatR;

namespace FullstackDevTS.Commands.Response;

public class ResponseDto<T> : IRequest<Unit>
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}