using Microsoft.AspNetCore.Mvc;

namespace SmartAPI.Application.Middleware.ResultException {
    public class HandleObjectResult : ActionResult {
        public HandleObjectResult() { }
        public string? message { get; set; }
    }
}
