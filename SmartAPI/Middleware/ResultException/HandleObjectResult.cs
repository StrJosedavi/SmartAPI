using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SmartAPI.Application.Middleware.ResultException {
    public class HandleObjectResult : ActionResult, IStatusCodeActionResult {
        public HandleObjectResult() { }

        public bool? Success { get; set; }
        public string? Message { get; set; }
        public int? StatusCode { get; set; }
    }
}
