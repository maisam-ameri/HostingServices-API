using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IHostService
    {
        Task<IEnumerable<HostDto>> GetAllHosts(bool trackChanges);
        Task<HostDto> GetHost(Guid hostId, bool trackChanges);
        Task<HostDto> CreateHost(HostForCreationDto hostDto);
        Task DeleteHost(Guid hostId, bool trackChanges);
        Task UpdateHost(Guid hostId, HostForUpdateDto hostForUpdate,bool trackChanges);
    }
}
