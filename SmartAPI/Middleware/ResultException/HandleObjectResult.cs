using Microsoft.AspNetCore.Mvc;

namespace SmartAPI.Application.Middleware.ResultException {
    public class HandleObjectResult : ActionResult {
        public string? message { get; set; }
    }
}
