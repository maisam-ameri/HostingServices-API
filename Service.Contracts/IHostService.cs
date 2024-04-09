using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IHostService
    {
        IEnumerable<HostDto> GetAllHosts(bool trackChanges);
        HostDto GetHost(Guid hostId, bool trackChanges);
        HostDto CreateHost(HostForCreationDto hostDto);
    }
}
