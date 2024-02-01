using System.Net;

namespace Nebula.Shared.Exceptions.Http;

public class NotFoundHttpException : HttpException
{
    public NotFoundHttpException(string message) : base(HttpStatusCode.NotFound, message)
    {
    }
}