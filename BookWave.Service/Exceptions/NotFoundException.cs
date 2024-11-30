using System.Net;

namespace BookWave.Service.Exceptions
{
    public class NotFoundException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public NotFoundException(string resourceName, string fieldName, object fieldValue)
            : base($"{resourceName} not found with the given input data {fieldName}: '{fieldValue}'")
        {
            StatusCode = HttpStatusCode.NotFound;
        }

        public NotFoundException(string message)
            : base(message)
        {
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}