using System.ComponentModel.DataAnnotations;
using Resources;

namespace LF.MVC.Helpers.Models
{
    public class LFHeightLimitsAttribute : RangeAttribute
    {
        public LFHeightLimitsAttribute()
            : base(1.3, 2.2)
        {
            ErrorMessage = Errors.InvalidRange;
        }

    }
}