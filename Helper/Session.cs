using WebMVC.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebMVC.Helper
{
    public class Session : ISessionUser
    {
        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        void ISessionUser.CreateUserSession(Login user)
        {
            string valueUser = JsonConvert.SerializeObject(user);

            _httpContext.HttpContext.Session.SetString("userloggedsession", valueUser);
            
        }

        void ISessionUser.RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("userloggedsession");
        }

        Login ISessionUser.SeachUserSession()
        {
            try
            {
                string sessionUser = _httpContext.HttpContext.Session.GetString("userloggedsession");
                if (string.IsNullOrEmpty(sessionUser))
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<Login>(sessionUser);
            }
            catch (System.Exception)
            {
                return null;
            }

        }
    }
}