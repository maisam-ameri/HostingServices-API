using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IHostRepository
    {
        Task<IEnumerable<Host>> GetAllHostsAsync(bool trackChanges);
        Task<Host> GetHostAsync(Guid hostId, bool trackChanges);
        void CreateHost(Host host);
        void DeleteHost(Host host);
    }
}
