using Shared.Core.Objects.DTO;
using Shared.Core.Objects.Requests;
using Shared.Core.Objects.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.Services
{
    public interface ICRUDService<TDto> : IService where TDto : IDTO
    {
        IEmptyResponse Delete(ISingleRequest<object> ikey);

        IEmptyResponse Delete(ISingleRequest<TDto> item);

        Task<ISingleResponse<bool>> DeleteAsync(IListRequest<object> keyValues);

        Task<ISingleResponse<bool>> DeleteAsync(CancellationToken cancellationToken, IListRequest<object> keyValues);

        ISingleResponse<TDto> Find(IListRequest<object> keyValues);

        Task<ISingleResponse<TDto>> FindAsync(IListRequest<object> keyValues);

        Task<ISingleResponse<TDto>> FindAsync(CancellationToken cancellationToken, IListRequest<object> keyValues);

        ISingleResponse<TDto> Insert(ISingleRequest<TDto> item);

        ISingleResponse<TDto> InsertGraph(ISingleRequest<TDto> request);

        IListResponse<TDto> InsertGraphRange(IListRequest<TDto> request);

        IListResponse<TDto> InsertRange(IListRequest<TDto> items);

        IListResponse<TDto> List(EmptyRequest emptyRequest);

        ISingleResponse<TDto> Update(ISingleRequest<TDto> item);
    }
}