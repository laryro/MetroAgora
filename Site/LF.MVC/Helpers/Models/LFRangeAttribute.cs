using System;
using System.ComponentModel.DataAnnotations;
using Resources;

namespace LF.MVC.Helpers.Models
{
    public class LFRangeAttribute : RangeAttribute
    {
        public LFRangeAttribute(Double minimum, Double maximum)
            : base(minimum, maximum)
        {
            ErrorMessage = Errors.InvalidRange;
        }

    }
}