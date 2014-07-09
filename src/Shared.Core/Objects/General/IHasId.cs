using System;

namespace Shared.Core.Core
{
    public interface IHasId
    {
        object ID { get; set; }
    }

    public interface IHasId<T> : IHasId
    {
        new T ID { get; set; }
    }

    public interface IHasGuidId : IHasId<Guid>
    {
    }

    public interface IHasIntId : IHasId<int>
    {
    }
}