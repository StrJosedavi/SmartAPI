using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SmartAPI.Application.Middleware.ResultException {
    public class HandleObjectResult : ActionResult {
        public HandleObjectResult() { }

        public bool? success { get; set; }
        public string? message { get; set; }
        public int? statusCode { get; set; }
    }
}
