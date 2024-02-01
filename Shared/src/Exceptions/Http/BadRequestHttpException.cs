using System.Net;

namespace Nebula.Shared.Exceptions.Http;

public class BadRequestHttpException : HttpException
{
    public BadRequestHttpException(string message) : base(HttpStatusCode.BadRequest, message)
    {
    }
}