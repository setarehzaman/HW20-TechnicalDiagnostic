//namespace App.EndPoints.Api
//{
//    public class ApiKeyMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private const string ApiKeyHeaderName = "X-Api-Key";

//        public ApiKeyMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task Invoke(HttpContext context, IConfiguration config)
//        {
//            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey) ||
//                extractedApiKey != config["ApiSettings:ApiKey"])
//            {
//                context.Response.StatusCode = 401;
//                await context.Response.WriteAsync("Unauthorized: Invalid API Key");
//                return;
//            }

//            await _next(context);
//        }
//    }

//}
