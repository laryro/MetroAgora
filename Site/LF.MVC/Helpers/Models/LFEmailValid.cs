using System.ComponentModel.DataAnnotations;
using Resources;

namespace LF.MVC.Helpers.Models
{
    public class LFEmailValid : RegularExpressionAttribute
    {
        public LFEmailValid() : base(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$")
        {
            ErrorMessage = Errors.Invalid;
        }

    }
}