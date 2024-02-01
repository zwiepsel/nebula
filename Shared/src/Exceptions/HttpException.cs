using System.Net;
using System.Net.Http;

namespace Nebula.Shared.Exceptions;

public class HttpException : HttpRequestException
{
    public HttpStatusCode HttpStatusCode { get; }

    public HttpException(HttpStatusCode httpStatusCode, string message) : base(message)
    {
        HttpStatusCode = httpStatusCode;
    }
}