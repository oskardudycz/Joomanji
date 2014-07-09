using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Extensions.Threading
{
    public static class ThreadExtensions
    {
        public static T WithUiCulture<T>(this Thread currentThread, string culture, Func<T> doAction)
        {
            var currentUiCulture = currentThread.CurrentUICulture;

            currentThread.CurrentUICulture = new CultureInfo(culture);

            T returnValue = doAction();

            currentThread.CurrentUICulture = currentUiCulture;

            return returnValue;
        }
    }
}
