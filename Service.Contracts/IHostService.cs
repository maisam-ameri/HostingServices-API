using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IHostService
    {
        Task<IEnumerable<HostDto>> GetAllHostsAsync(bool trackChanges);
        Task<HostDto> GetHostAsync(Guid hostId, bool trackChanges);
        Task<HostDto> CreateHostAsync(HostForCreationDto hostDto);
        Task DeleteHostAsync(Guid hostId, bool trackChanges);
        Task UpdateHostAsync(Guid hostId, HostForUpdateDto hostForUpdate,bool trackChanges);
    }
}
