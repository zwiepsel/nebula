using System.Net;

namespace Nebula.Shared.Exceptions.Http;

public class UnauthorizedHttpException : HttpException
{
    public UnauthorizedHttpException(string message) : base(HttpStatusCode.Unauthorized, message)
    {
    }
}