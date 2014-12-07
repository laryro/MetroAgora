using LF.Authentication;
using LF.Services;

namespace LF.MVC.Helpers.Views
{
    public static class Auth
    {
        public static Current Current
        {
            get { return AllServices.Access.Current; }
        }

    }
}