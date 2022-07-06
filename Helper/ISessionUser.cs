using WebMVC.Models;

namespace WebMVC.Helper
{
    public interface ISessionUser
    {
        void CreateUserSession(Login user);
        void RemoveUserSession();
        Login SeachUserSession();
    }
}