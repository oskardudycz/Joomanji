namespace Shared.Core.Modules
{
    public interface IModule
    {
        string Name { get; }
        void Initalize();
    }
}