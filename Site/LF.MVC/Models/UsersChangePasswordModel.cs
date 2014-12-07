using System;
using System.Collections.Generic;
using System.Linq;
using Resources;
using LF.Entities;
using LF.Generics.Reflection;
using LF.MVC.Helpers.Models;

namespace LF.MVC.Models
{
    public class UsersChangePasswordModel : BaseModel
    {
        public UsersChangePasswordModel() { }

        public UsersChangePasswordModel(Guid? passwordRecoverKey) : this()
        {
            setUserToChange(passwordRecoverKey);
        }

        private void setUserToChange(Guid? passwordRecoverKey)
        {
            if (IsAuthenticated)
            {
                UserToChange = Current.User;
            }
            else if (passwordRecoverKey.HasValue)
            {
                UserToChange = Access.User.GetUserByPasswordRecoverKey(passwordRecoverKey.Value);
            }
        }


        [LFRequired]
        public String Password { get; set; }
        public String RetypePassword { get; set; }
        
        internal User UserToChange { get; set; }


        public Dictionary<String, String> Validate(Guid? passwordRecoverKey)
        {
            var errors = new Dictionary<String, String>();

            setUserToChange(passwordRecoverKey);

            if (Password != RetypePassword)
            {
                var fieldName = this.GetFullPropertyName(m => m.RetypePassword);
                errors.Add(fieldName, Errors.PasswordDontMatch);
            }

            valid = !errors.Any();

            return errors;
        }
        
        private Boolean valid;


        public void Save()
        {
            if (!valid)
                throw new Exception("Model must be valid");

            Access.User.ChangePassword(UserToChange, Password);
        }


    }
}