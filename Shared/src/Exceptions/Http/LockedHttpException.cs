using System.Net;

namespace Nebula.Shared.Exceptions.Http;

public class LockedHttpException : HttpException
{
    public LockedHttpException(string message) : base(HttpStatusCode.Locked, message)
    {
    }
}