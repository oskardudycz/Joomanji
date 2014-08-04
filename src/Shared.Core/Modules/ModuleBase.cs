namespace Shared.Core.Modules
{
    public abstract class ModuleBase : IModule
    {
        public string Name { get; set; }

        public virtual void Initalize()
        {
        }
    }
}