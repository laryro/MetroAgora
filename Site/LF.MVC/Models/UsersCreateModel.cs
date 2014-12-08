using System;
using LF.Entities.Enums;

namespace LF.MVC.Models
{
    public class UsersCreateModel : BaseModel
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public String Action { get; set; }
        public String Controller { get; set; }

        public Boolean LoggedIn { get; private set; }
        public Boolean FirstAccess { get; set; }

        public String BackTo { get; set; }

        public void Create()
        {
            Access.User.CreateUser(Username, Password, new UserRole());
        }

    }
}