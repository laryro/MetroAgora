using System.ComponentModel.DataAnnotations;
using Resources;

namespace LF.MVC.Helpers.Models
{
    public class LFRequiredAttribute : RequiredAttribute
    {
        public LFRequiredAttribute()
        {
            ErrorMessage = Errors.Required;
        }

    }
}