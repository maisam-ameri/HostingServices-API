using Entities.Responses;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IHostService
    {
        Task<ApiBaseResponse> GetAllHostsAsync(HostParameters hostParameters, bool trackChanges);
        Task<ApiBaseResponse> GetHostAsync(Guid hostId, bool trackChanges);
        Task<HostDto> CreateHostAsync(HostForCreationDto hostDto);
        Task DeleteHostAsync(Guid hostId, bool trackChanges);
        Task UpdateHostAsync(Guid hostId, HostForUpdateDto hostForUpdate,bool trackChanges);
    }
}
