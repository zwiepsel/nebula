using System.Net;

namespace Nebula.Shared.Exceptions.Http;

public class UnprocessableEntityHttpException : HttpException
{
    public UnprocessableEntityHttpException(string message) : base(HttpStatusCode.UnprocessableEntity, message)
    {
    }
}