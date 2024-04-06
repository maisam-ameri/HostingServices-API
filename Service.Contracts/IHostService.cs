using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IHostService
    {
        IEnumerable<HostDto> GetAllHosts(bool trackChanges);
    }
}
