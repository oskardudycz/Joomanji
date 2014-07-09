#region Assembly mscorlib.dll, v4.0.0.0
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\mscorlib.dll
#endregion

using System.Runtime.InteropServices;

namespace System
{
    // Summary:
    //     Indicates that a class can be serialized. This class cannot be inherited.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate, Inherited = false)]
    public sealed class SerializableAttribute : Attribute
    {
        // Summary:
        //     Initializes a new instance of the System.SerializableAttribute class.
        public SerializableAttribute() { }
    }
}
