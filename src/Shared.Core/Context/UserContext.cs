using Shared.Core.Core;
using Shared.Core.Extensions.Basic;
using Shared.Core.Extensions.Collections;
using System.Collections.Generic;

namespace Shared.Core.Context
{
    public static class UserContext
    {
        private const string ValuesClientIP = "ClientIP";
        private const string ValuesClientDNS = "ClientDNS";
        private const string ValuesClientBrowser = "ClientBrowser";

        /// <summary>
        /// Gets collection to store context specific data.
        /// </summary>
        public static IDictionary<string, object> Values
        {
            get { return ContextValuesProviderWrapper.GetCurrentProvider().Values; }
        }

        ///// <summary>
        ///// Gets information about the current user.
        ///// </summary>
        //public static CurrentUser User
        //{
        //    get
        //    {
        //        if (!Values.ContainsKey(VALUES_USER))
        //            Values[VALUES_USER] = new CurrentUser();
        //        return (CurrentUser)Values[VALUES_USER];
        //    }
        //    set { Values[VALUES_USER] = value; }
        //}

        public static string ClientIP
        {
            get { return Get<string>(ValuesClientIP); }
            set { Set(ValuesClientIP, value); }
        }

        public static string ClientDNS
        {
            get { return Get<string>(ValuesClientDNS); }
            set { Set(ValuesClientDNS, value); }
        }

        public static string ClientBrowser
        {
            get { return Get<string>(ValuesClientBrowser); }
            set { Set(ValuesClientBrowser, value); }
        }

        public static T Get<T>(string name)
        {
            return !Values.ContainsKey(name) ? ObjectExtensions.GetEmpty<T>() : Values[name].CastTo<T>();
        }

        public static void Set<T>(string name, T value)
        {
            Values.AddOrReplace(name, value);
        }
    }
}