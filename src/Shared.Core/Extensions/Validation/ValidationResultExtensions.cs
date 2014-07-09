using System.Text;

namespace FluentValidation.Results
{
    public static class ValidationResultExtensions
    {
        public static string FormatErrorMessages(this ValidationResult result)
        {
            if (result.IsValid)
            {
                return null;
            }

            var sb = new StringBuilder();

            foreach (var error in result.Errors)
            {
                sb.AppendFormat("{0}\r\n", error.ErrorMessage);
            }

            return sb.ToString();
        }
    }
}
