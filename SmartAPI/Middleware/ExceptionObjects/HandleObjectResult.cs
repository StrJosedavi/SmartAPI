using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace SmartAPI.Middleware.ResultException {
    public class HandleExceptionObjectResult : ActionResult 
    {
        [DefaultValue(false)]
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
