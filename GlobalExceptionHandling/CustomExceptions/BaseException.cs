using System.Net;

namespace GlobalExceptionHandling.CustomExceptions
{
    public abstract class BaseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
