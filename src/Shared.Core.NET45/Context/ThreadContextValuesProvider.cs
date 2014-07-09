using Shared.Core.Core;
using Shared.Core.Extensions.Basic;
using Shared.Core.Extensions.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Shared.Core.Context
{
    public class ThreadContextValuesProvider : IContextValuesProvider
    {
        public static ThreadContextValuesProvider Instance
        {
            get { return GetThreadValues().SafeGet(el => el.GetValueOrDefault("ValuesProvider") as ThreadContextValuesProvider); }
            set { GetOrCreateThreadValues().AddOrReplace("ValuesProvider", value); }
        }

        public ThreadContextValuesProvider()
        {
        }

        public ThreadContextValuesProvider(IContextValuesProvider contextValuesProvider)
            : this()
        {
            CreateThreadValues(contextValuesProvider.Values);

            Values.Remove("UoW");
        }

        public IDictionary<string, object> Values
        {
            get { return GetOrCreateThreadValues(); }
        }

        private static IDictionary<string, object> GetOrCreateThreadValues()
        {
            //getting
            var items = GetThreadValues();

            if (items != null) return items;

            items = new Dictionary<string, object>();
            CreateThreadValues(items);

            return items;
        }

        private static IDictionary<string, object> GetThreadValues()
        {
            var lds = Thread.GetNamedDataSlot(Thread.CurrentThread.ManagedThreadId.ToString(CultureInfo.InvariantCulture));

            return Thread.GetData(lds) as IDictionary<string, object>;
        }

        private static void CreateThreadValues(IDictionary<string, object> items)
        {
            var lds = Thread.GetNamedDataSlot(Thread.CurrentThread.ManagedThreadId.ToString(CultureInfo.InvariantCulture));

            Thread.SetData(lds, items);
        }
    }
}