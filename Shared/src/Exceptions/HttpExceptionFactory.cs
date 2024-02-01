using System.Net;
using Nebula.Shared.Exceptions.Http;

namespace Nebula.Shared.Exceptions;

public static class HttpExceptionFactory
{
    public static HttpException Create(HttpStatusCode httpStatusCode, string message)
    {
        return httpStatusCode switch
        {
            HttpStatusCode.BadRequest => new BadRequestHttpException(message),
            HttpStatusCode.Unauthorized => new UnauthorizedHttpException(message),
            HttpStatusCode.Forbidden => new ForbiddenHttpException(message),
            HttpStatusCode.NotFound => new NotFoundHttpException(message),
            HttpStatusCode.Conflict => new ConflictHttpException(message),
            HttpStatusCode.UnprocessableEntity => new UnprocessableEntityHttpException(message),
            HttpStatusCode.Locked => new LockedHttpException(message),
            _ => new HttpException(httpStatusCode, message)
        };
    }
}