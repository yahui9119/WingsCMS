using System.ComponentModel.DataAnnotations;
using Wings.Resources;

namespace Wings.UI.Dto
{
    public class StrLenAttribute : StringLengthAttribute
    {
        public StrLenAttribute(int maximumLength) : base(maximumLength)
        {
            ErrorMessageResourceName = "strlen";
            ErrorMessageResourceType = typeof (Mui);
        }
    }
}