using LF.Entities;

namespace LF.Authentication
{
    public interface IAuthService
    {
        void Logout(string ticket);
        User ValidateUserAndSetTicket(string username, string password, string ticket);
        User GetUserByTicket(string ticket);
    }
}