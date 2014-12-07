using System;

namespace LF.MVC.Models
{
    public class UsersForgotPasswordModel : BaseModel
    {
        public String Username { get; set; }

        public Boolean SendRecoverLink()
        {
            return Access.User.SendRecoverLink(Username, Url.Action("ChangePassword", "Users"));
        }
    }
}