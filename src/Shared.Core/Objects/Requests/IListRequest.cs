using System.Collections.Generic;

namespace Shared.Core.Objects.Requests
{
    public interface IListRequest<T> : IRequest
    {
        IList<T> Items { get; set; }
    }
}