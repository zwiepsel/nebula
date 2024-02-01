using System.Net;

namespace Nebula.Shared.Exceptions.Http;

public class ForbiddenHttpException : HttpException
{
    public ForbiddenHttpException(string message) : base(HttpStatusCode.Forbidden, message)
    {
    }
}