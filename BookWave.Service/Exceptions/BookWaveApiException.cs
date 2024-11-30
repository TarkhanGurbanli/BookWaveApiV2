using System.Net;

namespace BookWave.Service.Exceptions;
public class BookWaveApiException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public BookWaveApiException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : base(message)
    {
        StatusCode = statusCode;
    }
}