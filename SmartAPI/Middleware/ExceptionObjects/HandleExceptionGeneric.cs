using System.Net;

namespace SmartAPI.Middleware.ExceptionObjects {
    public class HandleExceptionGeneric : Exception
    {
        public HandleExceptionGeneric(string message, HttpStatusCode? statusCode)
        : base(message) {
            StatusCode = statusCode;
        }

        public HandleExceptionGeneric(string message)
        : base(message) {
        }
        public HttpStatusCode? StatusCode { get; }
    }
}
