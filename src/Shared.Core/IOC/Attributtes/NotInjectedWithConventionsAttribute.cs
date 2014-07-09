using System;

namespace Shared.Core.IOC.Attributtes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class NotInjectedWithConventionsAttribute : Attribute
    {
    }
}