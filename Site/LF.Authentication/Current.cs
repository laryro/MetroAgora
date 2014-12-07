using System;
using LF.Entities;
using LF.Entities.Enums;
using LF.Generics.Cookies;

namespace LF.Authentication
{
    public class Current
    {
        private IAuthService service { get; set; }

        public Current(IAuthService service)
        {
            this.service = service;
        }


        public String Ticket
        {
            get { return MyCookie.Get(); }
        }

        public User User
        {
            get
            {
                try
                {
                    return service.GetUserByTicket(Ticket);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }



        public Boolean IsAuthenticated
        {
            get { return User != null; }
        }

        public Boolean IsAuthorized(UserRole role)
        {
            return role.HasFlag(User.Role);
        }



        public User Set(String username, String password)
        {
            return service.ValidateUserAndSetTicket(username, password, Ticket);
        }

        public void Reset(String username, String password)
        {
            Clean();
            Set(username, password);
        }

        public void Clean()
        {
            service.Logout(Ticket);
        }
        


    }
}