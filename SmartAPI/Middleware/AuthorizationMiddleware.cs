namespace SmartAPI.Application.Middleware {
    public class AuthorizationMiddleware {

        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {

            if (ApplicationAuthorize(context)) {
                await _next(context);
            }
            else {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                string json = "{\"Message\":\"Utilizador não autorizado\"}";
                await context.Response.WriteAsync(json);
            }
        }

        private bool ApplicationAuthorize(HttpContext context) {
            return true;
        }
    }
}
