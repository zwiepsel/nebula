using System.Net;

namespace Nebula.Shared.Exceptions.Http;

public class ConflictHttpException : HttpException
{
    public ConflictHttpException(string message) : base(HttpStatusCode.Conflict, message)
    {
    }
}