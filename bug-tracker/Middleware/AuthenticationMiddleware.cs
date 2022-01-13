using System.Text.Json;
using bug_tracker.Classes;
using bug_tracker.Models;
using Microsoft.AspNetCore.Http;

namespace bug_tracker.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async System.Threading.Tasks.Task Invoke(HttpContext context, IUserRepository userRepository)
        {

            RequestResponse res = new RequestResponse
            {
                Message = "Token de autenticação inválido",
                Data = null,
                Error = true
            };

            if (!context.Request.Path.StartsWithSegments("/public"))
            {
                User user = null;

                string token = context.Request.Headers["token"];

                if (token == null) res.Message = "Token de verificação não enviado";
                else user = userRepository.FindByToken(token);

                if (user != null){
                    SessionRepository.user = user;
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 422;
                    context.Response.ContentType = "application/json; charset=utf-32";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(res));
                }

            }
            else await _next.Invoke(context);
        }
    }

}