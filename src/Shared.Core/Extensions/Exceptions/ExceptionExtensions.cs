using Shared.Core.IOC;
using Shared.Core.Utils.Exceptions;
using System;
using System.Text;

namespace Shared.Core.Extensions.Exceptions
{
    public static class ExceptionExtensions
    {
        public static string FormatErrorMessage(this Exception exception)
        {
            var exceptionProvider = IOCContainer.Instance.Resolve<IExceptionProvider>();
            return exceptionProvider.HandleException(exception).Trim();
        }

        public static string FormatErrorMessage(this Exception exception, string header)
        {
            var message = new StringBuilder();

            message.AppendLine(header);
            message.AppendLine();
            message.Append(exception.FormatErrorMessage());

            return message.ToString();
        }
    }
}