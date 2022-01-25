using AIMachineAPI.Services;
using System.Text;

namespace AIMachineAPI.Authorization
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            try
            { 
            string authHeader = context.Request.Headers["Authorization"];
            
            //Extract credentials
            string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
            string[] credentials = usernamePassword.Split(':');
            string username = credentials[0];
            string password = credentials[1];

            context.Items["User"] = await userService.Authenticate(username, password);
            }
            catch
            {
                //throw new Exception("The authorization header is either empty or isn't Basic.");
            }


            await _next(context);
        }
    }
}
