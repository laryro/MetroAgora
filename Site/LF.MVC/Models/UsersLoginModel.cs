﻿using System;
using LF.Entities.Enums;

namespace LF.MVC.Models
{
    public class UsersLoginModel : BaseModel
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public String Action { get; set; }
        public String Controller { get; set; }

        public Boolean LoggedIn { get; private set; }

        public String BackTo { get; set; }

        public void Login()
        {
            var user = Current.Set(Username, Password);
            
            LoggedIn = user != null;
        }

        public void Logout()
        {
            Current.Clean();
        }
    }
}