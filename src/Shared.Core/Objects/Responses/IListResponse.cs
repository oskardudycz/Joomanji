using System.Collections.Generic;

namespace Shared.Core.Objects.Responses
{
    public interface IListResponse<T>
    {
        IList<T> Items { get; set; }
    }
}