
using Entities;

namespace Service.Contracts
{
    public interface IHostService
    {
        IEnumerable<Host> GetAllHosts(bool trackChanges);
    }
}
