using System;

namespace Shared.Core.IOC.Attributtes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectInSingletonScopeAttribute : Attribute
    {
    }
}