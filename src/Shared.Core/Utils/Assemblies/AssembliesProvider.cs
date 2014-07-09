using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Shared.Core.Utils.Assemblies
{
    public static class AssembliesProvider
    {
        public static Assembly[] GetAll()
        {
            //AppDomain.CurrentDomain.GetAssemblies()
            return new Assembly[] { };
        }
    }
}
