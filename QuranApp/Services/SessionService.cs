using QuranApp.Models;

namespace QuranApp.Services
{
    public class SessionService
    {
        public User? CurrentUser { get; private set; }
        public bool IsLoggedIn => CurrentUser != null;

        public void Login(User user)
        {
            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}